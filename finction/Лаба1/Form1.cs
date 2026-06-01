namespace finction
{
    public partial class Form1 : Form
    {
        private double a, b, h;
        private double x, y;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            a = -5;
            b = 5;
            h = 0.1;
            x = a;
            int i = 0;
            while (x <= b)
            {
                x = Math.Round(x, 1);
                y = Math.Pow(x, 2) + 4 * Math.Sin(x);
                chart1.Series[0].Points.AddXY(x, y);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = x.ToString();
                dataGridView1.Rows[i].Cells[1].Value = y.ToString();
                if (x >= -2 && x <= -1.5)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                x += h;
                i++;
            }

            
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            a = -5;
            b = 5;
            h = 0.1;
            int i = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = Math.Round(Math.Pow(x, 2), 6);
                chart2.Series[1].Points.AddXY(x, y);
                dataGridView1.Rows[i].Cells[3].Value = y.ToString();
                i++;
            }
            int j = 0;
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 1);
                y = Math.Round((-4 * Math.Sin(x)), 6);
                chart2.Series[0].Points.AddXY(x, y);

                dataGridView1.Rows[j].Cells[2].Value = y.ToString();
                j++;
            }

        }
        private void button_next_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
