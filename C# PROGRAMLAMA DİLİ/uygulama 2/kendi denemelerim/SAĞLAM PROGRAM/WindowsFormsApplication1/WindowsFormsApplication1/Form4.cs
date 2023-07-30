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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
                textBox1.Text=Form2.det_ad;
                textBox2.Text=Form2.det_soyad; 
                textBox3.Text=Form2.det_il;
                textBox4.Text=Form2.det_ilce;
                textBox5.Text=Form2.det_urun;
                textBox6.Text=Form2.det_toplam_borc;
                textBox7.Text=Form2.det_kalan_borc;
                textBox8.Text = Form2.det_kayıttarıhı;
        }
    }
}
