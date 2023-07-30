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
using Microsoft.VisualBasic;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");


        private void guncelle()
        {
            // giride bilgi çekme  1. yol

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM musteriler WHERE ADI='" + Form2.adısor+ "' AND SOYADI='" + Form2.soyadısor + "'", baglan); ;  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView2.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();



        }
        private void Form3_Load(object sender, EventArgs e)
        {
            guncelle();
        }
        int odeme_mıktarı,totalborc,sonuc;
        OleDbDataReader dr;
        int bırımfıyatt, adett, toplam_borcc;
        private void ödemeYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
        durak1:

             baglan.Open();

             OleDbCommand kayıtara = new OleDbCommand
             ("SELECT * FROM musteriler WHERE ADI='" + Form2.adısor + "' AND SOYADI='" + Form2.soyadısor + "'", baglan);   // toplam borc değişkene alındı.
             dr = kayıtara.ExecuteReader();
             if (dr.Read())
             {
                 totalborc = Convert.ToInt32(dr["TOPLAM_BORC"]);
               
             }
             baglan.Close();

             
            




            
            odeme_mıktarı = Convert.ToInt32(Interaction.InputBox("SAYIYI GİRİNİZ..", "SAYI GİRİŞİ", "BURAY YAZINIZ"));
            if (odeme_mıktarı > totalborc)
            {
                MessageBox.Show("Ödeme miktarı toplam borctan cok olamaz.Tekrar girin..");
                goto durak1;

            }
            else

            {
                sonuc=totalborc-odeme_mıktarı;
                if (sonuc == 0)
                {
                    //odemesi bitenlere kayıt.


                    


                    baglan.Open();

                    OleDbCommand çek1 = new OleDbCommand
                    ("SELECT * FROM musteriler WHERE ADI='" + Form2.adısor + "' AND SOYADI='" + Form2.soyadısor + "'", baglan);   // toplam borc değişkene alındı.
                    dr = çek1.ExecuteReader();
                    if (dr.Read())
                    {
                        bırımfıyatt = Convert.ToInt32(dr["BIRIM_FIYAT"]);

                    }
                    baglan.Close();



                    baglan.Open();

                    OleDbCommand çek2 = new OleDbCommand
                    ("SELECT * FROM musteriler WHERE ADI='" + Form2.adısor + "' AND SOYADI='" + Form2.soyadısor + "'", baglan);   // toplam borc değişkene alındı.
                    dr = çek2.ExecuteReader();
                    if (dr.Read())
                    {
                        adett = Convert.ToInt32(dr["ADET"]);

                    }
                    baglan.Close();


                    toplam_borcc = bırımfıyatt * adett;


                    OleDbCommand kaydet = new OleDbCommand
                        //("UPDATE  musteriler SET TOPLAM_BORC='" + sonuc.ToString() + "' WHERE ADI='" + Form2.adısor.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
                    ("INSERT INTO odemesi_bitenler(ADI,SOYADI,TOPLAM_BORCU) VALUES ('" + Form2.adısor + "','" + Form2.soyadısor + "','" + toplam_borcc + "')", baglan);
                    baglan.Open();
                    kaydet.ExecuteNonQuery();
                    // MessageBox.Show("Ödeme alındı.");
                    baglan.Close();
                    guncelle();



                    OleDbCommand kaydet2 = new OleDbCommand  // ÖDEMESİ BİTİNCE DE ÖDEMELER TABLOSUNA KAYIT YAPABİLMEK İÇİN KOYDUK
                        //("UPDATE  musteriler SET TOPLAM_BORC='" + sonuc.ToString() + "' WHERE ADI='" + Form2.adısor.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
                    ("INSERT INTO odeme_yapanlar(ADI,SOYADI,ODEME_MIKTARI,ODEME_TARIHI) VALUES ('" + Form2.adısor + "','" + Form2.soyadısor + "','" + odeme_mıktarı + "','" + DateTime.Now.ToShortDateString() + "')", baglan);
                    baglan.Open();
                    kaydet2.ExecuteNonQuery();
                    // MessageBox.Show("Ödeme alındı.");
                    baglan.Close();
                    guncelle();






                    //sonuc 0 ise kaydı silicez 
                    OleDbCommand kaydısil = new OleDbCommand
                   ("delete from  musteriler where ADI='" + Form2.adısor + "'", baglan);  // borçtan düştük girilen değeri.

                    baglan.Open();
                    kaydısil.ExecuteNonQuery();
                    baglan.Close();
                    guncelle();

                }

                else
                {
                    OleDbCommand kaydet = new OleDbCommand
                    //("UPDATE  musteriler SET TOPLAM_BORC='" + sonuc.ToString() + "' WHERE ADI='" + Form2.adısor.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
                    ("INSERT INTO odeme_yapanlar(ADI,SOYADI,ODEME_MIKTARI,ODEME_TARIHI) VALUES ('" + Form2.adısor+ "','" + Form2.soyadısor + "','" + odeme_mıktarı+ "','"+DateTime.Now.ToShortDateString()+"')", baglan);
                    baglan.Open();
                    kaydet.ExecuteNonQuery();
                    // MessageBox.Show("Ödeme alındı.");
                    baglan.Close();
                    guncelle();





                    OleDbCommand kaydıguncelle = new OleDbCommand
                    ("UPDATE  musteriler SET TOPLAM_BORC='" + sonuc.ToString() + "' WHERE ADI='" + Form2.adısor.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
                    baglan.Open();
                    kaydıguncelle.ExecuteNonQuery();
                    // MessageBox.Show("Ödeme alındı.");
                    baglan.Close();
                    guncelle();

                } //elsin endi.

            
            }
            
            //totalborc = Convert.ToInt32(dataGridView2.CurrentRow.Cells["TOPLAM_BORC"].Value);

           // MessageBox.Show(totalborc.ToString());
          
            
        }
    }
}
