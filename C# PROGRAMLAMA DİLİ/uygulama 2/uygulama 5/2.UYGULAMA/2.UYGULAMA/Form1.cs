using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.UYGULAMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // VERİ TABANI KULANMADAN İŞLEMLER.
        {
            dataGridView1.ColumnCount = 4;   //4 KOLON EKLEDİK
            dataGridView1.Columns[0].Name="MÜŞTERİ ADI VE SOYADI";
            dataGridView1.Columns[1].Name = "İŞE GİRİŞ TARİHİ";
            dataGridView1.Columns[2].Name = "İŞTEN AYRILIŞ TARİHİ";
            dataGridView1.Columns[3].Name = "ZAMAN FARKI";
            
            dataGridView1.Columns[0].Width = 220;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 220;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Rows.Add("SELAM KAÇMAZ","12.02.2017","08.04.2018");   //YABANCI PROGRAM OLDUGU İÇİN AY GÜN YIL ŞEKLİNDE YAZABİLİRİZ.
            dataGridView1.Rows.Add("ERAY YÜMLÜ","03.08.2020","05.05.2021");
            dataGridView1.Rows.Add("HÜSEYİN ASA","10.01.2008","04.06.2019");
            dataGridView1.Rows.Add("SELİM KAPLAN","01.03.2015","02.05.2017");
            dataGridView1.Rows.Add("ONUR PÜSKÜLLÜ","06.04.2014","06.03.2021");
            dataGridView1.Rows.Add("KAZIM ALACALI", "10.01.2017", "15.03.2020");
            dataGridView1.Rows.Add("ESİN MARAŞLI", "03.08.2000", "04.08.2019");
            dataGridView1.Rows.Add("DERYA EKİCİ", "10.08.2003", "04.06.2019");
            dataGridView1.Rows.Add("BUKET ACAR", "01.03.2003", "02.05.2021");
            dataGridView1.Rows.Add("AYŞENUR YILMAZ", "06.04.2008", "07.08.2020");


           
        }

        void renklendir()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            { 
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) <= 1500)
                {
                    renk.BackColor = Color.SandyBrown;

                }
                else
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) <= 3000)
                    {

                        renk.BackColor = Color.Silver;
                    }

                    else
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) <= 4500)
                        {

                            renk.BackColor = Color.Thistle;
                        }
                        else
                        {

                            renk.BackColor = Color.Purple;
                        }

                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        
        
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // şimdi gride eklemediğimz zaman farkı nı hesaplayıp göstericez ekrana

            DateTime tarih1, tarih2;
            int i;
            TimeSpan fark;  // tarihler arasındaki farkı alır.

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                tarih1 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                tarih2 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);
                fark = tarih2 - tarih1;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Rows[i].Cells[3].Value = fark.Days;
            }
            renklendir();




        }

        DialogResult soru;
        private void button2_Click(object sender, EventArgs e)
        {
            soru=MessageBox.Show("Ekran Bilgileri Yazdırılsınmı","YAZDIRMA İŞLEMİ",MessageBoxButtons.YesNo);
            if (soru == DialogResult.Yes)
            {
                printDocument1.Print();
            }
            else
            {

                MessageBox.Show("YAZDIRILMA İŞEMİNDEN VAZGEÇİLDİ");
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap
            (this.dataGridView1.Width , this.dataGridView1.Height );

            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm,0,0);
        }
    }
}
