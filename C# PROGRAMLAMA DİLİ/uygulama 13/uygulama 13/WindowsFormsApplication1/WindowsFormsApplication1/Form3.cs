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
        string[] isimler = new string[5];
        private void Form3_Load(object sender, EventArgs e)
        {
          
            isimler[0]= "SELAM KAÇMAZ";
            isimler[1] = "MEHMET KAÇMAZ";
            isimler[2] = "OSMAN KAÇAK";
            isimler[3] = "ADANA SORGU";
            isimler[4] = "MEHMET HOCA";
            
            listBox1.Items.Add(isimler[0]);
            listBox1.Items.Add(isimler[1]);
            listBox1.Items.Add(isimler[2]);
            listBox1.Items.Add(isimler[3]);
            listBox1.Items.Add(isimler[4]);
          
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ARTAN SIRALAMA
            listBox1.Items.Clear();
            Array.Sort(isimler);
            for (int i = 0; i <= 4; i++)
            {
                listBox1.Items.Add(isimler[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AZALAN SIRALAMA
            listBox1.Items.Clear();
            Array.Sort(isimler);
            for (int i = 4; i >= 0; i--)
            {
                listBox1.Items.Add(isimler[i]);
            }

        }
        public static string ad, soyad;
        private void button3_Click(object sender, EventArgs e)
        {
            ad = textBox1.Text;
            soyad = textBox2.Text;
            Form4 goster = new Form4();
            goster.ShowDialog();

        }
    }
}
