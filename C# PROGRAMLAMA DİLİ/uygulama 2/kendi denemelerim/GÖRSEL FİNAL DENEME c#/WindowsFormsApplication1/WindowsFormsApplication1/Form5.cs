using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        public static string metin;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("ARANILACAK KİŞİNİN ADINI GİRİN ..!");
            else if (textBox2.Text == "")
                MessageBox.Show("ARANILACAK KİŞİNİN SOYADINI GİRİN ..!");
            else 
            {
                baglan.Open();
                metin = "select * from musterıler where ADI='" + textBox1.Text + "' and SOYADI='" + textBox2.Text + "'";
                OleDbCommand cek = new OleDbCommand(metin,baglan);
                OleDbDataReader oku = cek.ExecuteReader();
                if (oku.Read())
                {
                    Form10 ac = new Form10();
                    ac.ShowDialog();
                }
                else
                {
                    MessageBox.Show("KAYIT BULUNAMADI");
                }
                baglan.Close();
            }
        }
        public static string metin1;
        public static DateTime t1, t2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            { MessageBox.Show("1. Seçilen tarih 2. seçilen tarihten sonra olamaz ..!"); }
            else
            {
                t1 = dateTimePicker1.Value;
                t2 = dateTimePicker2.Value;

                metin1 = "select * from musterıler where SATISTARIHI between @tar1 and @tar2";
                baglan.Open();
                DataTable tablo = new DataTable();
                OleDbDataAdapter bilgi = new OleDbDataAdapter("select * from musterıler where SATISTARIHI between @tar1 and @tar2", baglan);                
                bilgi.SelectCommand.Parameters.AddWithValue("@tar1", t1);
                bilgi.SelectCommand.Parameters.AddWithValue("@tar2", t2);
                bilgi.Fill(tablo);
                baglan.Close();
                Form11 ac = new Form11();
                ac.ShowDialog();
                
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 ac = new Form9();
            ac.ShowDialog();
        }
    }
}
