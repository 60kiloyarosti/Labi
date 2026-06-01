using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finction.Лаба2
{
    public partial class Grid2 : Form
    {
        private double x0, x, f_x_0, x_x0, deltaI;
        private const double EPSALANT = 0.001;
        private int counterCondition = 0;
        SearchLowPogresh lowPogresh;
        public Grid2()
        {
            InitializeComponent();
        }

        private void Grid2_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
        }
        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("col_x", "xᵢ");
            dataGridView1.Columns.Add("col_phi", "φ(xᵢ₋₁)");
            dataGridView1.Columns.Add("col_diff", "|xᵢ - xᵢ₋₁|");
            dataGridView1.Columns.Add("col_delta", "Δξ = |ξ - xᵢ|");
            dataGridView1.Columns.Add("col_stop", "Условие остановки итерации");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {

                col.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 9);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Symbol", 10, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x0 = DataZnachenij.X0;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = x0.ToString();

            for (int i = 1; counterCondition <= 3; i++)
            {
                dataGridView1.Rows.Add();
                x = x0 - (((Math.Log10(x0) - (5.0 / (2 * x0 + 1))) / DataZnachenij.M));
                f_x_0 = x;
                x_x0 = Math.Abs(x - x0);
                deltaI = (DataZnachenij.q / (1 - DataZnachenij.q)) * x_x0;
                if (x_x0 < EPSALANT * ((1 - DataZnachenij.q) / DataZnachenij.q))
                {
                    dataGridView1.Rows[i].Cells[4].Value = "Да";
                    counterCondition++;
                    if (counterCondition == 1)
                    {
                        lowPogresh = new SearchLowPogresh(x, deltaI);
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = "Нет";
                }
                dataGridView1.Rows[i].Cells[0].Value = x.ToString("F6");
                dataGridView1.Rows[i].Cells[1].Value = f_x_0.ToString("F6");
                dataGridView1.Rows[i].Cells[2].Value = x_x0.ToString("F8");
                dataGridView1.Rows[i].Cells[3].Value = deltaI.ToString("F8");
                x0 = x;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lowPogresh.Search();
        }
    }
}
