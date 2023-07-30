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

namespace _1.SORU_DENEME
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bilgiler.accdb");
        void guncelle()
        {
            OleDbDataAdapter cek = new OleDbDataAdapter("select * from müsteriler where ADI='" + Form1.adi + "'", baglan);
            DataTable tablo = new DataTable();
            cek.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            guncelle();


        }
        int ode,toplamborc,kalanborc;
        private void oDEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ode = Convert.ToInt32(Interaction.InputBox("ÖDEME YAPILACAK MİKTARI GİRİNİZ ..","ÖDEME EKRANI","Buraya giriniz ..."));
            toplamborc=Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
            if (ode > toplamborc)
            {
                MessageBox.Show("BÜYÜK OLAMAZ");
            }
            else
            {
                kalanborc = toplamborc - ode;
                OleDbCommand guncel = new OleDbCommand("update müsteriler set TOPLAMBORC='" + kalanborc.ToString() + "' where ADI='" + Form1.adi + "'", baglan);
                OleDbCommand kayit = new OleDbCommand("insert into odemeyapanlar(ADI,SOYADI,ODEMEMIKTARI,TARIH) values('" + Form1.adi + "','" + Form1.soyadi + "','" + ode.ToString() + "','" + DateAndTime.Now.ToShortDateString() + "')", baglan);
                baglan.Open();
                guncel.ExecuteNonQuery();
                kayit.ExecuteNonQuery();
                baglan.Close();
                guncelle();
                MessageBox.Show("ÖDEME YAPILDI");
            }
            if (Convert.ToInt32(Convert.ToInt32(dataGridView1.SelectedCells[6].Value.ToString())) == 0)
            {
                OleDbCommand kayit1 = new OleDbCommand("insert into odemesibitenler(AD,SOYAD,TOPLAMBORC) values('" + Form1.adi + "','" + Form1.soyadi + "','" + toplamborc.ToString() + "')", baglan);
                OleDbCommand sil = new OleDbCommand("delete from müsteriler where ADI='" + Form1.adi + "' and SOYADI='" + Form1.soyadi + "'", baglan);
                
                baglan.Open();
                kayit1.ExecuteNonQuery();
                sil.ExecuteNonQuery();
                baglan.Close();


            }
        }
    }
}
