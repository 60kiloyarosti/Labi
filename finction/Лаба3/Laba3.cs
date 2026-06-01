using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finction.Лаба2;

namespace finction.Лаба3
{
    public partial class Laba3 : Form
    {
        private double a, b, h;
        private double PointA, PointB;
        private double[] PointsAB;
        private double x, y, dify, dify2;
        private double y0;
        public Laba3()
        {
            InitializeComponent();
        }

        private void Laba3_Load(object sender, EventArgs e)
        {
            bool found = false;
            PointsAB = new double[2];
            a = 2.1;
            b = 50;
            h = 0.1;
            x = a;
            int i = 0;
            while (x <= b)
            {
                x = Math.Round(x, 1);
                y = Math.Log10(x - 2) + (3 / ((2 * x) + 7));
                dify = (1 / ((x - 2) * Math.Log(10))) - (6 / Math.Pow(2 * x + 7, 2));
                dify2 = (24.0 / Math.Pow(2 * x + 7, 3)) - (1 / (Math.Pow(x - 2, 2) * Math.Log(10)));
                chart1.Series[0].Points.AddXY(x, y);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = x.ToString();
                dataGridView1.Rows[i].Cells[1].Value = y.ToString();
                dataGridView1.Rows[i].Cells[4].Value = dify.ToString();
                dataGridView1.Rows[i].Cells[5].Value = dify2.ToString();
                if (y0 * y < 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    PointsAB[0] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                    DataTransfer.m = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    

                    dataGridView1.Rows[i - 1].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i - 1].DefaultCellStyle.BackColor = Color.Yellow;
                    PointsAB[1] = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[0].Value);
                    DataTransfer.M = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[4].Value);


                    for (int j = 0; j < PointsAB.Length && !found; j++)
                    {
                        if ((GetHieghtF(PointsAB[j]) * GetHieght2F(PointsAB[j])) > 0)
                        {
                            PointA = PointsAB[j];
                        }
                        else
                        {
                            PointB = PointsAB[j];
                        }
                    }
                    found = true;
                    DataTransfer.a = PointA;
                    DataTransfer.b = PointB;
                    labelA.Text = $"a = {PointA} - неподвижный конец";
                    labelB.Text = $"b = {PointB} - начальное приближение";
                    DataTransfer.F_a = GetHieghtF(DataTransfer.a);
                }
                y0 = y;
                x += h;
                i++;
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            a = 2.1;
            b = 7;
            h = 0.1;
            int i = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = -(3 / ((2 * x) + 7));
                chart2.Series[1].Points.AddXY(x, y);
                dataGridView1.Rows[i].Cells[3].Value = y.ToString();
                i++;
            }
            int j = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = Math.Log10(x - 2);
                chart2.Series[0].Points.AddXY(x, y);

                dataGridView1.Rows[j].Cells[2].Value = y.ToString();
                j++;
            }
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            Grid3 grid3 = new Grid3();
            grid3.Show();
        }

        private double GetHieght2F(double x)
        {
            return (24.0 / Math.Pow(2 * x + 7, 3)) - (1 / (Math.Pow(x - 2, 2) * Math.Log(10)));
        }
        private double GetHieghtF(double x)
        {
            return Math.Log10(x - 2) + (3 / ((2 * x) + 7)); 
        }
    }
}
