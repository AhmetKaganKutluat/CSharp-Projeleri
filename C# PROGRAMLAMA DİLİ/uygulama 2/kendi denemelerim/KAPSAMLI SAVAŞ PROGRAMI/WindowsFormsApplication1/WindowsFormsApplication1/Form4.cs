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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");
        private void guncelle()
        {
            // giride bilgi çekme  1. yol

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ADI,SOYADI,S_URUN_ADI,TOPLAM_BORC FROM musteriler", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();



        }

        private void Form4_Load(object sender, EventArgs e)
        {
            guncelle();
        }
        OleDbDataReader dr;
        int al,toplamtahsilat;
        private void button1_Click(object sender, EventArgs e)
        {



          

         /*   baglan.Open();
           OleDbCommand komut = new OleDbCommand("SELECT SUM (ODEME_MIKTARI) FROM odeme_yapanlar", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            
            baglan.Close();
            */

/*
            baglan.Open();

            OleDbCommand toplam_tahsıl = new OleDbCommand
            ("SELECT ODEME_MIKTARI FROM odeme_yapanlar", baglan);   // toplam borc değişkene alındı.
          //   ("SELECT * FROM musteriler WHERE ADI='" + Form2.adısor + "' AND SOYADI='" + Form2.soyadısor + "'", baglan);   // toplam borc değişkene alındı.
            dr = toplam_tahsıl.ExecuteReader();
            if (dr.Read())
            {
               al  = Convert.ToInt32(dr["ODEME_MIKTARI"]);

            }
            baglan.Close();

            textBox1.Text = al.ToString();

            */

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ODEME_MIKTARI FROM odeme_yapanlar", baglan); ;  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();

            toplamtahsilat = 0;  // eğer bunu 0 yapmazsak butona her basıldığında kendisi kadar ekliyor.
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplamtahsilat += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);  // tüm gelir satırlarını toplamgelir değişkeninde topla demek
               


            }
            textBox1.Text = toplamtahsilat.ToString();



            

            baglan.Open();
            string sql = "SELECT ADI,SOYADI,S_URUN_ADI,TOPLAM_BORC FROM musteriler Where SATIS_TARIHI BETWEEN @tar1 and @tar2";
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, baglan);
            adp.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            adp.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            adp.Fill(dt);
            baglan.Close();
            dataGridView1.DataSource = dt;

            

/*
            string query = "SELECT SUM (ODEME_MIKTARI) FROM odeme_yapanlar";
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, baglan);
            DataTable source = new DataTable();
            dAdapter.Fill(source);
            textBox1.Text = source.ToString();
 * */

/*
            int toplamgelir = 0; int toplamgider = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplamgelir += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);  // tüm gelir satırlarını toplamgelir değişkeninde topla demek
                toplamgider += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);  // tüm gider satırlarını toplamgider değişkeninde topla demek


            }




        */
        }
    }
}
