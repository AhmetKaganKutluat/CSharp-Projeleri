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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
       ("Provider=Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");

        int sayac = 3;

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();

            OleDbCommand vericek = new OleDbCommand
                ("SELECT * FROM TABLO3 WHERE KULLANICI='"+textBox1.Text.Trim()+"' AND SIFRE='"+textBox2.Text.Trim()+"'",baglan);

            OleDbDataReader oku = vericek.ExecuteReader();

            if (oku.Read() == true)
            {
                Form1 goster = new Form1();
                goster.ShowDialog();
            }
            else
            {
                sayac = sayac - 1;

                MessageBox.Show("KULLANICI ADI VEYA SIFREDE HATA VAR...    TEKRAR DENEYİNİZ KALAN HAKKINIZ  :" + sayac);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();

                if (sayac == 0)
                {
                    Environment.Exit(0);
                }
             
            }


            baglan.Close();

        }
    }
}
