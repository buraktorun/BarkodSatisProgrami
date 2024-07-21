using Lisans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSatisProgrami
{
    public class Kontrol
    {
        BarkodluSatisDbEntities3 db  = new BarkodluSatisDbEntities3();
        Lisans guvenlik = new Lisans();
        Lic lic = new Lic();
        public bool kontrolYap()
        {
            bool durum = false;
            if (db.Lisans.Count() == 0)
            {
                LisansFormuAc();
            }
            else
            {
                Lic lic = new Lic();
                var guvenlik = db.Lisans.First();
                if (lic.TarihCoz(guvenlik.Baslangic) < DateTime.Now)
                {
                    guvenlik.Baslangic = lic.TarihSifrele(DateTime.Now);
                    db.SaveChanges();
                    durum = true;
                }
                if (lic.TarihKontrol(lic.TarihCoz(guvenlik.Baslangic), lic.TarihCoz(guvenlik.Bitis)))
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                    LisansFormuAc();

                }
            }
            return durum;
        }

        public void LisansFormuAc()
        {
            Lic lic = new Lic();
            FormLisans f = new FormLisans();
            f.lbLisansNo.Text = lic.EkrandaGoster().ToString();
            f.Show();
        }

        public void Lisansla (string girilenkod)
        {
            int durum = lic.GirileniLisansiKontrolEt(girilenkod);
            switch (durum)
            {
                case 0: // geçersiz lisans kodu
                    MessageBox.Show("Girilen lisans numarası geçersizdir");
                    break;

                case 1:
                    DemoOlustur();
                    break;

                case 2:
                    YillikOlustur();
                    break;
                default:
                    break;
            }
        }

        private int LisansEkliMi()
        {
            return db.Lisans.Count();
        }

        private void LisansEkle(string baslangic , string bitis)
        {
            guvenlik.Baslangic = baslangic;
            guvenlik.Bitis = bitis;
            db.Lisans.Add(guvenlik);
            db.SaveChanges();

        }

        private void LisansGuncelle(string baslangic , string bitis)
        {
            var guvenlikguncelle = db.Lisans.First();
            guvenlikguncelle.Baslangic = baslangic ;
            guvenlikguncelle.Bitis = bitis;
            db.SaveChanges ();
        }


        private void DemoOlustur()
        {
            try
            {
                if (LisansEkliMi() == 0)
                {
                    // db ekleme işlemi
                    LisansEkle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.DemoTarihOlustur()));
                }
                else
                {
                    // db güncelleme işlemi
                    LisansGuncelle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.DemoTarihOlustur()));
                }
                MessageBox.Show("Program 10 günlük demo olarak kullanıma açılmıştır \n Programı Terkar Çalıştırınız");
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA OLUŞTU");
            }

        }

        private void YillikOlustur()
        {
            try
            {
                if (LisansEkliMi() == 0)
                {
                    // db ekleme işlemi
                    LisansEkle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.YillikTarihOlustur()));
                }
                else
                {
                    // db güncelleme işlemi
                    LisansGuncelle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.YillikTarihOlustur()));
                }
                MessageBox.Show("Program 1 yıllık olarak kullanıma açılmıştır \n Programı Terkar Çalıştırınız");
                Application.Exit();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA OLUŞTU");
            }

        }
    }
}
