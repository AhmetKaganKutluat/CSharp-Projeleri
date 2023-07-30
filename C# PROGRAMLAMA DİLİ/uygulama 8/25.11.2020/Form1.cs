using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25._11._2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 2; i <= 12; i++)
                comboBox1.Items.Add(i);
        }

        private void hesapla(double para,double vade)
        {
            double odenecek_taksitler = para / vade;
            DateTime bugun = DateTime.Now;
            DateTime odemegunu;

            for (int i = 0; i < vade; i++)

            {
                odemegunu = bugun.AddMonths(i + 1);

                if (odemegunu.DayOfWeek.ToString() == "Saturday")
                {
                    odemegunu = odemegunu.AddDays(-1);
                }
                else
                    if (odemegunu.DayOfWeek.ToString() == "Sunday")
                    {
                        odemegunu = odemegunu.AddDays(1);
                    }

                ListViewItem liste_elemanlari = new ListViewItem();
                liste_elemanlari.Text = odemegunu.ToLongDateString();
                liste_elemanlari.SubItems.Add(odenecek_taksitler.ToString ("C"));
                listView1.Items.Add(liste_elemanlari);
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                double para = Convert.ToDouble(textBox1.Text);
                double vade = Convert.ToDouble(comboBox1.SelectedItem);
                hesapla(para, vade);
            }

            catch
            {

                MessageBox.Show("LÜTFEN VERİ YADA DOĞRU VERİ GİRİNİZ\nMİKTAR ALANINI BOŞ BIRAKMAYINIZ!!!");
            }

            finally
            {
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                textBox1.Focus();
            }


        }
    }
}
