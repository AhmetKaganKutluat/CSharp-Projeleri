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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Int32 sayi1, sayi2, sonuc;  // int değişkenlerimiz
        
        //string metin1;              // string değişkenlerimiz.

        private void Form1_Load(object sender, EventArgs e)
        {

        //  this.Text = "Bugün Günlerden Çarşamba"; // formun ismini değiştimek içn kullanılır.
        //    metin1 = "selam kaçmaz";   // metin1'in içine bir değer atadık salam kaçmaz diye .
        //    label1.Text = metin1;             // ve bu değeri label birin textine yazdırdık
          
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            // label1.Text = "yarın günlerden salı";  // göster butonuna tıklanınca label1 de bu yazı çıkacak.
           // sayi1 = 4; sayi2 = 5;           sonuc = sayi1 + sayi2;  // sayi ve sayi2 değer atadık bunu sonuc adlı değişkende toplattık.
          //  this.Text ="sonuc = " + sonuc.ToString();   // formun ismine bu sonucu yazdırdık stringe çevirip yazdırdık .
            sayi1 = Convert.ToInt32(textBox1.Text);
            sayi2 = Convert.ToInt32(textBox2.Text);
            sonuc = sayi1 + sayi2;
            label1.Text = "sonuc " + sonuc.ToString();
            textBox1.Clear(); textBox2.Clear(); textBox1.Focus();
       
        }

       


    }
}
