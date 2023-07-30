using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.InitialDirectory = "C:\\";
           // dosya.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  // dosya açma penceresi açılınca masaüstünden getiriyor direk.
            dosya.Filter = "Tüm Dosyalar(*.*)|*.*|Metin Belgesi(*.txt)|*.txt|Word Belgesi(*.docx)|*.docx";
            dosya.FilterIndex = 2;
            dosya.Title = "Secilen Belgeleri Açar...";
            dosya.Multiselect = true;
            dosya.CheckFileExists = false;
            dosya.RestoreDirectory = true;
           // dosya.ShowDialog();
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(dosya.FileName);//Secilen dosyanın yolu
                MessageBox.Show(dosya.SafeFileName);//Secilen dosyaların adı
            
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            richTextBox1.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog bicim = new FontDialog();
            bicim.ShowColor = true;
            bicim.MinSize = 12;
            bicim.MaxSize = 52;
            bicim.ShowDialog();
            richTextBox1.SelectionFont = bicim.Font;
            richTextBox1.SelectionColor = bicim.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
         //      Böyle göstermek istersen burayı değiş yani namesini =   fontDialog1 goster = new FontDialog();  
            fontDialog1.ShowDialog(); //yukardakiyle aynı işi yapar
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;

     
        }
    }
}
