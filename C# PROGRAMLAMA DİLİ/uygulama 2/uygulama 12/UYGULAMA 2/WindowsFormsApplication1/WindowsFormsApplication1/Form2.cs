using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bilgilerDataSet.Tablo1' table. You can move, or remove it, as needed.
            this.Tablo1TableAdapter.Fill(this.bilgilerDataSet.Tablo1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
