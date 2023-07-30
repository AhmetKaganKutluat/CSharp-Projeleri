using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//bunu eklemeden dosya işlemleri olmazdı

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) //eğer colordialog1 den bir renk seçilip ok a basılırsa yap
            {
               // colorDialog1.ShowDialog();
                this.BackColor = colorDialog1.Color;   //bu formun arka rengini seçilen renk yap.
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text,//sistem kaynaklarındaki string metinleri richtextboxtan al ve yaz(yani yukarda sistem bize e olarak vermiş)
                new Font("Verdana",16,FontStyle.Bold),Brushes.Black,150,100); //yeni font verdana ,boyutu 16,fontstylesi kalın yani bold,rengi siyah (brushes),150-100 olayıda mürekkep basması makinenin
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog kayıt = new SaveFileDialog();
            kayıt.Filter = "Metin Belgesi|*.txt"; //aralara boşluk koyma
            kayıt.Title = "Metin Belgesi Tiğinde Kaydet";
            kayıt.InitialDirectory = @"C:\"; //yol bulunsun diye başına @ 
            kayıt.OverwritePrompt = true;  //üzerine yazılsın mı ?
            kayıt.CreatePrompt = true;  //yoksa dosya oluşturulsun mu ? (kendi sorusu var)
            if (kayıt.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dosya = new StreamWriter(kayıt.FileName);
                dosya.WriteLine(richTextBox1.Text);
                dosya.Close();
                MessageBox.Show("Bilgiler başarı ile kaydedildi... \nKaydedilen Dosya : "+kayıt.FileName);
            }

        }
    }
}
