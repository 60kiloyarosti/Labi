using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finction.Лаба3
{
    public partial class Grid3 : Form
    {
        public double x0;
        public double x, deltax1, deltax2;
        public double h0;
        public double h, deltah;
        public double y;
        private int counter = 0;
        private const double EPSLANT = 0.0001;
        private double otvetX = 0;
        private double xn_xn_1 = 0;
        public Grid3()
        {
            InitializeComponent();
        }

        private void Grid3_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            dataGridView2.Rows[0].Cells[0].Value = DataTransfer.a;
            dataGridView2.Rows[0].Cells[1].Value = DataTransfer.b;
            dataGridView2.Rows[0].Cells[2].Value = DataTransfer.F_a;
            dataGridView2.Rows[0].Cells[3].Value = DataTransfer.m;
            dataGridView2.Rows[0].Cells[4].Value = DataTransfer.M;
        }
        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("col_x", "x");
            dataGridView1.Columns.Add("col_phi", "y");
            dataGridView1.Columns.Add("col_diff", "Δx = x_n - a");
            dataGridView1.Columns.Add("col_delta", "h_n");
            dataGridView1.Columns.Add("col_deltas", "Δh");
            dataGridView1.Columns.Add("col_deltasx", "Δx");
            dataGridView1.Columns.Add("col_stop", "Условие остановки итерации");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {

                col.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 9);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Symbol", 10, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            x = DataTransfer.b;
            y = Math.Log10(x - 2) + (3 / ((2 * x) + 7));
            deltax1 = x - DataTransfer.a;
            h = (DataTransfer.F_a / (GetF(x) - DataTransfer.F_a)) * (x - DataTransfer.a);
            dataGridView1.Rows[0].Cells[0].Value = x;
            dataGridView1.Rows[0].Cells[1].Value = y;
            dataGridView1.Rows[0].Cells[2].Value = deltax1;
            dataGridView1.Rows[0].Cells[3].Value = h;
            x0 = x;
            h0 = h;

            for (int i = 1; counter < 1 && i < 100; i++)
            {
                dataGridView1.Rows.Add();
                x = x0 - (((DataTransfer.a - x0) * GetF(x0) / (DataTransfer.F_a - GetF(x0))));
                y = Math.Log10(x - 2) + (3 / ((2 * x) + 7));
                deltax1 = x - DataTransfer.a;
                h = (DataTransfer.F_a / (GetF(x) - DataTransfer.F_a)) * (x - DataTransfer.a);
                deltah = Math.Abs(h - h0);
                deltax2 = Math.Abs(x - x0);

                dataGridView1.Rows[i].Cells[0].Value = x;
                dataGridView1.Rows[i].Cells[1].Value = y;
                dataGridView1.Rows[i].Cells[2].Value = deltax1;
                dataGridView1.Rows[i].Cells[3].Value = h;
                dataGridView1.Rows[i].Cells[4].Value = deltah;
                dataGridView1.Rows[i].Cells[5].Value = deltax2;

                if (deltax2 <= EPSLANT)
                {
                    dataGridView1.Rows[i].Cells[6].Value = "Да";
                    counter++;
                    otvetX = x;
                    xn_xn_1 = Math.Abs(x - x0);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = "Нет";
                }

                x0 = x;
                h0 = h;
            }

        }

        private double GetF(double x)
        {
            return Math.Log10(x - 2) + (3 / ((2 * x) + 7));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double pogresh = ((DataTransfer.M - DataTransfer.m) / DataTransfer.m) * xn_xn_1;
            SearchLowPogresh lowPogresh = new SearchLowPogresh(otvetX, pogresh);
            lowPogresh.Search();
        }
    }
}
