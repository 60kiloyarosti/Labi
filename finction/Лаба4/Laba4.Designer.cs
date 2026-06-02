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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine5 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine6 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine7 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine8 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea3.AxisX.Interval = 5D;
            chartArea3.AxisX.Maximum = 50D;
            chartArea3.AxisX.Minimum = -50D;
            stripLine5.BorderColor = Color.Red;
            stripLine5.BorderWidth = 2;
            stripLine5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine5.Text = "Y";
            stripLine5.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea3.AxisX.StripLines.Add(stripLine5);
            chartArea3.AxisY.Interval = 1D;
            chartArea3.AxisY.Maximum = 10D;
            chartArea3.AxisY.Minimum = -10D;
            stripLine6.BorderColor = Color.Red;
            stripLine6.BorderWidth = 2;
            stripLine6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine6.Text = "X";
            chartArea3.AxisY.StripLines.Add(stripLine6);
            chartArea3.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(36, 24);
            chart1.Name = "chart1";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "y = x^3 - 3x^2 + x + 3 ";
            chart1.Series.Add(series4);
            chart1.Size = new Size(852, 376);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea4.AxisX.Interval = 0.5D;
            chartArea4.AxisX.Maximum = 7D;
            chartArea4.AxisX.Minimum = -7D;
            stripLine7.BorderColor = Color.Red;
            stripLine7.BorderWidth = 2;
            stripLine7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine7.Text = "Y";
            stripLine7.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea4.AxisX.StripLines.Add(stripLine7);
            chartArea4.AxisY.Interval = 1D;
            chartArea4.AxisY.Maximum = 6D;
            chartArea4.AxisY.Minimum = -6D;
            stripLine8.BorderColor = Color.Red;
            stripLine8.BorderWidth = 2;
            stripLine8.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine8.Text = "X";
            chartArea4.AxisY.StripLines.Add(stripLine8);
            chartArea4.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea4.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart2.Legends.Add(legend4);
            chart2.Location = new Point(36, 406);
            chart2.Name = "chart2";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "x^3 - 3x^2";
            series6.BorderColor = Color.Fuchsia;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "-x-3";
            chart2.Series.Add(series5);
            chart2.Series.Add(series6);
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