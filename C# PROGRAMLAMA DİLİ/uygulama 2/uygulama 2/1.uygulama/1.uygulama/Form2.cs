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

namespace _1.uygulama
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan2 = new OleDbConnection("Provider =Microsoft.Jet.Oledb.4.0; Data Source =bilgiler.mdb");

        private void yukle2()
        { 
            // 2 . bir yöntemle data adamptor kullanark veri tabanı bağlantısı yapma

            DataTable tablo = new DataTable(); // data table hangi yöntem olursa olsun şart

            OleDbDataAdapter bilgicek = new OleDbDataAdapter("SELECT * FROM TABLO1",baglan2); // bunun avantajı veri tabannı bağlantısı açmadan kapatmadan kendisi yapar. açma ve kapatmaya gerek kalmaz
            bilgicek.Fill(tablo);  // aktarma yapıcam kime sanal tabloya 
            dataGridView1.DataSource = tablo;  // kimden bilgi alıcak grid tablodan
        
        
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            yukle2();

            dataGridView1.Columns["MEMLEKET"].Visible = false;   // MEMLEKET KOLAUNUNU GİZLEMEK İÇİN YADA GRİD ÖZELLİKLERİDENDE YAPILABİLİRDİ


        }
    }
}
