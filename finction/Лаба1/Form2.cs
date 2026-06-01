using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace finction
{
    public partial class Form2 : Form
    {
        private double epslantx;
        private double deltaNum;
        private int currentN = 0;
        private int previousN = -1; 
        private int CountNumDoZapiat = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 17; i++)
            {
                dataGridView1.Rows.Add();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a1 = -2;
            double b1 = -1.5;
            double Epselant = 0.0001;
            int k = 1;

            dataGridView1.Rows[0].Cells[0].Value = a1.ToString();
            dataGridView1.Rows[0].Cells[1].Value = b1.ToString();
            double Dividea1b1 = (b1 + a1) / 2;
            dataGridView1.Rows[0].Cells[2].Value = Dividea1b1.ToString();
            double Fa1 = (Math.Pow(a1, 2) + (4 * Math.Sin(a1)));
            dataGridView1.Rows[0].Cells[3].Value = Fa1.ToString();
            double Fb1 = (Math.Pow(b1, 2) + (4 * Math.Sin(b1)));
            dataGridView1.Rows[0].Cells[4].Value = Fb1.ToString();
            double FDividea1b1 = (Math.Pow(Dividea1b1, 2) + (4 * Math.Sin(Dividea1b1)));
            dataGridView1.Rows[0].Cells[5].Value = FDividea1b1.ToString();
            double pogresh = (b1 - a1) / 2;
            dataGridView1.Rows[0].Cells[7].Value = pogresh.ToString();
            if (pogresh < Epselant)
                dataGridView1.Rows[0].Cells[8].Value = "Да";
            else
                dataGridView1.Rows[0].Cells[8].Value = "Нет";

            for (int i = 1; k <= 3; i++)
            {
                if ((Fa1 * FDividea1b1) >= 0)
                {
                    a1 = Dividea1b1;
                    Fa1 = FDividea1b1;
                }
                if ((Fa1 * FDividea1b1) <= 0)
                {
                    b1 = Dividea1b1;
                    Fb1 = FDividea1b1;
                }
                dataGridView1.Rows[i].Cells[0].Value = a1.ToString();
                dataGridView1.Rows[i].Cells[1].Value = b1.ToString();
                Dividea1b1 = (b1 + a1) / 2;
                dataGridView1.Rows[i].Cells[2].Value = Dividea1b1.ToString();
                Fa1 = (Math.Pow(a1, 2) + (4 * Math.Sin(a1)));
                dataGridView1.Rows[i].Cells[3].Value = Fa1.ToString();
                Fb1 = (Math.Pow(b1, 2) + (4 * Math.Sin(b1)));
                dataGridView1.Rows[i].Cells[4].Value = Fb1.ToString();
                FDividea1b1 = (Math.Pow(Dividea1b1, 2) + (4 * Math.Sin(Dividea1b1)));
                dataGridView1.Rows[i].Cells[5].Value = FDividea1b1.ToString();
                pogresh = (b1 - a1) / 2;
                dataGridView1.Rows[i].Cells[7].Value = pogresh.ToString("F10");
                if (pogresh < Epselant)
                {
                    if (k == 1)
                    {
                        epslantx = Dividea1b1;
                        deltaNum = pogresh;
                    }
                    dataGridView1.Rows[i].Cells[8].Value = "Да";
                    dataGridView1.Rows[i].Cells[6].Value = Dividea1b1.ToString();
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    k++;
                }

                else
                    dataGridView1.Rows[i].Cells[8].Value = "Нет";

            }
            dataGridView1.Refresh();
            dataGridView1.Update();
        }

        private void koren_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iteration = 1;
            string debugInfo = "";

            while (true)
            {
                string currentNumStr = epslantx.ToString("F10").TrimEnd('0').TrimEnd(',');
                string deltaNumStr = deltaNum.ToString("F10").TrimEnd('0').TrimEnd(',');

                if (deltaNumStr.EndsWith(',')) deltaNumStr += "0";
                if (string.IsNullOrEmpty(deltaNumStr)) deltaNumStr = "0";

                debugInfo += $"=== Итерация {iteration} ===\n";
                debugInfo += $"Текущее число: {currentNumStr}\n";
                debugInfo += $"Текущая погрешность: {deltaNumStr}\n";

                char[] chars = currentNumStr.ToCharArray();
                char[] chars1 = deltaNumStr.ToCharArray();

                int m = 0;
                int startIndex = 0;
                if (chars[0] == '-') startIndex = 1;

                if (currentNumStr.Contains(','))
                {
                    for (int i = startIndex; chars[i] != ','; i++)
                    {
                        m++;
                    }
                }
                else
                {
                    m = currentNumStr.Length - startIndex;
                }

                CountNumDoZapiat = m;
                debugInfo += $"Цифр до запятой: {CountNumDoZapiat}\n";

                m = m - 1;
                if (m < 0) m = 0;

                currentN = GetN(chars1);
                debugInfo += $"currentN = {currentN}\n";

                if (currentN == previousN)
                {
                    debugInfo += $"n стабилизировалось (currentN = {currentN}, previousN = {previousN})\n";
                    break;
                }

                int roundDigits = Math.Abs(currentN - CountNumDoZapiat);
                debugInfo += $"Округление до {roundDigits} знаков после запятой\n";

                double okrNum1 = Math.Round(Convert.ToDouble(currentNumStr), roundDigits);
                double deltaokrNum1 = Math.Abs(Convert.ToDouble(currentNumStr) - okrNum1);
                double strokryg1 = deltaokrNum1 + Convert.ToDouble(deltaNumStr);

                debugInfo += $"Округленное число: {okrNum1}\n";
                debugInfo += $"Погрешность округления: {deltaokrNum1}\n";
                debugInfo += $"Новая погрешность: {strokryg1}\n\n";

                epslantx = okrNum1;
                deltaNum = strokryg1;
                previousN = currentN;
                iteration++;
            }

            // Покажем всю отладочную информацию
            MessageBox.Show(debugInfo + $"\n\nОкончательный результат: {epslantx.ToString("F10").TrimEnd('0').TrimEnd(',')} +- {deltaNum.ToString("F10").TrimEnd('0').TrimEnd(',')}");
            // Или просто результат
            // MessageBox.Show($"{epslantx} +- {deltaNum}");
        }
        private int NextNumber(int i, char[] ch)
        {
            for (int j = i + 1; j < ch.Length; j++)
            {
                // Пропускаем запятую и знак минуса
                if (ch[j] == ',' || ch[j] == '-')
                    continue;

                // Проверяем, что символ - цифра
                if (char.IsDigit(ch[j]))
                {
                    int digit = Convert.ToInt32(ch[j].ToString());
                    if (digit > 0)
                        return 1; // есть значащая цифра
                }
            }
            return 0; // нет значащих цифр (только нули или конец строки)
        }
        private int GetN(char[] chars1)
        {
            int n = 0;
            int firstNumNoZero = 1;
            bool lastWasFiveAndNoMore = false;

            // Ищем позицию запятой в строке погрешности
            int indexZap = Array.IndexOf(chars1, ',');
            if (indexZap == -1) return 0; // нет запятой

            // Добавляем проверку на длину массива
            for (int i = indexZap + 1; i < chars1.Length && firstNumNoZero == 1; i++)
            {
                // Пропускаем нецифровые символы
                if (chars1[i] == ',' || chars1[i] == '-')
                    continue;

                int currentDigit = Convert.ToInt32(chars1[i].ToString());

                // Если цифра 0 или от 1 до 4 — увеличиваем n
                if (currentDigit == 0 || currentDigit <= 4)
                {
                    n++;
                }
                // Если цифра 5 — особая обработка
                if (currentDigit == 5)
                {
                    // Проверяем, есть ли значащие цифры после 5
                    if (NextNumber(i, chars1) == 0) // нет значащих цифр после
                    {
                        n++;        // увеличиваем n
                        lastWasFiveAndNoMore = true; // запоминаем, что это была 5 без продолжения
                    }
                    else // есть значащие цифры после 5
                    {
                        lastWasFiveAndNoMore = false;
                    }
                }
                // Если встретили ненулевую цифру, поднимаем флаг
                if (currentDigit != 0)
                {
                    firstNumNoZero++; // теперь firstNumNoZero = 2, цикл остановится
                }
            }

            // Если последняя значащая цифра была 5 и дальше нет цифр,
            // добавляем ещё один к n (по правилам округления)
            if (lastWasFiveAndNoMore)
            {
                n++;
            }
            return n;
        }

    }
}
