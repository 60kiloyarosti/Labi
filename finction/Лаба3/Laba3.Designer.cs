namespace finction.Лаба3
{
    partial class Laba3
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            Nextbtn = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            labelA = new Label();
            labelB = new Label();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // chart2
            // 
            chartArea1.AxisX.Interval = 0.5D;
            chartArea1.AxisX.Maximum = 7D;
            chartArea1.AxisX.Minimum = -7D;
            stripLine1.BorderColor = Color.Red;
            stripLine1.BorderWidth = 2;
            stripLine1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine1.Text = "Y";
            stripLine1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisY.Interval = 0.1D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = -1D;
            stripLine2.BorderColor = Color.Red;
            stripLine2.BorderWidth = 2;
            stripLine2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine2.Text = "X";
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart2.Legends.Add(legend1);
            chart2.Location = new Point(12, 415);
            chart2.Name = "chart2";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "lg(x - 2)";
            series2.BorderColor = Color.Fuchsia;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "-3/2x + 7";
            chart2.Series.Add(series1);
            chart2.Series.Add(series2);
            chart2.Size = new Size(852, 387);
            chart2.TabIndex = 4;
            chart2.Text = "chart2";
            chart2.Click += chart2_Click;
            // 
            // chart1
            // 
            chartArea2.AxisX.Interval = 5D;
            chartArea2.AxisX.Maximum = 50D;
            chartArea2.AxisX.Minimum = -50D;
            stripLine3.BorderColor = Color.Red;
            stripLine3.BorderWidth = 2;
            stripLine3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine3.Text = "Y";
            stripLine3.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea2.AxisX.StripLines.Add(stripLine3);
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.Maximum = 10D;
            chartArea2.AxisY.Minimum = -10D;
            stripLine4.BorderColor = Color.Red;
            stripLine4.BorderWidth = 2;
            stripLine4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine4.Text = "X";
            chartArea2.AxisY.StripLines.Add(stripLine4);
            chartArea2.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(12, 33);
            chart1.Name = "chart1";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "y = lg(x-2) - 3\\2x +7";
            chart1.Series.Add(series3);
            chart1.Size = new Size(852, 376);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // Nextbtn
            // 
            Nextbtn.Location = new Point(948, 428);
            Nextbtn.Name = "Nextbtn";
            Nextbtn.Size = new Size(153, 43);
            Nextbtn.TabIndex = 6;
            Nextbtn.Text = "Далее";
            Nextbtn.UseVisualStyleBackColor = true;
            Nextbtn.Click += Nextbtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(837, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(666, 390);
            dataGridView1.TabIndex = 5;
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
            // labelA
            // 
            labelA.AutoSize = true;
            labelA.Location = new Point(1250, 441);
            labelA.Name = "labelA";
            labelA.Size = new Size(24, 15);
            labelA.TabIndex = 7;
            labelA.Text = "a =";
            // 
            // labelB
            // 
            labelB.AutoSize = true;
            labelB.Location = new Point(1250, 473);
            labelB.Name = "labelB";
            labelB.Size = new Size(25, 15);
            labelB.TabIndex = 8;
            labelB.Text = "b =";
            // 
            // Laba3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1515, 837);
            Controls.Add(labelB);
            Controls.Add(labelA);
            Controls.Add(Nextbtn);
            Controls.Add(dataGridView1);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Name = "Laba3";
            Text = "Laba3";
            Load += Laba3_Load;
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button Nextbtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Label labelA;
        private Label labelB;
    }
}