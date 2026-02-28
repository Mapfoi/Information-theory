## General structure of the application

The application is implemented as a WinForms application (`WinExe`). The entry point is:

- **`Program.Main`**
  - Initializes application configuration (`ApplicationConfiguration.Initialize()`).
  - Creates and runs the main form: `Application.Run(new Form1());`.

All encryption and decryption logic is implemented in the **`Form1`** class.

## Main UI elements

- **Algorithm selection**
  - `radioButton1` — decimation method (English text).
  - `radioButton2` — Vigenère cipher with a direct key (Russian text).
- **Input fields**
  - `textBox_Key` — encryption/decryption key.
  - `textBox_Plaintext` — source text or text to be decrypted (typed from keyboard or loaded from file).
  - `textBox_Cyphertext` — encryption/decryption result.
- **File operations**
  - `button_ReadFromFile` — read source text from a file.
  - `checkBox_SaveToFile` — flag that controls whether the result should be saved to a file.
- **Action buttons**
  - `button_Encode` — encrypt.
  - `button_Decode` — decrypt.
  - `button_Clear` — clear all text fields and the key.

## Call sequence for encryption

1. The user selects an algorithm (`radioButton1` or `radioButton2`), enters text and key.  
2. The user presses **“Encrypt”** → event handler is invoked:
   - **`Form1.button_Encode_Click`**
3. Inside `button_Encode_Click`:
   - `plaintext` and `key` are read from `textBox_Plaintext` and `textBox_Key`.
   - Both fields are validated to be non-empty (otherwise an error message is shown and execution stops).
   - Depending on the selected algorithm:
     - If `radioButton1.Checked`:
       - **`EncryptDecimation(plaintext, key)`** is called;
     - If `radioButton2.Checked`:
       - **`EncryptVigenereRussian(plaintext, key)`** is called.
   - The resulting text is written to `textBox_Cyphertext`.
   - If `checkBox_SaveToFile.Checked == true`:
     - **`SaveResultToFile(result)`** is called (save‑file dialog and writing the result to the chosen file).

## Call sequence for decryption

1. The user selects an algorithm, enters the encrypted text (in `textBox_Plaintext`) and the key.  
2. The user presses **“Decrypt”** → event handler is invoked:
   - **`Form1.button_Decode_Click`**
3. Inside `button_Decode_Click`:
   - `ciphertext` and `key` are read.
   - Both fields are validated to be non-empty.
   - Depending on the selected algorithm:
     - If `radioButton1.Checked`:
       - **`DecryptDecimation(ciphertext, key)`** is called;
     - If `radioButton2.Checked`:
       - **`DecryptVigenereRussian(ciphertext, key)`** is called.
   - The resulting text is written to `textBox_Cyphertext`.
   - If `checkBox_SaveToFile` is checked, **`SaveResultToFile(result)`** is called.

## File operations

- **Reading source text from a file**
  - Event handler: **`button_ReadFromFile_Click`**.
  - Steps:
    - An `OpenFileDialog` with `*.txt` filter is opened.
    - The selected file is read entirely using UTF‑8:
      - `File.ReadAllText(openDialog.FileName, Encoding.UTF8)`.
    - The file content is written to `textBox_Plaintext`.

- **Saving the result to a file**
  - Method: **`SaveResultToFile(string result)`**.
  - Called only if `checkBox_SaveToFile.Checked == true`.
  - Steps:
    - A `SaveFileDialog` with `*.txt` filter is opened.
    - When the user confirms, the result is written to the selected file:
      - `File.WriteAllText(saveDialog.FileName, result, Encoding.UTF8)`.

## Decimation method implementation (English text)

- **Alphabet**
  - Only the English alphabet is used:
    - `EnglishAlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"`
    - `EnglishAlphabetLower = "abcdefghijklmnopqrstuvwxyz"`
  - Alphabet length \( m = 26 \).

- **Key**
  - Entered by the user as an **integer** in `textBox_Key`.
  - Parsed inside `EncryptDecimation` / `DecryptDecimation`.
  - Must satisfy:
    - \( k > 0 \) and `Gcd(k, 26) == 1` — the key must be **coprime** with the alphabet length, otherwise a multiplicative inverse does not exist.

