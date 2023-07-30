using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;// SQL SERVERİÇERİSİNE BAĞLANTI YAPMAK İÇİN KULLANILIR.
namespace _3.uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection bag = new SqlConnection("server=.; Initial Catalog=MUSTAFA; Integrated Security=True");
        //("Data Source=.; database=MUSTAFA; Integrated Security=SSPI");  // bu şekilede yazabilriz.
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand kaydet = new SqlCommand
           
           ("INSERT INTO Tablo1(ADI,SOYADI) VALUES ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "')", bag);

            kaydet.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("KAYIT EDİLDİ");


        }

    }
}
