using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i <= 9; i++)
            {
                i = i + 1;
                listBox1.Items.Add(i);
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           int  secim = Convert.ToInt16 (MessageBox.Show(listBox1.SelectedItem + "  karşıya yüklemek istermisiniz", "yükleme ", MessageBoxButtons.YesNo ));
            if (secim == 6)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            
            }
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                button1.Enabled = false;
            }
        }
    }
}
