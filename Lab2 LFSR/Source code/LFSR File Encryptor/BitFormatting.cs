using System.Text;

namespace LFSR_File_Encryptor;

internal static class BitFormatting
{
    public static string BytesToBitString(ReadOnlySpan<byte> bytes, int bytesPerLine = 8, string byteSeparator = " ")
    {
        if (bytesPerLine <= 0) bytesPerLine = 8;

        var sb = new StringBuilder(bytes.Length * 9);
        for (var i = 0; i < bytes.Length; i++)
        {
            if (i > 0)
            {
                if (i % bytesPerLine == 0) sb.AppendLine();
                else sb.Append(byteSeparator);
            }

            sb.Append(ByteToBits(bytes[i]));
        }
        return sb.ToString();
    }

    public static string ByteToBits(byte b)
    {
        Span<char> tmp = stackalloc char[8];
        for (var i = 7; i >= 0; i--)
        {
            tmp[7 - i] = ((b >> i) & 1) == 1 ? '1' : '0';
        }
        return new string(tmp);
    }

    public static string BitsPreviewHeader(int totalBytes, int shownBytes)
    {
        if (shownBytes >= totalBytes) return $"Показано: {totalBytes} байт ({totalBytes * 8} бит).";
        return $"Показано: первые {shownBytes} байт из {totalBytes} ({shownBytes * 8} бит из {totalBytes * 8} бит).";
    }
}

