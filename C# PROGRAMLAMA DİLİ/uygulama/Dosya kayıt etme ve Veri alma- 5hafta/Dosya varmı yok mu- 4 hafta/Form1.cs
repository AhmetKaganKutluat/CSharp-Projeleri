using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//txt dosyası ekleyince yazılır.

namespace Dosya_varmı_yok_mu__4_hafta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("bilgiler.txt") == true)
            {
                MessageBox.Show("Dosya Vardır.");
            }
            else
            {
                MessageBox.Show("Dosya Yoktur.");
                DialogResult sor;
                sor = MessageBox.Show("Dosya Yaratılsın Mı ?","Dosya Oluşturma",MessageBoxButtons.YesNo);

                if (sor == DialogResult.Yes)
                {
                    StreamWriter dosya;
                    dosya = File.CreateText("bilgiler.txt");
                    Close();
                }


            }


            comboBox1.Items.Add("SAMSUN");
            comboBox1.Items.Add("ANTALYA");
            comboBox1.Items.Add("ANKARA");
            comboBox1.Items.Add("İSTANBUL");
            comboBox1.Items.Add("İZMİR");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter kaydet;
            kaydet = File.AppendText("bilgiler.txt");
            kaydet.WriteLine(textBox1.Text+"\t\t"+comboBox1.Text+"\t\t"+richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Başarılı Kaydedildi.");

            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader dosya;
            string okunan;
            dosya = File.OpenText("bilgiler.txt");
            while (((okunan = dosya.ReadLine()) != null))
            {
                listBox1.Items.Add(okunan);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sor2;
            sor2 = MessageBox.Show("Dosya Yaratılsın Mı ?", "Dosya Oluşturma", MessageBoxButtons.YesNo);
        }
    }
}
