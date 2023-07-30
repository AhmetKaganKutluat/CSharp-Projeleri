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

        private void guncelle()
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC FROM bilgiler", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();

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
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            
          
        }

        
        

        private void Form2_Load(object sender, EventArgs e)
        {
            guncelle();

            var ogretmen = File.ReadLines(@"sehir\iller.txt");        //böyle bir txt yi programın debug kısmına eklemen lazım.
            foreach (var isim in ogretmen)
            {
                comboBox1.Items.Add(isim);
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                comboBox1.Focus();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                                           
            if (comboBox1.Text == "ANKARA")                       //combo 2 de METE HAN seçilirse ders1.txt dosyasındaki verileri combo3 e yaz demek.
            {
                comboBox2.Items.Clear(); 
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT ANKARA FROM ilce", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["ANKARA"]);
                }

                baglan.Close();
            }//if sonu




                                            
            if (comboBox1.Text == "AYDIN")                       //combo 2 de METE HAN seçilirse ders1.txt dosyasındaki verileri combo3 e yaz demek.
            {
                comboBox2.Items.Clear(); 
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT AYDIN FROM ilce", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["AYDIN"]);
                }

                baglan.Close();
            }//if sonu

                                           
            if (comboBox1.Text == "ANTALYA")                       //combo 2 de METE HAN seçilirse ders1.txt dosyasındaki verileri combo3 e yaz demek.
            {
                comboBox2.Items.Clear(); 
                baglan.Open();
                OleDbCommand il_goster = new OleDbCommand("SELECT ANTALYA FROM ilce", baglan);
                OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
                while (okuyucu.Read())
                {
                    comboBox2.Items.Add(okuyucu["ANTALYA"]);
                }

                baglan.Close();
            }//if sonu

            


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                comboBox3.Items.Clear();
                comboBox3.Items.Add("ARABA");
                comboBox3.Items.Add("MOTOR");

            }

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                comboBox3.Items.Clear();
                comboBox3.Items.Add("HELIKOPTER");
                comboBox3.Items.Add("UCAK");
            }
        }
        DialogResult sor;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                try
                {
                    OleDbCommand kaydet = new OleDbCommand
                       ("INSERT INTO bilgiler(ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC,KAYIT_TARIHI) VALUES ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + DateTime.Now.ToShortDateString() + "')", baglan);
                    sor = MessageBox.Show(textBox1.Text + " " + textBox2.Text + "  isimli kayıt yapılsınmı ", "KAYIT İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (sor == DialogResult.Yes)
                    {
                        baglan.Open();
                        kaydet.ExecuteNonQuery();
                        baglan.Close();
                    }
                    guncelle();
                }
                catch
                {
                    MessageBox.Show("HATAAA");
                }
                finally
                {
                    temizle();
                }
            }
            else//ifin endi.
            {

                MessageBox.Show("TÜM ALANLARIN DOLU OLDUĞUNDAN EMİN OLUN !!");
            
            }

        }// buton 1 sonu
        DataTable tablo1 = new DataTable();
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // arama böyle daha sağlıklı
            if (textBox4.Text != "")
            {



                baglan.Open();
                OleDbCommand komut = new OleDbCommand("SELECT ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC FROM bilgiler where SOYADI like'%" + textBox4.Text + "%'", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
                DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
                tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

                dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
                baglan.Close();

            }
            else
            {
                guncelle();
            }

        }
       public static  string det_ad, det_soyad, det_il, det_ilce, det_urun;
       public static string det_toplam_borc, det_kalan_borc,det_kayıttarıhı;
        OleDbDataReader dr;
        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            det_ad = dataGridView1.SelectedCells[0].Value.ToString();
            det_soyad = dataGridView1.SelectedCells[1].Value.ToString();
            baglan.Open();

            OleDbCommand kayıtara = new OleDbCommand
            ("SELECT * FROM bilgiler WHERE ADI='" + det_ad + "' AND SOYADI='" + det_soyad + "'", baglan);
            dr = kayıtara.ExecuteReader();
            if (dr.Read())
            {
              //  det_ad = dr["ADI"].ToString();
                //det_soyad = dr["SOYADI"].ToString();
                det_il = dr["IL"].ToString();
                det_ilce = dr["ILCE"].ToString();
                det_urun = dr["URUN"].ToString() ;
                det_toplam_borc = dr["TOPLAM_BORC"].ToString() + " ₺";
                det_kalan_borc = dr["KALAN_BORC"].ToString() + " ₺";
                det_kayıttarıhı = dr["KAYIT_TARIHI"].ToString() ;
                baglan.Close();

            }//if endi.



            Form4 goster1 = new Form4();
            goster1.ShowDialog();


        }
        string seciliad,secilisoyad;
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            seciliad = dataGridView1.SelectedCells[0].Value.ToString();
            secilisoyad = dataGridView1.SelectedCells[1].Value.ToString();

            MessageBox.Show(secilisoyad);
            baglan.Open();
            OleDbCommand sil = new OleDbCommand
                   ("DELETE FROM bilgiler  WHERE ADI='" + seciliad + "' AND SOYADI='" + secilisoyad + "' ", baglan);
            sil.ExecuteNonQuery();
            baglan.Close();
            guncelle();
        }
        int odenen,cektoplam_borc,cekkalan_borc,yenikalan;
        string cekad, ceksoyad, cekıl, cekılce, cekurun;
        private void ödemeYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("ödeme yap");

            // ÖDEME MİKTARINI AL 
            
            //ÖDEME MİKTARINI ÖDENENLER TABLOSUNA YAZ
            //ÖDEME MİKTARINDAN SONRA TOPLAM BORC 0 OLUYORSA KAYDI SİL
            // TABLODAKİ KALAN BORCU GÜNCELLE
            odenen = Convert.ToInt32(Interaction.InputBox("SAYIYI GİRİNİZ ?", "SAYI GİRİŞİ", "BURAY YAZINIZ"));
            cekad = dataGridView1.SelectedCells[0].Value.ToString();
            ceksoyad = dataGridView1.SelectedCells[1].Value.ToString();
            cekıl = dataGridView1.SelectedCells[2].Value.ToString();
            cekılce = dataGridView1.SelectedCells[3].Value.ToString();
            cekurun = dataGridView1.SelectedCells[4].Value.ToString();
            cektoplam_borc = Convert.ToInt32(dataGridView1.SelectedCells[5].Value);
            cekkalan_borc = Convert.ToInt32(dataGridView1.SelectedCells[6].Value);


            yenikalan = cekkalan_borc - odenen;
            if (yenikalan <= 0)
            {
                OleDbCommand kaydet = new OleDbCommand// veri ekleme
                      ("INSERT INTO odemeler(ADI,SOYADI,ODEME_MIKTARI,TARIH) VALUES ('" + cekad.ToString() + "','" + ceksoyad.ToString() + "','" + odenen.ToString() + "','" + DateTime.Now.ToShortDateString() + "')", baglan);

                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                guncelle();


                OleDbCommand kaydet2 = new OleDbCommand // veri ekleme
                      ("INSERT INTO odemesibitenler (ADI,SOYADI,SON_ODEME_TARIHI,SON_ODEME_MIKTARI) VALUES ('" + cekad.ToString() + "','" + ceksoyad.ToString() + "','" + DateTime.Now.ToShortDateString() + "','"+odenen.ToString()+"')", baglan);

                baglan.Open();
                kaydet2.ExecuteNonQuery();
                baglan.Close();
                guncelle();




                OleDbCommand sil = new OleDbCommand  // veri silme
                    ("DELETE FROM bilgiler  WHERE ADI='" + cekad + "' AND SOYADI='" + ceksoyad + "' ", baglan);

                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                guncelle();


            }
            else

            {
                OleDbCommand kaydet = new OleDbCommand  // veri ekleme 
                         ("INSERT INTO odemeler(ADI,SOYADI,ODEME_MIKTARI,TARIH) VALUES ('" + cekad.ToString() + "','" + ceksoyad.ToString() + "','" + odenen.ToString() + "','" + DateTime.Now.ToShortDateString() + "')", baglan);

                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                guncelle();



                OleDbCommand kaydıguncelle = new OleDbCommand  // veri güncelleme.
                   ("UPDATE  bilgiler SET KALAN_BORC='" + yenikalan   + "' WHERE SOYADI='" + ceksoyad + "'", baglan);  
                baglan.Open();
                kaydıguncelle.ExecuteNonQuery();
                // MessageBox.Show("Ödeme alındı.");
                baglan.Close();
                guncelle();
            
            }






        }
        int toplamtahsilat,kalantahsilat;
        private void button2_Click(object sender, EventArgs e)
        {
            

                baglan.Open();
                OleDbCommand komut = new OleDbCommand("SELECT ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC FROM bilgiler", baglan); ;  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
                DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
                tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

                dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
                baglan.Close();

                toplamtahsilat = 0;  // eğer bunu 0 yapmazsak butona her basıldığında kendisi kadar ekliyor.
                kalantahsilat = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    toplamtahsilat += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);  // tüm gelir satırlarını toplamgelir değişkeninde topla demek
                    kalantahsilat += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);  // select kısmına hepsini getirip habgi kısımları toplatacaksak oranın yerini giriyoruz 0 dan başlar.


                }




                textBox5.Text = toplamtahsilat.ToString();
                textBox6.Text = kalantahsilat.ToString();


           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string sql = "SELECT ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC FROM bilgiler Where KAYIT_TARIHI BETWEEN @tar1 and @tar2";
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, baglan);
            adp.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            adp.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            adp.Fill(dt);
            baglan.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand ara = new OleDbCommand// veri ekleme
                      ("SELECT ADI,SOYADI,IL,ILCE,URUN,TOPLAM_BORC,KALAN_BORC FROM bilgiler WHERE ADI like '%" + textBox4.Text + "%'", baglan);

            baglan.Open();
            ara.ExecuteNonQuery();
            baglan.Close();
            guncelle();
        }
        string kullanici_ad,kullanici_sifre;
        private void button4_Click_1(object sender, EventArgs e)
        {
            kullanici_ad =Interaction.InputBox("KULLANICI ADINI GİRİN.", "YENİ KULLANICI GİRİŞİ", "BURAY YAZINIZ").ToString();
            kullanici_sifre = Interaction.InputBox("KULLANICI SIFRESINI GİRİN.", "YENİ KULLANICI SİFRESİ", "BURAY YAZINIZ").ToString();
           kullanici_ad= kullanici_ad.ToUpper();
            kullanici_sifre =kullanici_sifre.ToUpper();

            OleDbCommand kaydet = new OleDbCommand// veri ekleme
                      ("INSERT INTO kullanicilar(KULLANICI,SIFRE) VALUES ('" + kullanici_ad  + "','" + kullanici_sifre + "')", baglan);

            baglan.Open();
            kaydet.ExecuteNonQuery();
            baglan.Close();
            guncelle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = dataGridView1.Rows.Count.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) <= 3000)
                {
                    renk.BackColor = Color.Green;

                }
                else
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) <= 6000)
                    {

                        renk.BackColor = Color.Yellow;
                    }

                    else
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) <= 10000)
                        {

                            renk.BackColor = Color.Red;
                        }
                        else
                        {

                            renk.BackColor = Color.Purple;
                        }

                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 goster = new Form5();
            goster.ShowDialog();
        }

        
    }
}
