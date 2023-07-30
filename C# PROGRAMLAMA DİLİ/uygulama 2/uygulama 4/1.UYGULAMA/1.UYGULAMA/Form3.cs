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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string[] kisi = new string[500];  // projeni heryerinde çalışan kişi adında bir değişken sonsuz boyutta 500 karakter uzunluğa sahip


        OleDbConnection baglan = new OleDbConnection
           ("Provider=Microsoft.Ace.Oledb.12.0; Data Source=bilgiler.accdb");

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bilgilerDataSet1.Tablo1' table. You can move, or remove it, as needed.
            this.tablo1TableAdapter.Fill(this.bilgilerDataSet1.Tablo1);

        }

        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand cmd = new OleDbCommand
            ("SELECT * FROM TABLO1 WHERE ADI='" + textBox1.Text + "' AND SOYADI='" + textBox2.Text + "'", baglan);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                for (int i = 0; i < 6; i++)
                {
                    kisi[i] = dr[i].ToString();
                }
                DialogResult sor = MessageBox.Show(kisi[0]+" "+kisi[1]+" isimli kişi yazdırılsınmı ? ","YAZDIR",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (sor == DialogResult.Yes)
                        {
                            Form4 ac = new Form4();
                            ac.ShowDialog();

                        }
                    else
                        {
                            textBox1.Clear();
                            textBox2.Clear();

                        }
            }
            else
            {
            MessageBox.Show("SİSTEMDE KAYITLI AD VE SOYAD YOKTUR.");
            }

            

            baglan.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
