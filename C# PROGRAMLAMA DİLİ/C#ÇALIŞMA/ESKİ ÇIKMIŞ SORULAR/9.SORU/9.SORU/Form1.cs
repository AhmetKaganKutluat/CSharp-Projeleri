using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, delta,tekkök;
            double x1, x2;
            string parabol,sonuc;
            
            a  = Convert.ToInt16(textBox1.Text);
            b  = Convert.ToInt16(textBox2.Text);
            c  = Convert.ToInt16(textBox3.Text);
            
            delta = (b*b) - (4*a*c); // b nin karesini al math kütüphanesiyle
            
            if (a < 0)
            {
                parabol = ("AŞAĞI YÖNLÜ PARABOL");
            }
            else
            {
                parabol = ("YUKARI YÖNLÜ PARABOL");
            }

            if (delta < 0)
            {
                sonuc = ("FONKSİYONUN REEL KÖKÜ YOKTUR");
                MessageBox.Show("A NIN DEĞERİ " + parabol + " DELTANIN SONUCU " + sonuc);
            }
            else if (delta == 0)
            {
                tekkök = (-1 * b) / (2 * a);
                sonuc = ("TEK KÖK VARDIR VE DEĞERİ" + tekkök);
                MessageBox.Show("A NIN DEĞERİ " + parabol + " DELTANIN SONUCU " + sonuc);
            }
            else if (delta >0)
            {
                x1 =   ((-1 * b) + Math.Sqrt(delta)) / (2 * a);
                x2 =  ((-1 * b) - Math.Sqrt(delta)) / (2 * a);
              // x1 ve x2 yuvarla 2 hane göster
                sonuc= ("ÇİFTKÖK VARDIR "+"X1 "+x1+" x2 "+x2  );
                MessageBox.Show("A NIN DEĞERİ " + parabol + " DELTANIN SONUCU " + sonuc);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
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
