using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                int sayi;
                sayi = Convert.ToInt16(textBox1.Text);
                if (sayi >= 1 && sayi <= 17)
                {
                    int sonuc = 1;
                    for (int i = 1; i <= sayi; i++)
                    {
                        sonuc = sonuc * i;
                    }
                    MessageBox.Show(sonuc.ToString());
                }
                else 
                {

                    MessageBox.Show("geçersiz sayı");
                }
               
               
            }
            catch
            {
                MessageBox.Show("farklı karakter tuşlandı");
            }
            finally
            {
                textBox1.Clear();
            }
        }
    }
}
