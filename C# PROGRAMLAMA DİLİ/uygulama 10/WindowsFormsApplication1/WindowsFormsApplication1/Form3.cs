﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        FHESAPLA faktoryel = new FHESAPLA();
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                int sayi = Convert.ToInt32(textBox1.Text.Trim());

                MessageBox.Show("girilen sayının faktoryeli  " + faktoryel.hesapla(sayi));

            }
            catch
            {
                MessageBox.Show("nütfen sayi giriniz");
            }
            finally
            {
                textBox1.Clear();
            }

        }
    }
}
