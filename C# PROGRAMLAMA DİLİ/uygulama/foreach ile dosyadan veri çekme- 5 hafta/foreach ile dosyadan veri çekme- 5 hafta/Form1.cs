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

namespace foreach_ile_dosyadan_veri_çekme__5_hafta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] okunan = File.ReadAllLines("bilgiler.txt");
               foreach(string okunanveriler in okunan)
               {
                   listBox1.Items.Add(okunanveriler);
               }
        }
    }
}
