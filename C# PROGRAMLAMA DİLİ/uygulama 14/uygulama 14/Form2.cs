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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int sayilar; // DİZİSİZ YAPIMI 
        private void button1_Click(object sender, EventArgs e)
        {
            // input bas için yukarı kütüphane ekleriz sonra referance bölümünde sağ tuş add refarecne
            int toplam = 0; double ortalama = 0.0;
            int i;

            for (i = 0; i <= 4; i++) 
            {
                sayilar= Convert.ToInt32(Interaction.InputBox(i + 1+ ".  sayıyı giriniz", "SAYILARI GİRİNİZ", "buraya yazınız"));
                toplam = sayilar + toplam;
            }
            ortalama = toplam / 5;
            MessageBox.Show("SAYILARIN TOPLAMI " + toplam + "\nSAYILARIN ORTALAMASI " + ortalama);
        }
    }
}
