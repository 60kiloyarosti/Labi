namespace finction
{
    partial class MainMenu
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
            laba1 = new Button();
            laba2 = new Button();
            laba3 = new Button();
            laba4 = new Button();
            laba5 = new Button();
            laba6 = new Button();
            SuspendLayout();
            // 
            // laba1
            // 
            laba1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba1.Location = new Point(46, 64);
            laba1.Name = "laba1";
            laba1.Size = new Size(216, 90);
            laba1.TabIndex = 0;
            laba1.Text = "Лаба1";
            laba1.UseVisualStyleBackColor = true;
            laba1.Click += laba1_Click;
            // 
            // laba2
            // 
            laba2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba2.Location = new Point(46, 181);
            laba2.Name = "laba2";
            laba2.Size = new Size(216, 90);
            laba2.TabIndex = 1;
            laba2.Text = "Лаба2";
            laba2.UseVisualStyleBackColor = true;
            laba2.Click += laba2_Click;
            // 
            // laba3
            // 
            laba3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba3.Location = new Point(46, 304);
            laba3.Name = "laba3";
            laba3.Size = new Size(216, 90);
            laba3.TabIndex = 2;
            laba3.Text = "Лаба3";
            laba3.UseVisualStyleBackColor = true;
            laba3.Click += laba3_Click;
            // 
            // laba4
            // 
            laba4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba4.Location = new Point(297, 64);
            laba4.Name = "laba4";
            laba4.Size = new Size(216, 90);
            laba4.TabIndex = 3;
            laba4.Text = "Лаба4";
            laba4.UseVisualStyleBackColor = true;
            laba4.Click += laba4_Click;
            // 
            // laba5
            // 
            laba5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba5.Location = new Point(297, 181);
            laba5.Name = "laba5";
            laba5.Size = new Size(216, 90);
            laba5.TabIndex = 4;
            laba5.Text = "Лаба5";
            laba5.UseVisualStyleBackColor = true;
            laba5.Click += laba5_Click;
            // 
            // laba6
            // 
            laba6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            laba6.Location = new Point(297, 304);
            laba6.Name = "laba6";
            laba6.Size = new Size(216, 90);
            laba6.TabIndex = 5;
            laba6.Text = "Лаба6";
            laba6.UseVisualStyleBackColor = true;
            laba6.Click += laba6_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 573);
            Controls.Add(laba6);
            Controls.Add(laba5);
            Controls.Add(laba4);
            Controls.Add(laba3);
            Controls.Add(laba2);
            Controls.Add(laba1);
            Name = "MainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button laba1;
        private Button laba2;
        private Button laba3;
        private Button laba4;
        private Button laba5;
        private Button laba6;
    }
}