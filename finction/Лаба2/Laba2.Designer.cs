namespace finction
{
    partial class Laba2
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            Nextbtn = new Button();
            mlabel = new Label();
            labelM = new Label();
            labelq = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.Maximum = 7D;
            chartArea3.AxisX.Minimum = -7D;
            stripLine5.BorderColor = Color.Red;
            stripLine5.BorderWidth = 2;
            stripLine5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine5.Text = "Y";
            stripLine5.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea3.AxisX.StripLines.Add(stripLine5);
            chartArea3.AxisY.Interval = 1D;
            chartArea3.AxisY.Maximum = 7D;
            chartArea3.AxisY.Minimum = -7D;
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
            chart1.Location = new Point(44, 3);
            chart1.Name = "chart1";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "y = lg(x) - 5\\2x +1";
            chart1.Series.Add(series4);
            chart1.Size = new Size(529, 281);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(273, 327);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(585, 246);
            dataGridView1.TabIndex = 1;
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
            // chart2
            // 
            chartArea4.AxisX.Interval = 1D;
            chartArea4.AxisX.Maximum = 7D;
            chartArea4.AxisX.Minimum = -7D;
            stripLine7.BorderColor = Color.Red;
            stripLine7.BorderWidth = 2;
            stripLine7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine7.Text = "Y";
            stripLine7.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea4.AxisX.StripLines.Add(stripLine7);
            chartArea4.AxisY.Interval = 1D;
            chartArea4.AxisY.Maximum = 7D;
            chartArea4.AxisY.Minimum = -7D;
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
            chart2.Location = new Point(579, 3);
            chart2.Name = "chart2";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "lg(x)";
            series6.BorderColor = Color.Fuchsia;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "5/2x + 1";
            chart2.Series.Add(series5);
            chart2.Series.Add(series6);
            chart2.Size = new Size(509, 281);
            chart2.TabIndex = 2;
            chart2.Text = "chart2";
            chart2.Click += chart2_Click;
            // 
            // Nextbtn
            // 
            Nextbtn.Location = new Point(44, 327);
            Nextbtn.Name = "Nextbtn";
            Nextbtn.Size = new Size(153, 43);
            Nextbtn.TabIndex = 3;
            Nextbtn.Text = "Далее";
            Nextbtn.UseVisualStyleBackColor = true;
            Nextbtn.Click += Nextbtn_Click;
            // 
            // mlabel
            // 
            mlabel.AutoSize = true;
            mlabel.Location = new Point(948, 341);
            mlabel.Name = "mlabel";
            mlabel.Size = new Size(29, 15);
            mlabel.TabIndex = 4;
            mlabel.Text = "m =";
            // 
            // labelM
            // 
            labelM.AutoSize = true;
            labelM.Location = new Point(948, 378);
            labelM.Name = "labelM";
            labelM.Size = new Size(29, 15);
            labelM.TabIndex = 5;
            labelM.Text = "M =";
            // 
            // labelq
            // 
            labelq.AutoSize = true;
            labelq.Location = new Point(948, 414);
            labelq.Name = "labelq";
            labelq.Size = new Size(25, 15);
            labelq.TabIndex = 6;
            labelq.Text = "q =";
            // 
            // Laba2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 630);
            Controls.Add(labelq);
            Controls.Add(labelM);
            Controls.Add(mlabel);
            Controls.Add(Nextbtn);
            Controls.Add(chart2);
            Controls.Add(dataGridView1);
            Controls.Add(chart1);
            Name = "Laba2";
            Text = "Laba2";
            Load += Laba2_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button Nextbtn;
        private Label mlabel;
        private Label labelM;
        private Label labelq;
    }
}