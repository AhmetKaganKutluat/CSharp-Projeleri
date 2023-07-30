using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcı;
            string sifre;

            kullanıcı = textBox1.Text.Trim();
            sifre = textBox2.Text.Trim();

            textBox3.Text = kullanıcı.Substring(0,3);
            textBox4.Text = sifre.Substring(textBox2 .Text.Length -3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.ShowDialog();

        }
    }
}
