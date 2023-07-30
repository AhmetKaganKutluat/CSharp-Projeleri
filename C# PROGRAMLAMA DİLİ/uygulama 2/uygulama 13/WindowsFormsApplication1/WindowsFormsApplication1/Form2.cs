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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection
            ("Provider = Microsoft.Jet.Oledb.4.0; Data Source=bilgiler.mdb");

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series["Series1"].Points.Clear();   //x ve y eksenlerini sıfırlıcak guncellicek.
            
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ADI,GELİR FROM TABLO1",baglan);
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                chart1.Series["Series1"].Points.AddXY(oku["ADI"],oku["GELİR"]);


            }
                
            baglan.Close();

        }
    }
}
