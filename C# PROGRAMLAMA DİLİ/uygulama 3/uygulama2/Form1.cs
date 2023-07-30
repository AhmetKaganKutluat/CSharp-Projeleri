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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char karakter;
            if (textBox1.Text != "") // boş değilse
            { // if başlangıç
                karakter = textBox1.Text[0];  // char tek karakter oldugu için döünüş yapmak zorundayız ve 0 karakter yani 1 karakter dır
                switch (karakter)
                { // switch başlangıç
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5': MessageBox.Show("0 - 5 aralığındaki sayı kullanıldı ."); break;
                    case 'a': 
                    case 'A': MessageBox.Show("3+5 ="+ (3 + 5).ToString()); break;
                    case '9':
                        {

                            
                            break;

                        }


                    default:  MessageBox.Show("YANLIŞ TUŞLAMA"); break; 
                 
                } // switch bitiş
            } // if bitiş
            else
            { // else başlangıç
                MessageBox.Show("text alanına bir karakter giriniz.");
            } // else bitiş 
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeniform = new Form2();
            yeniform.ShowDialog();
        }
    }
}
