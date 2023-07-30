using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        
        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bilgilerDataSet.musterıler' table. You can move, or remove it, as needed.
            this.musterılerTableAdapter.Fill(this.bilgilerDataSet.musterıler);

            this.reportViewer1.RefreshReport();
        }
    }
}
