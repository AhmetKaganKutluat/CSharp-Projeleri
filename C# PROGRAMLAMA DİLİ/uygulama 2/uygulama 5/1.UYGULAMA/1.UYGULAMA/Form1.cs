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


// aslında çalışıyor ama grid bağlamasını elle yapmmaız gerekiyor seçerek olunca çalımaz.
namespace _1.UYGULAMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter cek = new OleDbDataAdapter("SELECT * FROM TABLO2", baglan);
            cek.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("SİLİNECEK KİŞİNİN AD VE SOYADINI GİRİNİZ !!");
            }
            else
            {
                baglan.Open();

                OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                    ("SELECT ADI,SOYADI FROM Tablo2 WHERE ADI='"+textBox1.Text+"' AND SOYADI='"+textBox2.Text+"'",baglan);


                OleDbCommand sil = new OleDbCommand               // şimdi ise silmek için 
                   ("DELETE  FROM Tablo2 WHERE ADI='" + textBox1.Text + "' AND SOYADI='" + textBox2.Text + "'", baglan);

                OleDbDataReader dr = ara.ExecuteReader();             // veri okuyucu eger ara dogruysa yapıcak
                if (dr.Read())       //eger dogruysa
                {
                    sil.ExecuteNonQuery();   // sili çalıştır
                    DataTable tablo = new DataTable();
                    OleDbDataAdapter cek = new OleDbDataAdapter("SELECT * FROM TABLO2", baglan);
                    cek.Fill(tablo);
                    dataGridView1.DataSource = tablo;

                }
                else
                {
                    MessageBox.Show("İLGİLİ KAYIT BULUNAMADI");
                }


                baglan.Close();
            }
        }
    }
}
