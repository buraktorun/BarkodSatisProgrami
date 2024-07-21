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
    public partial class FormGelirGider : Form
    {
        public FormGelirGider()
        {
            InitializeComponent();
        }

        public string gelirgider { get; set; }
        public string kullanici { get; set; }

        private void FormGelirGider_Load(object sender, EventArgs e)
        {
            lbGelirGider.Text = gelirgider + " İŞLEMİ YAPILIYOR";
        }

        private void cmbOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOdemeTuru.SelectedIndex == 0) //NAKİT
            {
                txNakit.Enabled = true;
                txKart.Enabled = false;
            }
            else if (cmbOdemeTuru.SelectedIndex == 1) // KART
            {
                txNakit.Enabled = false;
                txKart.Enabled = true;
            }
            else if (cmbOdemeTuru.SelectedIndex == 2) // KART-NAKİT
            {
                txNakit.Enabled = true;
                txKart.Enabled=true;
            }
            txNakit.Text = "0";
            txKart.Text = "0";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbOdemeTuru.Text!="")
            {
                if (txNakit.Text!="" && txKart.Text!="" )
                {
                    using (var db = new BarkodluSatisDbEntities3())
                    {
                        IslemOzet io = new IslemOzet();
                        io.IslemNo = 0;
                        io.Iade = false;
                        io.OdemeSekli = cmbOdemeTuru.Text;
                        io.Nakit = Islemler.doubleYap(txNakit.Text);
                        io.Kart = Islemler.doubleYap(txKart.Text);
                        if(gelirgider=="GELİR")
                        {
                            io.Gelir = true; 
                            io.Gider = false;
                        }
                        else
                        {
                            io.Gelir = false;
                            io.Gider = true;
                        }
                        io.AlisFiyatToplam = 0;
                        io.Aciklama = gelirgider + " - İşlemi " + txAciklama.Text;
                        io.Tarih = dateTarih.Value;
                        io.Kullanici = kullanici;
                        db.IslemOzet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(gelirgider + " İşlemi Kaydedildi");
                        txNakit.Text = "0"; txKart.Text = "0"; txAciklama.Clear(); cmbOdemeTuru.Text = "";
                        FormRapor f = (FormRapor)Application.OpenForms["FormRapor"];
                        if(f != null) 
                        {
                            f.btnGoster_Click(null, null);
                        }
                        this.Hide();
                    }
                }

            }
            else 
            {
                MessageBox.Show("Lütfen Ödeme Türünü Belirleyiniz");
            }
        }
    }
}
