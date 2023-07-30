using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace uygulama_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] sayilar = new int[5];  // DİZİLİ YAPIMI
        private void button1_Click(object sender, EventArgs e)
        {
            // input bas için yukarı kütüphane ekleriz sonra referance bölümünde sağ tuş add refarecne
            int toplam = 0; double ortalama = 0.0;
            int i;

            for (i = 0; i <= 4; i++) // diziler gerçekte 0 dan başlar Version yoplam 5 eleamn olur
            {
                sayilar[i] = Convert.ToInt32(Interaction.InputBox(i + 1+".  sayıyı giriniz", "SAYILARI GİRİNİZ", "buraya yazınız"));
                toplam = sayilar[i] + toplam;
            }
            ortalama = toplam / 5;
            MessageBox.Show("SAYILARIN TOPLAMI " + toplam + "\nSAYILARIN ORTALAMASI " + ortalama);
        }
    }
}
