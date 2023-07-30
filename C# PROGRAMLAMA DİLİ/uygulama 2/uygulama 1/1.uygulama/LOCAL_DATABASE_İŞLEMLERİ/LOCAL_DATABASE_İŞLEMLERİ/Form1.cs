using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe; // VERİ TABANINI BAĞLANMAK İÇİN YAPILIR. CE OLAN KENDİ İÇİNDE (SQD )BAĞLANTI SQL SİĞER SQL SERVER NORMAL SQL BAĞLANMAK İÇİN


namespace LOCAL_DATABASE_İŞLEMLERİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            this.tablo1TableAdapter.Fill(this.bilgilerDataSet1.Tablo1);


        }
        
        SqlCeConnection baglanti = new SqlCeConnection("Data Source="+Application.StartupPath +"\\bilgiler.sdf"); // connection olan compact bağlantı için
        
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCeCommand kaydet = new SqlCeCommand("insert into Tablo1(ADI,SOYADI,MEMLEKET) VALUES('"+textBox1.Text.Trim () +"','"+textBox2.Text.Trim()+"','"+comboBox1.Text +"')",baglanti);

            kaydet.ExecuteNonQuery();

            baglanti.Close();

     
            
            MessageBox.Show("TÜM BİLGİLER KAYDEDİLDİ");
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;

        }
    }
}
