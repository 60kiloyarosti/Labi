namespace finction.Лаба11
{
    partial class Laba11
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridView1 = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 0.05D;
            chartArea1.AxisX.Maximum = 0.8D;
            chartArea1.AxisX.Minimum = -0.01D;
            stripLine1.BorderColor = Color.Red;
            stripLine1.BorderWidth = 2;
            stripLine1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine1.Text = "Y";
            stripLine1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisY.Interval = 0.05D;
            chartArea1.AxisY.Maximum = 0.21D;
            chartArea1.AxisY.Minimum = -0.01D;
            stripLine2.BorderColor = Color.Red;
            stripLine2.BorderWidth = 2;
            stripLine2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine2.Text = "X";
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Location = new Point(12, 3);
            chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            series2.BorderColor = Color.SpringGreen;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = Color.SpringGreen;
            series2.Name = "Series2";
            series3.BorderColor = Color.SpringGreen;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = Color.SpringGreen;
            series3.Name = "Series3";
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Series.Add(series3);
            chart1.Size = new Size(733, 347);
            chart1.TabIndex = 6;
            chart1.Text = "chart1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column5, Column6, Column7, Column8, Column9, Column10 });
            dataGridView1.Location = new Point(751, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(684, 347);
            dataGridView1.TabIndex = 7;
            // 
            // Column5
            // 
            Column5.HeaderText = "x";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "y";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "f(xi +xi+1)/2";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "y'";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "y''";
            Column9.Name = "Column9";
            // 
            // Column10
            // 
            Column10.HeaderText = "y(4)";
            Column10.Name = "Column10";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView2.Location = new Point(751, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(443, 47);
            dataGridView2.TabIndex = 8;
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
            Column3.HeaderText = "n";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "h";
            Column4.Name = "Column4";
            // 
            // button2
            // 
            button2.Location = new Point(12, 418);
            button2.Name = "button2";
            button2.Size = new Size(178, 47);
            button2.TabIndex = 10;
            button2.Text = "Вычислить по ф.л.п";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(222, 418);
            button1.Name = "button1";
            button1.Size = new Size(178, 47);
            button1.TabIndex = 11;
            button1.Text = "Вычислить по ф.п.п";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(431, 418);
            button3.Name = "button3";
            button3.Size = new Size(178, 47);
            button3.TabIndex = 12;
            button3.Text = "Вычислить по ф.с.п";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(65, 488);
            button4.Name = "button4";
            button4.Size = new Size(178, 47);
            button4.TabIndex = 13;
            button4.Text = "Вычислить по ф.т";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(357, 488);
            button5.Name = "button5";
            button5.Size = new Size(178, 47);
            button5.TabIndex = 14;
            button5.Text = "Вычислить по ф.С";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Laba11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 641);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(chart1);
            Name = "Laba11";
            Text = "Laba11";
            Load += Laba11_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}