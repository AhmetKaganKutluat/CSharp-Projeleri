using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");


        int sayac = 3;
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")  // boş değilse ! o anlama geliyo
            {

                baglan.Open();

                OleDbCommand vericek = new OleDbCommand
                    ("SELECT * FROM kullanicilar WHERE KULLANICI='" + textBox1.Text.Trim() + "' AND SIFRE='" + textBox2.Text.Trim() + "'", baglan);

                OleDbDataReader oku = vericek.ExecuteReader();

                if (oku.Read() == true)
                {
                    Form2 goster = new Form2();
                    goster.ShowDialog();
                }
                else
                {
                    sayac = sayac - 1;

                    MessageBox.Show("KULLANICI ADI VEYA SIFREDE HATA VAR...    TEKRAR DENEYİNİZ KALAN HAKKINIZ  :" + sayac);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();

                    if (sayac == 0)
                    {
                        Application.Exit();
                    }

                }


                baglan.Close();


            }
            else
            {
                MessageBox.Show("KULLANICI ADI VE ŞİFRE BOŞ BIRAKILAMAZZ.");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text ="KULLANICI PANELİ    "+ DateTime.Now.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                textBox2.PasswordChar = '\0'; //orjinal olsun demek.burada \0 varsayılan neyse onu yazsın demek.
                
                
            }
            else
            {
                textBox2.PasswordChar = '*';

                
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
