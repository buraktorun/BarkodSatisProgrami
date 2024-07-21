using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSatisProgrami
{
    public partial class FormUrunGiris : Form
    {
        public FormUrunGiris()
        {
            InitializeComponent();
        }

        BarkodluSatisDbEntities3 db = new BarkodluSatisDbEntities3();
        private void txBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            { 
                string barkod = txBarkod.Text.Trim();
                if (db.Urun.Any(a=> a.Barkod==barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    txUrunAdi.Text = urun.UrunAd;
                    cmbUrunGrubu.Text = urun.UrunGrup;
                    txAlisFiyati.Text = urun.AlisFiyat.ToString();
                    txSatisFiyati.Text = urun.SatisFiyat.ToString();
                    txMiktar.Text = urun.Miktar.ToString();
                    txKdvOrani.Text = urun.KdvOrani.ToString();
                    if (urun.Birim=="Kg")
                    {
                        cbUrunTipi.Checked = true;
                    }
                    else
                    {
                        cbUrunTipi.Checked=false;
                    }
                }
                else 
                {
                    MessageBox.Show("Ürün Kayıtlı değil , kaydedebilirsiniz...");
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txBarkod.Text != "" && txUrunAdi.Text != "" && cmbUrunGrubu.Text != "" && txAlisFiyati.Text != "" && txSatisFiyati.Text != "" && txKdvOrani.Text != "" && txMiktar.Text != "") 
            {
                if(db.Urun.Any(a=> a.Barkod==txBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == txBarkod.Text).SingleOrDefault();
                    guncelle.UrunAd = txUrunAdi.Text;
                    guncelle.UrunGrup = cmbUrunGrubu.Text;
                    guncelle.Aciklama = txAciklama.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(txAlisFiyati.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(txSatisFiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt32(txKdvOrani.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.doubleYap(txSatisFiyati.Text) * Islemler.doubleYap(txKdvOrani.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(txMiktar.Text);
                    guncelle.Onay = true;
                    if (cbUrunTipi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lbKullanici.Text;
                    db.SaveChanges();
                    GridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = txBarkod.Text;
                    urun.UrunAd = txUrunAdi.Text;
                    urun.Aciklama = txAciklama.Text;
                    urun.UrunGrup = cmbUrunGrubu.Text;
                    urun.AlisFiyat = Convert.ToDouble(txAlisFiyati.Text);
                    urun.SatisFiyat = Convert.ToDouble(txSatisFiyati.Text);
                    urun.KdvOrani = Convert.ToInt32(txKdvOrani.Text);
                    urun.KdvTutari = Math.Round(Islemler.doubleYap(txSatisFiyati.Text) * Islemler.doubleYap(txKdvOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(txMiktar.Text);
                    urun.Onay = true;
                    if (cbUrunTipi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lbKullanici.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if (txBarkod.Text.Length ==8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }
                    

                    GridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenleme(GridUrunler);
                }
                Islemler.StokHareket(txBarkod.Text, txUrunAdi.Text, "Adet", Convert.ToDouble(txMiktar.Text), cmbUrunGrubu.Text, lbKullanici.Text);
                Temizle();
                txUrunSayisi.Text = db.Urun.Count().ToString();
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz.");
            }
        }

        private void txUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txUrunAra.Text.Length >= 2)
            { 
            string urunad = txUrunAra.Text;
            GridUrunler.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
            Islemler.GridDuzenleme(GridUrunler);
            }
        }

        private void Temizle()
        {
            txBarkod.Clear();
            txUrunAdi.Clear();
            txAciklama.Clear();
            txAlisFiyati.Text = "0";
            txSatisFiyati.Text = "0";
            txMiktar.Text = "0";
            txKdvOrani.Text = "8";
            txBarkod.Focus();
            cbUrunTipi.Checked = false;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void FormUrunGiris_Load(object sender, EventArgs e)
        {
            txUrunSayisi.Text=db.Urun.Count().ToString();
            GridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
            Islemler.GridDuzenleme(GridUrunler);
            GrupDoldur();
        }

        public void GrupDoldur()
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "Id";
            cmbUrunGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void btnUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            FormUrunGrubuEkle f = new FormUrunGrubuEkle();
            f.ShowDialog();

        }

        private void btnBarkodOlustur_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8-karakter; i++) 
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            txBarkod.Text = olusanbarkod;
            txUrunAdi.Focus();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GridUrunler.Rows.Count >0)
            {
                int urunid = Convert.ToInt32(GridUrunler.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunad = GridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = GridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + " Ürünü Silmek İstiyor Musunuz?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunid);
                    db.Urun.Remove(urun);
                    db.SaveChanges();
                    var hizliurun = db.HizliUrunler.Where(u => u.Barkod == barkod).SingleOrDefault();
                    if (hizliurun != null)
                    {
                        hizliurun.Barkod = "-";
                        hizliurun.UrunAd = "-";
                        hizliurun.Fiyat = 0;
                        db.SaveChanges();

                    }
                    MessageBox.Show("Ürün Silinmiştir");
                    GridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenleme(GridUrunler);
                    txUrunSayisi.Text = db.Urun.Count().ToString();
                    txBarkod.Focus();

                }
            }

        }

        private void cbSatısIadeYapiliyor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUrunTipi.Checked)
            {
                cbUrunTipi.Text = "Gramajlı Ürün İşlemi";
                btnBarkodOlustur.Enabled = false;
            }
            else
            {
                cbUrunTipi.Text = "Barkodlu Ürün İşlemi";
                btnBarkodOlustur.Enabled = true;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridUrunler.Rows.Count > 0) 
            { 
                txBarkod.Text = GridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                txUrunAdi.Text =  GridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                txAciklama.Text = GridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                cmbUrunGrubu.Text = GridUrunler.CurrentRow.Cells["UrunGrup"].Value.ToString();
                txAlisFiyati.Text = GridUrunler.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                txSatisFiyati.Text = GridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                txKdvOrani.Text = GridUrunler.CurrentRow.Cells["KdvOrani"].Value.ToString();
                txMiktar.Text = GridUrunler.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim =  GridUrunler.CurrentRow.Cells["Birim"].Value.ToString();
                if (birim == "Kg")
                {
                    cbUrunTipi.Checked = true;
                }
                else
                {
                    cbUrunTipi.Checked = false;
                }

            }
        }

        private void btnGereksizSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("!!Lütfen Dikkat : \n Üürn Fiyat Düzenlemelerinin TAMAMINI yaptıysanız bu işlemi onaylayınız","DİKKAT -Kullanılmayan Ürün Silme İşlemi",MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes) 
            { 
                Cursor.Current = Cursors.WaitCursor;
                db.Urun.RemoveRange(db.Urun.Where(x => x.Onay == false));
                db.SaveChanges();
                GridUrunler.DataSource = db.Urun.OrderByDescending(a =>a.UrunId).Take(10).ToList();
                MessageBox.Show("Kullanılmayan Ürünler Silindi");
                txUrunSayisi.Text = db.Urun.Count().ToString();
                Cursor.Current = Cursors.Default;
            }
        }


    }
}
