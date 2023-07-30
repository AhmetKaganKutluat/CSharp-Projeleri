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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte a = Convert.ToByte(textBox1.Text);
                byte b = Convert.ToByte(textBox2.Text);
                int c = a + b;
                MessageBox.Show("SAYILARIN TOPLMAMI :" + c);
            }
            catch (FormatException hata1)
            {
                MessageBox.Show("LUTFEN TEXT ALANLARINA SAYI GİRİNİZ\n\n" + hata1);
            }
            catch(OverflowException hata2)
            {
                MessageBox.Show("0-255 ARASI SAY GİRİLMEDİ\n\n"+hata2);
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
