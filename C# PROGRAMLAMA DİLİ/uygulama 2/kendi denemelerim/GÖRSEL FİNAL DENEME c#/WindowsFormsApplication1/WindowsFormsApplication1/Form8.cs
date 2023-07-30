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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form6.adi;
            textBox2.Text = Form6.soyadi;
            textBox3.Text = Form6.urun;
            textBox4.Text = Form6.toplamfiyat;
            textBox5.Text = Form6.satısturu;
        }
    }
}
