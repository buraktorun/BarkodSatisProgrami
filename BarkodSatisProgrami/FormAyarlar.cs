using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSatisProgrami
{
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            txAdSoyad.Clear();
            txTelefon.Clear();
            txEPosta.Clear();
            txKullaniciAd.Clear();
            txSifre.Clear();
            txTekrar.Clear();
            chSatisEkrani.Checked = false;
            chRapor.Checked = false;
            chStok.Checked = false;
            chUrunGiris.Checked = false;
            chAyarlar.Checked = false;
            chFiyatGuncelle.Checked = false;
            chYedekleme.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kaydet")
            {
                if (txAdSoyad.Text != "" && txTelefon.Text != "" && txKullaniciAd.Text != "" && txSifre.Text != "" && txTekrar.Text != "")
                {
                    if (txSifre.Text == txTekrar.Text)
                    {
                        try
                        {
                            using (var db = new BarkodluSatisDbEntities3())
                            {
                                if (!db.Kullanici.Any(x => x.KullaniciAd == txKullaniciAd.Text))
                                {
                                    Kullanici k = new Kullanici();
                                    k.AdSoyad = txAdSoyad.Text;
                                    k.Telefon = txTelefon.Text;
                                    k.EPosta = txEPosta.Text;
                                    k.KullaniciAd = txKullaniciAd.Text.Trim();
                                    k.Sifre = txSifre.Text;
                                    k.Satis = chSatisEkrani.Checked;
                                    k.Rapor = chRapor.Checked;
                                    k.Stok = chStok.Checked;
                                    k.UrunGiris = chUrunGiris.Checked;
                                    k.Ayarlar = chAyarlar.Checked;
                                    k.FiyatGuncelle = chFiyatGuncelle.Checked;
                                    k.Yedekleme = chYedekleme.Checked;
                                    db.Kullanici.Add(k);
                                    db.SaveChanges();
                                    Doldur();                                   
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Bu Kullanıcı Zaten Kayıtlı");
                                }
                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hata Oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor");
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu alanları giriniz" + "\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");
                }
            }
            else if (btnKaydet.Text == "Düzenle/Kaydet")
            {
                if (txAdSoyad.Text != "" && txTelefon.Text != "" && txKullaniciAd.Text != "" && txSifre.Text != "" && txTekrar.Text != "")
                {
                    if (txSifre.Text == txTekrar.Text)
                    {
                        int id = Convert.ToInt32(lbKullaniciId.Text);
                        using (var db = new BarkodluSatisDbEntities3())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = txAdSoyad.Text;
                            guncelle.Telefon = txTelefon.Text;
                            guncelle.EPosta = txEPosta.Text;
                            guncelle.KullaniciAd = txKullaniciAd.Text.Trim();
                            guncelle.Sifre = txSifre.Text;
                            guncelle.Satis = chSatisEkrani.Checked;
                            guncelle.Rapor = chRapor.Checked;
                            guncelle.Stok = chStok.Checked;
                            guncelle.UrunGiris = chUrunGiris.Checked;
                            guncelle.Ayarlar = chAyarlar.Checked;
                            guncelle.FiyatGuncelle = chFiyatGuncelle.Checked;
                            guncelle.Yedekleme = chYedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme Yapılmıştır");
                            btnKaydet.Text="Kaydet";
                            Temizle();
                            Doldur();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu alanları giriniz" + "\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");
                }
            }

        }

        private void Doldur ()
        {
            using (var db = new BarkodluSatisDbEntities3())
            {
                if (db.Kullanici.Any())
                {
                    GridListeKullanici.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();

                }
                Islemler.SabitVarsayilan();
                var yazici = db.SabitDegerler.FirstOrDefault();
                chYazmaDurumu.Checked =(bool) yazici.Yazici;

                var sabitler = db.SabitDegerler.FirstOrDefault();
                txKartKomisyon.Text = sabitler.KartKomisyon.ToString();

                var terazionek = db.Terazi.ToList();
                cmbTeraziOnEk.DisplayMember = "TeraziOnNm";
                cmbTeraziOnEk.ValueMember = "Id";
                cmbTeraziOnEk.DataSource = terazionek;


                txIsyeriAdSoyad.Text = sabitler.AdSoyad;
                txIsyeriUnvan.Text = sabitler.Unvan;
                txIsyeriAdres.Text  = sabitler.Adres;
                txIsyeriTelefon.Text = sabitler.Telefon;
                txIsyeriEPosta.Text = sabitler.Eposta;

            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridListeKullanici.Rows.Count>0)
            {
                int id = Convert.ToInt32(GridListeKullanici.CurrentRow.Cells["Id"].Value.ToString());
                lbKullaniciId.Text = id.ToString();
                using (var db = new BarkodluSatisDbEntities3())
                {
                    var getir = db.Kullanici.Where(x=> x.Id == id).FirstOrDefault();
                    txAdSoyad.Text = getir.AdSoyad;
                    txTelefon.Text = getir.Telefon;
                    txEPosta.Text = getir.EPosta;
                    txKullaniciAd.Text = getir.KullaniciAd;
                    txSifre.Text = getir.Sifre;
                    txTekrar.Text = getir.Sifre;
                    chSatisEkrani.Checked = (bool)getir.Satis;
                    chRapor.Checked= (bool)getir.Rapor;
                    chStok.Checked= (bool)getir.Stok;
                    chUrunGiris.Checked = (bool)getir.UrunGiris;
                    chAyarlar.Checked=(bool)getir.Ayarlar;
                    chFiyatGuncelle.Checked = (bool)getir.FiyatGuncelle;
                    chYedekleme.Checked=(bool)getir.Yedekleme;
                    btnKaydet.Text = "Düzenle/Kaydet";
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz");
            }
        }

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Doldur();
            Cursor.Current = Cursors.Default;
        }

        private void chYazmaDurumu_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new BarkodluSatisDbEntities3())
            {
                if (chYazmaDurumu.Checked)
                {
                
                    Islemler.SabitVarsayilan();
                    var ayarla = db.SabitDegerler.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu AKTİF";
                 }
                else
                {
                    Islemler.SabitVarsayilan();
                    var ayarla = db.SabitDegerler.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu PASİF";
                }
            }
           

        }

        private void btnKartKomisyonAyarla_Click(object sender, EventArgs e)
        {
            if (txKartKomisyon.Text != "")
            {
                using (var db = new BarkodluSatisDbEntities3())
                {
                    var sabit = db.SabitDegerler.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(txKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyon Ayarlandı");
                }
            }
            else
            {
                MessageBox.Show("Kart Komisyon Bilgisini giriniz");
            }
            
        }

        private void btnTeraziOnEkKaydet_Click(object sender, EventArgs e)
        {
            if (txTeraziOnEk.Text!="")
            {
                int onek = Convert.ToInt16(txTeraziOnEk.Text);

                using ( var db = new BarkodluSatisDbEntities3())
                {
                    if (db.Terazi.Any(x=> x.TeraziOnNm==onek))
                    {
                        MessageBox.Show(onek.ToString() + " Önek Zaten Kayıtlı");
                    }
                    else
                    {
                        Terazi t = new Terazi();
                        t.TeraziOnNm = onek;
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler Kaydedilmiştir");
                        cmbTeraziOnEk.DisplayMember = "TeraziOnNm";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        txTeraziOnEk.Clear();

                    }
                }
            }
            else
            {
                MessageBox.Show("Terazi Ön ek Bilgisi Giriniz");

            }
        }


        private void btnTeraziOnEkSil_Click(object sender, EventArgs e)
        {
            if (cmbTeraziOnEk.Text != "")
            {
                int onekid = Convert.ToInt16(cmbTeraziOnEk.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbTeraziOnEk.Text + " öneki silmek istiyor musunuz?", "Terazi Önek Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    using (var db = new BarkodluSatisDbEntities3())
                    {
                        var onek = db.Terazi.Find(onekid);
                        db.Terazi.Remove(onek);
                        db.SaveChanges();
                        cmbTeraziOnEk.DisplayMember = "TeraziOnNm";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        MessageBox.Show("Önek Silinmiştir");
                    }
                }
            }
            else
            {
                MessageBox.Show("Önek Seçiniz");
            }
        }


        private void btnIsyeriKaydet_Click_1(object sender, EventArgs e)
        {
            if (txIsyeriAdSoyad.Text != "" && txIsyeriUnvan.Text != "" && txIsyeriAdres.Text != "" && txIsyeriTelefon.Text != "")
            {
                using (var db = new BarkodluSatisDbEntities3())
                {
                    var isyeri = db.SabitDegerler.FirstOrDefault();
                    isyeri.AdSoyad = txIsyeriAdSoyad.Text;
                    isyeri.Unvan = txIsyeriUnvan.Text;
                    isyeri.Adres = txIsyeriAdres.Text;
                    isyeri.Telefon = txIsyeriTelefon.Text;
                    isyeri.Eposta = txIsyeriEPosta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri Bilgileri Kaydedilmiştir");

                    var yeni = db.SabitDegerler.FirstOrDefault();
                    txIsyeriAdSoyad.Text = yeni.AdSoyad;
                    txIsyeriUnvan.Text = yeni.Unvan;
                    txIsyeriAdres.Text = yeni.Adres;
                    txIsyeriTelefon.Text = yeni.Telefon;
                    txIsyeriEPosta.Text = yeni.Eposta;

                }
            }
        }

        private void btnYedektenYukle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }

    }
}
