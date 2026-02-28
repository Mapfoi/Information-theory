using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    public partial class Form1 : Form
    {
        // English alphabet used by the decimation (multiplicative) cipher.
        // Only these characters are transformed; all other characters are passed through unchanged.
        private const string EnglishAlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string EnglishAlphabetLower = "abcdefghijklmnopqrstuvwxyz";

        // Russian alphabet (33 letters) including 'Ё'/'ё'.
        // Used by the Vigenère cipher; only these letters participate in shifting.
        private const string RussianAlphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string RussianAlphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Algorithm switch is handled only on encode/decode.
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Algorithm switch is handled only on encode/decode.
        }

        private void label_Cyphertext_Click(object sender, EventArgs e)
        {
        }

        // Encrypt button handler.
        // Reads input text and key, selects the appropriate algorithm (decimation or Vigenère),
        // performs encryption and optionally saves the result to a file.
        private void button_Encode_Click(object sender, EventArgs e)
        {
            try
            {
                var plaintext = textBox_Plaintext.Text;
                var key = textBox_Key.Text;

                if (string.IsNullOrWhiteSpace(plaintext))
                {
                    MessageBox.Show("Исходный текст пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Ключ не задан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string result;

                if (radioButton1.Checked)
                {
                    result = EncryptDecimation(plaintext, key);
                }
                else if (radioButton2.Checked)
                {
                    result = EncryptVigenereRussian(plaintext, key);
                }
                else
                {
                    MessageBox.Show("Выберите алгоритм шифрования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox_Cyphertext.Text = result;
                if (checkBox_SaveToFile.Checked)
                {
                    SaveResultToFile(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Decrypt button handler.
        // Interprets the text in textBox_Plaintext as ciphertext and applies
        // the inverse of the selected algorithm to recover the original text.
        private void button_Decode_Click(object sender, EventArgs e)
        {
            try
            {
                var ciphertext = textBox_Plaintext.Text;
                var key = textBox_Key.Text;

                if (string.IsNullOrWhiteSpace(ciphertext))
                {
                    MessageBox.Show("Текст для расшифрования пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Ключ не задан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string result;

                if (radioButton1.Checked)
                {
                    result = DecryptDecimation(ciphertext, key);
                }
                else if (radioButton2.Checked)
                {
                    result = DecryptVigenereRussian(ciphertext, key);
                }
                else
                {
                    MessageBox.Show("Выберите алгоритм шифрования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox_Cyphertext.Text = result;
                if (checkBox_SaveToFile.Checked)
                {
                    SaveResultToFile(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reads source text from a UTF-8 encoded text file into textBox_Plaintext.
        private void button_ReadFromFile_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Выберите файл для чтения"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var text = File.ReadAllText(openDialog.FileName, Encoding.UTF8);
                    textBox_Plaintext.Text = text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Clears all user input/output fields (plaintext, ciphertext and key).
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Plaintext.Clear();
            textBox_Cyphertext.Clear();
            textBox_Key.Clear();
        }

        // Computes the greatest common divisor of two integers using the Euclidean algorithm.
        // Used to verify that the decimation key is coprime with the alphabet length.
        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return Math.Abs(a);
        }

        // Finds the multiplicative inverse of 'a' modulo 'm' by brute-force search.
        // Needed to reverse the decimation cipher during decryption.
        private static int ModInverse(int a, int m)
        {
            a %= m;
            for (var x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                    return x;
                }
            }

            throw new ArgumentException("Для заданного ключа не существует мультипликативного обратного. Ключ должен быть взаимно простым с длиной алфавита.");
        }

        // Applies the decimation (multiplicative) cipher to English text.
        // Each English letter is mapped to its index in the alphabet, multiplied by 'k' modulo 26
        // and converted back to a letter; characters outside A–Z/a–z are copied unchanged.
        private static string EncryptDecimation(string text, string keyString)
        {
            if (!int.TryParse(keyString.Trim(), out var k))
            {
                throw new ArgumentException("Ключ для метода децимации должен быть целым числом.");
            }

            const int m = 26;

            if (k <= 0 || Gcd(k, m) != 1)
            {
                throw new ArgumentException("Ключ для метода децимации должен быть положительным и взаимно простым с 26 (длиной английского алфавита).");
            }

            var sb = new StringBuilder(text.Length);

            foreach (var ch in text)
            {
                if (char.IsLetter(ch) && ch is >= 'A' and <= 'Z' || ch is >= 'a' and <= 'z')
                {
                    bool isUpper = char.IsUpper(ch);
                    int idx = (isUpper ? EnglishAlphabetUpper.IndexOf(ch) : EnglishAlphabetLower.IndexOf(ch));

                    if (idx >= 0)
                    {
                        int newIdx = (k * idx) % m;
                        char enc = isUpper ? EnglishAlphabetUpper[newIdx] : EnglishAlphabetLower[newIdx];
                        sb.Append(enc);
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                else
                {
                    // Ignore (do not encrypt) non-English letters – just copy as is.
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        // Decrypts text that was encrypted by the decimation cipher.
        // Uses the multiplicative inverse of 'k' modulo 26 to restore original indices.
        private static string DecryptDecimation(string text, string keyString)
        {
            if (!int.TryParse(keyString.Trim(), out var k))
            {
                throw new ArgumentException("Ключ для метода децимации должен быть целым числом.");
            }

            const int m = 26;

            if (k <= 0 || Gcd(k, m) != 1)
            {
                throw new ArgumentException("Ключ для метода децимации должен быть положительным и взаимно простым с 26 (длиной английского алфавита).");
            }

            int inv = ModInverse(k, m);
            var sb = new StringBuilder(text.Length);

            foreach (var ch in text)
            {
                if (char.IsLetter(ch) && ch is >= 'A' and <= 'Z' || ch is >= 'a' and <= 'z')
                {
                    bool isUpper = char.IsUpper(ch);
                    int idx = (isUpper ? EnglishAlphabetUpper.IndexOf(ch) : EnglishAlphabetLower.IndexOf(ch));

                    if (idx >= 0)
                    {
                        int newIdx = (inv * idx) % m;
                        char dec = isUpper ? EnglishAlphabetUpper[newIdx] : EnglishAlphabetLower[newIdx];
                        sb.Append(dec);
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        // Builds an array of integer shifts for the Vigenère cipher from a Russian key string.
        // Only Russian letters contribute to the key; other characters are ignored.
        private static int[] BuildRussianKeyShifts(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Ключ не может быть пустым.");
            }

            var shifts = new List<int>();

            foreach (var ch in key)
            {
                int idx;

                if (RussianAlphabetUpper.Contains(ch))
                {
                    idx = RussianAlphabetUpper.IndexOf(ch);
                }
                else if (RussianAlphabetLower.Contains(ch))
                {
                    idx = RussianAlphabetLower.IndexOf(ch);
                }
                else
                {
                    // Ignore non-Russian symbols in key
                    continue;
                }

                if (idx >= 0)
                {
                    shifts.Add(idx);
                }
            }

            if (shifts.Count == 0)
            {
                throw new ArgumentException("Ключ должен содержать хотя бы одну русскую букву.");
            }

            return shifts.ToArray();
        }

        // Encrypts Russian text using the Vigenère cipher with a direct key.
        // For each Russian letter, its alphabet index is shifted by the corresponding key value;
        // non-Russian characters are left unchanged.
        private static string EncryptVigenereRussian(string text, string key)
        {
            var keyShifts = BuildRussianKeyShifts(key);
            int keyPos = 0;
            var sb = new StringBuilder(text.Length);

            foreach (var ch in text)
            {
                int idx;
                bool isUpper;

                if (RussianAlphabetUpper.Contains(ch))
                {
                    idx = RussianAlphabetUpper.IndexOf(ch);
                    isUpper = true;
                }
                else if (RussianAlphabetLower.Contains(ch))
                {
                    idx = RussianAlphabetLower.IndexOf(ch);
                    isUpper = false;
                }
                else
                {
                    // Not a Russian letter – leave unchanged.
                    sb.Append(ch);
                    continue;
                }

                int shift = keyShifts[keyPos % keyShifts.Length];
                int newIdx = (idx + shift) % RussianAlphabetUpper.Length;

                char enc = isUpper ? RussianAlphabetUpper[newIdx] : RussianAlphabetLower[newIdx];
                sb.Append(enc);

                keyPos++;
            }

            return sb.ToString();
        }

        // Decrypts Russian text that was encrypted with the Vigenère cipher.
        // For each Russian letter, the corresponding key shift is subtracted modulo alphabet length.
        private static string DecryptVigenereRussian(string text, string key)
        {
            var keyShifts = BuildRussianKeyShifts(key);
            int keyPos = 0;
            var sb = new StringBuilder(text.Length);

            foreach (var ch in text)
            {
                int idx;
                bool isUpper;

                if (RussianAlphabetUpper.Contains(ch))
                {
                    idx = RussianAlphabetUpper.IndexOf(ch);
                    isUpper = true;
                }
                else if (RussianAlphabetLower.Contains(ch))
                {
                    idx = RussianAlphabetLower.IndexOf(ch);
                    isUpper = false;
                }
                else
                {
                    sb.Append(ch);
                    continue;
                }

                int shift = keyShifts[keyPos % keyShifts.Length];
                int newIdx = (idx - shift) % RussianAlphabetUpper.Length;
                if (newIdx < 0)
                {
                    newIdx += RussianAlphabetUpper.Length;
                }

                char dec = isUpper ? RussianAlphabetUpper[newIdx] : RussianAlphabetLower[newIdx];
                sb.Append(dec);

                keyPos++;
            }

            return sb.ToString();
        }

        // Saves the resulting text to a user-selected file using UTF-8 encoding.
        // This method is called only when the "Save to file" checkbox is checked.
        private void SaveResultToFile(string result)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить результат в файл"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, result, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
