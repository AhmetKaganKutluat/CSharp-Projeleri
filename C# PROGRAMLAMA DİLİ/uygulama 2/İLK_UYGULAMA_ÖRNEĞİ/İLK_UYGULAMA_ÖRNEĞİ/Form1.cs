using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İLK_UYGULAMA_ÖRNEĞİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // çıkış işlemi.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1); // çevre olarak kapatılırsa 0 yada 1 değer ister.
        }
        Int16 cik; // int değerimiz.
        private void button3_Click(object sender, EventArgs e)
        {
            cik = Convert.ToInt16(MessageBox.Show("Program Kapatılsın mı ? ", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button2)); // değer verdik değerimiz int oldugu için string çevirdik mesaj verdirdik ekrana
            //mesaj dan sonra çıkış sonra button ekledik eve hayır sonra icon ekledik sonra da hangisinin aktif button olacağını belirleik.
            if (cik == 6) // eğer 6 yani evet seçilirse yap
            {
                Environment.Exit(1);  //çıkış yap bunun yerine application.exitte kullanabilirdik.
            }
            else         //eğer 6 değilse yani 7 yse yani hayırsa
            {
                MessageBox.Show("ÇIKIŞ GERÇEKLEŞMEDİ !");  // ekrana mesaj verdik.
            }
        }
        DialogResult secim; // iletişim kanalı ile de çıkış yapılabilir .
        private void button4_Click(object sender, EventArgs e)
        {
          secim = MessageBox.Show("Programdan Çıkılsın mı ?","ÇIKIŞ",MessageBoxButtons.YesNo);
          if (secim == DialogResult.Yes)
          {
              Application.Exit();
          }
          else
          {
              MessageBox.Show("Çıkış Gerçekleşmedi");
          }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 goster1 = new Form2();
            goster1.ShowDialog();  // diğer forma geçiş show dialog arka plana geçmeyi engeller .
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("SELAM KAÇMAZ");
            listBox1.Items.Add("TANER YILDIRIM");
            
            comboBox1.Items.Add("FENERBAHÇE");
            comboBox1.Items.Add("ANTALYASPOR");
            comboBox1.Items.Add("TRABZONSPOR");
            comboBox1.Sorted = true;


            string[] dersler = {"NESNE TABANLI PROGRAMLAMA","GÖRSEL PROGRAMLAMA ","YAZILIM MİMARİLERİ","VERİ TABANI"}; // dersleri comboya iletmek için 2.bir seçenek.
         //   comboBox2.Items.Add(dersler[1]);  //TEK TEK EKLEME YÖNTEMİ
         //   comboBox2.Items.Add(dersler[3]); // TEK TEK EKLEME YÖNTEMİ
            comboBox2.Items.AddRange(dersler); // range aralık demek hepsini girer
            comboBox2.Sorted = true;

        }

       

        
    }
}
