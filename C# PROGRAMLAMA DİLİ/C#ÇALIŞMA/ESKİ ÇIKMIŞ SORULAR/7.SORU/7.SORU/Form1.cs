using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  metin;
            metin = textBox1.Text;
            if (metin.Length <= 10)
            {
                for (int i = 0; i < metin.Length; i++)
                {
                    MessageBox.Show(metin[i].ToString());
                }
            }
            else
            {
                MessageBox.Show("10 KARAKTER DIŞINDA BİR METİN"); textBox1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 64 || e.KeyChar < 90 && e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }

      

    }
}
