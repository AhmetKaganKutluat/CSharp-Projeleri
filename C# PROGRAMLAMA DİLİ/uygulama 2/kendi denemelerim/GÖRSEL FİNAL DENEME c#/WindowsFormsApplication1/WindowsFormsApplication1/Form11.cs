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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        DataSet ds = new DataSet();
        CrystalReport2 rapor = new CrystalReport2();
        private void Form11_Load(object sender, EventArgs e)
        {
            baglan.Open();
            ds.Clear();
            OleDbDataAdapter cek = new OleDbDataAdapter(Form5.metin1, baglan);
            cek.SelectCommand.Parameters.AddWithValue("@tar1", Form5.t1);
            cek.SelectCommand.Parameters.AddWithValue("@tar2", Form5.t2);
            cek.Fill(ds, "musterıler");
            rapor.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rapor;
            baglan.Close();
        }
    }
}
