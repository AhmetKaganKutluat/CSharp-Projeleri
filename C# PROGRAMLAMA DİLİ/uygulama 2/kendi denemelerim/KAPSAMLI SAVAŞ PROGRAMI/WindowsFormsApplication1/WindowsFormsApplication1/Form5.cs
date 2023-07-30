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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form2.adıcek;


           textBox2.Text = Form2.soyadıcek;
          textBox3.Text =  Form2.ılcecek ;
          textBox4.Text =  Form2.uruncek ;
           textBox5.Text = Form2.birimfiyatcek.ToString(); 
           textBox6.Text = Form2.adetcek.ToString() ;
           textBox7.Text = Form2.toplamborccek.ToString();
           textBox8.Text = Form2.satistarihicek; 
        }
        public static string günceladı, güncelsoyadı;
        private void button1_Click(object sender, EventArgs e)
        {
            günceladı = textBox1.Text.Trim();
            güncelsoyadı = textBox2.Text.Trim();


            OleDbCommand kaydıguncelle = new OleDbCommand
                   ("UPDATE  musteriler SET ADI='" + günceladı + "' WHERE ADI='" + Form2.adıcek.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
            baglan.Open();
            kaydıguncelle.ExecuteNonQuery();
            // MessageBox.Show("Ödeme alındı.");
            baglan.Close();



            OleDbCommand kaydıguncelle1 = new OleDbCommand
                   ("UPDATE  musteriler SET SOYADI='" + güncelsoyadı + "' WHERE ADI='" + Form2.adıcek.ToString() + "'", baglan);  // borçtan düştük girilen değeri.
            baglan.Open();
            kaydıguncelle1.ExecuteNonQuery();
            // MessageBox.Show("Ödeme alındı.");
            baglan.Close();

            MessageBox.Show("Veritabanındaki Kayıt Güncellendi...");
            textBox1.Text = günceladı;
            textBox2.Text = güncelsoyadı;

        }
    }
}
