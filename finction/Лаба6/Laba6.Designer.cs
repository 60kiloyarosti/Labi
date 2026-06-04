namespace finction.Лаба6
{
    partial class Laba6
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
            CountKornej = new TextBox();
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // CountKornej
            // 
            CountKornej.Location = new Point(496, 28);
            CountKornej.Name = "CountKornej";
            CountKornej.Size = new Size(100, 23);
            CountKornej.TabIndex = 0;
            CountKornej.TextChanged += CountKornej_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(120, 26);
            label1.Name = "label1";
            label1.Size = new Size(370, 25);
            label1.TabIndex = 1;
            label1.Text = "Введите количество корней в системе";
            // 
            // button1
            // 
            button1.Location = new Point(762, 23);
            button1.Name = "button1";
            button1.Size = new Size(189, 30);
            button1.TabIndex = 2;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(969, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(712, 563);
            dataGridView1.TabIndex = 3;
            // 
            // Laba6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1689, 603);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(CountKornej);
            Name = "Laba6";
            Text = "Laba6";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CountKornej;
        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
    }
}