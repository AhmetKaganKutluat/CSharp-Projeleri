using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_Catch_Karşılaştırma__5_hafta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().ToUpper() == listBox1.SelectedItem.ToString())
                {
                    MessageBox.Show("AYNI İSİM VAR");
                }
                else
                {
                    MessageBox.Show("AYNI İSİM YOK");
                }
            }

            catch
            { 
            }
        }
    }
}
