using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Microsoft.VisualBasic;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source = bilgiler.accdb");
        void temizle()
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
            pictureBox1.Image = null;
        }
        void guncelle()
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter dt = new OleDbDataAdapter("select OZELSIFRE,ADI,SOYADI,URUN,BIRIMFIYAT,ADET,SATISTURU,TOPLAMFIYAT,SATISTARIHI from musterıler", baglan);
            dt.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        Random rastgele = new Random();
        public string sonsifre = "";
        string tarih = "";
        void sifre()
        {
            int sayi1 = rastgele.Next(100);
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ01234567899876543210123456879";
            string uret = "";           
            for (int i = 0; i < 6; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];                
            }
            tarih = DateTime.Now.Year.ToString();
            sonsifre = tarih + uret;
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            guncelle();
            sifre();
            
            for (int i = 1; i <= 8; i++)
            {
                comboBox4.Items.Add(i);
            }
            ////////////////////////////////////////
            StreamReader dosya = File.OpenText("iller.txt");
            while (!dosya.EndOfStream)
            {
                string yazi = dosya.ReadLine();                
                comboBox1.Items.Add(yazi);               
            }
            //////////////////////////////////////
           
            baglan.Open();
            OleDbCommand cins = new OleDbCommand("select CINSIYET from cınsıyet",baglan);
            OleDbDataReader oku = cins.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["CINSIYET"]);
            }
                baglan.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                comboBox3.Items.Clear();
                baglan.Open();
                OleDbCommand cins = new OleDbCommand("select BAY from urun", baglan);
                OleDbDataReader oku = cins.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["BAY"]);
                }
                baglan.Close();
                
            }
            if (comboBox2.SelectedIndex == 1)
            {
                comboBox3.Items.Clear();
                baglan.Open();
                OleDbCommand cins = new OleDbCommand("select BAYAN from urun", baglan);
                OleDbDataReader oku = cins.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["BAYAN"]);
                }
                baglan.Close();
            }
        }
        int pesin;
        string satısturu;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            satısturu = "PEŞİN";
            if(checkBox1.Checked)
            {
                checkBox2.Checked = false;
            git:
            pesin =Convert.ToInt32(Interaction.InputBox("İndirim oranını kirin","İNDİRİM","Buraya giriniz ...",0));
                if (pesin > 40 && pesin < 0)
                {
                    MessageBox.Show("OLMAZ KARDEŞİM SAÇMALAMA VALLAHA KURTARMAZ YAV");
                    goto git;
                }
                else
                {
                    if (comboBox4.Text != null)
                    {
                        int satısfiyat, adet, toplamborc;
                        satısfiyat = Convert.ToInt32(textBox3.Text);
                        adet = Convert.ToInt32(comboBox4.Text);
                        toplamborc = (adet * satısfiyat) - ((adet * satısfiyat) * pesin) / 100;
                        textBox4.Text = toplamborc.ToString(); ;
                    }
                }
            }
        }
        int toplamborç,vade,taksitsayisi,taksittutarı;
        DateTime baslangıctarihi,taksittarihi;
        string alanlar = "";
        string taksitler = "";
        string[] aylar = new string[]
                     {
                    "","OCAK","ŞUBAT","MART","NİSAN","MAYIS","HAZİRAN",
                    "TEMMUZ","AĞUSTOS","EYLÜL","EKİM","KASIM","ARALIK"
                     };
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            satısturu = "VADE";
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            git:
                vade = Convert.ToInt32(Interaction.InputBox("Vade sayısını kirin", "VADE", "Buraya giriniz ...", 0));
                if (pesin > 8 && pesin < 2)
                {
                    MessageBox.Show("OLMAZ KARDEŞİM SAÇMALAMA VALLAHA KURTARMAZ YAV");
                    goto git;
                }
                else
                {
                    toplamborç = Convert.ToInt32(textBox3.Text) * Convert.ToInt32(comboBox4.Text);
                    taksitsayisi = vade;
                    taksittutarı = toplamborç / taksitsayisi;
                    baslangıctarihi = DateTime.Now;
                    textBox4.Text = toplamborç.ToString();
                    
                                       
                    
                }
            }
        }
        string resimyolu;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Lütfen resim seçiniz...";
            openFileDialog1.Filter = "JPEG Dosyası(*.jpeg)|*.jpeg|JPEG Dosyası(*.jpg)|*.jpg|Gif Dosyası(*.gif)|*.gif|PNG Dosyası(*.png)|*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                resimyolu = openFileDialog1.FileName;
            }
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            if (textBox2.Text == "" || textBox1.Text == "")
            { button1.Enabled = false; }
            else
            { button1.Enabled = true; }
        }
        DialogResult sor;
        int taksitlercek;
        private void button1_Click(object sender, EventArgs e)
        {
            sor = MessageBox.Show(textBox1.Text+" "+textBox2.Text+" müşterisine "+comboBox3.Text+" , "+textBox4.Text+" T.L. SAtılsın mı ?","SATIŞ",MessageBoxButtons.YesNo);
            if (sor == DialogResult.Yes)
            {
                for (int i = 1; i <= taksitsayisi; i++)
                {
                    taksittarihi = baslangıctarihi.AddMonths(i);

                    alanlar = aylar[taksittarihi.Month] + " ";

                    taksitler = taksittutarı.ToString("C") + " ";

                    taksitlercek = taksittutarı;
                    OleDbCommand kayit = new OleDbCommand("insert into odemeler(OZELSIFRE,ADI,SOYADI,URUN,ODENECEKAY,TARIH,ODENECEKMIKTAR) values('" + sonsifre + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox3.Text + "','" + alanlar + "','" + taksittarihi.ToShortDateString() + "','" + taksitlercek + "')", baglan);

                    baglan.Open();
                    kayit.ExecuteNonQuery();
                    baglan.Close();
                }

                OleDbCommand kaydet = new OleDbCommand
                    ("insert into musterıler(OZELSIFRE,ADI,SOYADI,URUN,BIRIMFIYAT,ADET,SATISTURU,TOPLAMFIYAT,SATISTARIHI,RESIM) VALUES('"+sonsifre.ToString()+"','"+textBox1.Text+"','"+textBox2.Text
                    +"','"+comboBox3.Text+"','"+textBox3.Text+"','"+comboBox4.Text 
                    +"','"+satısturu+"','"+textBox4.Text +"','"+DateTime.Now.ToShortDateString()+"','"+pictureBox1.Image +"')",baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                guncelle();
                temizle();


                


            }
            else
            {
                temizle();
            }
            //timer2.Enabled = true;
        }
        int toplam,toplam1,toplam2;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            toplam = 0;
            toplam1 = 0;
            toplam2 = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "PEŞİN")
                {
                    toplam1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                   // dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Green;
                    renk.BackColor = Color.Green;
                }
                else
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "VADE")
                {
                    toplam2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                   // dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Violet;
                    renk.BackColor = Color.Red;

                }

                dataGridView1.Rows[i].DefaultCellStyle = renk;


            }
            label9.Text = "Toplam BORÇ = " + toplam.ToString("#,###.00 T.L.");
            label10.Text = "Toplam PEŞİN BORÇ = " + toplam1.ToString("#,###.00 T.L.");
            label11.Text = "Toplam VADELİ BORÇ = " + toplam2.ToString("#,###.00 T.L.");
            //timer2.enabled=false;
        }
        public static string sec, sifree, ad1, soyad1,urun;
        private void button2_Click(object sender, EventArgs e)
        {
            sec =  Interaction.InputBox("Ödeme yapmak için şifreye göre arama [1] / Ad-Soyad a göre arama [2] / Lütfen seçim yapınız", "SAYI GİRİŞİ", "BURAY YAZINIZ");

            if (sec == "1")
            {
               sifree  = Interaction.InputBox("Ödeme yapılacak kişinin şifresini girin.", "ŞİFRE GİRİŞİ", "BURAY YAZINIZ");
               OleDbCommand ara = new OleDbCommand("select * from musterıler where OZELSIFRE='"+sifree+"'  ", baglan);
               baglan.Open();
               OleDbDataReader dr = ara.ExecuteReader();
               if (dr.Read() == true)
               {

                   urun = dr["URUN"].ToString();
                   ad1 = dr["ADI"].ToString();
                   soyad1 = dr["SOYADI"].ToString();

                   Form3 ac = new Form3();
                   ac.ShowDialog();

               }
               else
               {
                   MessageBox.Show("BULAMADIK");
               }

               baglan.Close();

            
            }//sec1  end

            if (sec == "2")
            {

                ad1 = Interaction.InputBox("Ödeme yapılacak kişinin adını girin.", "ŞİFRE GİRİŞİ", "BURAY YAZINIZ");
                soyad1 = Interaction.InputBox("Ödeme yapılacak kişinin soyadını girin.", "ŞİFRE GİRİŞİ", "BURAY YAZINIZ");
                OleDbCommand ara = new OleDbCommand("select * from musterıler where ADI='" + ad1 + "' and SOYADI='"+soyad1+"'  ", baglan);
                baglan.Open();
                OleDbDataReader dr = ara.ExecuteReader();
                if (dr.Read() == true)
                {
                    sifree = dr["OZELSIFRE"].ToString();
                    urun = dr["URUN"].ToString();
                    ad1 = dr["ADI"].ToString();
                    soyad1 = dr["SOYADI"].ToString();

                    Form4 ac = new Form4();
                    ac.ShowDialog();

                }
                else
                {
                    MessageBox.Show("BULAMADIK");
                }

                baglan.Close();
            }//sec2 end.


            /*
            for (int i = 1; i <= taksitsayisi; i++)
            {
                taksittarihi = baslangıctarihi.AddMonths(i);

                alanlar = aylar[taksittarihi.Month] + " ";

                taksitler = taksittutarı.ToString("C") + " ";

                taksitlercek = taksittutarı;
                OleDbCommand kayit = new OleDbCommand("insert into odemeler(OZELSIFRE,ADI,SOYADI,URUN,ODENECEKAY,TARIH,ODENECEKMIKTAR) values('" + sonsifre + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox3.Text + "','" + alanlar + "','" + taksittarihi.ToShortDateString() + "','" + taksitlercek + "')", baglan);

                baglan.Open();
                kayit.ExecuteNonQuery();
                baglan.Close();
            }*/
        }// BUYON ENDİ.

        

       
    }
}
