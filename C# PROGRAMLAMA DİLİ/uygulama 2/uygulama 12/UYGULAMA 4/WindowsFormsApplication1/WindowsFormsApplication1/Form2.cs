using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;   // veri tabanı bağlantısı yaptık 

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
            ("Provider = Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");  // bağlantı yaptık

        CrystalReport1 rapor = new CrystalReport1();
        DataSet ds = new DataSet();  //veri kaynağı ile ilgili

        private void Form2_Load(object sender, EventArgs e)
        {
            baglan.Open();
            
            ds.Clear();    // her çalıştığında yenilesin.
            OleDbDataAdapter da = new OleDbDataAdapter(Form1.metin,baglan);  // form1 deki sql değerini çektik.
            da.Fill(ds,"TABLO1");
            rapor.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rapor;
            
            baglan.Close();

        }
    }
}
