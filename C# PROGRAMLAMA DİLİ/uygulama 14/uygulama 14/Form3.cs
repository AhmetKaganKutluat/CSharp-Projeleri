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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2. bi yötemle dosyadan okuma
            StreamReader dosya = File.OpenText("ogr/bilgiler.txt");
            while (!dosya.EndOfStream)
            {
                string yazi = dosya.ReadLine();
                listBox1.Items.Add(yazi );
                comboBox1.Items.Add(yazi );
                richTextBox1.Text += yazi + "\n";
                textBox1.Text += yazi + "\n" ;
 
            }
        }
    }
}
