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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 goster1 = new Form2();
            goster1.MdiParent = this;
            goster1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Form2.acik == true)
            {
                toolStripButton1.Enabled = false;
            } //if endi
            if (Form2.acik == false)
            {
                toolStripButton1.Enabled = true;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "ANA SAYFA  " + DateTime.Now;

        }
    }
}
