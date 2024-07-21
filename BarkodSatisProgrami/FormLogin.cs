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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            if (txKullaniciAdi.Text != "" && txSifre.Text != "")
            {
                try
                {
                    using (var db = new BarkodluSatisDbEntities3())
                       
                    {
                        if (db.Kullanici.Any())
                        {
                            var bak = db.Kullanici.Where(x => x.KullaniciAd == txKullaniciAdi.Text && x.Sifre == txSifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor = Cursors.WaitCursor;
                                Kontrol kontrol = new Kontrol();
                                if (kontrol.kontrolYap())
                                {
                                    FormBaslangic f = new FormBaslangic();
                                    f.btnSatisIslemi.Enabled = (bool)bak.Satis;
                                    f.btnGenelRapor.Enabled = (bool)bak.Rapor;
                                    f.btnStok.Enabled = (bool)bak.Stok;
                                    f.btnUrunGiris.Enabled = (bool)bak.UrunGiris;
                                    f.btnYedekleme.Enabled = (bool)bak.Yedekleme;
                                    f.btnAyarlar.Enabled = (bool)bak.Ayarlar;
                                    f.btnFiyatGuncelle.Enabled = (bool)bak.FiyatGuncelle;
                                    f.lbKullanici.Text = bak.AdSoyad;
                                    var isyeri = db.SabitDegerler.FirstOrDefault();
                                    f.lbIsYeri.Text = isyeri.Unvan;
                                    f.Show();
                                    this.Hide();
                                }
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                GirisYap();
            }
        }
    }
}
