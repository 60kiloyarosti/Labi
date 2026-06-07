using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace finction.Лаба7
{

    public partial class Laba7 : Form
    {
        private double[] Xs;
        private double[] Ys;
        private double x;
        private double Ksi;
        private double[] lxi;
        private double[] uniformX;
        private double[] uniformY;
        private double[,] diffTable;
        private double deltaX;
        SearchLowPogresh searchLowPogresh;
        public Laba7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Ksi = Convert.ToDouble(textBoxKsi.Text);
            var (xs, ys) = InitilizeArray();
            Xs = xs;
            Ys = ys;
            lxi = new double[xs.Length];
            FillLagrangeTable(Ksi);
            double result = GetZnachenjeFx(Ksi);
            double error = EstimateError(Ksi);
            BuildChart();
            searchLowPogresh = new SearchLowPogresh(result, error);
            MessageBox.Show($"Методом Лагранжа получаем значение в точке y({Ksi}) = {result:F6}\n" +
                           $"Оценка погрешности: ±{error:F8}\n" +
                           $"Результат с погрешностью: {result:F6} ± {error:F8}");

            

        }
        private (double[] x, double[] y) InitilizeArray()
        {
            double[] x = new double[dataGridView1.RowCount - 1];
            double[] y = new double[dataGridView1.RowCount - 1];
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null &&
                    dataGridView1.Rows[i].Cells[1].Value != null &&
                    dataGridView1.Rows[i].Cells[0].Value.ToString() != "" &&
                    dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                {
                    x[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                    y[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                }
            }
            return (x, y);
        }
        private double GetZnachenjeFx(double x)
        {
            double Lx = 0;
            for (int i = 0; i < Xs.Length; i++)
            {
                lxi[i] = 1.0;
                for (int j = 0; j < Xs.Length; j++)
                {
                    if (j != i)
                    {
                        lxi[i] *= (x - Xs[j]) / (Xs[i] - Xs[j]);
                    }
                }
                Lx += lxi[i] * Ys[i];
            }
            return Lx;

        }
        /// <summary>
        /// Оценка погрешности интерполяции методом конечных разностей
        /// </summary>
        /// <summary>
        /// Оценка погрешности интерполяции методом конечных разностей
        /// </summary>
        /// <summary>
        /// Оценка погрешности интерполяции методом конечных разностей
        /// </summary>
        private double EstimateError(double xi)
        {
            // Создаём равномерные узлы
            CreateUniformNodes();

            // Находим значения в равномерных узлах через интерполяцию Лагранжа
            FillUniformValues();

            // Заполняем таблицу конечных разностей
            FillDifferenceTable();

            // Вычисляем 
            double xn = uniformX[uniformX.Length - 1];
            double t = (xi - xn) / deltaX;

            // Заполняем таблицу произведения (t + k)
            FillProductTable(t);

            // Степень полинома 
            int n = Xs.Length - 1;

            // последняя конечная разность 
            
            double deltaPowerY = Math.Abs(diffTable[0, n]);  

            // n! (факториал)
            double factorial = Factorial(n); 

            // Вычисляем ∏(t + k) для k = 0..n
            double product = 1.0;
            for (int k = 0; k <= n; k++)
            {
                product *= (t + k);
            }

            // Формула
            double error = (deltaPowerY / factorial) * Math.Abs(product);

            return error;
        }
        /// <summary>
        /// Создание равномерных узлов
        /// </summary>
        private void CreateUniformNodes()
        {
            int n = Xs.Length;
            uniformX = new double[n];

            double x0 = Xs[0];
            double xn = Xs[n - 1];
            deltaX = (xn - x0) / (n - 1);

            for (int i = 0; i < n; i++)
            {
                uniformX[i] = x0 + i * deltaX;
            }
        }

        /// <summary>
        /// Нахождение значений в равномерных узлах через интерполяцию Лагранжа
        /// </summary>
        private void FillUniformValues()
        {
            uniformY = new double[uniformX.Length];
            for (int i = 0; i < uniformX.Length; i++)
            {
                uniformY[i] = GetZnachenjeFx(uniformX[i]);
            }

            // Заполняем таблицу 1: Равномерные узлы
            FillUniformNodesTable();
        }

        /// <summary>
        /// Таблица 1: Равномерные узлы
        /// </summary>
        private void FillUniformNodesTable()
        {
            dataGridViewUniform.Rows.Clear();
            dataGridViewUniform.Columns.Clear();

            dataGridViewUniform.Columns.Add("Index", "i");
            dataGridViewUniform.Columns.Add("X", "x̄ᵢ");
            dataGridViewUniform.Columns.Add("Y", "ȳᵢ = F(x̄ᵢ)");

            for (int i = 0; i < uniformX.Length; i++)
            {
                dataGridViewUniform.Rows.Add(i, uniformX[i].ToString("F6"), uniformY[i].ToString("F6"));
            }

            dataGridViewUniform.AutoResizeColumns();
        }

        /// <summary>
        /// Таблица конечных разностей
        /// </summary>
        private void FillDifferenceTable()
        {
            int n = uniformY.Length;
            diffTable = new double[n, n];

            // Заполняем нулевой столбец значениями y
            for (int i = 0; i < n; i++)
            {
                diffTable[i, 0] = uniformY[i];
            }

            // Вычисляем разности
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    diffTable[i, j] = diffTable[i + 1, j - 1] - diffTable[i, j - 1];
                }
            }

            // Заполняем таблицу 2: Конечные разности
            FillDifferenceGridView();
        }

        /// <summary>
        /// Таблица 2: Конечные разности
        /// </summary>
        private void FillDifferenceGridView()
        {
            dataGridViewDiff.Rows.Clear();
            dataGridViewDiff.Columns.Clear();

            dataGridViewDiff.Columns.Add("i", "i");
            dataGridViewDiff.Columns.Add("yi", "ȳᵢ");

            for (int j = 1; j <= diffTable.GetLength(1) - 1; j++)
            {
                dataGridViewDiff.Columns.Add($"Δ{j}", $"Δ^{j}");
            }

            for (int i = 0; i < uniformY.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewDiff);

                row.Cells[0].Value = i;
                row.Cells[1].Value = uniformY[i].ToString("F6");

                for (int j = 1; j < uniformY.Length - i; j++)
                {
                    row.Cells[1 + j].Value = diffTable[i, j].ToString("F6");
                }

                dataGridViewDiff.Rows.Add(row);
            }


            dataGridViewDiff.AutoResizeColumns();
        }

        /// <summary>
        /// Таблица произведения (t + k)
        /// </summary>
        private void FillProductTable(double t)
        {
            dataGridViewProduct.Rows.Clear();
            dataGridViewProduct.Columns.Clear();

            dataGridViewProduct.Columns.Add("k", "k");
            dataGridViewProduct.Columns.Add("t_k", "t + k");
            dataGridViewProduct.Columns.Add("Value", "Значение");
            dataGridViewProduct.Columns.Add("AbsValue", "|t + k|");

            double product = 1.0;

            for (int k = 0; k <= Xs.Length - 1; k++)
            {
                double value = t + k;
                double absValue = Math.Abs(value);
                product *= value;

                dataGridViewProduct.Rows.Add(k, $"t + {k}", value.ToString("F6"), absValue.ToString("F6"));
            }

            // Добавляем итоговую строку с произведением
            DataGridViewRow productRow = new DataGridViewRow();
            productRow.CreateCells(dataGridViewProduct);
            productRow.Cells[0].Value = "∏";
            productRow.Cells[1].Value = "Произведение:";
            productRow.Cells[2].Value = product.ToString("F8");
            productRow.DefaultCellStyle.BackColor = Color.LightBlue;
            productRow.DefaultCellStyle.Font = new Font(dataGridViewProduct.Font, FontStyle.Bold);
            dataGridViewProduct.Rows.Add(productRow);

            dataGridViewProduct.AutoResizeColumns();
        }

        /// <summary>
        /// Вычисление факториала
        /// </summary>
        private double Factorial(int n)
        {
            double result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }
        private void BuildChart()
        {
            double minX = Xs.Min();
            double maxX = Xs.Max();
            double minY = Ys.Min();
            double maxY = Ys.Max();
            double paddingX = (maxX - minX) * 0.2;
            double paddingY = (maxY - minY) * 0.2;
            double a = minX - paddingX;
            double b = maxX + paddingX;
            chart2.ChartAreas[0].AxisX.Minimum = a;
            chart2.ChartAreas[0].AxisX.Maximum = b;
            chart2.ChartAreas[0].AxisY.Minimum = minY - paddingY;
            chart2.ChartAreas[0].AxisY.Maximum = maxY + paddingY;
            double h = 0.05;
            double x = 0;
            double y = 0;
            x = a;
            while (x <= b)
            {
                y = GetZnachenjeFx(x);
                chart2.Series[0].Points.AddXY(x, y);
                x += h;
            }
            for (int i = 0; i < Xs.Length; i++)
            {
                chart2.Series[1].Points.AddXY(Xs[i], Ys[i]);
            }


        }
        private void FillLagrangeTable(double xi)
        {
            int n = Xs.Length;


            dataGridViewLagrange.Rows.Clear();
            dataGridViewLagrange.Columns.Clear();


            dataGridViewLagrange.Columns.Add("i", "i");
            dataGridViewLagrange.Columns.Add("xi", "xᵢ");
            dataGridViewLagrange.Columns.Add("yi", "yᵢ");


            for (int j = 0; j < n; j++)
            {
                dataGridViewLagrange.Columns.Add($"P_{j}", $"P({xi:F4}) при j={j}");
            }

            dataGridViewLagrange.Columns.Add("Product", "∏ Pᵢ,ⱼ(ξ)");
            dataGridViewLagrange.Columns.Add("Result", $"yᵢ * ∏ Pᵢ,ⱼ(ξ)");

            double total = 0;


            for (int i = 0; i < n; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewLagrange);

                row.Cells[0].Value = i;
                row.Cells[1].Value = Xs[i];
                row.Cells[2].Value = Ys[i];

                double product = 1.0;


                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        double p = (xi - Xs[j]) / (Xs[i] - Xs[j]);
                        product *= p;
                        row.Cells[3 + j].Value = p.ToString("F6");
                    }
                    else
                    {
                        row.Cells[3 + j].Value = "—";
                    }
                }

                double weighted = Ys[i] * product;
                total += weighted;

                row.Cells[3 + n].Value = product.ToString("F6");
                row.Cells[4 + n].Value = weighted.ToString("F6");

                dataGridViewLagrange.Rows.Add(row);
            }

            // Добавляем итоговую строку
            DataGridViewRow totalRow = new DataGridViewRow();
            totalRow.CreateCells(dataGridViewLagrange);
            totalRow.Cells[0].Value = "ИТОГО:";
            totalRow.Cells[4 + n].Value = total.ToString("F6");
            totalRow.DefaultCellStyle.BackColor = Color.LightYellow;
            totalRow.DefaultCellStyle.Font = new Font(dataGridViewLagrange.Font, FontStyle.Bold);
            dataGridViewLagrange.Rows.Add(totalRow);

            // Автоматически подгоняем ширину столбцов
            dataGridViewLagrange.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchLowPogresh.Search();
        }
    }
}
