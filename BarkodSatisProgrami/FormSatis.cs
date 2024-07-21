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
    public partial class FormSatis : Form
    {
        public FormSatis()
        {
            InitializeComponent();
        }

        BarkodluSatisDbEntities3 db = new BarkodluSatisDbEntities3();
        private void FormSatis_Load(object sender, EventArgs e)
        {
            HizliUurnlerDoldurma();
            btn5.Text = 5.ToString("C2");
            btn10.Text = 10.ToString("C2");
            btn20.Text = 20.ToString("C2");
            btn50.Text = 50.ToString("C2");
            btn100.Text = 100.ToString("C2");
            btn200.Text = 200.ToString("C2");
            using (var db = new BarkodluSatisDbEntities3())
            {
                var sabit = db.SabitDegerler.FirstOrDefault();
                chYazdirmaDurumu.Checked = Convert.ToBoolean(sabit.Yazici);
            }
        }

        private void HizliUurnlerDoldurma()
        {
            var hizliurun= db.HizliUrunler.ToList();
            foreach (var item in hizliurun)
            {
                Button btnH = this.Controls.Find("btnH" + item.Id,true).FirstOrDefault() as Button;
                if (btnH!=null)
                {
                    double fiyat = Islemler.doubleYap(item.Fiyat.ToString());
                    btnH.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }
            }

        }

        private void HizliUrunClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int buttonid = Convert.ToInt16(b.Name.ToString().Substring(4, b.Name.Length - 4));

            if (b.Text.ToString().StartsWith("-"))
            {
                FormHizliUrunEkle h = new FormHizliUrunEkle();
                h.lbBtnNo.Text = buttonid.ToString();
                h.ShowDialog();
            }
            else
            {
                var urunbarkod = db.HizliUrunler.Where(u => u.Id == buttonid).Select(u => u.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(u => u.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(txMiktar.Text));
                GenelToplam();
            }
        }

        private void btnH_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int buttonid = Convert.ToInt32(b.Name.ToString().Substring(4, b.Name.Length - 4));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + buttonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int buttonid = Convert.ToInt32(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrunler.Find(buttonid);

            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("btnH" + buttonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");
        }

        private void txBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = txBarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    txMiktar.Text = barkod;
                    txBarkod.Clear();
                    txBarkod.Focus();
                }
                else
                {
                    if (db.Urun.Any(u => u.Barkod==barkod)) 
                    { 
                        var urun = db.Urun.Where(u => u.Barkod == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod,Convert.ToDouble(txMiktar.Text));
                    }


                    else
                    {
                        int onnm = Convert.ToInt32(barkod.Substring(0, 2));
                        if(db.Terazi.Any(u=> u.TeraziOnNm==onnm))
                        {
                            string teraziurunno= barkod.Substring(2,5);
                            if(db.Urun.Any(u=> u.Barkod==teraziurunno))
                            {
                                var urunterazi= db.Urun.Where(u=> u.Barkod==teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7,5)) / 1000;
                                UrunGetirListeye(urunterazi, teraziurunno, miktarkg); 
                            }
                            else
                            {
                                Console.Beep(800, 600);
                                MessageBox.Show("Kg Ürün Ekleme Sayfası");
                            }
                        }
                        else
                        {
                            Console.Beep(800, 600);
                            FormUrunGiris f = new FormUrunGiris();
                            f.txBarkod.Text = barkod;
                            f.ShowDialog();
                        }
                    }
                }
                gridSatisListesi.ClearSelection();
                GenelToplam();
                txBarkod.Clear();
            }
        }

        private void UrunGetirListeye(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridSatisListesi.Rows.Count;
            bool eklendimi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridSatisListesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value);
                        gridSatisListesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Fiyat"].Value), 2);
                        double dblKdvTutari =(double)urun.KdvTutari;
                        gridSatisListesi.Rows[i].Cells["KdvTutar"].Value = Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value) * dblKdvTutari;
                        eklendimi = true;
                    }
                }
            }
            if (!eklendimi)
            {
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat);
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = urun.AlisFiyat;
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutar"].Value = urun.KdvTutari;
            }
        }

        private void GenelToplam()
        {
                double toplam = 0;
                for (int i = 0; i < gridSatisListesi.Rows.Count; i++)
                {
                    toplam += Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Toplam"].Value);
                }
                txGenelToplam.Text = toplam.ToString("C2");
        }

        private void gridSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                gridSatisListesi.Rows.Remove(gridSatisListesi.CurrentRow);
                gridSatisListesi.ClearSelection();
                GenelToplam();
                txBarkod.Focus();
            }
        }

        private void bNumaratör_Click (object sender, EventArgs e)
        {
            Button b =(Button) sender;
            if (b.Text== ",")
            {
                int virgul = txNumarator.Text.Count(x => x == ',');
                if (virgul < 1) 
                {
                    txNumarator.Text += b.Text;
                }
            }
            else if (b.Text=="<")
            {
                if (txNumarator.Text.Length > 0) 
                {
                    txNumarator.Text = txNumarator.Text.Substring(0, txNumarator.Text.Length - 1);
                }

            }
            else
            {
                txNumarator.Text+= b.Text;
            }
        }

        private void btnAdet_Click(object sender, EventArgs e)
        {
            if (txNumarator.Text !="") 
            {
                txMiktar.Text=txNumarator.Text;
                txNumarator.Clear();
                txBarkod.Clear();
                txBarkod.Focus();
            }
        }

        private void btnOdenen_Click(object sender, EventArgs e)
        {
            if (txNumarator.Text != "")
            {
                double sonuc = Islemler.doubleYap(txNumarator.Text) - Islemler.doubleYap(txGenelToplam.Text);
                txParaUstu.Text = sonuc.ToString("C2");
                txOdenen.Text = Islemler.doubleYap(txNumarator.Text).ToString("C2");
                txNumarator.Clear();
                txBarkod.Focus();
            }
        }

        private void btnBarkod_Click(object sender, EventArgs e)
        {
            if (txNumarator.Text!="")
            {
                if (db.Urun.Any(u=> u.Barkod== txNumarator.Text))
                {
                    var urun = db.Urun.Where(u=> u.Barkod == txNumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, txNumarator.Text, Convert.ToDouble(txMiktar.Text));
                    txNumarator.Clear();
                    txBarkod.Focus();
                }
            }
        }

        private void ParaUstuHesaplama_Click (object sender, EventArgs e) 
        { 
            Button b = (Button)sender;
            double sonuc = Islemler.doubleYap(b.Text) - Islemler.doubleYap(txGenelToplam.Text);
            txOdenen.Text = Islemler.doubleYap(b.Text).ToString("C2");
            txParaUstu.Text = sonuc.ToString("C2");
        }

        private void btnDigerUrun_Click(object sender, EventArgs e)
        {
            if (txNumarator.Text!="")
            {
                int satirsayisi = gridSatisListesi.Rows.Count;
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(txNumarator.Text);
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutar"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value=Convert.ToDouble(txNumarator.Text);
                txNumarator.Text = "";
                GenelToplam();
                txBarkod.Focus();
            }
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            if (cbSatısIadeYapiliyor.Checked)
            {
                cbSatısIadeYapiliyor.Checked = false;
                cbSatısIadeYapiliyor.Text = "Satış Yapılıyor";
            }
            else
            {
                cbSatısIadeYapiliyor.Checked = true;
                cbSatısIadeYapiliyor.Text = "İade Yapılıyor";
            }
        }
        private void Temizle()
        {
            gridSatisListesi.Rows.Clear();
            txMiktar.Text = "1";
            txBarkod.Clear();
            txOdenen.Clear();
            txParaUstu.Clear();
            txGenelToplam.Text = 0.ToString("C2");
            txNumarator.Clear();
            txBarkod.Focus();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        public void SatisYapma (string odemesekli)
        {
            int satirsayisi = gridSatisListesi.Rows.Count;
            bool satisiade = cbSatısIadeYapiliyor.Checked;
            double alisfiyattoplam = 0;
            if (satirsayisi > 0) 
            {
                int? islemno = db.Islem.First().IslemNo;
                Satis satis = new Satis();
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.IslemNo = islemno;
                    satis.UrunAd = gridSatisListesi.Rows[i].Cells["UrunAdi"].Value.ToString();
                    satis.UrunGrup = gridSatisListesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridSatisListesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyati"].Value.ToString());
                    satis.SatisFiyat = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutar = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["KdvTutar"].Value.ToString()) * Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.OdemeSekli = odemesekli;
                    satis.Iade = satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = LbKullanici.Text;
                    db.Satis.Add(satis);
                    db.SaveChanges();

                    if (!satisiade)
                    {
                        Islemler.StokAzalt(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));

                    }
                    else
                    {
                        Islemler.StokArtir(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    alisfiyattoplam += Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyati"].Value.ToString()) * Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());

                }

                IslemOzet io = new IslemOzet();
                io.IslemNo = islemno;
                io.Iade = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider= false;
                if (!satisiade)
                {
                    
                    io.Aciklama = odemesekli + " Satış";
                }
                else
                {
                    io.Aciklama = "İade İşlemi (" + odemesekli + ")";
                }
                io.OdemeSekli = odemesekli;
                io.Kullanici = LbKullanici.Text;
                io.Tarih = DateTime.Now;

                switch (odemesekli)
                {
                    case "Nakit":
                        io.Nakit = Islemler.doubleYap(txGenelToplam.Text);
                        io.Kart = 0;  
                        break;
                    case "Kart":
                        io.Nakit = 0;
                        io.Kart = Islemler.doubleYap(txGenelToplam.Text); 
                        break;
                    case "Nakit-Kart":
                        io.Kart = Islemler.doubleYap(lbKart.Text);
                        io.Nakit = Islemler.doubleYap(lbNakit.Text); 
                        break;

                }
                db.IslemOzet.Add(io);
                db.SaveChanges();

                var islemnoartir = db.Islem.First();
                islemnoartir.IslemNo += 1;
                db.SaveChanges();
                if (chYazdirmaDurumu.Checked)
                {
                    //Yazdır...
                    Yazdir yazdir = new Yazdir(islemno);
                    yazdir.YazdirmayaBasla();

                }
                
                Temizle();
            }
        }

        private void btnNakit_Click(object sender, EventArgs e)
        {
            SatisYapma("Nakit");
        }

        private void btnKart_Click(object sender, EventArgs e)
        {
            SatisYapma("Kart");
        }

        private void btnKartNakit_Click(object sender, EventArgs e)
        {
            FormNakitKart f = new FormNakitKart();
            f.ShowDialog();

        }

        private void txBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void FormSatis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F1)
                SatisYapma("Nakit");
            if (e.KeyCode == Keys.F2)
                SatisYapma("Kart");
            if (e.KeyCode == Keys.F3)
            {
                FormNakitKart f = new FormNakitKart();
                f.ShowDialog();
            }


        }

        private void Bekle()
        {
            int satir = gridSatisListesi.Rows.Count;
            int sutun = gridSatisListesi.Columns.Count;
            if (satir >0)
            {
                for (int i = 0; i < satir; i++) 
                {   
                    gridSatisBekle.Rows.Add();
                    for(int j = 0; j < sutun-1; j++)
                    {
                        gridSatisBekle.Rows[i].Cells[j].Value = gridSatisListesi.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void BeklemedenCik()
        {
            int satir = gridSatisBekle.Rows.Count;
            int sutun = gridSatisBekle.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridSatisListesi.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridSatisListesi.Rows[i].Cells[j].Value = gridSatisBekle.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void btnIslemBeklet_Click(object sender, EventArgs e)
        {
            if (btnIslemBeklet.Text == "İşlem Beklet")
            {
                Bekle();
                btnIslemBeklet.BackColor = System.Drawing.Color.OrangeRed;
                btnIslemBeklet.Text = "İşlem Bekliyor";
                gridSatisListesi.Rows.Clear();
            }
            else
            {
                BeklemedenCik();
                btnIslemBeklet.BackColor = System.Drawing.Color.YellowGreen;
                btnIslemBeklet.Text = "İşlem Beklet";
                gridSatisBekle.Rows.Clear();
            }
            
        }

        private void cbSatısIadeYapiliyor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSatısIadeYapiliyor.Checked)
            {
                cbSatısIadeYapiliyor.Text = "İade Yapılıyor";
            }
            else
            {
                cbSatısIadeYapiliyor.Text = "Satış Yapılıyor";
            }
        }
    }
}
 