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

    /// <summary>Human-readable line for how many bytes/bits are shown.</summary>
    public static string BitsPreviewHeader(int totalBytes, int edgeBytes, int fullIfAtMost)
    {
        if (totalBytes <= fullIfAtMost)
            return $"Показано полностью: {totalBytes} байт ({totalBytes * 8} бит).";
        var skipped = totalBytes - 2 * edgeBytes;
        return $"Показаны первые {edgeBytes} и последние {edgeBytes} байт из {totalBytes} (пропущено {skipped} байт, {skipped * 8} бит).";
    }

    /// <summary>
    /// If length &lt;= fullIfAtMost, format all bytes as bits; otherwise first edgeBytes and last edgeBytes.
    /// </summary>
    public static string BytesToBitStringEdges(ReadOnlySpan<byte> bytes, int edgeBytes = 10, int fullIfAtMost = 20)
    {
        if (bytes.Length <= fullIfAtMost)
            return BytesToBitString(bytes);

        var head = bytes[..edgeBytes];
        var tail = bytes[^edgeBytes..];
        var sb = new StringBuilder(head.Length * 9 + tail.Length * 9 + 64);
        sb.AppendLine("Первые байты:");
        sb.Append(BytesToBitString(head));
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"... (пропущено {bytes.Length - 2 * edgeBytes} байт) ...");
        sb.AppendLine();
        sb.AppendLine("Последние байты:");
        sb.Append(BytesToBitString(tail));
        return sb.ToString();
    }

    /// <summary>Same layout as <see cref="BytesToBitStringEdges"/> but from separate head/tail buffers (key stream).</summary>
    public static string FormatKeyEdgesAsBits(ReadOnlySpan<byte> keyFirst, ReadOnlySpan<byte> keyLast, int totalBytes, int edgeBytes)
    {
        var sb = new StringBuilder(keyFirst.Length * 9 + keyLast.Length * 9 + 64);
        sb.AppendLine("Первые байты:");
        sb.Append(BytesToBitString(keyFirst));
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"... (пропущено {totalBytes - 2 * edgeBytes} байт) ...");
        sb.AppendLine();
        sb.AppendLine("Последние байты:");
        sb.Append(BytesToBitString(keyLast));
        return sb.ToString();
    }
}

