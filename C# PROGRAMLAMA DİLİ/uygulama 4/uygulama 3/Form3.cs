using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulama_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 2)
            {
                MessageBox.Show("İKİ  BASAMAKLI DEĞER GİRMEDİNİZ");
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 fakt = 1;
                int sayi = Convert.ToInt32(textBox1.Text.Trim());
                if (sayi >= 0 && sayi <= 49)
                {
                    for (int i = 1; i <= sayi; i++)
                    {
                        //fakt=fakt*i;
                        fakt *= i;
                    }
                    MessageBox.Show("SAYININ FAKTORİYELİ :" + fakt);
                }
                else
                {
                    MessageBox.Show("0-49 ARASI BİR SAYI GİRİNİZ ");
                }
            }
            catch(Exception mesaj)
            {
                MessageBox.Show("LUTFEN SAYI GİRİNİZ :\n\n"+mesaj);
            }
            finally
            {
                textBox1.Clear();
                textBox1.Clear();
            }
        }
    }
}
