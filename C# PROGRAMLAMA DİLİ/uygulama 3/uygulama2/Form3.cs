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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         private void temizle() 
    {
        textBox1.Clear();
        textBox2.Clear();
        textBox3.Text = "";
        MessageBox.Show("Tüm text alanları temizledi ...");
    }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void yazdir(string adi,string soyadi,string memleket )
        {
            MessageBox.Show("müsterinin adı : " + adi + "" + soyadi + "\n" + memleket);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string adi = textBox4.Text;
            string soyadi = textBox5.Text;
            string memleket = textBox6.Text;
            yazdir(adi,soyadi,memleket);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox8.Focus();
            if (e.KeyChar > 64 || e.KeyChar < 90 && e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
      
            
            }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox9.Focus();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox10.Focus();
            if (e.KeyChar >=48 && e.KeyChar <=57 || e.KeyChar ==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox10.Focus();
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        string adsoyad;
        string ders;
        double vize, final;

        double hesapla(double vize, double final)
        {
            double ortalama;
            ortalama = (vize + final) / 2;
            return ortalama;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adsoyad = textBox7.Text.Trim();
            ders = textBox8.Text.Trim();
            vize = Convert.ToDouble(textBox9.Text);
            final = Convert.ToDouble(textBox10.Text);
            textBox11.Text = adsoyad + "öğrencisi " + ders + "dersinden" + hesapla(vize, final) + "ortalama almıştır .";
        }

      
    }
}
