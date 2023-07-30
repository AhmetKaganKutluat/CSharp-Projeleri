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

namespace _1.uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");

        void elemanlar()
        {
            baglan.Open();
            OleDbCommand il_goster = new OleDbCommand("SELECT OGRETMEN FROM TABLO2",baglan);
            OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["OGRETMEN"]);
            }

            baglan.Close();
        
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            elemanlar(); guncelle();
        }

        void guncelle()  // gride bilgi çekme
        {
            DataTable tablo = new DataTable();  //sanal tablo oluşturduk
            OleDbDataAdapter bilgi = new OleDbDataAdapter    // gride bilgi çekmek için adaptör nesnesi lazım
            ("SELECT * FROM TABLO1",baglan);
            bilgi.Fill(tablo);
            dataGridView1.DataSource = tablo;


            dataGridView1.Columns[3].Visible=false;
            dataGridView1.Columns[4].Visible=false;
            dataGridView1.Columns[5].Visible=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string kaydet;  // sql ifadesini bir değişkene atıpta kayıt işlemi yapabiliriz.
            // FARKLI BİR YÖNTEM KAYIT İŞLEMİ
            kaydet = "INSERT INTO TABLO1(ADI,SOYADI,MEMLEKET) VALUES (@M_ADI,@M_SOYADI,@MEM)";
            OleDbCommand komut = new OleDbCommand(kaydet,baglan);
            komut.Parameters.AddWithValue("@M_ADI",textBox1.Text.Trim());
            komut.Parameters.AddWithValue("@M_SOYADI", textBox2.Text.Trim());
            komut.Parameters.AddWithValue("@Mem", comboBox1.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();

            guncelle();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // textBox3.Text=dataGridView1.SelectedCells[0].Value.ToString();   // 1.yönetm
           // textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();  // 2.yöntem

            // 3. yöntem

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("ARANILAN KİŞİNİN AD VE SOYADINI GİRİNİZ");
            }
            else
            {


                baglan.Open();

                OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                    ("SELECT ADI,SOYADI FROM Tablo1 WHERE ADI='" + textBox6.Text.Trim() + "' AND SOYADI='" + textBox7.Text.Trim() + "'", baglan);


                OleDbCommand sil = new OleDbCommand
                    ("DELETE FROM TABLO1  WHERE ADI='" + textBox6.Text.Trim() + "' AND SOYADI='" + textBox7.Text.Trim() + "' ", baglan);

                OleDbDataReader dr = ara.ExecuteReader();         // kayıt yoksaki durumlar için yukardaki ise kayıt varsa onu siler
                if (dr.Read() == true)
                {
                    
                    sil.ExecuteNonQuery();
                    guncelle();

                    
                }
                else
                {
                    MessageBox.Show("ARANINILAN KAYIT SİSTEMDE YOK");
                }


                baglan.Close();
                guncelle();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();

            OleDbCommand ara = new OleDbCommand               // önce kayıdı arıcaz bulunursasilicez
                ("SELECT ADI,SOYADI FROM Tablo1 WHERE ADI='" + textBox8.Text.Trim() + "' AND SOYADI='" + textBox9.Text.Trim() + "'", baglan);

            OleDbDataReader dr = ara.ExecuteReader();

            // kayıt yoksaki durumlar için yukardaki ise kayıt varsa onu siler
            if (dr.Read() == true)
            {


                MessageBox.Show("KAYIT VAR");

                guncelle();


            }
            else
            {
                MessageBox.Show("ARANINILAN KAYIT SİSTEMDE YOK");
            }


            baglan.Close();
            guncelle();

        }

    }
}
