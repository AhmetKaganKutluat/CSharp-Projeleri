using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace _5.SORU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int secim = Convert.ToInt16 (MessageBox.Show(listBox1.SelectedItem + "  sağ tarafa eklensin mi ? ","EKLEME",MessageBoxButtons.YesNo ));
            if (secim == 6)
            {
                listBox2.Items.Add(listBox1.SelectedItem );
                listBox1.Items.Remove(listBox1.SelectedItem) ;

            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("FENERBAHÇE");
            listBox1.Items.Add("GALATASARAY");
            listBox1.Items.Add("BEŞİKTAŞ");
            listBox1.Items.Add("TRABZONSPOR");
            listBox1.Items.Add("BURSA");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int  sec = Convert.ToInt16(MessageBox.Show(" tümü eklensin mi ? ", "EKLEME", MessageBoxButtons.YesNo));
             if (sec == 6)
             {
                 for (int i = 0; i < listBox1.Items.Count; i++)
                 {

                     listBox2.Items.Add(listBox1.Items[i].ToString());

                 } //for parantezi
                 listBox1.Items.Clear();
             }
             
        }
    }
}
