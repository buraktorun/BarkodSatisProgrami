using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lisans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lic lic = new Lic();
            label2.Text = lic.CpuNo() + "\n" + lic.CpuKarakterToplam() .ToString();
            DateTime gelentarih = lic.TarihCoz("CLBHJB"); // 2 gün 4 ay 26
            var getirsifrelitarih = lic.TarihSifrele(DateTime.Now);
            var kontrolno = lic.EkrandaGoster();
            var getir0 = lic.yillar();
            var getir = lic.gunler();
            var getir2 = lic.aylar();
            
        }

    }
}
