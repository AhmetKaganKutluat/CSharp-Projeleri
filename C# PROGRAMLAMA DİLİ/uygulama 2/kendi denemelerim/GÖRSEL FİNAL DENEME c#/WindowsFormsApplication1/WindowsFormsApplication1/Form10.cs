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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source = bilgiler.accdb");
        DataSet ds = new DataSet();
        CrystalReport1 rapor = new CrystalReport1();
        private void Form10_Load(object sender, EventArgs e)
        {
            baglan.Open();
            ds.Clear();
            OleDbDataAdapter cek = new OleDbDataAdapter(Form5.metin, baglan);
            cek.Fill(ds, "musterıler");
            rapor.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rapor;
            baglan.Close();
        }

        
    }
}