- **Helper functions**
  - **`Gcd(int a, int b)`** — computes the greatest common divisor using the Euclidean algorithm.
  - **`ModInverse(int a, int m)`** — searches for the multiplicative inverse \( a^{-1} \mod m \) by brute force:
    - finds `x` such that `(a * x) % m == 1`.

- **Encryption: `EncryptDecimation(string text, string keyString)`**
  - For each character `ch`:
    - If `ch` is an English letter (`A–Z` or `a–z`):
      - its case (`isUpper`) is determined.
      - the index `idx` is found in `EnglishAlphabetUpper` or `EnglishAlphabetLower`.
      - new index is computed:
        - \[ newIdx = (k * idx) mod 26 \]
      - the encrypted character is taken from the corresponding alphabet at `newIdx`.
    - If `ch` is **not** an English letter:
      - it is **copied unchanged** (characters from other alphabets, spaces, punctuation, etc.).

- **Decryption: `DecryptDecimation(string text, string keyString)`**
  - Parses and validates the key in the same way.
  - Computes the **inverse key**:
    - `int inv = ModInverse(k, 26);`
  - For each English letter:
    - `idx` is found in the alphabet.
    - new index is computed:
      - \[ newIdx = (inv * idx) mod 26 \]
    - the original character (with correct case) is taken at `newIdx`.
  - All non‑English characters are **left unchanged**.

## Vigenère cipher implementation (Russian text)

- **Alphabet**
  - Russian alphabet **with `Ё`** is used:
    - `RussianAlphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"`
    - `RussianAlphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"`
  - Alphabet length \( m = 33 \).

- **Key preprocessing: `BuildRussianKeyShifts(string key)`**
  - Ensures the key is not empty.
  - For each key character:
    - If it is an uppercase Russian letter, its index in `RussianAlphabetUpper` is used.
    - If it is a lowercase Russian letter, its index in `RussianAlphabetLower` is used.
    - Any **non‑Russian** characters in the key are ignored.
  - A list of integer `shifts` is built, each representing a shift in the alphabet (0…32).
  - If the list is empty after filtering, an error is thrown: the key must contain at least one Russian letter.

- **Encryption: `EncryptVigenereRussian(string text, string key)`**
  - Builds the array of shifts: `keyShifts = BuildRussianKeyShifts(key)`.
  - Iterates over characters of the source text:
    - If the character is an uppercase Russian letter:
      - `idx` in `RussianAlphabetUpper` is found, `isUpper = true`.
    - If the character is a lowercase Russian letter:
      - `idx` in `RussianAlphabetLower` is found, `isUpper = false`.
    - If the character is **not** a Russian letter:
      - it is **copied unchanged**.
    - For Russian letters:
      - current shift is `shift = keyShifts[keyPos % keyShifts.Length]`.
      - new index is calculated:
        - \[ newIdx = (idx + shift) mod 33 \]
      - encrypted character is taken from `RussianAlphabetUpper` or `RussianAlphabetLower` depending on the case.
      - `keyPos` is incremented (the key is repeated over Russian letters only).

- **Decryption: `DecryptVigenereRussian(string text, string key)`**
  - Similar to encryption:
    - `keyShifts = BuildRussianKeyShifts(key)`.
    - For each Russian letter:
      - `idx` in the alphabet is found.
      - new index is computed:
        - \[ newIdx = (idx - shift) mod 33 \]
      - if `newIdx` is negative, it is adjusted:
        - `if (newIdx < 0) newIdx += RussianAlphabetUpper.Length;`
      - the original character is taken from the appropriate alphabet.
    - All non‑Russian characters are **copied as is**.

## Ignoring characters outside the alphabet

The same principle is used in both algorithms:

- **Decimation method**:
  - Only English letters `A–Z` and `a–z` are encrypted.
  - All other characters (Cyrillic, digits, spaces, punctuation, etc.) are **copied to the output unchanged**.

- **Vigenère cipher**:
  - Only Russian letters (including `Ё`/`ё`) are encrypted.
  - Any other characters (Latin letters, digits, spaces, punctuation) **remain unchanged**.

