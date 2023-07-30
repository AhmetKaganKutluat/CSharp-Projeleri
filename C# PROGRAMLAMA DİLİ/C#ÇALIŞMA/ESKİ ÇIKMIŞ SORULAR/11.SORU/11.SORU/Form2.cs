using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _11.SORU
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void temizle()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox1.Focus();
            checkBox1.Checked = false;
            checkBox2.Checked = false;

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
        
        private void Form2_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("BİLGİSAYAR BÖLÜMÜ");
            comboBox1.Items.Add("İŞLETME BÖLÜMÜ");
            comboBox1.Items.Add("MUHASEBE BÖLÜMÜ");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text == "BİLGİSAYAR BÖLÜMÜ")
            {
                var ogretmen = File.ReadLines(@"ogretimelemani1.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox2.Items.Add(isim);
                }
            } //if endi

            if (comboBox1.Text == "İŞLETME BÖLÜMÜ")
            {
                var ogretmen = File.ReadLines(@"ogretimelemani2.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox2.Items.Add(isim);
                }
            } //if endi

            if (comboBox1.Text == "MUHASEBE BÖLÜMÜ")
            {
                var ogretmen = File.ReadLines(@"ogretimelemani3.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox2.Items.Add(isim);
                }
            } //if endi

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)

            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox2.Text == "METE HAN")
            {
                var ogretmen = File.ReadLines(@"ders1.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi


            if (comboBox2.Text == "CENGİZ HAN")
            {
                var ogretmen = File.ReadLines(@"ders2.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi


            if (comboBox2.Text == "TİMUR HAN")
            {
                var ogretmen = File.ReadLines(@"ders3.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi


            if (comboBox2.Text == "KÜRŞAT HAN")
            {
                var ogretmen = File.ReadLines(@"ders4.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi
            if (comboBox2.Text == "ALPARSLAN HAN")
            {
                var ogretmen = File.ReadLines(@"ders5.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi
            if (comboBox2.Text == "BEYAZIT HAN")
            {
                var ogretmen = File.ReadLines(@"ders6.txt");
                foreach (var isim in ogretmen)
                {
                    comboBox3.Items.Add(isim);
                }
            } //if endi
        }
        double tcno, yaz1, yaz2, yaz3, söz1, söz2, yazort, sozort, ortalama;
        string adı, soyadı, bölüm, ogretmen, ders, sınıf, harfnotu;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(checkBox1.Checked==true)
            {
                sınıf = "1.SINIF";
            }
            if (checkBox2.Checked == true)
            {
                sınıf = "2.SINIF";
            }
            tcno = Convert.ToDouble(textBox1.Text);
            adı = textBox2.Text;
            soyadı = textBox3.Text;
            bölüm = comboBox1.Text;
            ogretmen = comboBox2.Text;
            ders = comboBox3.Text;
            yaz1 = Convert.ToDouble(textBox4.Text);
            yaz2 = Convert.ToDouble(textBox5.Text);
            yaz3 = Convert.ToDouble(textBox8.Text);
            söz1 = Convert.ToDouble(textBox6.Text);
            söz2 = Convert.ToDouble(textBox7.Text);

            yazort = (((yaz1 + yaz2 + yaz3)/3) / 100) * 70;
            sozort= (((söz1+söz2)/2 )/100)*30;
            ortalama = yazort + sozort;

            if((ortalama>0)&&(ortalama<44))
            {
            harfnotu="FF";
            }
            if ((ortalama > 45) && (ortalama < 64))
            {
                harfnotu = "CD";
            }
            if ((ortalama > 65) && (ortalama < 74))
            {
                harfnotu = "BC";
            }
            if ((ortalama > 75) && (ortalama < 84))
            {
                harfnotu = "BB";
            }
            if ((ortalama > 85) && (ortalama < 90))
            {
                harfnotu = "BA";
            }
            if ((ortalama > 91) && (ortalama < 100))
            {
                harfnotu = "AA";
            }

            listBox1.Items.Add((listBox1.Items.Count+1)+ "- "+tcno +"       "+adı +"       "+ soyadı + "       " +bölüm + "       "+ogretmen +"       "+ders + "       "+sınıf + "       "+ ortalama + "       "+harfnotu );




            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text = "TOPLAM KAYIT SAYISI = "+listBox1.Items.Count.ToString() ;
            if (textBox1.Text == "")
            {
                label14.Enabled = true;
            }
            if (textBox2.Text == "")
            {
                label15.Enabled = true;
            }
            if (textBox3.Text == "")
            {
                label16.Enabled = true;

            }


            if  (textBox1.Text != "")
            {
                label14.Enabled = false ;
            }
            if (textBox2.Text != "")
            {
                label15.Enabled = false;
            }
            if (textBox3.Text != "")
            {
                label16.Enabled = false;

            } 


        }
        Int16 cik;
        private void button2_Click(object sender, EventArgs e)
        {
            cik = Convert.ToInt16(MessageBox.Show("Program Kapatılsın mı ? ", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button2));

            if (cik == 6) // eğer 6 yani evet seçilirse yap
            {
                
                Application.Exit();
            }
            else         //eğer 6 değilse yani 7 yse yani hayırsa
            {
                MessageBox.Show("ÇIKIŞ GERÇEKLEŞMEDİ !");  // ekrana mesaj verdik.
            }
        }

        private void sİSTEMEKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(button1, new EventArgs());

        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(button2, new EventArgs());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "KAYIT FORMU     ---   " + DateTime.Now;
        }

      

    

        
    }
}
