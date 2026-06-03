namespace finction.Лаба5
{
    partial class Grid5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView2 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            dataGridView3 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            dataGridView2.Location = new Point(25, 626);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(844, 188);
            dataGridView2.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "a";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "b";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "F(a)";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "F(b)";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "F''(a)";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "F''(b)";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "m";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "M";
            Column8.Name = "Column8";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1429, 350);
            dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(1460, 12);
            button1.Name = "button1";
            button1.Size = new Size(151, 61);
            button1.TabIndex = 5;
            button1.Text = "Заполнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1460, 205);
            button2.Name = "button2";
            button2.Size = new Size(151, 61);
            button2.TabIndex = 6;
            button2.Text = "Ответ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(25, 368);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(844, 252);
            dataGridView3.TabIndex = 7;
            // 
            // Grid5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1654, 826);
            Controls.Add(dataGridView3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(dataGridView2);
            Name = "Grid5";
            Text = "Grid5";
            Load += Grid5_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView3;
    }
}