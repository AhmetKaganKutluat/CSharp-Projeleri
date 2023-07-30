using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static Boolean durum ;
        Random rastgele = new Random();
        private void Form3_Load(object sender, EventArgs e)
        {
            durum = true;
          
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ1234567890";
            string uret = "";
            for (int i = 0; i < 8; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            textBox1.Text = uret;

           

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            durum = false;
        }

        void hesapla(RadioButton secilen) //radiobutona isim verdik 
        {

            if (secilen.Checked==true) //radiobutonların hepsinde gönderdiğimiz secılmısse 
            {
                dogru++;

            }
            else
            {
                yanlış++;
            }

            label1.Text = "Doğru sayısı = " + dogru;
            label2.Text = "Yanlış sayısı = " + yanlış;
        
        }//voidin endi;
        int dogru = 0; int yanlış = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            dogru = 0; yanlış = 0;
            hesapla(radioButton4);
            hesapla(radioButton9);
            hesapla(radioButton12);
            hesapla(radioButton18);
            hesapla(radioButton25);
            DialogResult sor;
            sor = MessageBox.Show("Anket Bilgileri Kaydedilsin Mi?", "Kayıt Yapma", MessageBoxButtons.YesNo);
            if (sor == DialogResult.Yes)
            {
                StreamWriter kaydet;
                kaydet = File.AppendText("anket/anketler.txt");
                kaydet.WriteLine(textBox1.Text + "\t\t" + textBox2.Text + "\t\t" + textBox3.Text + "\t\t" + dogru + "\t\t"+yanlış);
                kaydet.Close();
                MessageBox.Show("BİLGİLER BAŞARIYLA KAYDEDİLDİ ");
            
            }//if endi.
           
            foreach (Control item in groupBox1.Controls)
            { 
             if(item is RadioButton)
                {
                  radioButton1.Checked=false;
                  radioButton2.Checked = false;
                  radioButton3.Checked = false;
                  radioButton4.Checked = false;
                  radioButton5.Checked = false;
                  radioButton6.Checked = false;
                  radioButton7.Checked = false;
                  radioButton8.Checked = false;
                  radioButton9.Checked = false;
                  radioButton10.Checked = false;
                  radioButton11.Checked = false;
                  radioButton12.Checked = false;
                  radioButton13.Checked = false;
                  radioButton14.Checked = false;
                  radioButton15.Checked = false;
                  radioButton16.Checked = false;
                  radioButton17.Checked = false;
                  radioButton18.Checked = false;
                  radioButton19.Checked = false;
                  radioButton20.Checked = false;
                  radioButton21.Checked = false;
                  radioButton22.Checked = false;
                  radioButton23.Checked = false;
                  radioButton24.Checked = false;
                  radioButton25.Checked = false;
                  
                }
}//foreach sonu

            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ1234567890";
            string uret = "";
            for (int i = 0; i < 8; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            textBox1.Text = uret;
            textBox2.Clear();
            textBox3.Clear();


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rbuton in this.Controls.OfType<RadioButton>())
            {
                rbuton.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control itemm in groupBox1.Controls)
            {
                if (itemm is RadioButton)
                {
                    radioButton1.Checked = false;


                }
            }
        }
    }
}
