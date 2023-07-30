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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "KULLANICI GİRİŞİ     ---   " + DateTime.Now;

        }
        int sayac = 3;
        private void button1_Click(object sender, EventArgs e)
        {
           

                StreamWriter kaydet;
                kaydet = File.AppendText("girişler.txt");
                kaydet.WriteLine(textBox1.Text + "\t\t" + DateTime.Now);
                kaydet.Close();


                textBox2.PasswordChar = '\0';//yoksa * alıyor.
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
        
        int sayac1;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sayac1 = sayac1 + 1;
                if (sayac1 == 3)  //3 kere checkboxu aktif edince full görünür oluyor.
                {

                    checkBox1.Enabled = false;
                
                }
                textBox2.PasswordChar = '\0'; //orjinal olsun demek.burada \0 varsayılan neyse onu yazsın demek.
            }
            else textBox2.PasswordChar = '*'; //char olunca tek tırnak string olunca çift (tahmin ediyorum);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 64 || e.KeyChar < 90 && e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form3.durum = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3.durum = false;
        }
    }
}
