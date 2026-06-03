namespace finction.Лаба4
{
    partial class Laba4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine9 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine10 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine11 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine12 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.AxisX.Interval = 5D;
            chartArea5.AxisX.Maximum = 50D;
            chartArea5.AxisX.Minimum = -50D;
            stripLine9.BorderColor = Color.Red;
            stripLine9.BorderWidth = 2;
            stripLine9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine9.Text = "Y";
            stripLine9.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea5.AxisX.StripLines.Add(stripLine9);
            chartArea5.AxisY.Interval = 1D;
            chartArea5.AxisY.Maximum = 10D;
            chartArea5.AxisY.Minimum = -10D;
            stripLine10.BorderColor = Color.Red;
            stripLine10.BorderWidth = 2;
            stripLine10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine10.Text = "X";
            chartArea5.AxisY.StripLines.Add(stripLine10);
            chartArea5.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea5.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            chart1.Legends.Add(legend5);
            chart1.Location = new Point(36, 24);
            chart1.Name = "chart1";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "y = x^3 - 3x^2 + x + 3 ";
            chart1.Series.Add(series7);
            chart1.Size = new Size(852, 376);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.AxisX.Interval = 0.5D;
            chartArea6.AxisX.Maximum = 7D;
            chartArea6.AxisX.Minimum = -7D;
            stripLine11.BorderColor = Color.Red;
            stripLine11.BorderWidth = 2;
            stripLine11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine11.Text = "Y";
            stripLine11.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea6.AxisX.StripLines.Add(stripLine11);
            chartArea6.AxisY.Interval = 1D;
            chartArea6.AxisY.Maximum = 6D;
            chartArea6.AxisY.Minimum = -6D;
            stripLine12.BorderColor = Color.Red;
            stripLine12.BorderWidth = 2;
            stripLine12.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine12.Text = "X";
            chartArea6.AxisY.StripLines.Add(stripLine12);
            chartArea6.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea6.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            chart2.Legends.Add(legend6);
            chart2.Location = new Point(36, 406);
            chart2.Name = "chart2";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "x^3 - 3x^2";
            series9.BorderColor = Color.Fuchsia;
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "-x-3";
            chart2.Series.Add(series8);
            chart2.Series.Add(series9);
            chart2.Size = new Size(852, 387);
            chart2.TabIndex = 5;
            chart2.Text = "chart2";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(894, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(666, 390);
            dataGridView1.TabIndex = 6;
            // 
            // Column1
            // 
            Column1.HeaderText = "X";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Y";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "F1";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "F2";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "F'";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "F''";
            Column6.Name = "Column6";
            // 
            // button1
            // 
            button1.Location = new Point(1158, 455);
            button1.Name = "button1";
            button1.Size = new Size(145, 46);
            button1.TabIndex = 7;
            button1.Text = "Далее";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Laba4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1611, 833);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Name = "Laba4";
            Text = "Laba4";
            Load += Laba4_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button button1;
    }
}