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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();   // executereader yönteminden farklı bir yntemle yapıcaz
            OleDbCommand vericek = new OleDbCommand
            ("SELECT Count(*) FROM Tablo1 WHERE KULLANICI='"+textBox1.Text+"' AND SIFRE='"+textBox2.Text+"'",baglan);                //farklı bir yöntem

            int oku = Convert.ToInt32(vericek.ExecuteScalar());
            if (oku == 1)     //doğruysa
            {
                Form1 göster = new Form1();
                göster.ShowDialog();
            }
            else
            {
                MessageBox.Show("KULLANICI GİRİŞİ DOĞRULANMADI");
            }

            baglan.Close();

        }
    }
}
