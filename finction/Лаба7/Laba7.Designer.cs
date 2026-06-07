namespace finction.Лаба7
{
    partial class Laba7
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            textBoxKsi = new TextBox();
            labelksi = new Label();
            button1 = new Button();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridViewLagrange = new DataGridView();
            dataGridViewDiff = new DataGridView();
            dataGridViewUniform = new DataGridView();
            dataGridViewProduct = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLagrange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUniform).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.Location = new Point(68, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(243, 329);
            dataGridView1.TabIndex = 0;
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
            // textBoxKsi
            // 
            textBoxKsi.Location = new Point(376, 25);
            textBoxKsi.Name = "textBoxKsi";
            textBoxKsi.Size = new Size(100, 23);
            textBoxKsi.TabIndex = 1;
            // 
            // labelksi
            // 
            labelksi.AutoSize = true;
            labelksi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelksi.Location = new Point(336, 25);
            labelksi.Name = "labelksi";
            labelksi.Size = new Size(34, 21);
            labelksi.TabIndex = 2;
            labelksi.Text = "E =";
            // 
            // button1
            // 
            button1.Location = new Point(352, 64);
            button1.Name = "button1";
            button1.Size = new Size(124, 41);
            button1.TabIndex = 3;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chart2
            // 
            chartArea1.AxisX.Interval = 0.2D;
            chartArea1.AxisX.Maximum = 3D;
            chartArea1.AxisX.Minimum = -3D;
            stripLine1.BorderColor = Color.Red;
            stripLine1.BorderWidth = 2;
            stripLine1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine1.Text = "Y";
            stripLine1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisY.Interval = 0.5D;
            chartArea1.AxisY.Maximum = 5D;
            chartArea1.AxisY.Minimum = -5D;
            stripLine2.BorderColor = Color.Red;
            stripLine2.BorderWidth = 2;
            stripLine2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stripLine2.Text = "X";
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.TitleAlignment = StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea1);
            chart2.Location = new Point(614, -2);
            chart2.Name = "chart2";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "y = 2 ^x -3x^2 + 2";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = Color.Crimson;
            series2.Name = "Series2";
            chart2.Series.Add(series1);
            chart2.Series.Add(series2);
            chart2.Size = new Size(885, 377);
            chart2.TabIndex = 6;
            chart2.Text = "chart2";
            // 
            // dataGridViewLagrange
            // 
            dataGridViewLagrange.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLagrange.Location = new Point(12, 381);
            dataGridViewLagrange.Name = "dataGridViewLagrange";
            dataGridViewLagrange.Size = new Size(693, 396);
            dataGridViewLagrange.TabIndex = 7;
            // 
            // dataGridViewDiff
            // 
            dataGridViewDiff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiff.Location = new Point(736, 481);
            dataGridViewDiff.Name = "dataGridViewDiff";
            dataGridViewDiff.Size = new Size(754, 183);
            dataGridViewDiff.TabIndex = 8;
            // 
            // dataGridViewUniform
            // 
            dataGridViewUniform.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUniform.Location = new Point(736, 381);
            dataGridViewUniform.Name = "dataGridViewUniform";
            dataGridViewUniform.Size = new Size(754, 85);
            dataGridViewUniform.TabIndex = 9;
            // 
            // dataGridViewProduct
            // 
            dataGridViewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduct.Location = new Point(736, 679);
            dataGridViewProduct.Name = "dataGridViewProduct";
            dataGridViewProduct.Size = new Size(754, 98);
            dataGridViewProduct.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(352, 121);
            button2.Name = "button2";
            button2.Size = new Size(256, 41);
            button2.TabIndex = 11;
            button2.Text = "Определить число верных знаков";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Laba7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1502, 805);
            Controls.Add(button2);
            Controls.Add(dataGridViewProduct);
            Controls.Add(dataGridViewUniform);
            Controls.Add(dataGridViewDiff);
            Controls.Add(dataGridViewLagrange);
            Controls.Add(chart2);
            Controls.Add(button1);
            Controls.Add(labelksi);
            Controls.Add(textBoxKsi);
            Controls.Add(dataGridView1);
            Name = "Laba7";
            Text = "Laba7";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLagrange).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiff).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUniform).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private TextBox textBoxKsi;
        private Label labelksi;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private DataGridView dataGridViewLagrange;
        private DataGridView dataGridViewDiff;
        private DataGridView dataGridViewUniform;
        private DataGridView dataGridViewProduct;
        private Button button2;
    }
}