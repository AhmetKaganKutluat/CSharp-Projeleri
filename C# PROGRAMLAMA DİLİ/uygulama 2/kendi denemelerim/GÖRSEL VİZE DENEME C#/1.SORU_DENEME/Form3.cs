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

namespace _1.SORU_DENEME
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        public static string cekadi, ceksoyadi,ilce,urun,birimfiyat,adet,toplamborc,satıstarihi;
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = cekadi;
            textBox2.Text = ceksoyadi;
            textBox3.Text = ilce;
            textBox4.Text = urun;
            textBox5.Text = birimfiyat;
            textBox6.Text = adet;
            textBox7.Text = toplamborc;
            textBox8.Text = satıstarihi;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand guncelle = new OleDbCommand("update müsteriler set ADI='" + textBox1.Text + "',SOYADI='" + textBox2.Text + "' where ADI='" + Form1.ad1 + "' and SOYADI='" + Form1.soyad1 + "'", baglan);
            baglan.Open();
            guncelle.ExecuteNonQuery();
            baglan.Close();          


        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
