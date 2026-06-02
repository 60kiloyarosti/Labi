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
    public partial class Grid4 : Form
    {
        private double x;
        private double x0 = 0;
        private double F1_b = DataTransfer.F1_b;
        private double y = 0;
        private double h = 0;
        private int counter = 0;
        private double deltax;
        private const double EPSALANT = 0.0001;
        private double OtvetX;
        private double Xn_Xn_1;
        public Grid4()
        {
            InitializeComponent();
        }

        private void Grid4_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            dataGridView2.Rows[0].Cells[0].Value = DataTransfer.a;
            dataGridView2.Rows[0].Cells[1].Value = DataTransfer.b;
            dataGridView2.Rows[0].Cells[2].Value = DataTransfer.F_a;
            dataGridView2.Rows[0].Cells[3].Value = DataTransfer.F_b;
            dataGridView2.Rows[0].Cells[4].Value = DataTransfer.F2_a;
            dataGridView2.Rows[0].Cells[5].Value = DataTransfer.F2_b;
            dataGridView2.Rows[0].Cells[6].Value = DataTransfer.m;
            dataGridView2.Rows[0].Cells[7].Value = DataTransfer.M;
        }
        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("col_x", "x");
            dataGridView1.Columns.Add("col_phi", "y");
            dataGridView1.Columns.Add("col_d", "F'(x₀)");
            dataGridView1.Columns.Add("col_diff", "h = F(xₙ)/F'(x₀)");
            dataGridView1.Columns.Add("col_deltasx", "Δx = = x_n + 1 - x_n");
            dataGridView1.Columns.Add("col_stop", "Условие остановки итерации");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
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
            y = GetY(x);
            h = GetY(x) / F1_b;
            dataGridView1.Rows[0].Cells[0].Value = x;
            dataGridView1.Rows[0].Cells[1].Value = y;
            dataGridView1.Rows[0].Cells[2].Value = F1_b;
            dataGridView1.Rows[0].Cells[3].Value = h;
            x0 = x;

            for (int i = 1; counter < 1; i++)
            {
                dataGridView1.Rows.Add();
                x = x0 - (GetY(x0) / F1_b);
                y = GetY(x);
                h = Math.Abs(GetY(x) / F1_b);
                deltax = Math.Abs(x - x0);
                dataGridView1.Rows[i].Cells[0].Value = x;
                dataGridView1.Rows[i].Cells[1].Value = y;
                dataGridView1.Rows[i].Cells[2].Value = F1_b;
                dataGridView1.Rows[i].Cells[3].Value = h;
                dataGridView1.Rows[i].Cells[4].Value = deltax;

                if (deltax < EPSALANT)
                {
                    dataGridView1.Rows[i].Cells[5].Value = "Да";
                    counter++;
                    OtvetX = x;
                    Xn_Xn_1 = Math.Abs(x - x0);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "Нет";
                }
                x0 = x;
            }
        }
        private double GetY(double x)
        {
            return Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + x + 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double pogresh = (DataTransfer.M / (2 * DataTransfer.m)) * Math.Pow(Xn_Xn_1,2);
            SearchLowPogresh searchLow = new SearchLowPogresh(OtvetX,pogresh);
            searchLow.Search();
        }
    }
}
