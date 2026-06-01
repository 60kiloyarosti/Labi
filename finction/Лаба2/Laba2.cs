using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finction.Лаба2;
using SySharp;


namespace finction
{
    public partial class Laba2 : Form
    {
        private double a, b, h;
        private double x, y, dify;
        private double y0;
        public Laba2()
        {
            InitializeComponent();

        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Laba2_Load(object sender, EventArgs e)
        {
            a = 0.1;
            b = 6;
            h = 0.1;
            x = a;
            int i = 0;
            while (x <= b)
            {
                x = Math.Round(x, 1);
                y = Math.Log10(x) - (5 / ((2 * x) + 1));
                dify = (1 / (x * Math.Log(10))) + (10 / Math.Pow(2 * x + 1, 2));
                chart1.Series[0].Points.AddXY(x, y);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = x.ToString();
                dataGridView1.Rows[i].Cells[1].Value = y.ToString();
                dataGridView1.Rows[i].Cells[4].Value = dify.ToString();
                if (y0 * y < 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    DataZnachenij.m = dify;
                    

                    dataGridView1.Rows[i - 1].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i - 1].DefaultCellStyle.BackColor = Color.Yellow;

                    dataGridView1.Rows[i - 2].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i - 2].DefaultCellStyle.BackColor = Color.Yellow;
                    DataZnachenij.M  = Convert.ToDouble(dataGridView1.Rows[i - 2].Cells[4].Value);
                    DataZnachenij.X0 = Convert.ToDouble(dataGridView1.Rows[i - 2].Cells[0].Value);
                }
                y0 = y;
                x += h;
                i++;
            }
            DataZnachenij.q = Math.Abs(1 - (DataZnachenij.m / DataZnachenij.M));
            mlabel.Text = $"m = {DataZnachenij.m}";
            labelM.Text = $"M = {DataZnachenij.M}";
            labelq.Text = $"q = {DataZnachenij.q}";
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            a = 0.1;
            b = 6;
            h = 0.1;
            int i = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = 5 / ((2 * x) + 1);
                chart2.Series[1].Points.AddXY(x, y);
                dataGridView1.Rows[i].Cells[3].Value = y.ToString();
                i++;
            }
            int j = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = Math.Log10(x);
                chart2.Series[0].Points.AddXY(x, y);

                dataGridView1.Rows[j].Cells[2].Value = y.ToString();
                j++;
            }
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            Grid2 grid2 = new Grid2();
            grid2.Show();
        }

    }
}
