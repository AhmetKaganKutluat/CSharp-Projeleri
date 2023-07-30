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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bilgiler.accdb");
        void vadeguncelle()
        {            
            OleDbDataAdapter cek = new OleDbDataAdapter("select ADI,SOYADI,URUN,TOPLAMFIYAT,SATISTURU from musterıler where SATISTURU='VADE' ",baglan);
            DataTable tablo1 = new DataTable();
            cek.Fill(tablo1);
            dataGridView1.DataSource = tablo1;            
        }
        void pesinguncelle()
        {
            OleDbDataAdapter cek = new OleDbDataAdapter("select ADI,SOYADI,URUN,TOPLAMFIYAT,SATISTURU from musterıler where SATISTURU='PEŞİN' ", baglan);
            DataTable tablo1 = new DataTable();
            cek.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }
        public static  string adi, soyadi, urun, toplamfiyat, satısturu;
        private void button1_Click(object sender, EventArgs e)
        {
            adi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            soyadi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            urun = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            toplamfiyat = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            satısturu = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Form8 ac = new Form8();
            
            ac.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i=0; i< dataGridView1.RowCount; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) < 500)
                {
                    renk.BackColor = Color.Yellow;
                }
                else if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) > 500 && Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) < 1500)
                {
                    renk.BackColor = Color.LightGreen;
                }
                else
                {
                    renk.BackColor = Color.Red;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = null;
                vadeguncelle();

            }
            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = null;
                pesinguncelle();
            }
        }
    }
}
