using System.Text;

namespace LFSR_File_Encryptor;

public partial class Form1 : Form
{
    private const int SeedLength = 28;
    /// <summary>First/last this many bytes in UI when file length exceeds FullDisplayMaxBytes.</summary>
    private const int DisplayEdgeBytes = 10;
    /// <summary>Show full binary text only when total length is at most this (bytes).</summary>
    private const int FullDisplayMaxBytes = 20;

    private string? _inputPath;
    private string? _outputPath;

    public Form1()
    {
        InitializeComponent();

        tbSeed.KeyPress += TbSeed_KeyPress;
        tbSeed.TextChanged += TbSeed_TextChanged;

        btnBrowseInput.Click += BtnBrowseInput_Click;
        btnBrowseOutput.Click += BtnBrowseOutput_Click;
        btnRun.Click += BtnRun_Click;
    }

    private void SetStatus(string text) => lblStatus.Text = text;

    private void TbSeed_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar)) return;
        if (e.KeyChar is '0' or '1') return;
        e.Handled = true;
    }

    private void TbSeed_TextChanged(object? sender, EventArgs e)
    {
        // Handle paste: keep only 0/1
        var text = tbSeed.Text;
        if (text.Length == 0) return;

        var filtered = new string(text.Where(c => c is '0' or '1').ToArray());
        if (filtered.Length > SeedLength) filtered = filtered[..SeedLength];

        if (!string.Equals(text, filtered, StringComparison.Ordinal))
        {
            var sel = tbSeed.SelectionStart;
            tbSeed.Text = filtered;
            tbSeed.SelectionStart = Math.Min(sel, tbSeed.Text.Length);
        }
    }

    private void BtnBrowseInput_Click(object? sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

        _inputPath = openFileDialog.FileName;
        tbInputFile.Text = _inputPath;

        if (string.IsNullOrWhiteSpace(_outputPath))
        {
            var dir = Path.GetDirectoryName(_inputPath) ?? Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var name = Path.GetFileName(_inputPath);
            _outputPath = Path.Combine(dir, $"{name}.xor");
            tbOutputFile.Text = _outputPath;
        }

        SetStatus("Выбран входной файл.");
    }

    private void BtnBrowseOutput_Click(object? sender, EventArgs e)
    {
        saveFileDialog.FileName = string.IsNullOrWhiteSpace(_outputPath) ? "output.bin" : Path.GetFileName(_outputPath);
        if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

        _outputPath = saveFileDialog.FileName;
        tbOutputFile.Text = _outputPath;
        SetStatus("Выбран выходной файл.");
    }

    private void BtnRun_Click(object? sender, EventArgs e)
    {
        try
        {
            RunXor();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetStatus("Ошибка.");
        }
    }

    private void RunXor()
    {
        var seed = tbSeed.Text.Trim();
        if (seed.Length != SeedLength)
            throw new InvalidOperationException($"Начальное состояние должно быть длиной ровно {SeedLength} символов (0/1).");

        if (string.IsNullOrWhiteSpace(_inputPath) || !File.Exists(_inputPath))
            throw new InvalidOperationException("Выберите существующий входной файл.");

        if (string.IsNullOrWhiteSpace(_outputPath))
            throw new InvalidOperationException("Выберите путь для сохранения выходного файла.");

        SetStatus("Чтение файла…");

        var inputBytes = File.ReadAllBytes(_inputPath);
        var totalBytes = inputBytes.Length;

        var lfsr = new Lfsr28(seed);

        SetStatus("Генерация ключа и XOR…");

        var outputBytes = new byte[totalBytes];
        byte[]? keyAll = totalBytes <= FullDisplayMaxBytes ? new byte[totalBytes] : null;
        var keyFirst = new byte[Math.Min(DisplayEdgeBytes, totalBytes)];
        var keyLast = new byte[totalBytes > FullDisplayMaxBytes ? DisplayEdgeBytes : 0];

        for (var i = 0; i < totalBytes; i++)
        {
            var keyByte = lfsr.NextByte();
            if (keyAll != null) keyAll[i] = keyByte;
            else
            {
                if (i < DisplayEdgeBytes) keyFirst[i] = keyByte;
                if (i >= totalBytes - DisplayEdgeBytes) keyLast[i - (totalBytes - DisplayEdgeBytes)] = keyByte;
            }

            outputBytes[i] = (byte)(inputBytes[i] ^ keyByte);
        }

        File.WriteAllBytes(_outputPath, outputBytes);

        SetStatus("Формирование двоичного отображения…");

        tbKeyBits.Text = BuildBitsBlock(
            title: "Ключ",
            totalBytes: totalBytes,
            keyAll: keyAll,
            keyFirst: keyFirst,
            keyLast: keyLast);

        tbInputBits.Text = BuildBitsBlockFromBuffer(
            title: "Вход",
            totalBytes: totalBytes,
            buffer: inputBytes);

        tbOutputBits.Text = BuildBitsBlockFromBuffer(
            title: "Выход",
            totalBytes: totalBytes,
            buffer: outputBytes);

        SetStatus($"Готово. Сохранено: {_outputPath}");
    }

    private static string BuildBitsBlock(string title, int totalBytes, byte[]? keyAll, byte[] keyFirst, byte[] keyLast)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{title}. {BitFormatting.BitsPreviewHeader(totalBytes, DisplayEdgeBytes, FullDisplayMaxBytes)}");
        sb.AppendLine();
        if (keyAll != null)
            sb.Append(BitFormatting.BytesToBitString(keyAll.AsSpan(), bytesPerLine: 8, byteSeparator: " "));
        else
            sb.Append(BitFormatting.FormatKeyEdgesAsBits(keyFirst, keyLast, totalBytes, DisplayEdgeBytes));
        return sb.ToString();
    }

    private static string BuildBitsBlockFromBuffer(string title, int totalBytes, byte[] buffer)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{title}. {BitFormatting.BitsPreviewHeader(totalBytes, DisplayEdgeBytes, FullDisplayMaxBytes)}");
        sb.AppendLine();
        sb.Append(BitFormatting.BytesToBitStringEdges(buffer.AsSpan(), edgeBytes: DisplayEdgeBytes, fullIfAtMost: FullDisplayMaxBytes));
        return sb.ToString();
    }


}
