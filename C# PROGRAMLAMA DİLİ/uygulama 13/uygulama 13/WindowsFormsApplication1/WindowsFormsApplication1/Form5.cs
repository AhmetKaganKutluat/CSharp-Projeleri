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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("AKDENİZ BÖLGESİ");
            comboBox1.Items.Add("MARMARA BÖLGESİ");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        
            int secim;
            secim = comboBox1.SelectedIndex;//indekse göre aldık yani sırasına göre ama istersek textine görede alabilirdik. //textine almak istersek 
           /* if (secim == "AKDENİZ BÖLGESİ")
            {
                comboBox2.Items.Add("ANTALYA");
                comboBox2.Items.Add("ADANA");
                comboBox2.Items.Add("MERSİN");
            }*/ 
            //şeklinde olurdu ama değişkeni string yapmak gerekirdi.
            comboBox2.Items.Clear();
            if (secim == 0)
            {
              
                comboBox2.Items.Add("ANTALYA");
                comboBox2.Items.Add("ADANA");
                comboBox2.Items.Add("MERSİN");
            
            }
            if (secim == 1)
            {
               
                comboBox2.Items.Add("İSTANBUL");
                comboBox2.Items.Add("EDİRNE");
                comboBox2.Items.Add("BURSA");


            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(comboBox1.Text+" "+ comboBox2.Text+"\n");
            label1.Text = "Toplam Kayıt Sayısı = " + (richTextBox1.Lines.Count() - 1);

        }
    }
}
