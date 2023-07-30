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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bilgilerDataSet.Tablo1' table. You can move, or remove it, as needed.
            this.tablo1TableAdapter.Fill(this.bilgilerDataSet.Tablo1);

        }


        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();

            OleDbCommand kayıtara = new OleDbCommand
            ("SELECT * FROM TABLO1 WHERE ADI='" + textBox1.Text + "' AND SOYADI='" + textBox2.Text + "'", baglan);
            dr = kayıtara.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["ADI"].ToString();
                textBox4.Text = dr["SOYADI"].ToString();
                textBox5.Text = dr["MEMLEKET"].ToString();
                textBox6.Text = dr["MESLEK"].ToString();
                textBox7.Text = dr["GELİR"].ToString()+" ₺";
                textBox8.Text = dr["GİDER"].ToString()+ " ₺";
            }
            else
            {
                MessageBox.Show("ARANILAN KAYIT SİSTEMDE YOK");
            }

            baglan.Close();

        }
    }
}
