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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

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

        private void guncelle()
        {
            // giride bilgi çekme  1. yol

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM musteriler", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();



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

        private void Form2_Load(object sender, EventArgs e)
        {
            guncelle();
            var il = File.ReadLines(@"iller.txt");    // txt den illeri çektik
            foreach (var isim in il)
            {
                comboBox1.Items.Add(isim);
            }


            for (int i = 2; i <= 8; i++)  // adet combosunu doldurduk
            {
                comboBox4.Items.Add(i);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ADANA")  // illeri ilçelerle doldurduk
            {


                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT ADANA FROM ilceler", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["ADANA"]);
                }

                baglan.Close();


            }
            if (comboBox1.Text == "ANKARA") // illeri ilçelerle doldurduk
            {


                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT ANKARA FROM ilceler", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["ANKARA"]);
                }

                baglan.Close();





            }
            if (comboBox1.Text == "AYDIN") // illeri ilçelerle doldurduk
            {

                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT AYDIN FROM ilceler", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["AYDIN"]);
                }

                baglan.Close();





            } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)    // BAY SEÇİLİYSE BAY ÜRÜNLERİNİ GETİRDİK
            {
                checkBox2.Checked = false;
                cinsiyet = "BAY";



                comboBox3.Items.Clear();
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT BAY FROM urun", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox3.Items.Add(okuyucu["BAY"]);
                }

                baglan.Close();




            
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)            // BAYAN SEÇİLİYSE BAYAN ÜRÜNLERİNİ GETİRDİK
            {
                checkBox1.Checked = false;
                cinsiyet = "BAYAN";



                comboBox3.Items.Clear();
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT BAYAN FROM urun", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox3.Items.Add(okuyucu["BAYAN"]);
                }

                baglan.Close();





            }
        }
        int adet_fiyatı, adet;
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                adet_fiyatı = Convert.ToInt32(textBox3.Text);   // adete göre toplam borcu hesaplatıp texte yazdık.
                adet = Convert.ToInt32(comboBox4.Text);

                textBox4.Text = (adet_fiyatı * adet).ToString();
            }   


            
        }
        string adı, soyadı, il, ilce, cinsiyet, satılan_urun;
        int toplamborc;
      //  DateTime tarih;
        DialogResult sor;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Adı girin..");


            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Soyadı girin..");
            }
            else
            {
                adı = textBox1.Text.Trim();
                soyadı = textBox2.Text.Trim();
                adet_fiyatı = Convert.ToInt32(textBox3.Text.Trim());
                toplamborc = Convert.ToInt32(textBox4.Text.Trim());
                il = comboBox1.Text;
                ilce = comboBox2.Text;
                satılan_urun = comboBox3.Text;
                //tarih = dateTimePicker1.Value.ToShortDateString();




                baglan.Open();

                OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                    ("SELECT ADI,SOYADI FROM musteriler WHERE ADI='" + adı + "' AND SOYADI='" + soyadı+ "'", baglan);


                OleDbCommand kaydet = new OleDbCommand
                   ("INSERT INTO musteriler(ADI,SOYADI,ILCE,S_URUN_ADI,BIRIM_FIYAT,ADET,TOPLAM_BORC,SATIS_TARIHI) VALUES ('" + adı + "','" + soyadı + "','" + ilce + "','" + satılan_urun + "','" + adet_fiyatı.ToString() + "','" + adet.ToString() + "','" + toplamborc.ToString() + "','" + DateTime.Now.ToShortDateString() + "')", baglan);
                sor = MessageBox.Show(adı + " " + soyadı + "  isimli müşteriye olan "+satılan_urun+" satışı toplam = "+toplamborc+" T.L üzerinden gerçekleşsin mi ?" , "KAYIT İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sor == DialogResult.Yes)
                {



                    OleDbDataReader dr = ara.ExecuteReader();         // kayıt yoksaki durumlar için yukardaki ise kayıt varsa onu siler
                    if (dr.Read() == true)
                    {
                        MessageBox.Show("AYNI İSİM VE SOYİSİMLE SİSTEME KAYIT YAPILAMAZ.");
                        temizle();
                        baglan.Close();


                    }
                    else
                    {
                        kaydet.ExecuteNonQuery();
                        temizle();
                        baglan.Close();
                    }


                    // buradada bağlanı kapatmayı unutma.
                    guncelle();
                }//dialog yes in endi
                if (sor == DialogResult.No)
                {
                    MessageBox.Show("ALANLAR TEMİZLENİYOR...");
                    temizle();
                    
                }// dialog no nun endi
            
            
            
            
            }

            baglan.Close(); // buradakinin amacı program hayır dedikten sonra tekrar kayıt yaparken patlıyordu onu çözmek için
            
        }
        public static string adısor, soyadısor;
        private void button2_Click(object sender, EventArgs e)
        {
            adısor= Interaction.InputBox("ADINIZI GİRİN", "AD GİRİŞİ", "BURAY YAZINIZ");
            soyadısor = Interaction.InputBox("SOYADINIZI GİRİN", "SOYAD GİRİŞİ", "BURAY YAZINIZ");





            baglan.Open();
            OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                    ("SELECT ADI,SOYADI FROM musteriler WHERE ADI='" + adısor + "' AND SOYADI='" + soyadısor + "'", baglan);





            OleDbDataReader dr = ara.ExecuteReader();         // kayıt yoksaki durumlar için yukardaki ise kayıt varsa onu siler
            if (dr.Read() == true)
            {
                Form3 goster = new Form3();
                goster.ShowDialog();


            }
            else
            {

                MessageBox.Show("ARANAN KAYIT BULUNAMADI.");
                

            }

            baglan.Close();

        } // BUTON 2 ENDİ
        Int16 cik;
        private void button4_Click(object sender, EventArgs e)
        {
            cik = Convert.ToInt16(MessageBox.Show("Program Kapatılsın mı ? ", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button2)); // değer verdik değerimiz int oldugu için string çevirdik mesaj verdirdik ekrana
            //mesaj dan sonra çıkış sonra button ekledik eve hayır sonra icon ekledik sonra da hangisinin aktif button olacağını belirleik.
            if (cik == 6) // eğer 6 yani evet seçilirse yap
            {
                Environment.Exit(0);  //çıkış yap bunun yerine application.exitte kullanabilirdik.
            }//if sonu
            else         //eğer 6 değilse yani 7 yse yani hayırsa
            {
                MessageBox.Show("ÇIKIŞ GERÇEKLEŞMEDİ !");  // ekrana mesaj verdik.
            } // else sonu





        }

        private void kayitİnceleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 goster = new Form4();
            goster.ShowDialog();
        }






    public static string adısor2, soyadısor2;
    public static string adıcek, soyadıcek, ılcecek, uruncek, satistarihicek;
    public static int birimfiyatcek, adetcek, toplamborccek;
        DialogResult sor2;
        private void button3_Click(object sender, EventArgs e)
        {
            adısor2 = Interaction.InputBox("ADINIZI GİRİN", "AD GİRİŞİ", "BURAY YAZINIZ");
            soyadısor2 = Interaction.InputBox("SOYADINIZI GİRİN", "SOYAD GİRİŞİ", "BURAY YAZINIZ");





            baglan.Open();
            OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                    ("SELECT * FROM musteriler WHERE ADI='" + adısor2 + "' AND SOYADI='" + soyadısor2 + "'", baglan);





            OleDbDataReader dr = ara.ExecuteReader();         // kayıt yoksaki durumlar için yukardaki ise kayıt varsa onu siler
            if (dr.Read() == true)
            {
                adıcek = dr["ADI"].ToString();
                soyadıcek = dr["SOYADI"].ToString();
                ılcecek = dr["ILCE"].ToString();
                uruncek = dr["S_URUN_ADI"].ToString();
                birimfiyatcek = Convert.ToInt32(dr["BIRIM_FIYAT"]);
                adetcek = Convert.ToInt32(dr["ADET"]);
                toplamborccek = Convert.ToInt32(dr["TOPLAM_BORC"]);
                satistarihicek = dr["SATIS_TARIHI"].ToString() ;

                sor2 = MessageBox.Show("ADI = " + adıcek + "\n" + "SOYADI = " + soyadıcek + "\n" + "ILCE =" + ılcecek + "\n" + "URUN = " + uruncek + "\n" + "B.FIYAT = " + birimfiyatcek + "\n" + "ADET = " + adetcek + "\n" + "T.BORC = " + toplamborccek + "\n" + "TARIH = " + satistarihicek + "\n" + "KAYIT DÜZELTİLSİN Mİ ?", "KAYIT İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sor2 == DialogResult.Yes)
                {
                    Form5 goster = new Form5();
                    goster.ShowDialog();
                }
                if (sor2 == DialogResult.No)
                {
                    MessageBox.Show("KAYIT GÜNCELLENMEDİ.");
                }


            }
            else
            {

                MessageBox.Show("ARANAN KAYIT BULUNAMADI.");


            }

            baglan.Close();

        }// butoon 3 sonu.
        
       
    }
}
