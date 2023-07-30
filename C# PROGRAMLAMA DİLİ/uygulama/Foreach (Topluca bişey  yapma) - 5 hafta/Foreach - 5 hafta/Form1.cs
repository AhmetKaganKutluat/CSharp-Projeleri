using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreach___5_hafta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(CheckBox pasif in Controls.OfType<CheckBox>())
            {
                pasif.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(char karakter in textBox1.Text.Trim().ToUpper())
            {
                MessageBox.Show(karakter.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(TextBox temizle in Controls.OfType<TextBox>())
            {
                temizle.Clear();
            }
        }
    }
}
