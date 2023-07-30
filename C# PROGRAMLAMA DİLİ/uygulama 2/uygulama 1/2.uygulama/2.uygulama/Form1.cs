using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb ;// accses veri tabanı dosyası için kullanıldı

namespace _2.uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


    
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.Ace.Oledb.12.0; Data Source =bilgiler.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                baglan.Open();
                MessageBox.Show("BAĞLANTI AÇIK");
                
            }
            catch(Exception hata)
            {
                MessageBox.Show("VERİ TABANI BAĞLANTISI YAPILAMIYOR\n"+hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (baglan.State == ConnectionState.Open)
            {
                MessageBox.Show("VERİ TABANI BAĞLANTISI ZATEN AÇIK");
                baglan.Close();
            }
            else
            {
                MessageBox.Show("BAĞLANTI KAPALI");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
