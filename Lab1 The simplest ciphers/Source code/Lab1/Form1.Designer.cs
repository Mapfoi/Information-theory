namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelKey = new Label();
            textBox_Key = new TextBox();
            button_ReadFromFile = new Button();
            textBox_Plaintext = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label_Plaintext = new Label();
            label_Cyphertext = new Label();
            textBox_Cyphertext = new TextBox();
            button_Encode = new Button();
            button_Decode = new Button();
            button_Clear = new Button();
            checkBox_SaveToFile = new CheckBox();
            SuspendLayout();
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Font = new Font("Segoe UI", 12F);
            labelKey.Location = new Point(8, 107);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(66, 28);
            labelKey.TabIndex = 1;
            labelKey.Text = "Ключ:";
            // 
            // textBox_Key
            // 
            textBox_Key.Font = new Font("Segoe UI", 12F);
            textBox_Key.Location = new Point(76, 104);
            textBox_Key.Name = "textBox_Key";
            textBox_Key.Size = new Size(411, 34);
            textBox_Key.TabIndex = 2;
            // 
            // button_ReadFromFile
            // 
            button_ReadFromFile.Font = new Font("Segoe UI", 12F);
            button_ReadFromFile.Location = new Point(493, 104);
            button_ReadFromFile.Name = "button_ReadFromFile";
            button_ReadFromFile.Size = new Size(276, 34);
            button_ReadFromFile.TabIndex = 3;
            button_ReadFromFile.Text = "Прочитать из файла";
            button_ReadFromFile.UseVisualStyleBackColor = true;
            button_ReadFromFile.Click += button_ReadFromFile_Click;
            // 
            // textBox_Plaintext
            // 
            textBox_Plaintext.Font = new Font("Segoe UI", 12F);
            textBox_Plaintext.Location = new Point(8, 198);
            textBox_Plaintext.Multiline = true;
            textBox_Plaintext.Name = "textBox_Plaintext";
            textBox_Plaintext.Size = new Size(757, 39);
            textBox_Plaintext.TabIndex = 4;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 14F);
            radioButton1.ForeColor = SystemColors.ControlText;
            radioButton1.Location = new Point(8, 11);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(239, 36);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Метод децимации";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 14F);
            radioButton2.Location = new Point(8, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(433, 36);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "Шифр Виженера с прямым ключем";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label_Plaintext
            // 
            label_Plaintext.AutoSize = true;
            label_Plaintext.Font = new Font("Segoe UI", 12F);
            label_Plaintext.Location = new Point(8, 167);
            label_Plaintext.Name = "label_Plaintext";
            label_Plaintext.Size = new Size(160, 28);
            label_Plaintext.TabIndex = 7;
            label_Plaintext.Text = "Исходный текст:";
            // 
            // label_Cyphertext
            // 
            label_Cyphertext.AutoSize = true;
            label_Cyphertext.Font = new Font("Segoe UI", 12F);
            label_Cyphertext.Location = new Point(8, 269);
            label_Cyphertext.Name = "label_Cyphertext";
            label_Cyphertext.Size = new Size(225, 28);
            label_Cyphertext.TabIndex = 9;
            label_Cyphertext.Text = "Результирующий текст:";
            label_Cyphertext.Click += label_Cyphertext_Click;
            // 
            // textBox_Cyphertext
            // 
            textBox_Cyphertext.Font = new Font("Segoe UI", 12F);
            textBox_Cyphertext.Location = new Point(8, 300);
            textBox_Cyphertext.Multiline = true;
            textBox_Cyphertext.Name = "textBox_Cyphertext";
            textBox_Cyphertext.Size = new Size(757, 40);
            textBox_Cyphertext.TabIndex = 8;
            // 
            // button_Encode
            // 
            button_Encode.Font = new Font("Segoe UI", 12F);
            button_Encode.Location = new Point(8, 376);
            button_Encode.Name = "button_Encode";
            button_Encode.Size = new Size(236, 50);
            button_Encode.TabIndex = 10;
            button_Encode.Text = "Зашифровать";
            button_Encode.UseVisualStyleBackColor = true;
            button_Encode.Click += button_Encode_Click;
            // 
            // button_Decode
            // 
            button_Decode.Font = new Font("Segoe UI", 12F);
            button_Decode.Location = new Point(266, 376);
            button_Decode.Name = "button_Decode";
            button_Decode.Size = new Size(236, 50);
            button_Decode.TabIndex = 11;
            button_Decode.Text = "Расшифровать";
            button_Decode.UseVisualStyleBackColor = true;
            button_Decode.Click += button_Decode_Click;
            // 
            // button_Clear
            // 
            button_Clear.Font = new Font("Segoe UI", 12F);
            button_Clear.Location = new Point(529, 376);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(236, 50);
            button_Clear.TabIndex = 12;
            button_Clear.Text = "Очистить";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // checkBox_SaveToFile
            // 
            checkBox_SaveToFile.AutoSize = true;
            checkBox_SaveToFile.Checked = true;
            checkBox_SaveToFile.CheckState = CheckState.Checked;
            checkBox_SaveToFile.Font = new Font("Segoe UI", 12F);
            checkBox_SaveToFile.Location = new Point(493, 11);
            checkBox_SaveToFile.Name = "checkBox_SaveToFile";
            checkBox_SaveToFile.Size = new Size(290, 32);
            checkBox_SaveToFile.TabIndex = 13;
            checkBox_SaveToFile.Text = "Сохранять результат в файл";
            checkBox_SaveToFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Clear);
            Controls.Add(button_Decode);
            Controls.Add(button_Encode);
            Controls.Add(checkBox_SaveToFile);
            Controls.Add(label_Cyphertext);
            Controls.Add(textBox_Cyphertext);
            Controls.Add(label_Plaintext);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox_Plaintext);
            Controls.Add(button_ReadFromFile);
            Controls.Add(textBox_Key);
            Controls.Add(labelKey);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Шифратор";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelKey;
        private TextBox textBox_Key;
        private Button button_ReadFromFile;
        private TextBox textBox_Plaintext;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label_Plaintext;
        private Label label_Cyphertext;
        private TextBox textBox_Cyphertext;
        private Button button_Encode;
        private Button button_Decode;
        private Button button_Clear;
        private CheckBox checkBox_SaveToFile;
    }
}
