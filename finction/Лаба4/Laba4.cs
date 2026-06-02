using finction.Лаба3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finction.Лаба4
{
    public partial class Laba4 : Form
    {
        private double a = -6;
        private double b = 6;
        private double h = 0.1;
        private double x, y, y1, y2, y0, dify1, dify2;
        private double[] Points;
        public Laba4()
        {
            InitializeComponent();
        }

        private void Laba4_Load(object sender, EventArgs e)
        {
            x = a;
            y0 = 0;
            Points = new double[2];
            bool found = false;
            for (int i = 0; x <= b; i++)
            {
                x = Math.Round(x, 1);
                dataGridView1.Rows.Add();
                y = GetY(x);
                dify1 = GetDify1(x);
                dify2 = GetDify2(x);
                chart1.Series[0].Points.AddXY(x, y);
                y1 = GetY1(x);
                y2 = GetY2(x);
                chart2.Series[0].Points.AddXY(x, y1);
                chart2.Series[1].Points.AddXY(x, y2);
                dataGridView1.Rows[i].Cells[0].Value = x;
                dataGridView1.Rows[i].Cells[1].Value = y;
                dataGridView1.Rows[i].Cells[2].Value = y1;
                dataGridView1.Rows[i].Cells[3].Value = y2;
                dataGridView1.Rows[i].Cells[4].Value = dify1;
                dataGridView1.Rows[i].Cells[5].Value = dify2;

                if (y0 * y < 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    Points[0] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                    DataTransfer.m = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

                    dataGridView1.Rows[i - 1].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i - 1].DefaultCellStyle.BackColor = Color.Yellow;
                    Points[1] = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[0].Value);
                    DataTransfer.M = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[4].Value);

                    for (int j = 0; j < Points.Length && !found; j++)
                    {
                        if ((GetDify2(Points[j]) * GetY(Points[j])) > 0)
                        {
                            DataTransfer.a = Points[j];
                        }
                        else
                            DataTransfer.b = Points[j];
                    }
                    found = true;
                }

                y0 = y;
                x += h;
            }
            DataTransfer.F_a = GetY(DataTransfer.a);
            DataTransfer.F_b = GetY(DataTransfer.b);
            DataTransfer.F2_a = GetDify2(DataTransfer.a);
            DataTransfer.F2_b = GetDify2(DataTransfer.b);
            DataTransfer.F1_b = GetDify1(DataTransfer.b);
        }
        private double GetY(double x)
        {
            return Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + x + 3;
        }
        private double GetDify1(double x)
        {
            return 3 * Math.Pow(x, 2) - 6 * x + 1;
        }
        private double GetDify2(double x)
        {
            return dify2 = 6 * x - 6;
        }
        private double GetY1(double x)
        {
            return y1 = Math.Pow(x, 3) - (3 * Math.Pow(x, 2));
        }
        private double GetY2(double x)
        {
            return y2 = -x - 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grid4 grid4 = new Grid4();
            grid4.Show();
        }
    }
}
