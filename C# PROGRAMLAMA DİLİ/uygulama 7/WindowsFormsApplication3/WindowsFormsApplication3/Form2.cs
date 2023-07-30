using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NESNE TABANLI PROGRAMALMA"); 
        }

        private void Form2_Resize(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)

            {

                notifyIcon1.Icon = SystemIcons.Asterisk;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.BalloonTipText = "Simge Durumuna Getirildi";
                notifyIcon1.BalloonTipTitle = "SİMGE";
                notifyIcon1.ShowBalloonTip(1500);
            }

            else
                if (this.WindowState == FormWindowState.Normal)
                {

                    notifyIcon1.Icon = SystemIcons.Error;
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipText = "Normal Durumuna Getirildi";
                    notifyIcon1.BalloonTipTitle = "NORMAL";
                    notifyIcon1.ShowBalloonTip(1500);
                }
                else
                    if (this.WindowState == FormWindowState.Maximized)
                    {

                        notifyIcon1.Icon = SystemIcons.Question;
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                        notifyIcon1.BalloonTipText = "Tam Ekran Durumuna Getirildi";
                        notifyIcon1.BalloonTipTitle = "Tam Ekran";
                        notifyIcon1.ShowBalloonTip(1500);
                    }

            



        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter dosya = new StreamWriter("bilgiler.txt", true);
            dosya.WriteLine(e.Name + "  " + DateTime.Now + "  tarihinde yaratıldı." );
            dosya.Close();
            listBox1.Items.Add(e.Name + "  " + DateTime.Now + "  tarihinde yaratıldı.");
        }

    }
}
