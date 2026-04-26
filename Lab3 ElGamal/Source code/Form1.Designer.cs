namespace Lab3_ElGamal
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
            components = new System.ComponentModel.Container();
            labelP = new Label();
            textBoxP = new TextBox();
            labelX = new Label();
            textBoxX = new TextBox();
            labelK = new Label();
            textBoxK = new TextBox();
            labelY = new Label();
            textBoxY = new TextBox();
            buttonFindRoots = new Button();
            listBoxRoots = new ListBox();
            labelRootsCount = new Label();
            radioEncrypt = new RadioButton();
            radioDecrypt = new RadioButton();
            buttonLoad = new Button();
            buttonEncrypt = new Button();
            buttonDecrypt = new Button();
            buttonSave = new Button();
            buttonClear = new Button();
            labelLoadedFile = new Label();
            labelInput = new Label();
            textBoxInput = new TextBox();
            labelOutput = new Label();
            textBoxOutput = new TextBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            SuspendLayout();
            // 
            // labelP
            // 
            labelP.AutoSize = true;
            labelP.Location = new Point(12, 15);
            labelP.Name = "labelP";
            labelP.Size = new Size(16, 15);
            labelP.TabIndex = 0;
            labelP.Text = "P:";
            // 
            // textBoxP
            // 
            textBoxP.Location = new Point(34, 12);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(110, 23);
            textBoxP.TabIndex = 1;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(160, 15);
            labelX.Name = "labelX";
            labelX.Size = new Size(17, 15);
            labelX.TabIndex = 2;
            labelX.Text = "X:";
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(183, 12);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(110, 23);
            textBoxX.TabIndex = 3;
            // 
            // labelK
            // 
            labelK.AutoSize = true;
            labelK.Location = new Point(309, 15);
            labelK.Name = "labelK";
            labelK.Size = new Size(16, 15);
            labelK.TabIndex = 4;
            labelK.Text = "K:";
            // 
            // textBoxK
            // 
            textBoxK.Location = new Point(331, 12);
            textBoxK.Name = "textBoxK";
            textBoxK.Size = new Size(110, 23);
            textBoxK.TabIndex = 5;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new Point(457, 15);
            labelY.Name = "labelY";
            labelY.Size = new Size(17, 15);
            labelY.TabIndex = 6;
            labelY.Text = "Y:";
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(480, 12);
            textBoxY.Name = "textBoxY";
            textBoxY.ReadOnly = true;
            textBoxY.Size = new Size(110, 23);
            textBoxY.TabIndex = 7;
            // 
            // buttonFindRoots
            // 
            buttonFindRoots.Location = new Point(12, 46);
            buttonFindRoots.Name = "buttonFindRoots";
            buttonFindRoots.Size = new Size(190, 30);
            buttonFindRoots.TabIndex = 8;
            buttonFindRoots.Text = "Найти все первообразные корни";
            buttonFindRoots.UseVisualStyleBackColor = true;
            buttonFindRoots.Click += buttonFindRoots_Click;
            // 
            // listBoxRoots
            // 
            listBoxRoots.FormattingEnabled = true;
            listBoxRoots.ItemHeight = 15;
            listBoxRoots.Location = new Point(12, 82);
            listBoxRoots.Name = "listBoxRoots";
            listBoxRoots.Size = new Size(190, 184);
            listBoxRoots.TabIndex = 9;
            // 
            // labelRootsCount
            // 
            labelRootsCount.AutoSize = true;
            labelRootsCount.Location = new Point(12, 274);
            labelRootsCount.Name = "labelRootsCount";
            labelRootsCount.Size = new Size(116, 15);
            labelRootsCount.TabIndex = 10;
            labelRootsCount.Text = "Найдено корней: 0";
            // 
            // radioEncrypt
            // 
            radioEncrypt.AutoSize = true;
            radioEncrypt.Checked = true;
            radioEncrypt.Location = new Point(227, 52);
            radioEncrypt.Name = "radioEncrypt";
            radioEncrypt.Size = new Size(92, 19);
            radioEncrypt.TabIndex = 11;
            radioEncrypt.TabStop = true;
            radioEncrypt.Text = "Шифрование";
            radioEncrypt.UseVisualStyleBackColor = true;
            radioEncrypt.CheckedChanged += radioEncrypt_CheckedChanged;
            // 
            // radioDecrypt
            // 
            radioDecrypt.AutoSize = true;
            radioDecrypt.Location = new Point(335, 52);
            radioDecrypt.Name = "radioDecrypt";
            radioDecrypt.Size = new Size(106, 19);
            radioDecrypt.TabIndex = 12;
            radioDecrypt.Text = "Дешифрование";
            radioDecrypt.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(457, 46);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(133, 30);
            buttonLoad.TabIndex = 13;
            buttonLoad.Text = "Загрузить файл";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(606, 46);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(100, 30);
            buttonEncrypt.TabIndex = 14;
            buttonEncrypt.Text = "Шифровать";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += buttonEncrypt_Click;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Enabled = false;
            buttonDecrypt.Location = new Point(721, 46);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(100, 30);
            buttonDecrypt.TabIndex = 15;
            buttonDecrypt.Text = "Дешифровать";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(606, 82);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(721, 82);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(100, 30);
            buttonClear.TabIndex = 17;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelLoadedFile
            // 
            labelLoadedFile.AutoEllipsis = true;
            labelLoadedFile.Location = new Point(227, 85);
            labelLoadedFile.Name = "labelLoadedFile";
            labelLoadedFile.Size = new Size(363, 27);
            labelLoadedFile.TabIndex = 18;
            labelLoadedFile.Text = "Файл: не выбран";
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(227, 125);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(111, 15);
            labelInput.TabIndex = 19;
            labelInput.Text = "Входные данные:";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(227, 143);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ReadOnly = true;
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(594, 149);
            textBoxInput.TabIndex = 20;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(227, 302);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(119, 15);
            labelOutput.TabIndex = 21;
            labelOutput.Text = "Результат операции:";
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(227, 320);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(594, 170);
            textBoxOutput.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 503);
            Controls.Add(textBoxOutput);
            Controls.Add(labelOutput);
            Controls.Add(textBoxInput);
            Controls.Add(labelInput);
            Controls.Add(labelLoadedFile);
            Controls.Add(buttonClear);
            Controls.Add(buttonSave);
            Controls.Add(buttonDecrypt);
            Controls.Add(buttonEncrypt);
            Controls.Add(buttonLoad);
            Controls.Add(radioDecrypt);
            Controls.Add(radioEncrypt);
            Controls.Add(labelRootsCount);
            Controls.Add(listBoxRoots);
            Controls.Add(buttonFindRoots);
            Controls.Add(textBoxY);
            Controls.Add(labelY);
            Controls.Add(textBoxK);
            Controls.Add(labelK);
            Controls.Add(textBoxX);
            Controls.Add(labelX);
            Controls.Add(textBoxP);
            Controls.Add(labelP);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab3 ElGamal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelP;
        private TextBox textBoxP;
        private Label labelX;
        private TextBox textBoxX;
        private Label labelK;
        private TextBox textBoxK;
        private Label labelY;
        private TextBox textBoxY;
        private Button buttonFindRoots;
        private ListBox listBoxRoots;
        private Label labelRootsCount;
        private RadioButton radioEncrypt;
        private RadioButton radioDecrypt;
        private Button buttonLoad;
        private Button buttonEncrypt;
        private Button buttonDecrypt;
        private Button buttonSave;
        private Button buttonClear;
        private Label labelLoadedFile;
        private Label labelInput;
        private TextBox textBoxInput;
        private Label labelOutput;
        private TextBox textBoxOutput;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
    }
}
