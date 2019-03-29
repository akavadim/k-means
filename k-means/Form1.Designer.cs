namespace k_means
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonFile = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoX = new System.Windows.Forms.CheckedListBox();
            this.numberOfCluster = new System.Windows.Forms.NumericUpDown();
            this.buttonStartKMeans = new System.Windows.Forms.Button();
            this.buttonRes = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxOnlyNumbers = new System.Windows.Forms.CheckBox();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCluster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(184, 44);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(85, 27);
            this.buttonFile.TabIndex = 0;
            this.buttonFile.Text = "Открыть";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPath.Location = new System.Drawing.Point(15, 46);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(163, 22);
            this.textBoxPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбранный файл";
            // 
            // checkedListBoX
            // 
            this.checkedListBoX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoX.CheckOnClick = true;
            this.checkedListBoX.Enabled = false;
            this.checkedListBoX.FormattingEnabled = true;
            this.checkedListBoX.HorizontalScrollbar = true;
            this.checkedListBoX.Location = new System.Drawing.Point(12, 116);
            this.checkedListBoX.Name = "checkedListBoX";
            this.checkedListBoX.Size = new System.Drawing.Size(163, 429);
            this.checkedListBoX.TabIndex = 5;
            this.checkedListBoX.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoX_ItemCheck);
            this.checkedListBoX.SelectedIndexChanged += new System.EventHandler(this.numberOfCluster_ValueChanged);
            // 
            // numberOfCluster
            // 
            this.numberOfCluster.Enabled = false;
            this.numberOfCluster.Location = new System.Drawing.Point(559, 29);
            this.numberOfCluster.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCluster.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCluster.Name = "numberOfCluster";
            this.numberOfCluster.Size = new System.Drawing.Size(75, 22);
            this.numberOfCluster.TabIndex = 6;
            this.numberOfCluster.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfCluster.ValueChanged += new System.EventHandler(this.numberOfCluster_ValueChanged);
            // 
            // buttonStartKMeans
            // 
            this.buttonStartKMeans.Enabled = false;
            this.buttonStartKMeans.Location = new System.Drawing.Point(275, 44);
            this.buttonStartKMeans.Name = "buttonStartKMeans";
            this.buttonStartKMeans.Size = new System.Drawing.Size(164, 27);
            this.buttonStartKMeans.TabIndex = 7;
            this.buttonStartKMeans.Text = "Запустить алгоритм";
            this.buttonStartKMeans.UseVisualStyleBackColor = true;
            this.buttonStartKMeans.Click += new System.EventHandler(this.buttonStartKMeans_Click);
            // 
            // buttonRes
            // 
            this.buttonRes.Enabled = false;
            this.buttonRes.Location = new System.Drawing.Point(442, 44);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(91, 27);
            this.buttonRes.TabIndex = 8;
            this.buttonRes.Text = "Результат";
            this.buttonRes.UseVisualStyleBackColor = true;
            this.buttonRes.Click += new System.EventHandler(this.buttonRes_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(181, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(765, 429);
            this.dataGridView1.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(559, 88);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numberOfCluster_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Количество кластеров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Максимум итераций";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Колонки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Выбранный файл";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(847, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Справка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxOnlyNumbers
            // 
            this.checkBoxOnlyNumbers.AutoSize = true;
            this.checkBoxOnlyNumbers.Enabled = false;
            this.checkBoxOnlyNumbers.Location = new System.Drawing.Point(15, 92);
            this.checkBoxOnlyNumbers.Name = "checkBoxOnlyNumbers";
            this.checkBoxOnlyNumbers.Size = new System.Drawing.Size(145, 21);
            this.checkBoxOnlyNumbers.TabIndex = 17;
            this.checkBoxOnlyNumbers.Text = "Только числовые";
            this.checkBoxOnlyNumbers.UseVisualStyleBackColor = true;
            this.checkBoxOnlyNumbers.CheckedChanged += new System.EventHandler(this.checkBoxOnlyNumbers_CheckedChanged);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancle.Enabled = false;
            this.buttonCancle.Location = new System.Drawing.Point(871, 87);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 18;
            this.buttonCancle.Text = "Стоп";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProgress.Location = new System.Drawing.Point(760, 87);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.ReadOnly = true;
            this.textBoxProgress.Size = new System.Drawing.Size(105, 22);
            this.textBoxProgress.TabIndex = 19;
            this.textBoxProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 557);
            this.Controls.Add(this.textBoxProgress);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.checkBoxOnlyNumbers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRes);
            this.Controls.Add(this.buttonStartKMeans);
            this.Controls.Add(this.numberOfCluster);
            this.Controls.Add(this.checkedListBoX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonFile);
            this.MinimumSize = new System.Drawing.Size(976, 604);
            this.Name = "Form1";
            this.Text = "K-Means";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfCluster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoX;
        private System.Windows.Forms.NumericUpDown numberOfCluster;
        private System.Windows.Forms.Button buttonStartKMeans;
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxOnlyNumbers;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.TextBox textBoxProgress;
    }
}

