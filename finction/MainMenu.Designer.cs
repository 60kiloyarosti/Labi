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
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 573);
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
    }
}