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


        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void yukle()
        {
            // giride bilgi çekme  1. yol

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM TABLO1", baglan);  // bilgiyi çektik  * istediğimiz alan adını çağırıp sadece onlarıda gride çekebilirdik.
            DataTable tablo = new DataTable();   //  sanal bir tabloya aktarıcaz
            tablo.Load(komut.ExecuteReader());    // bu tablo şablonuna bir değer yüklicem soruyu soruyoruz nerden yüklicez ? execute reare oku sanal tabloya aktar demek.

            dataGridView1.DataSource = tablo;  // DATAGİRİND  VERİ KAYNAĞI(datasource) nerden gelicek = tablo 'dan .
            baglan.Close();
        
        
        
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yukle();

        }
    }
}
