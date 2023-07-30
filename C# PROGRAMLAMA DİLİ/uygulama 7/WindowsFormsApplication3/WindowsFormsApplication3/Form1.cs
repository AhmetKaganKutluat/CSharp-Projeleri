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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 2;
            label1.Text = "Program yükleniyor. Bekleyiniz % " + progressBar1.Value;

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                //this.Hide();
                //Form2 mahmut = new Form2();
                //mahmut.ShowDialog();
                //this.Close();
            
            }

        }

       
       
    }
}
