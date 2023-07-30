using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//dosya işlemleri için eklemek gerekir.

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
            if (File.Exists("ogr/bilgiler.txt") == true)
            {
                MessageBox.Show("bilgiler.txt dosyası VARDIR .");
            }
            else
            {
                MessageBox.Show("Bilgiler.txt dosyası YOKTUR.");
                DialogResult sor;
                sor = MessageBox.Show("bilgiler.txt dosyası yaratılsınmı ", "TXT OLUŞTURMA", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (sor == DialogResult.Yes)
                {
                    StreamWriter dosya;
                    dosya = File.CreateText("ogr/bilgiler.txt");
                    dosya.WriteLine("PROGRAMLAMA");
                    dosya.Close();
                
                }//idin endi.
            }//elsin endi.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sor;
            sor = MessageBox.Show("bilgiler.txt dosyasını kopyalansın mı ? ", "TXT KOPYALAMA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sor == DialogResult.Yes)
            {
                File.Copy("ogr/bilgiler.txt","kopya/yedekbilgiler.txt",true); // yanına eklediğimiz true eğer daha önceden kopyalandıysa üzerine yazamaya yarıyor.
                MessageBox.Show("KOPYALAMA İŞLEMİ BAŞARIYLA TAMAMLAMDI.");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sor;
            sor = MessageBox.Show("bilgiler.txt dosyası taşınsın mı? ", "TXT TAŞIMA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sor == DialogResult.Yes)
            {
                File.Move("ogr/bilgiler.txt","kopya/taşındı.txt"); // ilk yer taşdığın şey 2. yerde taşıdığın yer //taşıdığın yere gönderirken ismini değiştirirsen değişir.
                MessageBox.Show("TAŞIMA İŞLEMİ BAŞARIYLA TAMAMLAMDI.");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sor;
            sor = MessageBox.Show("TAŞINDI.TXT SİLİNSİN Mİ ? ", "TXT SİLME ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sor == DialogResult.Yes)
            {
                File.Delete("kopya/taşındı.txt");
                MessageBox.Show("Silme İŞLEMİ BAŞARIYLA TAMAMLAMDI.");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Directory.Exists("aga")==true)  // aga dosyası var mı diyoruz. dosyaların uzantısı olmadığı için uzantı koymuyoruz.
            {
                MessageBox.Show("aga Adında bir dosya vardır.");
            
            }//if in
            else
            {
                MessageBox.Show("aga Adında bir dosya yoktur.");
                DialogResult sor;
                sor = MessageBox.Show("aga adında dosya oluşturulsun mu ? ", "KLASÖR OLUŞTURMA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sor == DialogResult.Yes)
                {

                    Directory.CreateDirectory("aga");
                }
            
            }//else in
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Directory.Move("ogr","aga/ogrtası");  //ilki gidecek dosya//ikincisi içine atılacak olan dosya / ' dan sonrası giderken verilecek isim.
            MessageBox.Show("Görev Başarılı.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Directory.Delete("aga/ogrtası",true);//true koymamızın sebebi klasörün içide doluysa komple sil demek yoksa silmiyor.
            MessageBox.Show("Görev Başarılı");
        }
    }
}
