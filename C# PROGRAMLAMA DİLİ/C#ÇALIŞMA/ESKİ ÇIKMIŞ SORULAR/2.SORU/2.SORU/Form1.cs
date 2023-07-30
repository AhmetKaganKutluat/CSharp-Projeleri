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

namespace _2.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int toplam = 0; double ortalama = 0;
            int i;
            for (i = 1; i <= 5; i++)
            {
                toplam += Convert.ToInt32(Interaction.InputBox(i + "  .  SAYIYI GİRİNİZ ?", "SAYI GİRİŞİ", "BURAY YAZINIZ"));

            }
            ortalama = toplam / 5;
            MessageBox.Show("SAYILARIN TOPLAMI :" + toplam + "\nSAYILARIN ORTALAMASI : " + ortalama);



        }
    }
}
