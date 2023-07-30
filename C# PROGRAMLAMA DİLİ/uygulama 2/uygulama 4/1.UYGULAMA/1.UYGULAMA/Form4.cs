using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.UYGULAMA
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form3.kisi[0];
            textBox2.Text = Form3.kisi[1];
            textBox3.Text = Form3.kisi[2];
            textBox4.Text = Form3.kisi[3];
            textBox5.Text = Form3.kisi[4];
            textBox6.Text = Form3.kisi[5];

        }
    }
}
