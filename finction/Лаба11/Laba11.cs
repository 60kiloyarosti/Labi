using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace finction.Лаба11
{
    public partial class Laba11 : Form
    {
        private double okryga = 0.3;
        private double a = 0.1;
        private double b = 0.485;
        double original_a;
        double original_b;
        private double hChart = 0.01;
        private double x, y, y1, y2, y0, dify1, dify2;
        private double[] Points;
        private double Epsalnt = 0.001;
        private double h;
        private int n;
        private double[] Ms;
        private double M;
        private double x0;
        private double f_delenie;

        public enum RectangleType
        {
            Left,
            Right,
            Middle,
            Trapezoid
        }
        public Laba11()
        {

            InitializeComponent();
        }

        private void Laba11_Load(object sender, EventArgs e)
        {
            original_a = a;
            original_b = b;
            dataGridView2.Rows[0].Cells[0].Value = a;
            dataGridView2.Rows[0].Cells[1].Value = b;
            chart1.Series[1].Points.AddXY(a, 0);
            chart1.Series[1].Points.AddXY(a, 0.2);
            chart1.Series[2].Points.AddXY(b, 0);
            chart1.Series[2].Points.AddXY(b, 0.2);
            int pointsCount = Convert.ToInt32((b - a) / hChart) + 1;
            Ms = new double[pointsCount];
            a -= okryga;
            b += okryga;
            x = a;
            y0 = 0;
            int MsIndex = 0;
            for (int i = 0; x <= b; i++)
            {
                y = GetY(x);
                dify1 = GetDify1(x);
                chart1.Series[0].Points.AddXY(x, y);
                if (x >= original_a && x <= original_b && MsIndex < Ms.Length)
                {
                    Ms[MsIndex] = dify1;
                    MsIndex++;
                }

                y0 = y;
                x += hChart;
            }
            M = Ms.Max(x => Math.Abs(x));

        }
        private double GetY(double x)
        {
            return Math.Cos((0.07 * 13) + (0.5 * x)) / (0.4 + Math.Sqrt(Math.Pow(x, 2) + 13));
        }
        private double GetDify1(double x)
        {
            return (-0.5 * Math.Sin((0.07 * 13) + (0.5 * x)) * (0.4 + Math.Sqrt(Math.Pow(x, 2) + 13)) -
                (x * Math.Cos((0.07 * 13) +
                (0.5 * x)) / Math.Sqrt(Math.Pow(x, 2) + 13))) / Math.Pow(0.4 + Math.Sqrt(Math.Pow(x, 2) + 13), 2);
        }
        private double GetDify2(double x)
        {
            return (-0.25 * Math.Cos(0.91 + 0.5 * x) * (0.4 + Math.Sqrt(x * x + 13)) -
                Math.Cos(0.91 + 0.5 * x) * (13 / Math.Pow(x * x + 13, 1.5)) -
                2 * (x / Math.Sqrt(x * x + 13)) * (-0.5 * Math.Sin(0.91 + 0.5 * x) * (0.4 + Math.Sqrt(x * x + 13))
                - Math.Cos(0.91 + 0.5 * x) * (x / Math.Sqrt(x * x + 13)))) / Math.Pow(0.4 + Math.Sqrt(x * x + 13), 3);
        }
        private double GetDify4(double x)
        {
            double s = Math.Sin(0.91 + 0.5 * x); double c = Math.Cos(0.91 + 0.5 * x);
            double r = Math.Sqrt(x * x + 13); double v = 0.4 + r;
            double v1 = x / r; double v2 = 13 / (r * r * r); double v3 = -39 * x / (r * r * r * r * r);
            double v4 = (156 * x * x - 507) / Math.Pow(x * x + 13, 3.5);
            return 0.0625 * c / v - 4 * 0.125 * s * v1 / (v * v) - 6 * (-0.25 * c) * v2 / (v * v) +
                12 * (-0.25 * c) * v1 * v1 / (v * v * v) - 4 * (-0.5 * s) * v3 / (v * v) +
                24 * (-0.5 * s) * v1 * v2 / (v * v * v) - 24 * (-0.5 * s) * v1 * v1 * v1 / (v * v * v * v) -
                c * v4 / (v * v) + 8 * c * v1 * v3 / (v * v * v) + 6 * c * v2 * v2 / (v * v * v) - 36 * c * v1 * v1 * v2 / (v * v * v * v) +
                24 * c * v1 * v1 * v1 * v1 / (v * v * v * v * v);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Sumleft = 0;
            double pogreshLeft = 0;

            dataGridView1.Rows.Clear();

            n = (int)Math.Ceiling((Math.Pow(original_b - original_a, 2) * M) / (2 * Epsalnt));
            h = (original_b - original_a) / n;

            dataGridView2.Rows[0].Cells[2].Value = n;
            dataGridView2.Rows[0].Cells[3].Value = Math.Round(h, 6);

            x = original_a;
            x0 = x;

            for (int i = 0; i <= n; i++)
            {
                dataGridView1.Rows.Add();
                x = original_a + i * h;
                y = GetY(x);
                f_delenie = (x + x0) / 2;

                dataGridView1.Rows[i].Cells[0].Value = Math.Round(x, 6);
                dataGridView1.Rows[i].Cells[1].Value = y;
                dataGridView1.Rows[i].Cells[2].Value = (i == 0) ? 0 : GetY(f_delenie);
                dataGridView1.Rows[i].Cells[3].Value = GetDify1(x);
                dataGridView1.Rows[i].Cells[4].Value = GetDify2(x);
                dataGridView1.Rows[i].Cells[5].Value = GetDify4(x);

                // Для левых прямоугольников суммируем только для i от 0 до n-1
                if (i < n)
                {
                    Sumleft += y;
                }

                x0 = x;
            }

            double S_left = h * Sumleft;
            pogreshLeft = (Math.Pow(original_b - original_a, 2) * M) / (2 * n);

            DrawFigures(original_a, original_b, n, h, RectangleType.Left);

            SearchLowPogresh searchLowPogresh = new SearchLowPogresh(S_left, pogreshLeft);
            searchLowPogresh.Search();
        }
        private void DrawFigures(double a, double b, int n, double h, RectangleType type)
        {
            // Очищаем старые фигуры
            ClearAllFigures();

            string seriesName = type.ToString() + "Figures";

            // Создаём или очищаем серию
            if (chart1.Series.IndexOf(seriesName) == -1)
            {
                chart1.Series.Add(seriesName);
            }
            else
            {
                chart1.Series[seriesName].Points.Clear();
            }

            chart1.Series[seriesName].ChartType = SeriesChartType.Line;
            chart1.Series[seriesName].BorderWidth = 2;

            // Выбор цвета
            switch (type)
            {
                case RectangleType.Left:
                    chart1.Series[seriesName].Color = Color.FromArgb(150, Color.Black);
                    break;
                case RectangleType.Right:
                    chart1.Series[seriesName].Color = Color.FromArgb(150, Color.Blue);
                    break;
                case RectangleType.Middle:
                    chart1.Series[seriesName].Color = Color.FromArgb(150, Color.Green);
                    break;
                case RectangleType.Trapezoid:
                    chart1.Series[seriesName].Color = Color.FromArgb(150, Color.Orange);
                    break;
            }

            double x_left = a;
            for (int i = 0; i < n; i++)
            {
                double x_right = x_left + h;
                double y_left = GetY(x_left);
                double y_right = GetY(x_right);
                double y_height;

                switch (type)
                {
                    case RectangleType.Left:
                        y_height = y_left;
                        // Левая сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, 0);
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        // Верхняя сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        // Правая сторона
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, 0);
                        break;

                    case RectangleType.Right:
                        y_height = y_right;
                        // Левая сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, 0);
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        // Верхняя сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        // Правая сторона
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, 0);
                        break;

                    case RectangleType.Middle:
                        double x_mid = (x_left + x_right) / 2;
                        y_height = GetY(x_mid);
                        // Левая сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, 0);
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        // Верхняя сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        // Правая сторона
                        chart1.Series[seriesName].Points.AddXY(x_right, y_height);
                        chart1.Series[seriesName].Points.AddXY(x_right, 0);
                        break;

                    case RectangleType.Trapezoid:
                        // Трапеция: наклонная верхняя сторона
                        // Левая сторона
                        chart1.Series[seriesName].Points.AddXY(x_left, 0);
                        chart1.Series[seriesName].Points.AddXY(x_left, y_left);
                        // Верхняя наклонная сторона (соединяет левую и правую высоты)
                        chart1.Series[seriesName].Points.AddXY(x_right, y_right);
                        // Правая сторона
                        chart1.Series[seriesName].Points.AddXY(x_right, 0);
                        break;
                }

                // Разделитель между фигурами
                if (i < n - 1)
                    chart1.Series[seriesName].Points.AddXY(double.NaN, 0);

                x_left = x_right;
            }

            chart1.Refresh();
        }

        // Метод для очистки всех фигур
        private void ClearAllFigures()
        {
            string[] figureSeries = { "LeftFigures", "RightFigures", "MiddleFigures", "TrapezoidFigures" };

            foreach (string seriesName in figureSeries)
            {
                if (chart1.Series.IndexOf(seriesName) != -1)
                {
                    chart1.Series[seriesName].Points.Clear();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            n = (int)Math.Ceiling((Math.Pow(original_b - original_a, 2) * M) / (2 * Epsalnt));
            h = (original_b - original_a) / n;

            dataGridView2.Rows[0].Cells[2].Value = n;
            dataGridView2.Rows[0].Cells[3].Value = Math.Round(h, 6);

            double SumRight = 0;

            // Заполнение таблицы
            for (int i = 0; i <= n; i++)
            {
                double current_x = original_a + i * h;
                double current_y = GetY(current_x);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Math.Round(current_x, 6);
                dataGridView1.Rows[i].Cells[1].Value = current_y;
                dataGridView1.Rows[i].Cells[3].Value = GetDify1(current_x);
                dataGridView1.Rows[i].Cells[4].Value = GetDify2(current_x);
                dataGridView1.Rows[i].Cells[5].Value = GetDify4(current_x);

                // Средняя точка для i >= 1
                if (i >= 1)
                {
                    double prev_x = original_a + (i - 1) * h;
                    double mid_x = (prev_x + current_x) / 2;
                    dataGridView1.Rows[i].Cells[2].Value = GetY(mid_x);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }
            }

            // Вычисление суммы для правых прямоугольников (от i=1 до n)
            for (int i = 1; i <= n; i++)
            {
                double xi = original_a + i * h;
                SumRight += GetY(xi);
            }

            double S_right = h * SumRight;
            double pogreshRight = (Math.Pow(original_b - original_a, 2) * M) / (2 * n);

            DrawFigures(original_a, original_b, n, h, RectangleType.Right);

            SearchLowPogresh searchLowPogresh = new SearchLowPogresh(S_right, pogreshRight);
            searchLowPogresh.Search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            double M2 = FindMaxSecondDerivative();

            if (Epsalnt <= 0 || M2 <= 0)
            {
                MessageBox.Show("Ошибка: Epsalnt или M2 равны нулю");
                return;
            }

            n = (int)Math.Ceiling(Math.Sqrt(Math.Pow(original_b - original_a, 3) * M2 / (36 * Epsalnt)));
            if (n < 1) n = 1;
            h = (original_b - original_a) / n;

            dataGridView2.Rows[0].Cells[2].Value = n;
            dataGridView2.Rows[0].Cells[3].Value = Math.Round(h, 6);

            double SumMid = 0;

            for (int i = 0; i <= n; i++)
            {
                double current_x = original_a + i * h;
                double current_y = GetY(current_x);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Math.Round(current_x, 6);
                dataGridView1.Rows[i].Cells[1].Value = current_y;
                dataGridView1.Rows[i].Cells[3].Value = GetDify1(current_x);
                dataGridView1.Rows[i].Cells[4].Value = GetDify2(current_x);
                dataGridView1.Rows[i].Cells[5].Value = GetDify4(current_x);

                if (i >= 1)
                {
                    double prev_x = original_a + (i - 1) * h;
                    double mid_x = (prev_x + current_x) / 2;
                    double mid_y = GetY(mid_x);
                    dataGridView1.Rows[i].Cells[2].Value = mid_y;
                    SumMid += mid_y;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }
            }

            double S_mid = h * SumMid;
            double pogreshMid = (Math.Pow(original_b - original_a, 3) * M2) / (36 * n * n);

            DrawFigures(original_a, original_b, n, h, RectangleType.Middle);

            SearchLowPogresh searchLowPogresh = new SearchLowPogresh(S_mid, pogreshMid);
            searchLowPogresh.Search();
        }

        // Метод для нахождения максимума второй производной
        private double FindMaxSecondDerivative()
        {
            double maxValue = 0;
            int steps = 1000;
            double step = (original_b - original_a) / steps;

            for (int i = 0; i <= steps; i++)
            {
                double x = original_a + i * step;
                double val = Math.Abs(GetDify2(x));
                if (val > maxValue)
                    maxValue = val;
            }
            return maxValue;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            // Находим максимум второй производной M2 = max|f''(x)|
            double M2 = FindMaxSecondDerivative();

            if (Epsalnt <= 0 || M2 <= 0)
            {
                MessageBox.Show("Ошибка: Epsalnt или M2 равны нулю");
                return;
            }

            // Формула для трапеций: R ≤ (b-a)^3 * M2 / (12 * n^2) ≤ ε
            // n ≥ sqrt( (b-a)^3 * M2 / (12 * ε) )
            n = (int)Math.Ceiling(Math.Sqrt(Math.Pow(original_b - original_a, 3) * M2 / (12 * Epsalnt)));
            if (n < 1) n = 1;
            h = (original_b - original_a) / n;

            dataGridView2.Rows[0].Cells[2].Value = n;
            dataGridView2.Rows[0].Cells[3].Value = Math.Round(h, 6);

            double SumTrap = 0;

            // Заполнение таблицы и вычисление суммы для метода трапеций
            for (int i = 0; i <= n; i++)
            {
                double current_x = original_a + i * h;
                double current_y = GetY(current_x);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Math.Round(current_x, 6);
                dataGridView1.Rows[i].Cells[1].Value = current_y;
                dataGridView1.Rows[i].Cells[3].Value = GetDify1(current_x);
                dataGridView1.Rows[i].Cells[4].Value = GetDify2(current_x);
                dataGridView1.Rows[i].Cells[5].Value = GetDify4(current_x);

                // Средняя точка для i >= 1
                if (i >= 1)
                {
                    double prev_x = original_a + (i - 1) * h;
                    double mid_x = (prev_x + current_x) / 2;
                    dataGridView1.Rows[i].Cells[2].Value = GetY(mid_x);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }

                // Для метода трапеций суммируем все f(x_i), кроме первой и последней
                if (i > 0 && i < n)
                {
                    SumTrap += current_y;
                }
            }

            // Добавляем полусумму крайних точек
            double f_a = GetY(original_a);
            double f_b = GetY(original_b);
            SumTrap += (f_a + f_b) / 2;

            double S_trap = h * SumTrap;
            double pogreshTrap = (Math.Pow(original_b - original_a, 3) * M2) / (12 * n * n);

            // Рисуем трапеции (можно использовать отдельный метод или общий)
            DrawFigures(original_a, original_b, n, h, RectangleType.Trapezoid);

            SearchLowPogresh searchLowPogresh = new SearchLowPogresh(S_trap, pogreshTrap);
            searchLowPogresh.Search();
        }

        private void button5_Click(object sender, EventArgs e)  // Симпсон
        {
            dataGridView1.Rows.Clear();

            // Находим максимум четвёртой производной M4 = max|f''''(x)|
            double M4 = FindMaxFourthDerivative();

            if (Epsalnt <= 0 || M4 <= 0)
            {
                MessageBox.Show("Ошибка: Epsalnt или M4 равны нулю");
                return;
            }

            // Формула для Симпсона: R ≤ (b-a)^5 * M4 / (2880 * n^4) ≤ ε
            // n ≥ ( (b-a)^5 * M4 / (2880 * ε) )^(1/4)
            double required_n = Math.Pow(Math.Pow(original_b - original_a, 5) * M4 / (2880 * Epsalnt), 0.25);
            n = (int)Math.Ceiling(required_n);

            // n должно быть чётным
            if (n % 2 != 0) n++;
            if (n < 2) n = 2;

            h = (original_b - original_a) / n;

            dataGridView2.Rows[0].Cells[2].Value = n;
            dataGridView2.Rows[0].Cells[3].Value = Math.Round(h, 6);

            double sumOdd = 0;  // Сумма для нечётных индексов (4 * f(x_{2i-1}))
            double sumEven = 0; // Сумма для чётных индексов (2 * f(x_{2i}))

            // Заполнение таблицы
            for (int i = 0; i <= n; i++)
            {
                double current_x = original_a + i * h;
                double current_y = GetY(current_x);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Math.Round(current_x, 6);
                dataGridView1.Rows[i].Cells[1].Value = current_y;
                dataGridView1.Rows[i].Cells[3].Value = GetDify1(current_x);
                dataGridView1.Rows[i].Cells[4].Value = GetDify2(current_x);
                dataGridView1.Rows[i].Cells[5].Value = GetDify4(current_x);

                // Средняя точка для i >= 1
                if (i >= 1)
                {
                    double prev_x = original_a + (i - 1) * h;
                    double mid_x = (prev_x + current_x) / 2;
                    dataGridView1.Rows[i].Cells[2].Value = GetY(mid_x);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }

                // Для метода Симпсона
                if (i > 0 && i < n)
                {
                    if (i % 2 == 1) // Нечётные индексы (1, 3, 5, ...)
                        sumOdd += current_y;
                    else // Чётные индексы (2, 4, 6, ...)
                        sumEven += current_y;
                }
            }

            // Формула Симпсона
            double f_a = GetY(original_a);
            double f_b = GetY(original_b);
            double S_simpson = (h / 3) * (f_a + f_b + 4 * sumOdd + 2 * sumEven);

            // Погрешность метода Симпсона
            double pogreshSimpson = (Math.Pow(original_b - original_a, 5) * M4) / (2880 * Math.Pow(n, 4));

            // Рисуем параболы (Симпсон)
            DrawSimpson(original_a, original_b, n, h);

            SearchLowPogresh searchLowPogresh = new SearchLowPogresh(S_simpson, pogreshSimpson);
            searchLowPogresh.Search();
        }

        // Метод для нахождения максимума четвёртой производной
        private double FindMaxFourthDerivative()
        {
            double maxValue = 0;
            int steps = 1000;
            double step = (original_b - original_a) / steps;

            for (int i = 0; i <= steps; i++)
            {
                double x = original_a + i * step;
                double val = Math.Abs(GetDify4(x));
                if (val > maxValue)
                    maxValue = val;
            }
            return maxValue;
        }

        // Метод для рисования парабол (Симпсона) - показывает квадратичные сегменты
        private void DrawSimpson(double a, double b, int n, double h)
        {
            ClearAllFigures();

            string seriesName = "SimpsonFigures";

            if (chart1.Series.IndexOf(seriesName) == -1)
            {
                chart1.Series.Add(seriesName);
            }
            else
            {
                chart1.Series[seriesName].Points.Clear();
            }

            chart1.Series[seriesName].ChartType = SeriesChartType.Line;
            chart1.Series[seriesName].Color = Color.FromArgb(150, Color.Purple);
            chart1.Series[seriesName].BorderWidth = 2;

            // Для метода Симпсона рисуем параболические сегменты через каждые 2 отрезка
            for (int i = 0; i < n; i += 2)
            {
                double x0 = a + i * h;
                double x1 = a + (i + 1) * h;
                double x2 = a + (i + 2) * h;

                double y0 = GetY(x0);
                double y1 = GetY(x1);
                double y2 = GetY(x2);

                // Рисуем параболу через три точки
                int segments = 20;
                for (int j = 0; j <= segments; j++)
                {
                    double t = (double)j / segments;
                    double x = x0 + t * 2 * h;

                    // Интерполяция по параболе (Лагранж для точек x0, x1, x2)
                    double y = y0 * ((x - x1) * (x - x2)) / ((x0 - x1) * (x0 - x2)) +
                               y1 * ((x - x0) * (x - x2)) / ((x1 - x0) * (x1 - x2)) +
                               y2 * ((x - x0) * (x - x1)) / ((x2 - x0) * (x2 - x1));

                    chart1.Series[seriesName].Points.AddXY(x, y);
                }

                // Разделитель между сегментами
                if (i < n - 2)
                    chart1.Series[seriesName].Points.AddXY(double.NaN, 0);
            }

            chart1.Refresh();
        }
    }
}
