using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finction.Лаба3;
using finction.Лаба4;
using finction.Лаба5;
using finction.Лаба6;

namespace finction
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void laba1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void laba2_Click(object sender, EventArgs e)
        {
            Laba2 laba2 = new Laba2();
            laba2.Show();
        }

        private void laba3_Click(object sender, EventArgs e)
        {
            Laba3 laba3 = new Laba3();
            laba3.Show();
        }

        private void laba4_Click(object sender, EventArgs e)
        {
            Laba4 laba4 = new Laba4();
            laba4.Show();
        }

        private void laba5_Click(object sender, EventArgs e)
        {
            Laba5 laba5 = new Laba5();
            laba5.Show();
        }

        private void laba6_Click(object sender, EventArgs e)
        {
            Laba6 laba6 = new Laba6();
            laba6.Show();
        }
    }
}
