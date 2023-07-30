using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4.SORU
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
                if (sayi % 6 == 0)
                {
                    MessageBox.Show("sayı tam bölünür");
                }
                else
                {
                    MessageBox.Show("tam bölünmez");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("hatalı tuslama lütfen sayı giriniz");
            }
            finally
            { 
            textBox1.Clear ();
            }
            

        }
    }
}
