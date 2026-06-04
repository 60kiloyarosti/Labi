using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finction.Лаба6
{
    public partial class Laba6 : Form
    {
        private double[,] arraySystemKoifi;
        private TextBox[,] koifi;
        private Label[,] iksi;

        // Сохраняем результаты вычислений для отрисовки таблицы
        private List<IterationData> iterationResults = new List<IterationData>();
        private List<IterationData> zeidelResults = new List<IterationData>(); // Для метода Зейделя

        public Laba6()
        {
            InitializeComponent();

            // Создаем кнопку для отрисовки таблицы (метод простой итерации)
            Button buttonDrawTable = new Button();
            buttonDrawTable.Text = "Отрисовать таблицу (Итерации)";
            buttonDrawTable.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 50);
            buttonDrawTable.Size = new System.Drawing.Size(180, 30);
            buttonDrawTable.Click += ButtonDrawTable_Click;
            this.Controls.Add(buttonDrawTable);

            // Создаем кнопку для метода Зейделя
            Button buttonZeidel = new Button();
            buttonZeidel.Text = "Метод Зейделя";
            buttonZeidel.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 100);
            buttonZeidel.Size = new System.Drawing.Size(180, 30);
            buttonZeidel.Click += ButtonZeidel_Click;
            this.Controls.Add(buttonZeidel);

            // Создаем кнопку для отрисовки таблицы Зейделя
            Button buttonDrawZeidelTable = new Button();
            buttonDrawZeidelTable.Text = "Отрисовать таблицу (Зейдель)";
            buttonDrawZeidelTable.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 150);
            buttonDrawZeidelTable.Size = new System.Drawing.Size(180, 30);
            buttonDrawZeidelTable.Click += ButtonDrawZeidelTable_Click;
            this.Controls.Add(buttonDrawZeidelTable);
        }

        // Класс для хранения данных одной итерации
        public class IterationData
        {
            public int Iteration { get; set; }
            public double[] XValues { get; set; }
            public double[] Diffs { get; set; }
            public bool Converged { get; set; }
        }

        // Класс SearchLowPogresh (ваш класс)
        public class SearchLowPogresh
        {
            private double value;
            private double diff;
            private double pogreshnost;

            public SearchLowPogresh(double value, double diff)
            {
                this.value = value;
                this.diff = diff;
            }

            public void Search()
            {
                // Относительная погрешность в процентах
                if (Math.Abs(value) > 1e-10)
                {
                    pogreshnost = (diff / Math.Abs(value)) * 100;
                }
                else
                {
                    pogreshnost = diff * 100;
                }

                // Вывод в консоль для отладки
                System.Diagnostics.Debug.WriteLine($"Значение: {value}, Погрешность: {pogreshnost:F4}%");
            }

            public double GetPogreshnost()
            {
                return pogreshnost;
            }

            public double GetAbsolutePogreshnost()
            {
                return diff;
            }
        }

        private void CountKornej_TextChanged(object sender, EventArgs e)
        {
            // Очищаем старые элементы
            if (koifi != null)
            {
                foreach (var tb in koifi)
                    if (tb != null) this.Controls.Remove(tb);
            }
            if (iksi != null)
            {
                foreach (var lbl in iksi)
                    if (lbl != null) this.Controls.Remove(lbl);
            }

            arraySystemKoifi = new double[Convert.ToInt32(CountKornej.Text), Convert.ToInt32(CountKornej.Text) + 1];
            koifi = new TextBox[Convert.ToInt32(CountKornej.Text), Convert.ToInt32(CountKornej.Text) + 1];
            iksi = new Label[Convert.ToInt32(CountKornej.Text), Convert.ToInt32(CountKornej.Text) + 1];

            for (int i = 0; i < arraySystemKoifi.GetLength(0); i++)
            {
                for (int j = 0; j < arraySystemKoifi.GetLength(1); j++)
                {
                    koifi[i, j] = new TextBox();
                    koifi[i, j].Name = $"a{i + 1}{j + 1}";
                    koifi[i, j].Location = new System.Drawing.Point(100 + j * 100, 100 + i * 30);
                    koifi[i, j].Width = 60;
                    this.Controls.Add(koifi[i, j]);

                    if (j < arraySystemKoifi.GetLength(1) - 1)
                    {
                        iksi[i, j] = new Label();
                        iksi[i, j].Text = $"x{j + 1}";
                        iksi[i, j].Location = new System.Drawing.Point(koifi[i, j].Location.X + 65, koifi[i, j].Location.Y + 5);
                        iksi[i, j].AutoSize = true;
                        this.Controls.Add(iksi[i, j]);
                    }
                }

                Label equalLabel = new Label();
                equalLabel.Text = "=";
                equalLabel.Location = new System.Drawing.Point(
                    koifi[i, arraySystemKoifi.GetLength(1) - 2].Location.X + 90,
                    koifi[i, arraySystemKoifi.GetLength(1) - 2].Location.Y + 5
                );
                equalLabel.AutoSize = true;
                this.Controls.Add(equalLabel);
            }

            MessageBox.Show("Введите данные системы!!!");
        }

        // МЕТОД ПРОСТОЙ ИТЕРАЦИИ
        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем старые результаты
            iterationResults.Clear();

            int counTrueIF = 0;
            int n = Convert.ToInt32(CountKornej.Text);

            double[,] ABSarraySystemKoifi = new double[n, n + 1];
            double[] sumArray = new double[n];
            double[] DiagArray = new double[n];
            double[] DiagArrayABS = new double[n];
            double[] SvobodnijChlen = new double[n];
            double[,] KofiBezSvobodnijChlen = new double[n, n];

            // Чтение данных
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    double value = Convert.ToDouble(koifi[i, j].Text);
                    arraySystemKoifi[i, j] = value;
                    ABSarraySystemKoifi[i, j] = Math.Abs(value);

                    if (j == n)
                        SvobodnijChlen[i] = value;
                    else
                        KofiBezSvobodnijChlen[i, j] = value;
                }
            }

            // Проверка диагонального преобладания
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                        sumArray[i] += ABSarraySystemKoifi[i, j];
                    else
                    {
                        DiagArrayABS[i] = ABSarraySystemKoifi[i, j];
                        DiagArray[i] = arraySystemKoifi[i, j];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (DiagArrayABS[i] > sumArray[i])
                    counTrueIF++;
            }

            if (counTrueIF == n)
                MessageBox.Show("Условие выполнено!");
            else
                MessageBox.Show("Условие не выполнено!");

            double[] Xs = new double[n];
            double[] Xs0 = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (DiagArrayABS[i] == 0)
                {
                    MessageBox.Show($"Ошибка: Диагональный элемент [{i},{i}] равен 0!");
                    return;
                }
                Xs[i] = SvobodnijChlen[i] / DiagArray[i];
            }

            // Сохраняем начальное приближение
            IterationData initialData = new IterationData();
            initialData.Iteration = 0;
            initialData.XValues = new double[n];
            initialData.Diffs = new double[n];
            Array.Copy(Xs, initialData.XValues, n);
            for (int i = 0; i < n; i++)
                initialData.Diffs[i] = -1;
            initialData.Converged = false;
            iterationResults.Add(initialData);

            Array.Copy(Xs, Xs0, n);

            double epsilon = 0.5 * Math.Pow(10, -3);
            int maxIterations = 100;
            int iteration = 1;
            bool converged = false;
            double[] diffs = null;

            while (!converged && iteration <= maxIterations)
            {
                for (int k = 0; k < n; k++)
                    Xs0[k] = Xs[k];

                for (int k = 0; k < n; k++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != k)
                            sum += KofiBezSvobodnijChlen[k, j] * Xs0[j];
                    }
                    Xs[k] = (SvobodnijChlen[k] - sum) / KofiBezSvobodnijChlen[k, k];
                }

                double maxDiff = 0;
                diffs = new double[n];

                for (int k = 0; k < n; k++)
                {
                    diffs[k] = Math.Abs(Xs[k] - Xs0[k]);
                    if (diffs[k] > maxDiff)
                        maxDiff = diffs[k];
                }

                if (maxDiff < epsilon)
                    converged = true;

                IterationData data = new IterationData();
                data.Iteration = iteration;
                data.XValues = new double[n];
                data.Diffs = new double[n];
                Array.Copy(Xs, data.XValues, n);
                Array.Copy(diffs, data.Diffs, n);
                data.Converged = converged;
                iterationResults.Add(data);

                iteration++;
            }

            if (converged)
            {
                string result = $"Решение найдено за {iteration - 1} итераций:\n\n";
                for (int k = 0; k < n; k++)
                {
                    result += $"x{k + 1} = {Xs[k]:F6}\n";
                    SearchLowPogresh searchLow = new SearchLowPogresh(Xs[k], diffs[k]);
                    searchLow.Search();
                }
                MessageBox.Show(result, "Результат (Метод простой итерации)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Метод не сошелся за {maxIterations} итераций!",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DrawTable();
        }

        // МЕТОД ЗЕЙДЕЛЯ
        private void ButtonZeidel_Click(object sender, EventArgs e)
        {
            zeidelResults.Clear();

            int n = Convert.ToInt32(CountKornej.Text);
            double[,] KofiBezSvobodnijChlen = new double[n, n];
            double[] SvobodnijChlen = new double[n];
            double[] DiagArray = new double[n];

            // Чтение данных
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    double value = Convert.ToDouble(koifi[i, j].Text);
                    if (j == n)
                        SvobodnijChlen[i] = value;
                    else
                        KofiBezSvobodnijChlen[i, j] = value;
                }
                DiagArray[i] = KofiBezSvobodnijChlen[i, i];
                if (DiagArray[i] == 0)
                {
                    MessageBox.Show($"Ошибка: Диагональный элемент [{i},{i}] равен 0!");
                    return;
                }
            }

            // Начальное приближение
            double[] Xs = new double[n];
            double[] XsPrev = new double[n];
            for (int i = 0; i < n; i++)
            {
                Xs[i] = SvobodnijChlen[i] / DiagArray[i];
                XsPrev[i] = 0;
            }

            // Сохраняем начальное приближение
            IterationData initialData = new IterationData();
            initialData.Iteration = 0;
            initialData.XValues = new double[n];
            initialData.Diffs = new double[n];
            Array.Copy(Xs, initialData.XValues, n);
            for (int i = 0; i < n; i++)
                initialData.Diffs[i] = -1;
            initialData.Converged = false;
            zeidelResults.Add(initialData);

            double epsilon = 0.5 * Math.Pow(10, -3);
            int maxIterations = 100;
            int iteration = 1;
            bool converged = false;
            double[] diffs = null;

            while (!converged && iteration <= maxIterations)
            {
                // Сохраняем предыдущие значения
                for (int k = 0; k < n; k++)
                    XsPrev[k] = Xs[k];

                // Метод Зейделя - используем уже обновленные значения
                for (int k = 0; k < n; k++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != k)
                        {
                            sum += KofiBezSvobodnijChlen[k, j] * Xs[j]; // Используем Xs (уже обновленные)
                        }
                    }
                    Xs[k] = (SvobodnijChlen[k] - sum) / KofiBezSvobodnijChlen[k, k];
                }

                // Вычисляем разницы
                double maxDiff = 0;
                diffs = new double[n];
                for (int k = 0; k < n; k++)
                {
                    diffs[k] = Math.Abs(Xs[k] - XsPrev[k]);
                    if (diffs[k] > maxDiff)
                        maxDiff = diffs[k];
                }

                if (maxDiff < epsilon)
                    converged = true;

                // Сохраняем данные итерации
                IterationData data = new IterationData();
                data.Iteration = iteration;
                data.XValues = new double[n];
                data.Diffs = new double[n];
                Array.Copy(Xs, data.XValues, n);
                Array.Copy(diffs, data.Diffs, n);
                data.Converged = converged;
                zeidelResults.Add(data);

                iteration++;
            }

            if (converged)
            {
                string result = $"Решение найдено за {iteration - 1} итераций (метод Зейделя):\n\n";

                for (int k = 0; k < n; k++)
                {
                    result += $"x{k + 1} = {Xs[k]:F6}\n";
                    // Ваш класс SearchLowPogresh
                    SearchLowPogresh searchLow = new SearchLowPogresh(Xs[k], diffs[k]);
                    searchLow.Search();

                }
                MessageBox.Show(result, "Результат (Метод Зейделя)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Метод Зейделя не сошелся за {maxIterations} итераций!",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DrawZeidelTable();
        }

        // Отрисовка таблицы для метода простой итерации
        private void ButtonDrawTable_Click(object sender, EventArgs e)
        {
            DrawTable();
        }

        // Отрисовка таблицы для метода Зейделя
        private void ButtonDrawZeidelTable_Click(object sender, EventArgs e)
        {
            DrawZeidelTable();
        }

        private void DrawTable()
        {
            if (iterationResults.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения. Сначала выполните вычисления методом простой итерации!",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            int n = iterationResults[0].XValues.Length;

            dataGridView1.Columns.Add("Iteration", "k");
            for (int i = 0; i < n; i++)
                dataGridView1.Columns.Add($"x{i}", $"x{i + 1}");
            for (int i = 0; i < n; i++)
                dataGridView1.Columns.Add($"dif{i}", $"Δx{i + 1}");
            dataGridView1.Columns.Add("Stop", "Условие остановки итераций");

            foreach (var data in iterationResults)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = data.Iteration;

                for (int i = 0; i < n; i++)
                    dataGridView1.Rows[rowIndex].Cells[1 + i].Value = data.XValues[i].ToString("F6");

                for (int i = 0; i < n; i++)
                {
                    if (data.Diffs[i] >= 0)
                        dataGridView1.Rows[rowIndex].Cells[n + 1 + i].Value = data.Diffs[i].ToString("E6");
                    else
                        dataGridView1.Rows[rowIndex].Cells[n + 1 + i].Value = "-";
                }

                if (data.Iteration == 0)
                    dataGridView1.Rows[rowIndex].Cells[2 * n + 1].Value = "-";
                else
                    dataGridView1.Rows[rowIndex].Cells[2 * n + 1].Value = data.Converged ? "Да" : "Нет";
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

            MessageBox.Show($"Таблица отрисована! Всего строк: {dataGridView1.Rows.Count} (Метод простой итерации)",
                            "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DrawZeidelTable()
        {
            if (zeidelResults.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения. Сначала выполните вычисления методом Зейделя!",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            int n = zeidelResults[0].XValues.Length;

            dataGridView1.Columns.Add("Iteration", "k");
            for (int i = 0; i < n; i++)
                dataGridView1.Columns.Add($"x{i}", $"x{i + 1}");
            for (int i = 0; i < n; i++)
                dataGridView1.Columns.Add($"dif{i}", $"Δx{i + 1}");
            dataGridView1.Columns.Add("Stop", "Условие остановки итераций");

            foreach (var data in zeidelResults)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = data.Iteration;

                for (int i = 0; i < n; i++)
                    dataGridView1.Rows[rowIndex].Cells[1 + i].Value = data.XValues[i].ToString("F6");

                for (int i = 0; i < n; i++)
                {
                    if (data.Diffs[i] >= 0)
                        dataGridView1.Rows[rowIndex].Cells[n + 1 + i].Value = data.Diffs[i].ToString("E6");
                    else
                        dataGridView1.Rows[rowIndex].Cells[n + 1 + i].Value = "-";
                }

                if (data.Iteration == 0)
                    dataGridView1.Rows[rowIndex].Cells[2 * n + 1].Value = "-";
                else
                    dataGridView1.Rows[rowIndex].Cells[2 * n + 1].Value = data.Converged ? "Да" : "Нет";
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

            MessageBox.Show($"Таблица отрисована! Всего строк: {dataGridView1.Rows.Count} (Метод Зейделя)",
                            "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}