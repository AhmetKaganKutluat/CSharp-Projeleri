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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] rakam = { "SIFIR ", "BİR ", "İKİ ", "ÜÇ ", "DÖRT ", "BEŞ ", "ALTI ", "YEDİ ", "SEKİZ ", "DOKUZ " };

            if(e.KeyChar >= '0' && e.KeyChar <= '9')

            {

                textBox1.SelectedText = rakam[e.KeyChar - (char)'0'];//sadece basılanı gösterir.
                //textbob1.selectedindex derse ardı ardına ekler 
                e.Handled = true;//bu ifade yazılmaz ise basılan ifade ve metin birlikte gözükür.

            
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
          /*  switch (e.KeyCode)
            {
                case Keys.F1: textBox1.SelectedText = DateTime.Now.ToLongDateString();  // selected index yerine sadece text yazsak yukarda olduğu gibi tek sefer yazar arka arkaya eklemez.
                    break;
                case Keys.F2: textBox1.SelectedText = DateTime.Now.ToShortDateString();
                    break;
                case Keys.F5: textBox1.SelectedText = DateTime.Now.ToString();
                    break;
                      }
           */
            //veya
            /*
                if(e.KeyCode == Keys.F1)
                {textBox1.SelectedText = DateTime.Now.ToLongDateString();}
                 if(e.KeyCode == Keys.F2)
                 {textBox1.SelectedText = DateTime.Now.ToShortDateString();}
                 if(e.KeyCode == Keys.F5)
                 {textBox1.SelectedText = DateTime.Now.ToString();}
            */
            //veya
            if (e.KeyValue == Convert.ToInt32(Keys.F1))
            { textBox1.SelectedText = DateTime.Now.ToLongDateString(); }
            if (e.KeyValue == Convert.ToInt32(Keys.F2))
            { textBox1.SelectedText = DateTime.Now.ToShortDateString(); }
            if (e.KeyValue == Convert.ToInt32(Keys.F5))
            { textBox1.SelectedText = DateTime.Now.ToString(); }


            }
        }
    }

