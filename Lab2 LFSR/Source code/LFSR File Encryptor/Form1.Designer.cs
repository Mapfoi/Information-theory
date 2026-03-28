namespace LFSR_File_Encryptor
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
            tableRoot = new TableLayoutPanel();
            groupParams = new GroupBox();
            tableParams = new TableLayoutPanel();
            lblSeed = new Label();
            tbSeed = new TextBox();
            lblInputFile = new Label();
            tbInputFile = new TextBox();
            btnBrowseInput = new Button();
            lblOutputFile = new Label();
            tbOutputFile = new TextBox();
            btnBrowseOutput = new Button();
            lblStatus = new Label();
            label1 = new Label();
            btnRun = new Button();
            splitMain = new SplitContainer();
            groupKey = new GroupBox();
            tbKeyBits = new TextBox();
            splitIo = new SplitContainer();
            groupInputBits = new GroupBox();
            tbInputBits = new TextBox();
            groupOutputBits = new GroupBox();
            tbOutputBits = new TextBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            tableRoot.SuspendLayout();
            groupParams.SuspendLayout();
            tableParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            groupKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitIo).BeginInit();
            splitIo.Panel1.SuspendLayout();
            splitIo.Panel2.SuspendLayout();
            splitIo.SuspendLayout();
            groupInputBits.SuspendLayout();
            groupOutputBits.SuspendLayout();
            SuspendLayout();
            // 
            // tableRoot
            // 
            tableRoot.ColumnCount = 1;
            tableRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableRoot.Controls.Add(groupParams, 0, 0);
            tableRoot.Controls.Add(splitMain, 0, 1);
            tableRoot.Dock = DockStyle.Fill;
            tableRoot.Location = new Point(0, 0);
            tableRoot.Name = "tableRoot";
            tableRoot.RowCount = 2;
            tableRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 274F));
            tableRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRoot.Size = new Size(1811, 912);
            tableRoot.TabIndex = 0;
            // 
            // groupParams
            // 
            groupParams.Controls.Add(tableParams);
            groupParams.Dock = DockStyle.Fill;
            groupParams.Location = new Point(10, 10);
            groupParams.Margin = new Padding(10);
            groupParams.Name = "groupParams";
            groupParams.Padding = new Padding(10);
            groupParams.Size = new Size(1791, 254);
            groupParams.TabIndex = 0;
            groupParams.TabStop = false;
            groupParams.Text = "Параметры";
            // 
            // tableParams
            // 
            tableParams.ColumnCount = 3;
            tableParams.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 361F));
            tableParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableParams.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330F));
            tableParams.Controls.Add(lblSeed, 0, 0);
            tableParams.Controls.Add(tbSeed, 1, 0);
            tableParams.Controls.Add(lblInputFile, 0, 1);
            tableParams.Controls.Add(tbInputFile, 1, 1);
            tableParams.Controls.Add(btnBrowseInput, 2, 1);
            tableParams.Controls.Add(lblOutputFile, 0, 2);
            tableParams.Controls.Add(tbOutputFile, 1, 2);
            tableParams.Controls.Add(btnBrowseOutput, 2, 2);
            tableParams.Controls.Add(lblStatus, 1, 3);
            tableParams.Controls.Add(label1, 0, 3);
            tableParams.Controls.Add(btnRun, 2, 3);
            tableParams.Dock = DockStyle.Fill;
            tableParams.Location = new Point(10, 42);
            tableParams.Name = "tableParams";
            tableParams.RowCount = 4;
            tableParams.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableParams.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableParams.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableParams.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableParams.Size = new Size(1771, 202);
            tableParams.TabIndex = 0;
            // 
            // lblSeed
            // 
            lblSeed.AutoSize = true;
            lblSeed.Dock = DockStyle.Fill;
            lblSeed.Location = new Point(3, 0);
            lblSeed.Name = "lblSeed";
            lblSeed.Size = new Size(355, 47);
            lblSeed.TabIndex = 0;
            lblSeed.Text = "Начальное состояние (28 бит):";
            lblSeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbSeed
            // 
            tbSeed.Dock = DockStyle.Fill;
            tbSeed.Location = new Point(364, 3);
            tbSeed.MaxLength = 28;
            tbSeed.Name = "tbSeed";
            tbSeed.Size = new Size(1074, 39);
            tbSeed.TabIndex = 1;
            tbSeed.Text = "1111111111111111111111111111";
            // 
            // lblInputFile
            // 
            lblInputFile.AutoSize = true;
            lblInputFile.Dock = DockStyle.Fill;
            lblInputFile.Location = new Point(3, 47);
            lblInputFile.Name = "lblInputFile";
            lblInputFile.Size = new Size(355, 50);
            lblInputFile.TabIndex = 2;
            lblInputFile.Text = "Входной файл:";
            lblInputFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbInputFile
            // 
            tbInputFile.Dock = DockStyle.Fill;
            tbInputFile.Location = new Point(364, 50);
            tbInputFile.Name = "tbInputFile";
            tbInputFile.ReadOnly = true;
            tbInputFile.Size = new Size(1074, 39);
            tbInputFile.TabIndex = 3;
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Dock = DockStyle.Fill;
            btnBrowseInput.Location = new Point(1444, 50);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(324, 44);
            btnBrowseInput.TabIndex = 4;
            btnBrowseInput.Text = "Выбрать файл";
            btnBrowseInput.UseVisualStyleBackColor = true;
            // 
            // lblOutputFile
            // 
            lblOutputFile.AutoSize = true;
            lblOutputFile.Dock = DockStyle.Fill;
            lblOutputFile.Location = new Point(3, 97);
            lblOutputFile.Name = "lblOutputFile";
            lblOutputFile.Size = new Size(355, 49);
            lblOutputFile.TabIndex = 5;
            lblOutputFile.Text = "Выходной файл:";
            lblOutputFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbOutputFile
            // 
            tbOutputFile.Dock = DockStyle.Fill;
            tbOutputFile.Location = new Point(364, 100);
            tbOutputFile.Name = "tbOutputFile";
            tbOutputFile.ReadOnly = true;
            tbOutputFile.Size = new Size(1074, 39);
            tbOutputFile.TabIndex = 6;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Dock = DockStyle.Fill;
            btnBrowseOutput.Location = new Point(1444, 100);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(324, 43);
            btnBrowseOutput.TabIndex = 7;
            btnBrowseOutput.Text = "Сохранить как…";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(364, 146);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(130, 32);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Ожидание";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 146);
            label1.Name = "label1";
            label1.Size = new Size(136, 32);
            label1.TabIndex = 9;
            label1.Text = "Состояние:";
            // 
            // btnRun
            // 
            btnRun.AutoSize = true;
            btnRun.Location = new Point(1441, 146);
            btnRun.Margin = new Padding(0);
            btnRun.Name = "btnRun";
            btnRun.Padding = new Padding(12, 4, 12, 4);
            btnRun.Size = new Size(330, 50);
            btnRun.TabIndex = 0;
            btnRun.Text = "Запустить шифрование/дешифрование";
            btnRun.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(10, 284);
            splitMain.Margin = new Padding(10);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(groupKey);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(splitIo);
            splitMain.Size = new Size(1791, 618);
            splitMain.SplitterDistance = 645;
            splitMain.TabIndex = 1;
            // 
            // groupKey
            // 
            groupKey.Controls.Add(tbKeyBits);
            groupKey.Dock = DockStyle.Fill;
            groupKey.Location = new Point(0, 0);
            groupKey.Name = "groupKey";
            groupKey.Padding = new Padding(10);
            groupKey.Size = new Size(645, 618);
            groupKey.TabIndex = 0;
            groupKey.TabStop = false;
            groupKey.Text = "Ключевой поток (биты)";
            // 
            // tbKeyBits
            // 
            tbKeyBits.Dock = DockStyle.Fill;
            tbKeyBits.Location = new Point(10, 42);
            tbKeyBits.Multiline = true;
            tbKeyBits.Name = "tbKeyBits";
            tbKeyBits.ReadOnly = true;
            tbKeyBits.ScrollBars = ScrollBars.Both;
            tbKeyBits.Size = new Size(625, 566);
            tbKeyBits.TabIndex = 0;
            // 
            // splitIo
            // 
            splitIo.Dock = DockStyle.Fill;
            splitIo.Location = new Point(0, 0);
            splitIo.Name = "splitIo";
            splitIo.Orientation = Orientation.Horizontal;
            // 
            // splitIo.Panel1
            // 
            splitIo.Panel1.Controls.Add(groupInputBits);
            // 
            // splitIo.Panel2
            // 
            splitIo.Panel2.Controls.Add(groupOutputBits);
            splitIo.Size = new Size(1142, 618);
            splitIo.SplitterDistance = 296;
            splitIo.TabIndex = 0;
            // 
            // groupInputBits
            // 
            groupInputBits.Controls.Add(tbInputBits);
            groupInputBits.Dock = DockStyle.Fill;
            groupInputBits.Location = new Point(0, 0);
            groupInputBits.Name = "groupInputBits";
            groupInputBits.Padding = new Padding(10);
            groupInputBits.Size = new Size(1142, 296);
            groupInputBits.TabIndex = 0;
            groupInputBits.TabStop = false;
            groupInputBits.Text = "Исходный файл (биты)";
            // 
            // tbInputBits
            // 
            tbInputBits.Dock = DockStyle.Fill;
            tbInputBits.Location = new Point(10, 42);
            tbInputBits.Multiline = true;
            tbInputBits.Name = "tbInputBits";
            tbInputBits.ReadOnly = true;
            tbInputBits.ScrollBars = ScrollBars.Both;
            tbInputBits.Size = new Size(1122, 244);
            tbInputBits.TabIndex = 0;
            // 
            // groupOutputBits
            // 
            groupOutputBits.Controls.Add(tbOutputBits);
            groupOutputBits.Dock = DockStyle.Fill;
            groupOutputBits.Location = new Point(0, 0);
            groupOutputBits.Name = "groupOutputBits";
            groupOutputBits.Padding = new Padding(10);
            groupOutputBits.Size = new Size(1142, 318);
            groupOutputBits.TabIndex = 0;
            groupOutputBits.TabStop = false;
            groupOutputBits.Text = "Результат (биты)";
            // 
            // tbOutputBits
            // 
            tbOutputBits.Dock = DockStyle.Fill;
            tbOutputBits.Location = new Point(10, 42);
            tbOutputBits.Multiline = true;
            tbOutputBits.Name = "tbOutputBits";
            tbOutputBits.ReadOnly = true;
            tbOutputBits.ScrollBars = ScrollBars.Both;
            tbOutputBits.Size = new Size(1122, 266);
            tbOutputBits.TabIndex = 0;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить результат";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1811, 912);
            Controls.Add(tableRoot);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Потоковое шифрование файла (LFSR)";
            WindowState = FormWindowState.Maximized;
            tableRoot.ResumeLayout(false);
            groupParams.ResumeLayout(false);
            tableParams.ResumeLayout(false);
            tableParams.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            groupKey.ResumeLayout(false);
            groupKey.PerformLayout();
            splitIo.Panel1.ResumeLayout(false);
            splitIo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitIo).EndInit();
            splitIo.ResumeLayout(false);
            groupInputBits.ResumeLayout(false);
            groupInputBits.PerformLayout();
            groupOutputBits.ResumeLayout(false);
            groupOutputBits.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableRoot;
        private GroupBox groupParams;
        private TableLayoutPanel tableParams;
        private Label lblSeed;
        private TextBox tbSeed;
        private Label lblInputFile;
        private TextBox tbInputFile;
        private Label lblOutputFile;
        private TextBox tbOutputFile;
        private Button btnBrowseOutput;
        private Button btnRun;
        private SplitContainer splitMain;
        private GroupBox groupKey;
        private TextBox tbKeyBits;
        private SplitContainer splitIo;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Button btnBrowseInput;
        private Label lblStatus;
        private Label label1;
        private GroupBox groupInputBits;
        private TextBox tbInputBits;
        private GroupBox groupOutputBits;
        private TextBox tbOutputBits;
    }
}
