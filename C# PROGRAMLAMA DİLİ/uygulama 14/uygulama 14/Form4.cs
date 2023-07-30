using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace uygulama_14
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] dosya = File.ReadAllLines("ogr/bilgiler.txt");
            foreach (string veriler in dosya)
            {
                listBox1.Items.Add(veriler);
                comboBox1.Items.Add(veriler );
                richTextBox1.Text += veriler + "\n";
                textBox1.Text += veriler + "\n";
            }


        }
    }
}
