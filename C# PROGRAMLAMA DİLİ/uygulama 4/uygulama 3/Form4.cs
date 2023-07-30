using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // txt dosyaları için buraya tanımlanır.//streamreade yada streamwriter işlemleri için kullanılır.

namespace uygulama_3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (File.Exists("bilgiler.txt") == true)
            {
                MessageBox.Show("bilgiler.txt dosyası vardır .");
            }
            else
            {
                MessageBox.Show("bilgiler.txt dosyası yoktu !! ");
                DialogResult sor;
                sor = MessageBox.Show("bilgiler.txt dosyası yaratılsınmı ", "DOSYA OLUŞTURMA", MessageBoxButtons.YesNo);
                if (sor == DialogResult.Yes)
                {
                    StreamWriter dosya;
                    dosya = File.CreateText("bilgiler.txt");
                    dosya.Close();

                }

            }

            comboBox1.Items.Add("SAMSUN");
            comboBox1.Items.Add("İSTANBUL");
            comboBox1.Items.Add("KIRKLARELİ");
            comboBox1.Items.Add("İZMİR");
            comboBox1.Items.Add("BURSA");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter kaydet;
            kaydet = File.AppendText("bilgiler.txt");
            kaydet.WriteLine(textBox1 .Text +"\t\t"+comboBox1 .Text +"\t\t"+richTextBox1 .Text );
            kaydet.Close();
            MessageBox.Show("BİLGİLER BAŞARIYLA KAYDEDİLDİ ");
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            richTextBox1.Clear();
            textBox1.Focus();
        }
    }
}   
