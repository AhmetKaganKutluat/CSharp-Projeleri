using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        void guncelle()
        {
            OleDbDataAdapter cek = new OleDbDataAdapter("select * from musterıler",baglan);
            DataTable tablo = new DataTable();
            cek.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        int vadetoplam, pesintoplam;
        private void Form7_Load(object sender, EventArgs e)
        {
            guncelle();
            vadetoplam = 0;
            pesintoplam = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "PEŞİN")
                {
                    pesintoplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                }
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "VADE")
                {
                    vadetoplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                }
            }

            chart1.Series["Series1"].Points.Clear();


            chart1.Series["Series1"].Points.AddXY("VADE  " + vadetoplam.ToString("#,###.00 ₺"), vadetoplam);
            chart1.Series["Series1"].Points.AddXY("PEŞİN  " + pesintoplam.ToString("#,###.00 ₺"), pesintoplam);
                //chart1.Series["Series1"].LegendText = vadetoplam.ToString();
            chart1.Titles["Title1"].Text = "PEŞİN - VADE GRAFİĞİ";
            

                
           
        }
    }
}
