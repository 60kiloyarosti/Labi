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
    }
}
