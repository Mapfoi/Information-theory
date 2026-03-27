namespace LFSR_File_Encryptor;

internal sealed class Lfsr28
{
    private const int RegisterSize = 28;
    private readonly bool[] _state; // index 0 is MSB (output bit)

    // Characteristic polynomial: x^28 + x^3 + 1
    // Output bit: MSB
    // Shift: left, feedback goes into LSB
    //
    // Tap mapping for this shift convention:
    // feedback = state[25] XOR state[27]
    // where:
    // - state[27] is LSB (x^0 term)
    // - state[25] corresponds to x^3 term
    public Lfsr28(string seedBits)
    {
        if (seedBits is null) throw new ArgumentNullException(nameof(seedBits));
        if (seedBits.Length != RegisterSize)
            throw new ArgumentException($"Seed must be exactly {RegisterSize} bits.", nameof(seedBits));

        _state = new bool[RegisterSize];
        for (var i = 0; i < RegisterSize; i++)
        {
            var ch = seedBits[i];
            _state[i] = ch switch
            {
                '0' => false,
                '1' => true,
                _ => throw new ArgumentException("Seed must contain only '0' and '1'.", nameof(seedBits)),
            };
        }

        if (_state.All(b => !b))
            throw new ArgumentException("Seed must not be all zeros (LFSR would lock up).", nameof(seedBits));
    }

    public int NextBit()
    {
        var output = _state[0] ? 1 : 0;
        var feedback = _state[25] ^ _state[27];

        // shift left: [0] <- [1] ... [26] <- [27], [27] <- feedback
        for (var i = 0; i < RegisterSize - 1; i++)
            _state[i] = _state[i + 1];
        _state[RegisterSize - 1] = feedback;

        return output;
    }

    public byte NextByte()
    {
        byte value = 0;
        for (var i = 0; i < 8; i++)
        {
            // Most-significant bit first for readability in bit strings
            value <<= 1;
            value |= (byte)NextBit();
        }
        return value;
    }
}

