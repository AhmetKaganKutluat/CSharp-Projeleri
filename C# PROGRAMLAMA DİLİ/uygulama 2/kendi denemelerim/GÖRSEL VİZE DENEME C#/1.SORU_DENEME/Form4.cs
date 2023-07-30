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

namespace _1.SORU_DENEME
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglan = new OleDbConnection("Provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            DataTable tablo = new DataTable();
            OleDbDataAdapter bilgi = new OleDbDataAdapter("select * from müsteriler where SATISTARIHI between @tarih1 and @tarhih2", baglan);
            bilgi.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            bilgi.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            bilgi.Fill(tablo);
            baglan.Close();
            dataGridView1.DataSource = tablo;
        }
    }
}
