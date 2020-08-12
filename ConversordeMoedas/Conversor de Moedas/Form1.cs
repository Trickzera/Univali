using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversor_de_Moedas_2
{
    public partial class Form1 : Form
    {
        double valor = 0;
        double taxa1 = 5.44;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor = double.Parse(real1.Text) / taxa1;
            dolar1.Text = valor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            valor = taxa1 * double.Parse(dolar1.Text);
            real1.Text = valor.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        double taxa2 = 6.41;

        private void button3_Click(object sender, EventArgs e)
        {
            valor = double.Parse(real2.Text) / taxa2;
            euro1.Text = valor.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            valor = taxa2 * double.Parse(euro1.Text);
            real2.Text = valor.ToString();
        }
        double taxa3 = 1.18;

        private void button5_Click(object sender, EventArgs e)
        {
            valor = double.Parse(dolar2.Text) / taxa3;
            euro2.Text = valor.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            valor = taxa3 * double.Parse(euro2.Text);
            dolar2.Text = valor.ToString();
        }
    }
}
