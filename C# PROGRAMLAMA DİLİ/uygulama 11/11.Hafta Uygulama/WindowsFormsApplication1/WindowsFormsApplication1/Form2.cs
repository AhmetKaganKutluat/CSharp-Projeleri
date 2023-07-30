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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form3 goster2 = new Form3();
            goster2.Name = "deneme";
            //if (Application.OpenForms["deneme"] == null) //eğer form serbest değilse yap(null hem boş hem serbest demek)
            //{
                goster2.MdiParent = this; // mdi formun içinde çalışması için böyle yapıp sonra gösteriyoruz.
                goster2.Show(); toolStripButton1.Enabled = false;
          //  }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (Application.OpenForms["deneme"] == null)
          //  { toolStripButton1.Enabled = false; }
            
            if (Form3.durum == true) toolStripButton1.Enabled = false;
            else toolStripButton1.Enabled = true;
        }
    }
}
