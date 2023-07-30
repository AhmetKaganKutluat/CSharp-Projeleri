using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Şifre_Türetme__5_hafta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Random rasgele = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
           // int sayi;
          //  sayi = rasgele.Next(15);
           // textBox1.Text = sayi.ToString();

            Random rasgele = new Random();
            StringBuilder sb = new StringBuilder();

            int i;
            for (i = 0; i <= 7; i++)
            {
                int ascii = rasgele.Next(65,90);
                char karakter = Convert.ToChar(ascii);
                sb.Append(karakter);
            }

            textBox1.Text = sb.ToString();
        
        
        
        }
    }
}
