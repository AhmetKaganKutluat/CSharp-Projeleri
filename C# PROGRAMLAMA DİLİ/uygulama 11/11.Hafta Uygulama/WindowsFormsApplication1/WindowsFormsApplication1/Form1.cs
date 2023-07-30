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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.PasswordChar = '\0'; //orjinal olsun demek.burada \0 varsayılan neyse onu yazsın demek.
            else textBox2.PasswordChar = '*'; //char olunca tek tırnak string olunca çift (tahmin ediyorum);
            
            
        }
        string kullanici = "AHMET"; string sifre = "KAGAN"; int sayac = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            if( textBox1.Text.Trim() == "")  MessageBox.Show("Lütfen Kullanıcı Adını Boş Bırakmayın ..");
            else if(textBox2.Text.Trim() =="") MessageBox.Show("Lütfen Şifreyi Boş Bırakmayın ..");
            else
            {
                
                if ((textBox1.Text.Trim() == kullanici) && (textBox2.Text.Trim() == sifre))
                {
                    Form2 goster1 = new Form2();
                    goster1.ShowDialog();
                    this.Close();

                }//ifin endi.
                else
                {
                    sayac = sayac - 1;
                    MessageBox.Show("Hatali Giris." + "KALAN HAK = " + sayac);
                    if (sayac == 0) { MessageBox.Show("Hakkıniz bitti.."); Application.Exit(); }// uygulamayı kapat demek //this.Close(); bu formu kapat demek;
                        
                    
                }//elsin endi.
            
            }
            
        }
    }
}
