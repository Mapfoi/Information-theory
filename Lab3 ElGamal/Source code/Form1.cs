using System.Text;

namespace Lab3_ElGamal
{
    public partial class Form1 : Form
    {
        private byte[]? sourceBytes;
        private int[]? encryptedPairs;
        private readonly Random random = new();
        private string? loadedFilePath;

        public Form1()
        {
            InitializeComponent();

            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Выберите файл";

            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.OverwritePrompt = true;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = string.Empty;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            loadedFilePath = openFileDialog.FileName;
            labelLoadedFile.Text = $"Файл: {loadedFilePath}";

            if (radioEncrypt.Checked)
            {
                sourceBytes = File.ReadAllBytes(loadedFilePath);
                encryptedPairs = null;
                textBoxInput.Text = FormatBytes(sourceBytes);
            }
            else
            {
                try
                {
                    encryptedPairs = ReadEncryptedFile(loadedFilePath);
                    sourceBytes = null;
                    textBoxInput.Text = FormatPairs(encryptedPairs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Не удалось прочитать шифртекст: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void buttonFindRoots_Click(object sender, EventArgs e)
        {
            if (!TryReadPrimeP(out var p))
            {
                return;
            }

            var roots = FindAllPrimitiveRoots(p);
            listBoxRoots.Items.Clear();

            foreach (var root in roots)
            {
                listBoxRoots.Items.Add(root);
            }

            labelRootsCount.Text = $"Найдено корней: {roots.Count}";

            if (roots.Count > 0)
            {
                listBoxRoots.SelectedIndex = 0;
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (!TryReadPrimeP(out var p) ||
                !TryReadX(p, out var x) ||
                !TryReadInitialK(p, out var initialK) ||
                !TryReadSelectedG(out var g) ||
                sourceBytes is null)
            {
                return;
            }

            var y = FastPowMod(g, x, p);
            textBoxY.Text = y.ToString();

            encryptedPairs = new int[sourceBytes.Length * 2];
            var index = 0;
            var k = initialK;

            for (var i = 0; i < sourceBytes.Length; i++)
            {
                var a = FastPowMod(g, k, p);
                var b = (int)((long)FastPowMod(y, k, p) * sourceBytes[i] % p);

                encryptedPairs[index++] = a;
                encryptedPairs[index++] = b;

                if (i == 0)
                {
                    k = GenerateRandomCoprimeK(p);
                }
                else if (i < sourceBytes.Length - 1)
                {
                    k = GenerateRandomCoprimeK(p);
                }
            }

            textBoxOutput.Text = FormatPairs(encryptedPairs);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (!TryReadPrimeP(out var p) ||
                !TryReadX(p, out var x) ||
                encryptedPairs is null)
            {
                return;
            }

            sourceBytes = new byte[encryptedPairs.Length / 2];
            var outIndex = 0;

            for (var i = 0; i < encryptedPairs.Length; i += 2)
            {
                var a = encryptedPairs[i];
                var b = encryptedPairs[i + 1];

                // a^(p-2) mod p - обратный элемент к a.
                var inverseA = FastPowMod(a, p - 2, p);
                var plain = (int)((long)FastPowMod(inverseA, x, p) * (b % p) % p);
                sourceBytes[outIndex++] = (byte)plain;
            }

            textBoxOutput.Text = FormatBytes(sourceBytes);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var targetFile = saveFileDialog.FileName;

            try
            {
                if (radioEncrypt.Checked)
                {
                    if (encryptedPairs is null)
                    {
                        MessageBox.Show("Сначала выполните шифрование.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using var writer = new BinaryWriter(File.Open(targetFile, FileMode.Create, FileAccess.Write));
                    foreach (var value in encryptedPairs)
                    {
                        writer.Write(value);
                    }
                }
                else
                {
                    if (sourceBytes is null)
                    {
                        MessageBox.Show("Сначала выполните дешифрование.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    File.WriteAllBytes(targetFile, sourceBytes);
                }

                MessageBox.Show("Файл сохранен.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxP.Text = string.Empty;
            textBoxX.Text = string.Empty;
            textBoxK.Text = string.Empty;
            textBoxY.Text = string.Empty;
            listBoxRoots.Items.Clear();
            labelRootsCount.Text = "Найдено корней: 0";
            labelLoadedFile.Text = "Файл: не выбран";
            textBoxInput.Text = string.Empty;
            textBoxOutput.Text = string.Empty;
            sourceBytes = null;
            encryptedPairs = null;
            loadedFilePath = null;
        }

        private void radioEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            buttonEncrypt.Enabled = radioEncrypt.Checked;
            buttonDecrypt.Enabled = !radioEncrypt.Checked;
        }

        private static int[] ReadEncryptedFile(string path)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Length % sizeof(int) != 0)
            {
                throw new InvalidDataException("Размер файла должен быть кратен 4 байтам.");
            }

            var count = fileInfo.Length / sizeof(int);
            if (count % 2 != 0)
            {
                throw new InvalidDataException("Количество чисел в шифртексте должно быть четным (A,B).");
            }

            var result = new int[count];
            using var reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            for (var i = 0; i < count; i++)
            {
                result[i] = reader.ReadInt32();
            }

            return result;
        }

        private bool TryReadPrimeP(out int p)
        {
            if (!int.TryParse(textBoxP.Text, out p) || p <= 255 || !IsPrime(p))
            {
                MessageBox.Show("Параметр P должен быть простым целым числом и P > 255.", "Проверка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool TryReadX(int p, out int x)
        {
            if (!int.TryParse(textBoxX.Text, out x) || x <= 1 || x >= p - 1)
            {
                MessageBox.Show("Параметр X должен удовлетворять 1 < X < P-1.", "Проверка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool TryReadInitialK(int p, out int k)
        {
            if (!int.TryParse(textBoxK.Text, out k) || k <= 1 || k >= p - 1 || Gcd(k, p - 1) != 1)
            {
                MessageBox.Show("Параметр K должен удовлетворять 1 < K < P-1 и gcd(K, P-1)=1.", "Проверка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool TryReadSelectedG(out int g)
        {
            if (listBoxRoots.SelectedItem is not int selected)
            {
                MessageBox.Show("Выберите первообразный корень G из списка.", "Проверка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                g = 0;
                return false;
            }

            g = selected;
            return true;
        }

        private int GenerateRandomCoprimeK(int p)
        {
            int k;
            do
            {
                k = random.Next(2, p - 1);
            }
            while (Gcd(k, p - 1) != 1);

            return k;
        }

        private static int FastPowMod(long a, int n, int m)
        {
            long res = 1;
            long degreeBase = a;
            long degree = n;

            while (degree != 0)
            {
                while (degree % 2 == 0)
                {
                    degree /= 2;
                    degreeBase = (degreeBase * degreeBase) % m;
                }

                degree -= 1;
                res = (res * degreeBase) % m;
            }

            return (int)res;
        }

        private static List<int> FindAllPrimitiveRoots(int p)
        {
            var uniqPrimeDivisors = GetUniquePrimeDivisors(p - 1);
            var primitiveRoots = new List<int>();
            int j;
            bool flag;

            for (var i = 2; i <= p - 1; i++)
            {
                j = 0;
                flag = true;
                while (flag && j < uniqPrimeDivisors.Count)
                {
                    if (FastPowMod(i, (p - 1) / uniqPrimeDivisors[j], p) == 1)
                    {
                        flag = false;
                    }

                    j++;
                }

                if (flag)
                {
                    primitiveRoots.Add(i);
                }
            }

            return primitiveRoots;
        }

        private static List<int> GetUniquePrimeDivisors(int number)
        {
            var result = new List<int>();
            var n = number;

            for (var i = 2; i * i <= n; i++)
            {
                if (n % i != 0)
                {
                    continue;
                }

                result.Add(i);
                while (n % i == 0)
                {
                    n /= i;
                }
            }

            if (n > 1)
            {
                result.Add(n);
            }

            return result;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            if (number % 2 == 0)
            {
                return number == 2;
            }

            for (var i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                var t = a % b;
                a = b;
                b = t;
            }

            return a;
        }

        private static string FormatBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b);
                sb.Append(' ');
            }

            return sb.ToString();
        }

        private static string FormatPairs(int[] pairs)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < pairs.Length; i += 2)
            {
                sb.Append('[');
                sb.Append(pairs[i]);
                sb.Append(", ");
                sb.Append(pairs[i + 1]);
                sb.Append("] ");
            }

            return sb.ToString();
        }
    }
}
