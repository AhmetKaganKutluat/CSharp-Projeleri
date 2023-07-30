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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Random rastgele = new Random(); 
        public void uret() // genel heryerde çalışcan // void=procedure 
        {
            
            int sayi1 = rastgele.Next(100);
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ1234567890";
            string uret = "";
            for (int i = 0; i < 6; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }
            textBox1.Text = uret;

        }
        private void temizle()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

             foreach (Control item in this.Controls)
    {

        if (item is TextBox)

        {
            TextBox tbox = (TextBox)item;
            tbox.Clear();

        }//ifin endi

    }//foreachın endi


            
            foreach (Control ctl in this.Controls)
                if (ctl is GroupBox)
                //Dolaşmaya başla
                {
                    foreach (Control karakterim in ctl.Controls)
                    {
                      
                        if (karakterim is CheckBox)
                        {

                            CheckBox cbox = new CheckBox();
                            cbox = (CheckBox)karakterim;

                            cbox.Checked = false;
                        }
                        
                    }
                }

             uret();

        }//temizle voidinin endi.







        public static Boolean acik;
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("ANKARA");
            comboBox2.Items.Add("İSTANBUL");
            comboBox2.Items.Add("ANTALYA");
            comboBox1.Items.Add("METE HAN");
            comboBox1.Items.Add("CENGİZ HAN");
            comboBox1.Items.Add("FATİH MEHMET");
            comboBox1.Items.Add("KÜRŞAT");
            comboBox1.Items.Add("ALPARSLAN");
            uret();
            acik = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            acik = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uret();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)  textBox3.Focus();


           
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)textBox2.Focus();


           
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox2.Text == "ANKARA")
            {
                comboBox3.Items.Add("KEÇİÖREN");
                comboBox3.Items.Add("ÇANKAYA");
                comboBox3.Items.Add("SİNCAN");
                comboBox3.Items.Add("POLATLI");
                comboBox3.Items.Add("OVACIK");
            }
            if (comboBox2.Text == "İSTANBUL")
            {
                comboBox3.Items.Add("PENDİK");
                comboBox3.Items.Add("KARTAL");
                comboBox3.Items.Add("BOSTANCI");
                comboBox3.Items.Add("KADIKÖY");
                comboBox3.Items.Add("İSTİKLAL");
            }
            if (comboBox2.Text == "ANTALYA")
            {
                comboBox3.Items.Add("MANAVGAT");
                comboBox3.Items.Add("SERİK");
                comboBox3.Items.Add("TİTREYENGÖL");
                comboBox3.Items.Add("ÇOLAKLI");
                comboBox3.Items.Add("KAŞ");
            }
        }
        string anketno,anketor, musteriad, musterisoyad, il, ilçe, soru;
        int  secim,sorgu;
        private void button1_Click(object sender, EventArgs e)
        {
            if((checkBox1.Checked==true) || (checkBox2.Checked==true) || (checkBox3.Checked ==true) || (checkBox4.Checked==true))
            {
                soru = "1. SORU SEÇİLDİ";
            
            }
            if ((checkBox5.Checked == true) || (checkBox6.Checked == true) || (checkBox7.Checked == true) || (checkBox8.Checked == true))
            {
                soru = "2. SORU SEÇİLDİ";

            }
            if ((checkBox1.Checked == true) || (checkBox5.Checked == true))
            {
                secim = 1;

            }
                if ((checkBox2.Checked == true) || (checkBox6.Checked == true))
            {
                secim = 2;
            
            }
                if ((checkBox3.Checked == true) || (checkBox7.Checked == true))
            {
                secim = 3;
            
            }
                if ((checkBox4.Checked == true) || (checkBox8.Checked == true))
            {
                secim = 4;
            
            }

                anketno = textBox1.Text;
                anketor = comboBox1.Text;
                musteriad = textBox2.Text;
                musterisoyad = textBox3.Text;
                il = comboBox2.Text;
                ilçe = comboBox3.Text;
                sorgu = Convert.ToInt16(MessageBox.Show(musteriad +" "+musterisoyad+" "+"Kayıt Yapılsın mı ? ", "KAYIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2));
                if (sorgu == 6)
                {
                    //MessageBox.Show(anketno+anketor+musteriad+musterisoyad+il+ilçe+soru+secim );
                    listBox1.Items.Add("ANKET NO = "+anketno +" "+"ANKETÖR = "+anketor+" "+"MÜŞTERİ ADI = "+musteriad+" "+"MÜŞTERİ SOYADI = "+musterisoyad +" "+"İLİ = "+il+" "+"İLÇESİ= "+ilçe+" "+"SORU SEÇİM = "+soru +" "+"CEVABI= "+secim);
                    temizle();
                }//EVETİN ENDİ
                if (sorgu == 7)
                {
                    temizle();
                }//hayırın sonu 

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox1.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = ("Sisteme Yüklü Kayıt Sayısı = " +(listBox1.SelectedIndex +1 ).ToString()+ " / " + listBox1.Items.Count);
          
        }

        private void seçiliKaydıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        
    }
}
