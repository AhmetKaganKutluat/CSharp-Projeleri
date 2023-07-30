using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulama2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Int64 faktoriyel(Int64 sayi)
        {
            int fakt = 1;
            for (int i = 1; i <= sayi; i++)
            {
                fakt = fakt * i;
            }
            return fakt;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Int64 sayi = Convert.ToInt64(textBox1.Text);
                if (sayi > 0 && sayi <= 8)
                {
                    textBox2.Text = sayi + "! =" + faktoriyel(sayi);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("hatalı giriş");
            }
            finally
            {
                textBox1.Clear();
            }
            
        }
    }
}
