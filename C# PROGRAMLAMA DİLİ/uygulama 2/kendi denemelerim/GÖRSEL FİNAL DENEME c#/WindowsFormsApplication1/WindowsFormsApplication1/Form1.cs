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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DialogResult sor;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            sor = MessageBox.Show("PROGRAM KAPATILSIN MI ?","ÇIKIŞ",MessageBoxButtons.YesNo);
            if (sor == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 ac = new Form2();
            ac.MdiParent = this;
            ac.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form7 ac1 = new Form7();
            ac1.MdiParent = this;
            ac1.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form6 ac2 = new Form6();
            ac2.MdiParent = this;
            ac2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form5 ac3 = new Form5();
            ac3.MdiParent = this;
            ac3.Show();
        }
    }
}
