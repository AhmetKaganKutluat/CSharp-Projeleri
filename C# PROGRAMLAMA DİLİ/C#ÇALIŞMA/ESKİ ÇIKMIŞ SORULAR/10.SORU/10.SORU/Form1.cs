using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int faktoryel(int sayi)
        {
            int fak = 1;
            for (int i = 1; i <= sayi; i++)
            {
                fak = fak * i;
            }
            return fak;
        }

        private void temizle()
    {
        textBox1.Clear();
    
    }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi;
            sayi = Convert.ToInt16 (textBox1.Text);
            if (sayi < 1 || sayi > 10)
            {
                MessageBox.Show("yanlış değer aralığı girdiniz ");
                temizle();
                textBox1.Focus();
            }
            MessageBox.Show(faktoryel (Convert.ToInt16(textBox1.Text)).ToString());

        }
    }
}
