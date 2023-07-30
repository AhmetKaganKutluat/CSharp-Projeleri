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
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace _1.SORU_DENEME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bilgiler.accdb");
        
        private void guncelle()
        {           
            OleDbDataAdapter  komut = new OleDbDataAdapter("SELECT * FROM müsteriler", baglan);  
            DataTable tablo = new DataTable();
            komut.Fill(tablo);  
            dataGridView1.DataSource = tablo;           
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        DialogResult soru;
        private void button1_Click(object sender, EventArgs e)
        {

            
            if (textBox1.Text == "")
            {
                MessageBox.Show("ADI KISMI BOŞ BIRAKILAMAZ");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("SOYADI KISMI BOŞ BIRAKILAMAZ");
            }
            else
            {
                soru = MessageBox.Show("KAYIT EDİLSİN Mİ =?","KAYIT",MessageBoxButtons.YesNo );
                if (soru == DialogResult.Yes)
                {
                    baglan.Open();
                    OleDbCommand cek = new OleDbCommand("select * from müsteriler where ADI='"+textBox1.Text +"' and SOYADI='"+textBox2.Text +"'",baglan);
                    OleDbDataReader oku = cek.ExecuteReader();
                    if (oku.Read())
                    { 
                        MessageBox.Show("AYNI İSİM SOYİSİMLİ KAYIT VARDIR"); 
                        temizle(); 
                    }
                    else
                    {
                        OleDbCommand kayit = new OleDbCommand("insert into müsteriler(ADI,SOYADI,ILCE,URUN,BIRIMFIYAT,ADET,TOPLAMBORC,SATISTARIHI) values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "','" + textBox4.Text + "','"+dateTimePicker1.Value.ToShortDateString()+"')", baglan);
                        kayit.ExecuteNonQuery();
                        
                    }
                    baglan.Close();
                    guncelle();
                    temizle();
                }
                else
                {
                    temizle();  
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            guncelle();

            StreamReader dosya;
            String okunan;
                dosya = File.OpenText("iller.txt");
                while(((okunan=dosya.ReadLine())!=null))
                {
                comboBox1.Items.Add(okunan);
                }
            
            

                for (int i = 2; i <= 8; i++)
                {
                    comboBox4.Items.Add(i);
                }

                    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand cek = new OleDbCommand("SELECT ANKARA FROM ilçeler",baglan);
                OleDbDataReader oku = cek.ExecuteReader();
                
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["ANKARA"]);
                }
                baglan.Close();

            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand cek = new OleDbCommand("SELECT ISTANBUL FROM ilçeler", baglan);
                OleDbDataReader oku = cek.ExecuteReader();

                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["ISTANBUL"]);
                }
                baglan.Close();

            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand cek = new OleDbCommand("SELECT IZMIR FROM ilçeler", baglan);
                OleDbDataReader oku = cek.ExecuteReader();

                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["IZMIR"]);
                }
                baglan.Close();

            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                {
                checkBox2.Checked=false;
                comboBox3.Items.Clear();

                baglan.Open();
                OleDbCommand cek = new OleDbCommand("SELECT BAY FROM ürünler", baglan);
                OleDbDataReader oku = cek.ExecuteReader();

                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["BAY"]);
                }
                baglan.Close();

                

                }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                comboBox3.Items.Clear();

                baglan.Open();
                OleDbCommand cek = new OleDbCommand("SELECT BAYAN FROM ürünler", baglan);
                OleDbDataReader oku = cek.ExecuteReader();

                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["BAYAN"]);
                }
                baglan.Close();



            }
        }

        int  adet, adetfiyat;


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                adet = Convert.ToInt32(comboBox4.Text);
                adetfiyat = Convert.ToInt32(textBox3.Text);
                
                textBox4.Text = (adet * adetfiyat).ToString();
            }
        }
        public static  string adi, soyadi;
        private void button2_Click(object sender, EventArgs e)
        {
            adi = Interaction.InputBox("ÖDEME YAPILACAK KİŞİNİN ADINI GİRİN ..", "ÖDEME", "Buraya Giriniz ...");
            soyadi = Interaction.InputBox("ÖDEME YAPILACAK KİŞİNİN SOYADINI GİRİN ..", "ÖDEME", "Buraya Giriniz ...");
            baglan.Open();
            OleDbCommand cek = new OleDbCommand("select * from müsteriler where ADI='"+adi+"' and SOYADI='"+soyadi+"'",baglan);
            OleDbDataReader oku = cek.ExecuteReader();
            if (oku.Read())
            { 

            Form2 ac = new Form2();
            ac.ShowDialog();
            }
                
            else
            {
                MessageBox.Show("ARAnılan kayıt bulunamadı ..!"); 
            }
            baglan.Close();
        }
        public static string ad1, soyad1;
        private void button4_Click(object sender, EventArgs e)
        {
            ad1 = Interaction.InputBox("GÜNCELLEME YAPILACAK KİŞİNİN ADINI GİRİN ..", "ÖDEME", "Buraya Giriniz ...");
            soyad1 = Interaction.InputBox("GÜNCELLEME YAPILACAK KİŞİNİN SOYADINI GİRİN ..", "ÖDEME", "Buraya Giriniz ...");
            baglan.Open();
            OleDbCommand cek = new OleDbCommand("select * from müsteriler where ADI='" + ad1 + "' and SOYADI='" + soyad1 + "'", baglan);
            OleDbDataReader oku = cek.ExecuteReader();
            if (oku.Read())
            {
                Form3.cekadi = oku["ADI"].ToString();
                Form3.ceksoyadi = oku["SOYADI"].ToString();
                Form3.ilce = oku["ILCE"].ToString();
                Form3.urun = oku["URUN"].ToString();
                Form3.birimfiyat = oku["BIRIMFIYAT"].ToString();
                Form3.adet = oku["ADET"].ToString();
                Form3.toplamborc = oku["TOPLAMBORC"].ToString();
                Form3.satıstarihi = oku["SATISTARIHI"].ToString();
                Form3 ac = new Form3();
                ac.ShowDialog();
            }

            else
            {
                MessageBox.Show("ARAnılan kayıt bulunamadı ..!");
            }
            baglan.Close();
        }

        private void kAYITİNCELEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 ac = new Form4();
            ac.ShowDialog();
        }
    }
}
