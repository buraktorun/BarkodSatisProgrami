using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSatisProgrami
{
    public partial class FormNakitKart : Form
    {
        public FormNakitKart()
        {
            InitializeComponent();
        }

        private void txNakit_KeyDown(object sender, KeyEventArgs e)
        {
            if (txNakit.Text!="")
            {
                if (e.KeyCode == Keys.Enter) 
                {
                    OdemeHesapla();
                }
            }
        }

        private void bNumaratör_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = txNakit.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    txNakit.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (txNakit.Text.Length > 0)
                {
                    txNakit.Text = txNakit.Text.Substring(0, txNakit.Text.Length - 1);
                }

            }
            else
            {
                txNakit.Text += b.Text;
            }
        }

        private void OdemeHesapla()
        {
            FormSatis f = (FormSatis)Application.OpenForms["FormSatis"];
            double nakit = Islemler.doubleYap(txNakit.Text);
            double geneltoplam = Islemler.doubleYap(f.txGenelToplam.Text);
            double kart = geneltoplam - nakit;
            f.lbNakit.Text = nakit.ToString("C2");
            f.lbKart.Text = kart.ToString("C2");
            f.SatisYapma("Nakit-Kart");
            this.Hide();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txNakit.Text != "")
            {
                OdemeHesapla();

            }
        }

        private void txNakit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08) 
            { 
                e.Handled = true;
            }
        }


    }
}
