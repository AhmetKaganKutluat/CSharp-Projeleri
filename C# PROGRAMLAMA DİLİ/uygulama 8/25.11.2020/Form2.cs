using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25._11._2020
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 2; i <= 10; i++)
                comboBox1.Items.Add(i).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double toplamtutar = Convert.ToDouble(textBox1.Text);
            double taksitsayisi = Convert.ToDouble(comboBox1.SelectedItem);
            DateTime baslangictarihi = dateTimePicker1.Value;

            double taksittutari = toplamtutar / taksitsayisi;
            DateTime taksittarihi;

            string[] aylar = new string[]
            {"","OCAK","ŞUBAT","MART","NİSAN","MAYIS","HAZİRAN",
            "TEMMUZ","AĞUSTOS","EYLÜL","EKİM","KASIM","ARALIK"};

            string alanlar = "";
            string taksitler = "";

            for (int i = 1; i <=taksitsayisi; i++)
            {
                taksittarihi = baslangictarihi.AddMonths(i);
                alanlar = alanlar + aylar[taksittarihi.Month] + "  ";
                taksitler = taksitler + taksittutari.ToString("C") + " ";
                
            }
            MessageBox.Show(alanlar + "\n" + taksitler);




        }
    }
}
