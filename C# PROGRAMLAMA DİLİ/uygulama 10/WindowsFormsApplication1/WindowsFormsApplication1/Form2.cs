using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class2 kullan = new Class2();
            kullan.ADI = "selam";
            kullan.SOYADI = "kaçmaz";
            kullan.gelir = 3500;

            MessageBox.Show(kullan.ADI + " " + kullan.SOYADI + " " + kullan.gelir);

            textBox1.Text = kullan.ADI;
            textBox2.Text = kullan.SOYADI;
            textBox3.Text = kullan.gelir.ToString("c"); // parantez içindeki bu ifade tl işareti gösterir.

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            bilgiler bilgi = new bilgiler();

            bilgi.ad = textBox4.Text.Trim();
            bilgi.soyad = textBox5.Text.Trim();
            bilgi.ders = comboBox1.Text;
            bilgi.goster();
           

            MessageBox.Show(bilgi.al);


        }
    }
}
