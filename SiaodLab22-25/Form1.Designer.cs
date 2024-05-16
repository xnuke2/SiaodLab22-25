namespace SiaodLab22_25
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
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            Column1 = new DataGridViewCheckBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            ColumnSorted = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(518, 385);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 13;
            label3.Text = "не выбрана сортировка";
            label3.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(462, 414);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 12;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(12, 373);
            button2.Name = "button2";
            button2.Size = new Size(157, 40);
            button2.TabIndex = 11;
            button2.Text = "Сортировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 385);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 10;
            label1.Text = "Размер массива";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(286, 383);
            numericUpDown1.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(113, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(694, 373);
            button1.Name = "button1";
            button1.Size = new Size(115, 40);
            button1.TabIndex = 8;
            button1.Text = "выход";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, ColumnSorted });
            dataGridView1.Location = new Point(12, 11);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(801, 356);
            dataGridView1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(415, 385);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 14;
            label4.Text = "%ОП";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(458, 383);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(55, 23);
            numericUpDown2.TabIndex = 15;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Column1
            // 
            Column1.FillWeight = 30F;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.FillWeight = 101.725891F;
            Column2.HeaderText = "Название сортировки";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Resizable = DataGridViewTriState.True;
            Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            Column3.FillWeight = 101.725891F;
            Column3.HeaderText = "Сравнения";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Resizable = DataGridViewTriState.True;
            Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            Column4.FillWeight = 101.725891F;
            Column4.HeaderText = "Перестановки";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Resizable = DataGridViewTriState.True;
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            Column5.FillWeight = 101.725891F;
            Column5.HeaderText = "Время";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // ColumnSorted
            // 
            ColumnSorted.FillWeight = 101.725891F;
            ColumnSorted.HeaderText = "Отсортировано?";
            ColumnSorted.MinimumWidth = 6;
            ColumnSorted.Name = "ColumnSorted";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 415);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Лабораторная работа 22-25 Хмыренков";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Button button2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn ColumnSorted;
    }
}
