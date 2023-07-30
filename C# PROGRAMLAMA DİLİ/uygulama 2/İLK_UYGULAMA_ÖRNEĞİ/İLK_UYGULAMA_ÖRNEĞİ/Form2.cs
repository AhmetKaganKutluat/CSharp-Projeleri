using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İLK_UYGULAMA_ÖRNEĞİ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sonuc;
            if (textBox1.Text == "")
            {

                MessageBox.Show("LÜTFEN BİR SAYI GİRİŞİ YAPINIZ.");
                textBox1.Focus();
                textBox1.BackColor = Color.Yellow;
            }
            else
            {
            int sayi = Convert.ToInt32(textBox1.Text); // int değerindeki sayıyı çevirim textbox birden aldı.
            switch (sayi)
            {
                case 1: { MessageBox.Show("BUGÜN GÜNLERDEN ÇARŞAMBA"); break; }
                case 2:
                    {

                        sonuc = 3 * 5;
                        label1.Text = "3 ile 5 çarpımı " + sonuc.ToString();
                        break;

                    }
                case 3:
                case 4:
                case 5:
                case 6: { MessageBox.Show("DİZİYİ KULLANDINIZ"); break; }
                default: { MessageBox.Show("TANIMSIZ SAYI GİRİŞİ"); break; }
            }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int gun = (int) DateTime.Now.DayOfWeek;
            switch (gun)
            {
                case 1: textBox2.Text = "PAZARTESİ"; break;
                case 2: textBox2.Text = "SALI"; break;
                case 3: textBox2.Text = "ÇARŞAMBA"; break;
                case 4: textBox2.Text = "PERŞEMBE"; break;
                case 5: textBox2.Text = "CUMA"; break;
                case 6: textBox2.Text = "CUMARTESİ"; break;
                case 7: textBox2.Text = "PAZAR"; break;
            }

        }
         //  "||" SEMBOLU YADA DEMEK   "&&" VE DEMEK " != " EŞİT DEĞİL YANİ BOŞ DEĞİLSE DEMEK. "\n" alt alta yazdırmak için.
        // "\t" yan yana boşluk bırakmak için .
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("SAYI1 VEYA SAYI2 VEYA BOŞ BIRAKMA");
            }
                
            else
            {
                int a, b,c , toplam;
                a = Convert.ToInt32(textBox3.Text);
                b = Convert.ToInt32(textBox4.Text);
                c = Convert.ToInt32(textBox5.Text);
                toplam = a + b + c ;
                MessageBox.Show("SAYIALRIN TOPLAMI \n\n\t"+ toplam);
            
           }
        }

        
    }
}
