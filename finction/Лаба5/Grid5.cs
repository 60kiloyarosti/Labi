using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finction.Лаба5
{
    public partial class Grid5 : Form
    {
        private double x = 0;
        private double x0 = 0;
        private double x_ = 0;
        private double x0_ = 0;
        private double Fx = 0;
        private double h1 = 0;
        private double Fx_ = 0;
        private double h2 = 0;
        private double difFx_ = 0;
        private double x__x = 0;
        private double ksi = 0;
        private double deltaksi = 0;
        private int counter = 0;
        private const double EPSALANT = 0.0001;
        private double OtvetX = 0;
        private double pogresh = 0;
        public Grid5()
        {
            InitializeComponent();
        }

        private void Grid5_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            SetupDataGrid2ViewColumns();
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
            dataGridView1.Columns.Add("col_xn", "xₙ");
            dataGridView1.Columns.Add("col_xn_bar", "x̄ₙ");
            dataGridView1.Columns.Add("col_Fxn", "F(xₙ)");
            dataGridView1.Columns.Add("col_h1", "h₁");
            dataGridView1.Columns.Add("col_Fxn_bar", "F(x̄ₙ)");
            dataGridView1.Columns.Add("col_h2", "h₂");
            dataGridView1.Columns.Add("col_if", "Условие остановки итерации");
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
        private void SetupDataGrid2ViewColumns()
        {
            dataGridView3.Columns.Clear();
            dataGridView3.Columns.Add("col_Fprime", "F'(x̄ₙ)");
            dataGridView3.Columns.Add("col_diff", "x̄ₙ - xₙ");
            dataGridView3.Columns.Add("col_xi_tilde", "ξ̃ₙ");
            dataGridView3.Columns.Add("col_delta", "Δξ̃ₙ");
            dataGridView3.Columns[0].Width = 200;
            dataGridView3.Columns[1].Width = 200;
            dataGridView3.Columns[2].Width = 200;
            dataGridView3.Columns[3].Width = 200;

            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {

                col.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 9);
            }
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Symbol", 10, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = DataTransfer.a;
            x_ = DataTransfer.b;
            Fx = GetY(x);
            Fx_ = GetY(x_);
            difFx_ = GetDify1(x_);
            h1 = (Fx / (Fx_ - Fx)) * (x_ - x);
            h2 = Fx_ / difFx_;

            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = x;
            dataGridView1.Rows[0].Cells[1].Value = x_;
            dataGridView1.Rows[0].Cells[2].Value = Fx;
            dataGridView1.Rows[0].Cells[3].Value = h1;
            dataGridView1.Rows[0].Cells[4].Value = Fx_;
            dataGridView1.Rows[0].Cells[5].Value = h2;

            x__x = Math.Abs(x_ - x);
            ksi = (x + x_) / 2;
            if (x__x < EPSALANT)
            {
                dataGridView1.Rows[0].Cells[6].Value = "Да";
                OtvetX = ksi;
                counter++;
            }
            else
            {
                dataGridView1.Rows[0].Cells[6].Value = "Нет";
            }

            dataGridView3.Rows.Add();
            deltaksi = Math.Abs(x - x_) / 2;
            dataGridView3.Rows[0].Cells[0].Value = difFx_;
            dataGridView3.Rows[0].Cells[1].Value = x__x;
            dataGridView3.Rows[0].Cells[2].Value = ksi;
            dataGridView3.Rows[0].Cells[3].Value = deltaksi;

            x0 = x;
            x0_ = x_;

            for (int i = 1; counter < 1; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView3.Rows.Add();
                h1 = (Fx / (Fx_ - Fx)) * (x_ - x);
                h2 = Fx_ / difFx_;
                x = x0 - h1;
                x_ = x0_ - h2;
                Fx = GetY(x);
                Fx_ = GetY(x_);
                difFx_ = GetDify1(x_);
                dataGridView1.Rows[i].Cells[0].Value = x;
                dataGridView1.Rows[i].Cells[1].Value = x_;
                dataGridView1.Rows[i].Cells[2].Value = Fx;
                dataGridView1.Rows[i].Cells[3].Value = h1;
                dataGridView1.Rows[i].Cells[4].Value = Fx_;
                dataGridView1.Rows[i].Cells[5].Value = h2;
                x__x = Math.Abs(x_ - x);
                ksi = (x + x_) / 2;
                deltaksi = Math.Abs(x - x_) / 2;
                dataGridView3.Rows[i].Cells[0].Value = difFx_;
                dataGridView3.Rows[i].Cells[1].Value = x__x;
                dataGridView3.Rows[i].Cells[2].Value = ksi;
                dataGridView3.Rows[i].Cells[3].Value = deltaksi;
                if (x__x < EPSALANT)
                {
                    dataGridView1.Rows[i].Cells[6].Value = "Да";
                    OtvetX = ksi;
                    pogresh = deltaksi;
                    counter++;

                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = "Нет";
                }

                x0 = x;
                x0_ = x_;
            }
        }
        private double GetY(double x)
        {
            return Math.Pow(2, x) - 3 * Math.Pow(x, 2) + 2;
        }
        private double GetDify1(double x)
        {
            return Math.Pow(2, x) * Math.Log(2) - 6 * x;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchLowPogresh lowPogresh = new SearchLowPogresh(OtvetX,pogresh);
            lowPogresh.Search();
        }
    }
}
