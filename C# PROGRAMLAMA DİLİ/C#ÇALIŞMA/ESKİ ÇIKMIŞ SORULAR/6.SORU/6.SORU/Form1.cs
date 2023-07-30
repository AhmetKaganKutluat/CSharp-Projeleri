using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secim = Convert.ToInt16 (textBox1.Text);
            if (secim < 1  || secim > 12)
            {
                MessageBox.Show("DEĞER ARALIĞI YANLIŞ GİRDİNİZ");
                textBox1.Clear();
            }
            else
            {
                switch (secim)
                {
                    case 1: MessageBox.Show("OCAK \nJANUARY"); textBox1.Clear(); break;
                    case 2: MessageBox.Show("ŞUBAT \nFEBRUARY"); textBox1.Clear(); break;
                    case 3: MessageBox.Show("MART \nMARCH"); textBox1.Clear(); break;
                    case 4: MessageBox.Show("NİSAN \nAPRİL"); textBox1.Clear(); break;
                    case 5: MessageBox.Show("MAYIS \nMAY"); textBox1.Clear(); break;
                    case 6: MessageBox.Show("HAZİRAN \nJUNE"); textBox1.Clear(); break;
                    case 7: MessageBox.Show("TEMMUZ \nJULY"); textBox1.Clear(); break;
                    case 8: MessageBox.Show("AĞUSTOS \nAUGUST"); textBox1.Clear(); break;
                    case 9: MessageBox.Show("EYLÜL \nSEPTEMBER"); textBox1.Clear(); break;
                    case 10: MessageBox.Show("EKİM \nOCTOBER"); textBox1.Clear(); break;
                    case 11: MessageBox.Show("KASIM \nNOVEMBER"); textBox1.Clear(); break;
                    case 12: MessageBox.Show("ARALIK \nDECEMBER"); textBox1.Clear(); break;
                    
                            
                }

            }    
               
        }
    }
}
