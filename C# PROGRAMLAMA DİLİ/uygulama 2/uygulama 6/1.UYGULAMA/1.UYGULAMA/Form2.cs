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

namespace _1.UYGULAMA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");

        void guncelle()
        {
            DataTable veriler = new DataTable();
            OleDbDataAdapter cek = new OleDbDataAdapter   //giride çekerken tabloyu adapter kullanıyoruz command değil
            ("SELECT * FROM Tablo3", baglan);
            cek.Fill(veriler);
            dataGridView1.DataSource = veriler;

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            guncelle();

        }

        bool durum;

        void mukerrer()
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand // adına göre karşılaştırma işlemi yada isteğe göre
            ("SELECT * FROM Tablo3 WHERE ADI='"+textBox1.Text+"'",baglan);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mukerrer();
            if (durum == true)
            {
                OleDbCommand kaydet = new OleDbCommand       // kayıt işlemi yapılabilir.
                ("INSERT INTO Tablo3 (ADI,SOYADI,MEMLEKET) VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')",baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                guncelle();

            }

            else
            {
                MessageBox.Show("VERİ TABANINDA AYNI İSİMLİ KAYIT VARDIR");
            }
        }



        void birlestir()     //TABLO1 DEKİ ADI SOYADI TABLO2 DEKİ DERS VE ORTALAMA BİRLEŞTİRİCEZ. *****
        {
            DataTable veriler = new DataTable();
            OleDbDataAdapter cek = new OleDbDataAdapter   //giride çekerken tabloyu adapter kullanıyoruz command değil
            ("SELECT Tablo1.ADI,SOYADI, Tablo2.DERS,ORTALAMA FROM Tablo1 INNER JOIN Tablo2 ON Tablo1.TC=Tablo2.TC", baglan);    // TC LERİNE GÖRE AYNI OLUP OLMASINA GÖRE BİRLEŞTİRDİK.
            cek.Fill(veriler);
            dataGridView2.DataSource = veriler;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            birlestir();

            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.Crimson;  //ADI 
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.Crimson;  //SOYADI
            dataGridView2.Columns[2].DefaultCellStyle.BackColor = Color.DeepPink;  //DERS
            dataGridView2.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;  //ORTALAMA

            dataGridView2.Columns[2].Width=250;
            
            //          1 . YÖNTEM 
            //using (Font etki = new Font(dataGridView2.DefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold))  // ben birşey kullanıcam ne kullanıcam yazı olayı
            //{
            //    dataGridView2.Columns[3].DefaultCellStyle.Font = etki;
            // }

            //          2. YÖNTEM
            dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dataGridView2.DefaultCellStyle.ForeColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue;
            //dataGridView2.DefaultCellStyle.Alignment; yarım kaldı bu
            



        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                DataTable veriler = new DataTable();
                OleDbDataAdapter cek = new OleDbDataAdapter   //giride çekerken tabloyu adapter kullanıyoruz command değil
                ("SELECT ADI,SOYADI FROM Tablo3", baglan);
                cek.Fill(veriler);
                dataGridView1.DataSource = veriler;
                radioButton1.Checked = false;
                button3.Enabled = false;
            }
            else
            
                if (radioButton2.Checked == true)
                {

                    DataTable veriler = new DataTable();
                    OleDbDataAdapter cek = new OleDbDataAdapter   //giride çekerken tabloyu adapter kullanıyoruz command değil
                    ("SELECT ADI,MEMLEKET FROM Tablo3", baglan);
                    cek.Fill(veriler);
                    dataGridView1.DataSource = veriler;
                    radioButton2.Checked = false;
                    button3.Enabled = false;
                }
            
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }


        


        


    }
}
