using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct bilgiler
        {
            public string adı;
            public string soyadı;
            public string memleket;
            public string adres;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bilgiler bil = new bilgiler();
            bil.adı = textBox1.Text.ToUpper ();
            bil.soyadı = textBox2.Text.ToUpper();
            bil.memleket = textBox3.Text.ToUpper();
            bil.adres = textBox4.Text.ToUpper();
            MessageBox.Show("ADI "+bil.adı +" SOYADI "+bil.soyadı +" MEMLEKETİ  "+bil.memleket +" ADRESİ "+bil.adres,"BİLGİLER");
            
        }
    }
}
