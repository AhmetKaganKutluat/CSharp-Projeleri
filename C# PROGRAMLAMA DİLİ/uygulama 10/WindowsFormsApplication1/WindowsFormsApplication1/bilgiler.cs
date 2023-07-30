using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class bilgiler
    {
        public string ad;
        public string soyad;
        public string ders;

        public string al; // dosterimi yapacak olan değişken !!

        public void goster()

    {
        al = "öğrencinin adı : " + ad + " soyadı " + soyad + " dersi " + ders;  
            
    }


    }
}
