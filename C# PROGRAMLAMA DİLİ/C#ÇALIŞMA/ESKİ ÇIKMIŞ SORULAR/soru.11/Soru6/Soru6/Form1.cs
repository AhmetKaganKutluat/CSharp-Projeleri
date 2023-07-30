using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soru6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string tc, ad, soyad, bolum, hoca, ders, sinif, harfNot;
        int y1, y2, y3, s1, s2; double yOrt, sOrt,Ort;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("1.BÖLÜM");
            comboBox1.Items.Add("2.BÖLÜM");
            comboBox1.Items.Add("3.BÖLÜM");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.Add(comboBox1.Text + " 1. HOCA");
            comboBox2.Items.Add(comboBox1.Text + " 2. HOCA");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(comboBox2.Text + " 1. Ders");
            comboBox3.Items.Add(comboBox2.Text + " 2. Ders");
            comboBox3.Items.Add(comboBox2.Text + " 3. Ders");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "ÖĞRENCİ OTOMASYON SİSTEMİ " + DateTime.Now.ToString();
            if (label7.Enabled && label8.Enabled && label9.Enabled)
            {
                label7.Enabled = false;
                label8.Enabled = false;
                label9.Enabled = false;
            }
            else
            {
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar>47 && e.KeyChar<58) || e.KeyChar==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sinif = checkBox1.Text;
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                sinif = checkBox2.Text;
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text!="")
            {
                   if (textBox2.Text!="")
                {
                        if (textBox3.Text!="")
                    {
                       
                        tc = textBox1.Text;
                        ad = textBox2.Text.ToUpper();
                        soyad= textBox3.Text.ToUpper();
                        bolum = comboBox1.Text.ToUpper();
                        hoca = comboBox2.Text.ToUpper();
                        ders = comboBox3.Text.ToUpper();

                        
                        y1 = Convert.ToInt32(textBox4.Text);
                        y2 = Convert.ToInt32(textBox5.Text);
                        y3 = Convert.ToInt32(textBox6.Text);
                        yOrt = ((y1 + y2 + y3) / 3) * 0.7;
                        s1 = Convert.ToInt32(textBox7.Text);
                        s2 = Convert.ToInt32(textBox8.Text);
                        sOrt = ((s1 + s2) / 2) * 0.3;
                        Ort = yOrt + sOrt;
                      
                        if (Ort >= 0 && Ort < 45)
                        {
                            harfNot = "FF";
                        }
                        else if (Ort >= 45 && Ort < 65)
                        {
                            harfNot = "CD";
                        }
                        else if (Ort >= 65 && Ort < 75)
                        {
                            harfNot = "BC";
                        }
                        else if (Ort >= 75 && Ort < 85)
                        {
                            harfNot = "BB";
                        }
                        else if (Ort >= 85 && Ort < 90)
                        {
                            harfNot = "BA";
                        }
                        else if (Ort >= 90 && Ort < 101)
                        {
                            harfNot = "AA";
                        }
                        DialogResult kaydet;
                        kaydet = MessageBox.Show(textBox1.Text + " "+textBox2.Text+ " "+textBox3.Text +" İSİMLİ KİŞİ KAYIT YAPILSIN MI?", 
                            "KAYIT İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (kaydet == DialogResult.Yes)
                        {
                            listBox1.Items.Add(tc + "  " + ad + "  " + soyad + "  " + bolum +
                              "  " + hoca + "  " + ders + "  " + sinif + Ort.ToString() + "  " + harfNot);
                            temizle();
                        }
                        else
                        {
                            temizle();
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show(label3.Text+" Alanını Doldurunuz");
                    }
                }
                else
                {
                    MessageBox.Show(label2.Text + " Alanını Doldurunuz");
                }
            }
            else
            {
                MessageBox.Show(label1.Text + " Alanını Doldurunuz");
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
               Application.Exit();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void sistemeKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
            }
        }


        void temizle()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
            comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1; comboBox3.SelectedIndex = -1;
            checkBox1.Checked = false; checkBox2.Checked = false;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox3.Focus();
            }
        }

       

    }
}
