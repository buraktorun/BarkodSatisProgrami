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
    public partial class FormFiyatGuncelle : Form
    {
        public FormFiyatGuncelle()
        {
            InitializeComponent();
        }

        private void txNumaratik1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            { 
                using ( var db = new BarkodluSatisDbEntities3())
                {
                    if ( db.Urun.Any(x=> x.Barkod== txBarkod.Text)) 
                    { 
                        var getir = db.Urun.Where(x=> x.Barkod == txBarkod.Text).SingleOrDefault();
                        lbBarkod.Text = getir.Barkod;
                        lbUrunAdi.Text = getir.UrunAd;
                        double mevcutfiyat = Convert.ToDouble( getir.SatisFiyat);
                        lbMevcutFiyat.Text = mevcutfiyat.ToString("C2");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txYeniFiyat.Text!="" && lbBarkod.Text!="")
            {
                using (var db = new BarkodluSatisDbEntities3())
                {
                    var guncellenecek = db.Urun.Where(x => x.Barkod == lbBarkod.Text).SingleOrDefault();
                    guncellenecek.SatisFiyat = Islemler.doubleYap(txYeniFiyat.Text);
                    int kdvorani = Convert.ToInt16( guncellenecek.KdvOrani);
                    Math.Round(Islemler.doubleYap(txYeniFiyat.Text) * kdvorani / 100, 2);
                    db.SaveChanges();
                    MessageBox.Show("Yeni Fiyat Kaydedilmiştir");
                    lbBarkod.Text = "";
                    lbUrunAdi.Text = "";
                    lbMevcutFiyat.Text = "";
                    txYeniFiyat.Clear();
                    txBarkod.Clear();
                    txBarkod.Focus();

                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
                txBarkod.Focus();
            }
        }

        private void FormFiyatGuncelle_Load(object sender, EventArgs e)
        {
            lbBarkod.Text = "";
            lbUrunAdi.Text = "";
            lbMevcutFiyat.Text = "";

        }
    }
}
