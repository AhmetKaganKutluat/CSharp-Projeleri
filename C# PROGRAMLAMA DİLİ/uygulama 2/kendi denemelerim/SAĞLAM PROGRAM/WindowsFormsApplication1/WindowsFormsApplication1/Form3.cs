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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 goster1 = new Form1();
            goster1.MdiParent = this;
            goster1.Show();
        }
        public static Boolean durum;
        private void Form3_Load(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (durum == true)
            {
                toolStripButton1.Enabled = false;
            }
            if(durum ==false)
            {
                toolStripButton1.Enabled = true;
            }
        }
    }
}
