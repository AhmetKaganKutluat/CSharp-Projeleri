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

namespace _2.uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider =Microsoft.Ace.Oledb.12.0; Data Source =bilgiler.accdb");

        private void vericek()
        {
            // 2 . bir yöntemle data adamptor kullanark veri tabanı bağlantısı yapma

            DataTable tablo = new DataTable(); // data table hangi yöntem olursa olsun şart

            OleDbDataAdapter bilgiler = new OleDbDataAdapter("SELECT * FROM TABLO1", baglan); // bunun avantajı veri tabannı bağlantısı açmadan kapatmadan kendisi yapar. açma ve kapatmaya gerek kalmaz
            bilgiler.Fill(tablo);  // aktarma yapıcam kime sanal tabloya 
            dataGridView1.DataSource = tablo;  // kimden bilgi alıcak grid tablodan



        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            mes = "";
        
        
        }



        string mes;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                mes = checkBox1.Text;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                mes = checkBox2.Text;
                checkBox1.Checked = false;
                checkBox3.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                mes = checkBox3.Text;
                checkBox1.Checked = false;
                checkBox2.Checked = false;

            }
        }

        DialogResult sor;
        private void button1_Click(object sender, EventArgs e)
        {
            // try catch finally kullanarak kayıt işlemi yapılacak
            if (textBox1.Text != "" && textBox2.Text != "")  // boş değilse ! o anlama geliyo
            {

                try
                {


                    OleDbCommand kaydet = new OleDbCommand
                    ("INSERT INTO TABLO1(ADI,SOYADI,MEMLEKET,MESLEK,KAYIT_ZAMANI) VALUES ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox1.Text + "','" + mes + "','"+DateTime.Now+"')", baglan);
                    sor = MessageBox.Show(textBox1.Text + " " + textBox2.Text + "  isimli kayıt yapılsınmı ", "KAYIT İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (sor == DialogResult.Yes)
                    {
                        baglan.Open();
                        kaydet.ExecuteNonQuery();
                        baglan.Close();
                    }
                    vericek();
                    temizle();





                }
                catch
                {
                    MessageBox.Show("VERİTABANINA (bilgiler.accdb) DOSYASINA KAYIT YAPILAMADI");

                }
                finally
                {
                    temizle();
                }

            }

            else
            {
                MessageBox.Show("LÜRFEN MÜŞTERİNİN ADINI VE SOYADINI GİRİNİZ .\n\n            LÜTFEN ALANLARI DOLDURUNUZ");

            }



           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            vericek();
            dataGridView1.Columns[0].Visible = false;   // kimliği gizlemek için 
            dataGridView1.Columns[3].Width = 150;   // memleketin colonunu uzattık
            dataGridView1.Columns[4].Width = 150;   // kayıt tarıhını uzattık
        }
    }
}
