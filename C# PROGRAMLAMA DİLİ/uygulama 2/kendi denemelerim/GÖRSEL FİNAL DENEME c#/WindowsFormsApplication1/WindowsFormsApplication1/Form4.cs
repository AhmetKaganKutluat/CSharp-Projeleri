﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private void comboyenile()
        {
            comboBox1.Items.Clear();
            baglan.Open();
            OleDbCommand il_goster = new OleDbCommand("SELECT ODENECEKAY FROM odemeler where ADI='" + Form2.ad1 + "' and SOYADI='"+Form2.soyad1+"'", baglan);
            OleDbDataReader okuyucu = il_goster.ExecuteReader();  // data adaptor gride veri ceker reader nesnelere çeker
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["ODENECEKAY"]);
            }

            baglan.Close();

        }
        string odememıktarı;
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form2.sifree;
            textBox2.Text = Form2.ad1;
            textBox3.Text = Form2.soyad1;
            textBox4.Text = Form2.urun;




            comboyenile();
            OleDbDataReader dr;
            OleDbCommand kayıtara = new OleDbCommand
            ("SELECT ODENECEKMIKTAR FROM odemeler", baglan);
            baglan.Open();
            dr = kayıtara.ExecuteReader();
            if (dr.Read())
            {
                odememıktarı = dr["ODENECEKMIKTAR"].ToString();
            }
            else
            {
                MessageBox.Show("HATA");
            }

            baglan.Close();
            comboyenile();
        }
        string secili;
        DialogResult soru;
        private void button1_Click(object sender, EventArgs e)
        {
            secili = comboBox1.Text;
            soru = MessageBox.Show("ODEME YAPILSIN MI ?", "ODEME YAP.", MessageBoxButtons.YesNo);
            if (soru == DialogResult.Yes)
            {
                OleDbCommand kayıt = new OleDbCommand
                       ("insert into odemeyapanlar(ADI,SOYADI,ODEME_MIKTARI,ODEME_TARIHI) values('" + textBox2.Text + "','" + textBox3.Text + "','" + odememıktarı.ToString() + "','" + DateTime.Now.ToShortDateString() + "')", baglan);
                OleDbCommand sil = new OleDbCommand
                       ("DELETE FROM odemeler  WHERE ADI='" + Form2.ad1 + "' and ODENECEKAY='" + secili + "' and SOYADI='"+Form2.soyad1+"'", baglan);
                baglan.Open();
                
                sil.ExecuteNonQuery();
                kayıt.ExecuteNonQuery();
                baglan.Close();
                comboyenile();
            }
        }
    }
}
