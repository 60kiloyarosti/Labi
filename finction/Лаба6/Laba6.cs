using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace finction.Лаба6
{
    public partial class Laba6 : Form
    {
        private double[,] arraySystemKoifi;
        private TextBox[,] koifi;
        private Label[,] iksi;

        private List<IterationData> iterationResults = new List<IterationData>();
        private List<IterationData> zeidelResults = new List<IterationData>();

        public Laba6()
        {
            InitializeComponent();

            Button buttonDrawTable = new Button();
            buttonDrawTable.Text = "Отрисовать таблицу (Итерации)";
            buttonDrawTable.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 50);
            buttonDrawTable.Size = new System.Drawing.Size(180, 30);
            buttonDrawTable.Click += ButtonDrawTable_Click;
            this.Controls.Add(buttonDrawTable);

            Button buttonZeidel = new Button();
            buttonZeidel.Text = "Метод Зейделя";
            buttonZeidel.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 100);
            buttonZeidel.Size = new System.Drawing.Size(180, 30);
            buttonZeidel.Click += ButtonZeidel_Click;
            this.Controls.Add(buttonZeidel);

            Button buttonDrawZeidelTable = new Button();
            buttonDrawZeidelTable.Text = "Отрисовать таблицу (Зейдель)";
            buttonDrawZeidelTable.Location = new System.Drawing.Point(button1.Location.X, button1.Location.Y + 150);
            buttonDrawZeidelTable.Size = new System.Drawing.Size(180, 30);
            buttonDrawZeidelTable.Click += ButtonDrawZeidelTable_Click;
            this.Controls.Add(buttonDrawZeidelTable);
        }

        public class IterationData
        {
            public int Iteration { get; set; }
            public double[] XValues { get; set; }
            public double[] Diffs { get; set; }
            public bool Converged { get; set; }
        }

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
                if (Math.Abs(value) > 1e-10)
                {
                    pogreshnost = (diff / Math.Abs(value)) * 100;
                }
                else
                {
                    pogreshnost = diff * 100;
                }
                System.Diagnostics.Debug.WriteLine($"Значение: {value}, Погрешность: {pogreshnost:F4}%");
            }

            public double GetPogreshnost() { return pogreshnost; }
            public double GetAbsolutePogreshnost() { return diff; }
        }

        private void CountKornej_TextChanged(object sender, EventArgs e)
        {
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

        // ==================== РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ ====================

        /// <summary>
        /// Проверка диагонального преобладания
        /// </summary>
        private bool CheckDiagonalDominance(double[,] A)
        {
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                double diag = Math.Abs(A[i, i]);
                double sumOff = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                        sumOff += Math.Abs(A[i, j]);
                }
                if (diag <= sumOff)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 1. ПЕРЕСТАНОВКА СТРОК - ставим на диагональ максимальные элементы
        /// </summary>
        private void ReorderRows(ref double[,] A, ref double[] b)
        {
            int n = A.GetLength(0);
            bool[] usedRows = new bool[n];
            double[,] newA = new double[n, n];
            double[] newB = new double[n];

            for (int col = 0; col < n; col++)
            {
                int bestRow = -1;
                double maxValue = -1;

                for (int row = 0; row < n; row++)
                {
                    if (!usedRows[row])
                    {
                        double absValue = Math.Abs(A[row, col]);
                        if (absValue > maxValue)
                        {
                            maxValue = absValue;
                            bestRow = row;
                        }
                    }
                }

                if (bestRow != -1)
                {
                    for (int j = 0; j < n; j++)
                        newA[col, j] = A[bestRow, j];
                    newB[col] = b[bestRow];
                    usedRows[bestRow] = true;
                }
            }

            A = newA;
            b = newB;
        }

        /// <summary>
        /// 2. УСИЛЕНИЕ ДИАГОНАЛИ - умножение строки на коэффициент
        /// </summary>
        private void StrengthenDiagonal(ref double[,] A, ref double[] b)
        {
            int n = A.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                double diag = Math.Abs(A[i, i]);
                double sumOffDiag = 0;

                for (int j = 0; j < n; j++)
                    if (j != i) sumOffDiag += Math.Abs(A[i, j]);

                // Если диагональ не доминирует, усиливаем её
                if (diag <= sumOffDiag && diag > 1e-10)
                {
                    // Коэффициент усиления: делаем диагональ на 50% больше суммы остальных
                    double factor = (sumOffDiag * 1.5) / diag;
                    for (int j = 0; j < n; j++)
                        A[i, j] *= factor;
                    b[i] *= factor;
                }
            }
        }

        /// <summary>
        /// 3. ЛИНЕЙНАЯ КОМБИНАЦИЯ - добавление одного уравнения к другому
        /// </summary>
        private void CombineEquations(ref double[,] A, ref double[] b)
        {
            int n = A.GetLength(0);
            double[,] newA = (double[,])A.Clone();
            double[] newB = (double[])b.Clone();

            for (int i = 0; i < n; i++)
            {
                double diag = Math.Abs(A[i, i]);
                double sumOffDiag = 0;

                for (int j = 0; j < n; j++)
                    if (j != i) sumOffDiag += Math.Abs(A[i, j]);

                // Если диагональный элемент мал, добавляем другие уравнения
                if (diag <= sumOffDiag)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (k != i && Math.Abs(A[k, i]) > diag)
                        {
                            // Добавляем k-е уравнение к i-му с весом
                            double weight = 0.5;
                            for (int j = 0; j < n; j++)
                            {
                                newA[i, j] = A[i, j] + weight * A[k, j];
                            }
                            newB[i] = b[i] + weight * b[k];
                            break;
                        }
                    }
                }
            }

            A = newA;
            b = newB;
        }

        /// <summary>
        /// ПОЛНОЕ ПРЕОБРАЗОВАНИЕ СИСТЕМЫ - комбинация всех равносильных методов
        /// </summary>
        private void FullTransformSystem(ref double[,] A, ref double[] b, int maxAttempts = 10)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                if (CheckDiagonalDominance(A))
                    return;

                // Метод 1: Перестановка строк
                ReorderRows(ref A, ref b);
                if (CheckDiagonalDominance(A)) return;

                // Метод 2: Усиление диагонали
                StrengthenDiagonal(ref A, ref b);
                if (CheckDiagonalDominance(A)) return;

                // Метод 3: Линейные комбинации
                CombineEquations(ref A, ref b);
                if (CheckDiagonalDominance(A)) return;
            }
        }

        /// <summary>
        /// Показать результат преобразований
        /// </summary>
        private void ShowTransformationResults(double[,] originalA, double[] originalB,
                                                double[,] newA, double[] newB,
                                                bool convergenceGuaranteed)
        {
            int n = originalA.GetLength(0);
            string message = "";

            message = "РЕЗУЛЬТАТЫ РАВНОСИЛЬНЫХ ПРЕОБРАЗОВАНИЙ\n";
            message += "=====================================\n\n";

            if (convergenceGuaranteed)
            {
                message += "✓ ПРЕОБРАЗОВАНИЯ УСПЕШНЫ!\n";
                message += "✓ Система имеет диагональное преобладание.\n";
                message += "✓ Сходимость метода гарантирована.\n\n";
            }
            else
            {
                message += "⚠ ПРЕДУПРЕЖДЕНИЕ!\n";
                message += "После преобразований диагональное преобладание не достигнуто.\n";
                message += "Метод может не сойтись.\n\n";
            }

            message += "ИСХОДНАЯ СИСТЕМА:\n";
            for (int i = 0; i < n && i < 5; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    message += $"{originalA[i, j],8:F2}";
                    if (j < n - 1) message += "x" + (j + 1) + " + ";
                }
                message += $" = {originalB[i],8:F2}\n";
            }

            message += "\nПРЕОБРАЗОВАННАЯ СИСТЕМА:\n";
            for (int i = 0; i < n && i < 5; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    message += $"{newA[i, j],8:F2}";
                    if (j < n - 1) message += "x" + (j + 1) + " + ";
                }
                message += $" = {newB[i],8:F2}\n";
            }

            message += "\nПРОВЕРКА ДИАГОНАЛЬНОГО ПРЕОБЛАДАНИЯ:\n";
            for (int i = 0; i < n; i++)
            {
                double diag = Math.Abs(newA[i, i]);
                double sumOff = 0;
                for (int j = 0; j < n; j++)
                    if (j != i) sumOff += Math.Abs(newA[i, j]);
                message += $"Ур.{i + 1}: |{newA[i, i],8:F2}| = {diag:F2} > {sumOff:F2} ";
                message += (diag > sumOff) ? "✓ ДА\n" : "✗ НЕТ\n";
            }

            if (n > 5)
                message += $"\n... и еще {n - 5} уравнений\n";

            MessageBox.Show(message, "РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ",
                           MessageBoxButtons.OK,
                           convergenceGuaranteed ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Проверка решения на исходной системе
        /// </summary>
        private bool ValidateSolution(double[,] A, double[] b, double[] Xs, double tolerance = 0.001)
        {
            int n = A.GetLength(0);
            double maxError = 0;
            string errors = "";

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += A[i, j] * Xs[j];
                }
                double error = Math.Abs(sum - b[i]);
                maxError = Math.Max(maxError, error);

                if (error > tolerance) 
                    errors += $"Уравнение {i + 1}: {sum:F6} ≠ {b[i]}, ошибка: {error:E6}\n";
            }

            return maxError <= tolerance;  // Если ошибка меньше заданной точности - решение верное
        }

        // ==================== МЕТОД ПРОСТОЙ ИТЕРАЦИИ ====================

        private void button1_Click(object sender, EventArgs e)
        {
            iterationResults.Clear();

            int n = Convert.ToInt32(CountKornej.Text);
            double[,] A = new double[n, n];
            double[] b = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = Convert.ToDouble(koifi[i, j].Text);
                }
                b[i] = Convert.ToDouble(koifi[i, n].Text);
            }

            double[,] originalA = (double[,])A.Clone();
            double[] originalB = (double[])b.Clone();
            double[,] workingA = (double[,])A.Clone();
            double[] workingB = (double[])b.Clone();

            bool hasDominance = CheckDiagonalDominance(workingA);

            if (!hasDominance)
            {
                DialogResult res = MessageBox.Show(
                    "СИСТЕМА НЕ ИМЕЕТ ДИАГОНАЛЬНОГО ПРЕОБЛАДАНИЯ!\n\n" +
                    "Выполнить РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ для обеспечения сходимости?\n\n" +
                    "Преобразования:\n" +
                    "• Перестановка строк\n" +
                    "• Усиление диагональных элементов\n" +
                    "• Линейные комбинации уравнений\n\n" +
                    "Это не изменит решение системы!",
                    "РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FullTransformSystem(ref workingA, ref workingB);
                    bool success = CheckDiagonalDominance(workingA);
                    ShowTransformationResults(originalA, originalB, workingA, workingB, success);
                }
            }

            SolveBySimpleIteration(workingA, workingB, originalA, originalB);
        }

        private void SolveBySimpleIteration(double[,] A, double[] b, double[,] originalA, double[] originalB)
        {
            int n = A.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(A[i, i]) < 1e-10)
                {
                    MessageBox.Show($"Ошибка: Диагональный элемент [{i},{i}] равен 0!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double[,] B = new double[n, n];
            double[] c = new double[n];

            for (int i = 0; i < n; i++)
            {
                c[i] = b[i] / A[i, i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        B[i, j] = -A[i, j] / A[i, i];
                    else
                        B[i, j] = 0;
                }
            }

            double[] Xs = new double[n];
            double[] XsPrev = new double[n];

            for (int i = 0; i < n; i++)
            {
                Xs[i] = c[i];
                XsPrev[i] = Xs[i];
            }

            IterationData initialData = new IterationData();
            initialData.Iteration = 0;
            initialData.XValues = new double[n];
            initialData.Diffs = new double[n];
            Array.Copy(Xs, initialData.XValues, n);
            for (int i = 0; i < n; i++)
                initialData.Diffs[i] = -1;
            initialData.Converged = false;
            iterationResults.Add(initialData);

            double epsilon = 0.5 * Math.Pow(10, -3);
            int maxIterations = 100;
            int iteration = 1;
            bool converged = false;
            double[] diffs = null;

            while (!converged && iteration <= maxIterations)
            {
                Array.Copy(Xs, XsPrev, n);

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sum += B[i, j] * XsPrev[j];
                    }
                    Xs[i] = c[i] + sum;
                }

                double maxDiff = 0;
                diffs = new double[n];

                for (int i = 0; i < n; i++)
                {
                    diffs[i] = Math.Abs(Xs[i] - XsPrev[i]);
                    if (diffs[i] > maxDiff)
                        maxDiff = diffs[i];
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

            // Проверяем решение на исходной системе
            bool isValid = ValidateSolution(originalA, originalB, Xs);

            if (converged)
            {
                string result = "";
                if (isValid)
                    result = $"✓ РЕШЕНИЕ НАЙДЕНО за {iteration - 1} итераций:\n\n";
                else
                    result = $"⚠ ВНИМАНИЕ! Метод сошелся за {iteration - 1} итераций, НО РЕШЕНИЕ НЕВЕРНОЕ!\n\n";

                for (int i = 0; i < n; i++)
                {
                    result += $"x{i + 1} = {Xs[i]:F6}\n";
                    SearchLowPogresh searchLow = new SearchLowPogresh(Xs[i], diffs[i]);
                    searchLow.Search();
                }

                MessageBox.Show(result, "РЕЗУЛЬТАТ (Метод простой итерации)",
                               MessageBoxButtons.OK,
                               isValid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Метод не сошелся за {maxIterations} итераций!\n\n" +
                               "Рекомендации:\n" +
                               "1. Используйте метод Зейделя\n" +
                               "2. Выполните преобразования системы\n" +
                               "3. Проверьте корректность данных",
                               "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DrawTable();
        }

        // ==================== МЕТОД ЗЕЙДЕЛЯ ====================

        private void ButtonZeidel_Click(object sender, EventArgs e)
        {
            zeidelResults.Clear();

            int n = Convert.ToInt32(CountKornej.Text);
            double[,] A = new double[n, n];
            double[] b = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = Convert.ToDouble(koifi[i, j].Text);
                }
                b[i] = Convert.ToDouble(koifi[i, n].Text);
            }

            // СОХРАНЯЕМ ОРИГИНАЛЬНУЮ СИСТЕМУ ДЛЯ ПРОВЕРКИ
            double[,] originalA = (double[,])A.Clone();
            double[] originalB = (double[])b.Clone();
            double[,] workingA = (double[,])A.Clone();
            double[] workingB = (double[])b.Clone();

            bool hasDominance = CheckDiagonalDominance(workingA);

            if (!hasDominance)
            {
                DialogResult res = MessageBox.Show(
                    "СИСТЕМА НЕ ИМЕЕТ ДИАГОНАЛЬНОГО ПРЕОБЛАДАНИЯ!\n\n" +
                    "Выполнить РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ для метода Зейделя?\n\n" +
                    "Преобразования:\n" +
                    "• Перестановка строк\n" +
                    "• Усиление диагональных элементов\n" +
                    "• Линейные комбинации уравнений\n\n" +
                    "Это значительно повысит шансы на сходимость!",
                    "РАВНОСИЛЬНЫЕ ПРЕОБРАЗОВАНИЯ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FullTransformSystem(ref workingA, ref workingB);
                    bool success = CheckDiagonalDominance(workingA);
                    ShowTransformationResults(originalA, originalB, workingA, workingB, success);
                }
            }

            SolveBySeidel(workingA, workingB, originalA, originalB);
        }

        private void SolveBySeidel(double[,] A, double[] b, double[,] originalA, double[] originalB)
        {
            int n = A.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(A[i, i]) < 1e-10)
                {
                    MessageBox.Show($"Ошибка: Диагональный элемент [{i},{i}] равен 0!\n" +
                                   "Невозможно применить метод Зейделя.",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            double[] Xs = new double[n];
            double[] XsPrev = new double[n];

            // Начальное приближение - нулевое
            for (int i = 0; i < n; i++)
            {
                Xs[i] = 0;
                XsPrev[i] = 0;
            }

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
            int maxIterations = 200;
            int iteration = 1;
            bool converged = false;
            double[] diffs = null;
            double previousMaxDiff = double.MaxValue;

            while (!converged && iteration <= maxIterations)
            {
                Array.Copy(Xs, XsPrev, n);

                // Метод Зейделя
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            sum += A[i, j] * Xs[j];
                        }
                    }
                    Xs[i] = (b[i] - sum) / A[i, i];
                }

                double maxDiff = 0;
                diffs = new double[n];

                for (int i = 0; i < n; i++)
                {
                    diffs[i] = Math.Abs(Xs[i] - XsPrev[i]);
                    if (diffs[i] > maxDiff)
                        maxDiff = diffs[i];
                }

                // Проверка на расходимость
                if (maxDiff > previousMaxDiff && iteration > 5)
                {
                    MessageBox.Show($"ВНИМАНИЕ: Метод Зейделя расходится!\n" +
                                   $"Итерация {iteration}: Δ = {maxDiff:E6}\n\n" +
                                   $"Рекомендации:\n" +
                                   $"1. Выполните преобразования системы\n" +
                                   $"2. Проверьте корректность введенных данных",
                                   "Расходимость метода",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    break;
                }
                previousMaxDiff = maxDiff;

                if (maxDiff < epsilon)
                    converged = true;

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

            // ПРОВЕРЯЕМ РЕШЕНИЕ НА ОРИГИНАЛЬНОЙ СИСТЕМЕ
            bool isValid = ValidateSolution(originalA, originalB, Xs);

            if (converged)
            {
                string result = "";
                if (isValid)
                    result = $"✓ РЕШЕНИЕ НАЙДЕНО за {iteration - 1} итераций (метод Зейделя):\n\n";
                else
                    result = $"⚠ ВНИМАНИЕ! Метод сошелся за {iteration - 1} итераций, НО РЕШЕНИЕ НЕВЕРНОЕ!\n\n" +
                             "Возможно, система плохо обусловлена или метод сошелся к ложному корню.\n\n";

                for (int i = 0; i < n; i++)
                {
                    result += $"x{i + 1} = {Xs[i]:F6}\n";
                    SearchLowPogresh searchLow = new SearchLowPogresh(Xs[i], diffs[i]);
                    searchLow.Search();
                }

                MessageBox.Show(result, "РЕЗУЛЬТАТ (Метод Зейделя)",
                               MessageBoxButtons.OK,
                               isValid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Метод Зейделя не сошелся за {maxIterations} итераций!\n\n" +
                               "ВОЗМОЖНЫЕ РЕШЕНИЯ:\n" +
                               "1. Выполните равносильные преобразования (кнопка \"Да\")\n" +
                               "2. Используйте метод простой итерации\n" +
                               "3. Проверьте правильность ввода данных\n" +
                               "4. Система может не иметь решения или иметь бесконечно много решений",
                               "НЕТ СХОДИМОСТИ",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            DrawZeidelTable();
            // В конце метода SolveBySeidel, после нахождения решения:

            if (converged)
            {
                // Находим максимальную разницу (погрешность)
                double maxDiff = 0;
                for (int i = 0; i < n; i++)
                {
                    if (diffs[i] > maxDiff)
                        maxDiff = diffs[i];
                }

                // Выводим информацию о погрешности в требуемом формате
                PrintPogreshnostInfo(Xs, diffs, maxDiff, iteration - 1);

                // Проверяем решение
                bool isValid1 = ValidateSolution(originalA, originalB, Xs);

                string result = "";
                if (isValid1)
                    result = $"✓ РЕШЕНИЕ НАЙДЕНО за {iteration - 1} итераций (метод Зейделя):\n\n";
                else
                    result = $"⚠ ВНИМАНИЕ! Решение найдено за {iteration - 1} итераций, НО ПОГРЕШНОСТЬ МОЖЕТ БЫТЬ ВЫШЕ!\n\n";

                for (int i = 0; i < n; i++)
                {
                    result += $"x{i + 1} = {Xs[i]:F6}\n";
                    SearchLowPogresh searchLow = new SearchLowPogresh(Xs[i], diffs[i]);
                    searchLow.Search();
                }

                result += $"\nПогрешность Δξ̄ = {maxDiff:F6}";

                MessageBox.Show(result, "РЕЗУЛЬТАТ (Метод Зейделя)",
                               MessageBoxButtons.OK,
                               isValid1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }

        // ==================== МЕТОДЫ ОТРИСОВКИ ТАБЛИЦ ====================

        private void ButtonDrawTable_Click(object sender, EventArgs e)
        {
            DrawTable();
        }

        private void ButtonDrawZeidelTable_Click(object sender, EventArgs e)
        {
            DrawZeidelTable();
        }

        private void DrawTable()
        {
            if (iterationResults.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения. Сначала выполните вычисления методом простой итерации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void DrawZeidelTable()
        {
            if (zeidelResults.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения. Сначала выполните вычисления методом Зейделя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        /// <summary>
        /// Вывод информации о погрешности в требуемом формате
        /// </summary>
        private void PrintPogreshnostInfo(double[] Xs, double[] diffs, double maxDiff, int iteration)
        {
            string result = "";

            // Формируем вектор x^(k)
            result += "ξ̄ = x^(" + iteration + ") = (";
            for (int i = 0; i < Xs.Length; i++)
            {
                result += Xs[i].ToString("F7");
                if (i < Xs.Length - 1)
                    result += "; ";
            }
            result += "), ";

            // Добавляем погрешность Δξ̄
            result += "Δξ̄ = " + maxDiff.ToString("F6");

            // Дополнительная информация о погрешностях по каждой переменной
            result += "\n\nПогрешности по каждой переменной:\n";
            for (int i = 0; i < Xs.Length; i++)
            {
                result += $"Δx{i + 1} = {diffs[i]:E6}\n";
            }

            MessageBox.Show(result, "Информация о погрешности",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Вывод информации о погрешности с указанием точного решения (если известно)
        /// </summary>
        private void PrintPogreshnostInfoWithExact(double[] Xs, double[] diffs, double maxDiff,
                                                   int iteration, double[] exactSolution)
        {
            string result = "";

            // Формируем вектор x^(k)
            result += "ξ̄ = x^(" + iteration + ") = (";
            for (int i = 0; i < Xs.Length; i++)
            {
                result += Xs[i].ToString("F7");
                if (i < Xs.Length - 1)
                    result += "; ";
            }
            result += "), ";

            // Добавляем погрешность Δξ̄
            result += "Δξ̄ = " + maxDiff.ToString("F6");

            // Сравнение с точным решением (если известно)
            if (exactSolution != null && exactSolution.Length == Xs.Length)
            {
                result += "\n\nСравнение с точным решением:\n";
                double maxExactError = 0;
                for (int i = 0; i < Xs.Length; i++)
                {
                    double exactError = Math.Abs(Xs[i] - exactSolution[i]);
                    maxExactError = Math.Max(maxExactError, exactError);
                    result += $"x{i + 1}: {Xs[i]:F7} - {exactSolution[i]:F7} = {exactError:E6}\n";
                }
                result += $"\nМаксимальная погрешность относительно точного решения: {maxExactError:E6}";
            }

            // Дополнительная информация о погрешностях по каждой переменной
            result += "\n\nΔx (разница между итерациями):\n";
            for (int i = 0; i < Xs.Length; i++)
            {
                result += $"Δx{i + 1} = {diffs[i]:E6}\n";
            }

            MessageBox.Show(result, "Информация о погрешности",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}