using System.Text;

namespace LFSR_File_Encryptor;

public partial class Form1 : Form
{
    private const int SeedLength = 28;
    private const int MaxDisplayBytes = 4096; // UI safety limit

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
        var shownBytes = Math.Min(totalBytes, MaxDisplayBytes);

        var lfsr = new Lfsr28(seed);

        SetStatus("Генерация ключа и XOR…");

        var outputBytes = new byte[totalBytes];
        var shownKey = new byte[shownBytes];
        for (var i = 0; i < totalBytes; i++)
        {
            var keyByte = lfsr.NextByte();
            if (i < shownBytes) shownKey[i] = keyByte;
            outputBytes[i] = (byte)(inputBytes[i] ^ keyByte);
        }

        File.WriteAllBytes(_outputPath, outputBytes);

        SetStatus("Формирование двоичного отображения…");

        var shownInput = inputBytes.AsSpan(0, shownBytes);
        var shownOutput = outputBytes.AsSpan(0, shownBytes);

        tbKeyBits.Text = BuildBitsBlock(
            title: "Ключ",
            totalBytes: totalBytes,
            shownBytes: shownBytes,
            bytes: shownKey);

        tbInputBits.Text = BuildBitsBlock(
            title: "Вход",
            totalBytes: totalBytes,
            shownBytes: shownBytes,
            bytes: shownInput);

        tbOutputBits.Text = BuildBitsBlock(
            title: "Выход",
            totalBytes: totalBytes,
            shownBytes: shownBytes,
            bytes: shownOutput);

        SetStatus($"Готово. Сохранено: {_outputPath}");
    }

    private static string BuildBitsBlock(string title, int totalBytes, int shownBytes, ReadOnlySpan<byte> bytes)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{title}. {BitFormatting.BitsPreviewHeader(totalBytes, shownBytes)}");
        sb.AppendLine();
        sb.Append(BitFormatting.BytesToBitString(bytes, bytesPerLine: 8, byteSeparator: " "));
        return sb.ToString();
    }


}
