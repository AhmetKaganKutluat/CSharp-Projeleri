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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void fark_hesapla()
        { 
         // kaç tane kayıt var önce saydırmamız lazım
            for (int i = 0; i < dataGridView1.RowCount; i++)
            { 
            int gelir_toplam = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            int gider_toplam = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            int gelir_gider_fark = gelir_toplam - gider_toplam;
            dataGridView1.Rows[i].Cells[6].Value = gelir_gider_fark;
            }

        }

            OleDbConnection baglan = new OleDbConnection
            ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");
       
        DataTable tablo = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter
            ("SELECT * FROM Tablo1",baglan);
           
            adaptor.Fill(tablo);
            
            dataGridView1.DataSource = tablo;

            fark_hesapla();

            int toplamgelir = 0; int toplamgider = 0;
            for (int i = 0; i< dataGridView1.Rows.Count; i++)
            {
                toplamgelir += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                toplamgider += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);

                label1.Text = "GELİR TOPLAMLARI    : " + toplamgelir.ToString("0,###.00")+" ₺";
                label2.Text = "GİDER TOPLAMLARI    : " + toplamgider.ToString("0,###.00") + " ₺";
                label3.Text = "GELİR GİDER FARKI   : " + (toplamgelir - toplamgider).ToString("0,###.00") + " ₺";
          
          


            }

        }

        DataView isme_gore_ara()
        {
            DataView ara = new DataView();
            ara = tablo.DefaultView;
            ara.RowFilter = "ADI LIKE '%"+textBox1.Text+"%'";
            dataGridView1.DataSource = ara;
            return ara;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isme_gore_ara();
        }

        DataTable tablo1 = new DataTable();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                OleDbDataAdapter veri = new OleDbDataAdapter
                ("SELECT * FROM TABLO1",baglan);
                veri.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
            }
            else
            {
                OleDbDataAdapter veri = new OleDbDataAdapter
                  ("SELECT * FROM TABLO1 WHERE SOYADI='%"+textBox2.Text+"%'", baglan);
                veri.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
            }
        }
    }
}
