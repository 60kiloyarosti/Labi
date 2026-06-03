using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finction
{
    public class SearchLowPogresh
    {
        private double x;
        private double x1 = 0;
        private double pogresh;
        private double pogresh1 = 0;
        private int m = 0;
        private int n = 0;
        private int n1 = -1;
        private double deltaOkr = 0;
        private int counter = 0;
        private bool hasMinus = false;
        public double ResultX { get; private set; }
        public double ResultError { get; private set; }
        public SearchLowPogresh(double x, double pogresh)
        {
            this.x = x;
            this.pogresh = pogresh;
        }

        public void Search()
        {
            string debugInfo = "";
            debugInfo += "Приближенное значение корня только верными значащими цифрами в узком смысле\n\n";
            debugInfo += $"Исходные значения: {x} +- {pogresh.ToString("F10")}\n";
            Console.WriteLine();
            while (true)
            {
                hasMinus = false;
                counter++;
                debugInfo += "Итерация " + counter.ToString() + "\n";
                char[] stringCharX = x.ToString().ToCharArray();
                for (int i = 0; i < stringCharX.Length; i++)
                {
                    if (stringCharX[i] == '-') { hasMinus = true; break; }
                }
                int IndexZap = Array.IndexOf(stringCharX, ',');
                if (hasMinus)
                {
                    IndexZap--;
                }
                if (IndexZap > 0) m = IndexZap - 1;
                else { m = 0; IndexZap = 0; }
                for (n = 1; (pogresh <= 0.5 * Math.Pow(10, (m - n + 1)) && n <= 20); n++) { }
                ;
                n--;
                if (n1 == n)
                {
                   debugInfo += $"n1: {n1} == n: {n} - стабилизировалась \n";
                    break;
                }
                x1 = x;
                x1 = Math.Round(x1, n - IndexZap);
                deltaOkr = Math.Abs(x - x1);
                pogresh1 = deltaOkr + pogresh;
                debugInfo += $"{x1} +-{pogresh1.ToString("F10")}\n";
                x = x1;
                pogresh = pogresh1;
                n1 = n;
            }
            debugInfo += "\n";
            debugInfo += $"Итоговый ответ: {x} +- {pogresh.ToString("F10")}";
            MessageBox.Show(debugInfo);
            ResultX = x;
            ResultError = pogresh;
        }
    }
}
