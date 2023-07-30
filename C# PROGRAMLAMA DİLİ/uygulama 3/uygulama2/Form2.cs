using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulama2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        struct ogrenci
        {
            public string ad; public string soyad;
            public string memleket; public string adres;
        }
        ogrenci ogr;
        private void button1_Click(object sender, EventArgs e)
        {
            ogr.ad = textBox1.Text.Trim().ToUpper();
            ogr.soyad = textBox2.Text.Trim().ToUpper();
            ogr.memleket = textBox3.Text.Trim().ToUpper();
            ogr.adres = textBox4.Text.Trim().ToUpper();
            MessageBox.Show(ogr.ad + " " + ogr.soyad + " " + ogr.memleket + "\n" + ogr.adres);
        }
    }
}
