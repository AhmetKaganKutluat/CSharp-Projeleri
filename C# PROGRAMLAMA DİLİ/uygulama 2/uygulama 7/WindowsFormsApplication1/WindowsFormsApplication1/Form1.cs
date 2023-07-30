using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection
            ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 97 || e.KeyChar > 122) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (e.KeyChar == 13)
            { textBox2.Focus(); }

                
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 97 || e.KeyChar > 122) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (e.KeyChar == 13)
            { textBox3.Focus(); }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else { e.Handled = false; }
        }

        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();        
        }

        void dusuksifre()
        {
            string dusuk = "";
            Random sayi1 = new Random();
            char[] karakter1 = "QWERTZXCJKMKLHNBVYUOP".ToArray();
            for (int i = 1; i <= 4; i++)
            {
                dusuk += karakter1[sayi1.Next(karakter1.Length)];
                textBox4.Text = dusuk;
            }
        
        }
        void ortasifre()
        {
            string orta = "";
            Random sayi2 = new Random();
            char[] karakter2 = "QWERTZXCJKMKLHNBVYUOP0123456789".ToArray();
            for (int i = 1; i <= 8; i++)
            {
                orta += karakter2[sayi2.Next(karakter2.Length)];
                textBox4.Text = orta;
            }
        }
        void yukseksifre()
        {
            string yuksek = "";
            Random sayi3 = new Random();
            char[] karakter3 = "QWERTZXCJKMKLHNBVYUOP0123456789/*-+(){[]}?%&".ToArray();
            for (int i = 1; i <= 12; i++)
            {
                yuksek += karakter3[sayi3.Next(karakter3.Length)];
                textBox4.Text = yuksek ;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            goster();
            baglan.Open();
            OleDbCommand duzeycek = new OleDbCommand("select * from duzey",baglan);
            OleDbDataReader duzeyara = duzeycek.ExecuteReader();

            while(duzeyara.Read())
            {
                comboBox1.Items.Add(duzeyara["duzeyler"]);
            }

            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { dusuksifre(); }
            if (comboBox1.SelectedIndex == 1)
            { ortasifre(); }
            if (comboBox1.SelectedIndex == 2)
            { yukseksifre(); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        void goster()
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter veri = new OleDbDataAdapter("select * from musteriler",baglan);
            veri.Fill(tablo);
            dataGridView1.DataSource = tablo;

            /////KALAN BORÇ ÖDEMESİ//////

            baglan.Open();

            for (int i = 0; i<dataGridView1.Rows.Count; i++)
            {

                OleDbCommand odeara = new OleDbCommand ("SELECT SUM(ODEME_MIKTARI) from odemeler WHERE ADI='"+
                    dataGridView1.Rows[i].Cells["column2"].Value.ToString() + "' and SOYADI='" +
                    dataGridView1.Rows[i].Cells["column3"].Value.ToString() + "'", baglan);

                OleDbDataReader odeoku = odeara.ExecuteReader();
                dataGridView1.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells["column4"].Value;

                if (odeoku.Read())
                {
                    if (odeoku[0].ToString() != "")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = (Convert.ToInt32(dataGridView1.Rows[i].Cells["column4"].Value) - Convert.ToInt32(odeoku[0].ToString()));

                    }
                
                }
                    baglan.Close();                        

            }    




                
        }
        DialogResult soru;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
             MessageBox.Show("Müşterinin adını girinizz ..!"); 
            else 
                if(textBox2.Text.Trim()=="")
                    MessageBox.Show("Müşterinin soyadını girinizz ..!");
                else
                    if(textBox3.Text.Trim()=="")
                        MessageBox.Show("Müşterinin toplam borcunu girinizz ..!");
                    else
                        if (textBox4.Text.Trim() == "")
                            MessageBox.Show("Müşterinin şifresini girinizz ..!");
                        else
                        { ///KAYIT YERİ

                            baglan.Open();
                            OleDbCommand kayit = new OleDbCommand("select * from musteriler where ADI='"+textBox1.Text +"' and SOYADI='"+textBox2.Text +"'",baglan);
                            OleDbDataReader kayıtoku = kayit.ExecuteReader();
                            if (kayıtoku.Read())
                                MessageBox.Show("Aynı isim ve soyisimli kayıt vardır.Lütfen yeni kayıt girin");
                            else
                            {
                                soru  = MessageBox.Show(textBox1.Text + " " + textBox2.Text + " kişisinin " + textBox3.Text + " T.L. borç kaydı yapılsın mı?","BORÇ KAYDI",MessageBoxButtons.YesNo);
                                if (soru == DialogResult.Yes)
                                {
                                    OleDbCommand ekle = new OleDbCommand("insert into musteriler(OZEL_SIFRE,ADI,SOYADI,TOPLAM_BORC,YUKLEME_TARIHI) values('"+textBox4.Text +"','"+textBox1.Text +"','"+textBox2.Text +"','"+textBox3.Text +"','"+DateTime.Now.ToString()+"')", baglan);
                                    ekle.ExecuteNonQuery();
                                    MessageBox.Show("Tüm Bilgiler Sisteme Başarı ile Kaydedildi ..!");           
                                }
                            }

                            temizle();
                            baglan.Close();
                            goster();
                            
                        }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int satir = dataGridView1.CurrentCell.RowIndex;
            string odead, odesoyad, silad, silsoyad, silborc;
            odead=dataGridView1.Rows[satir].Cells[2].ToString();
            odesoyad = dataGridView1.Rows[satir].Cells[3].ToString();
            

            try 
            {
                int miktar = Convert.ToInt32(Interaction.InputBox("ÖDEME YAPMAK İSTEDİĞİNİZ MİKTARI GİRİNİZ ..!","ödeme miktarı"));
                if (miktar < 0) MessageBox.Show("Doğru bilgi giriniz");
                else
                    if (miktar < Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value))
                    {
                        MessageBox.Show("Ödenecek tutar toplam tutardan büyük olamaz ..!", "BİLGİ !", MessageBoxButtons.OK);
                    }
                    else
                    {
                        baglan.Open();
                        OleDbCommand odeme = new OleDbCommand("insert into odemelertablosu(ADI,SOYADI,ODEME_MIKTARI,ODEME_TARIHI) values('"+odead+"','"+odesoyad+"','"+miktar+"','"+DateTime.Now.ToShortDateString()+"')",baglan);
                        odeme.ExecuteNonQuery();
                        baglan.Close();
                        goster();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)<=0)
                            {
                                silad = dataGridView1.Rows[i].Cells["ADI"].Value.ToString();
                                silsoyad = dataGridView1.Rows[i].Cells["SOYADI"].Value.ToString();
                                silborc = dataGridView1.Rows[i].Cells["TOPLAM_BORC"].Value.ToString();
                                baglan.Open();
                                OleDbCommand bitenisil = new OleDbCommand("delete from musteriler where ADI='"+silad+"' and SOYADI='"+silsoyad+"' ",baglan);
                                bitenisil.ExecuteNonQuery();

                                OleDbCommand biteniekle = new OleDbCommand("insert into odemesibitenler(ADI,SOYADI,TOPLAM_BORC) values('"+silad+"','"+silsoyad+"','"+silborc+"')",baglan);
                                biteniekle.ExecuteNonQuery();
                                baglan.Close();
                                goster();
                            }
                        }

                        StreamWriter kaydet = new StreamWriter("odemeler.txt",true,Encoding.Default);
                        kaydet.WriteLine(odead+" "+odesoyad+"  İsimli kişi  "+miktar+" T.L. ücreti  "+DateTime.Now.ToString()+" tarihinde ödedi.");
                        kaydet.Close();

                    }//else sonu
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
            finally 
            {
            
            }

        }
    }
}
