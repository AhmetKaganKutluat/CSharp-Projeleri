using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 2;
            label1.Text = "PROGRAM YÜKLENİYOR.... %" + progressBar1.Value;
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                



            }
         

        }
    }
}
