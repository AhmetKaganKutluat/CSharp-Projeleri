using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true) // textbox 1 deki boşsa 
            {

                MessageBox.Show("yarıçap değerini giriniz ");

            }
            else
            {
                double yaricap = Convert.ToDouble(textBox1.Text.Trim());
                Class3 hesapla = new Class3();
               
                label2.Text = "dairenin alanı :  " + Math.Round(hesapla.alan(yaricap),2) ;
                label3.Text = "dairenin cevresi : " + Math.Round(hesapla.cevre(yaricap),2);

                textBox1.Clear();






            }
        }
    }
}
