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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
        ("Provider=Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            
            yukle();
            

            // VERİ TABANINDAKİ BİLGİLER 1 DAN BAŞLAR KAYIT OLARAK
            int i;

            for (i = 0; i<=dataGridView1.Rows.Count - 1; i++)
            {
                if ((int)(dataGridView1.Rows[i].Cells["ORTALAMA"].Value) <= 50)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }
                else
                    if ((int)(dataGridView1.Rows[i].Cells["ORTALAMA"].Value) <= 70)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else
                        if ((int)(dataGridView1.Rows[i].Cells["ORTALAMA"].Value) <= 85)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Fuchsia;
                        }
                        else
                            if ((int)(dataGridView1.Rows[i].Cells["ORTALAMA"].Value) <= 99)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                            }
                            else
                                if ((int)(dataGridView1.Rows[i].Cells["ORTALAMA"].Value) == 100)
                                {
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                                }


            }

        }

        void yukle()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter veriler = new OleDbDataAdapter   //giride çekerken tabloyu adapter kullanıyoruz command değil
            ("SELECT * FROM Tablo2",baglan);
            veriler.Fill(dt);
            dataGridView1.DataSource = dt;
        
        }

    }
}
