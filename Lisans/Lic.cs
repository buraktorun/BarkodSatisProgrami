using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lisans
{
    public class Lic
    {
        public string CpuNo()
        {
            string islemciid = "";
            ManagementObjectSearcher ara = new ManagementObjectSearcher("Select * From WIN32_Processor");
            ManagementObjectCollection obje = ara.Get();
            foreach (ManagementObject item in obje)
            {
                islemciid = item["ProcessorId"].ToString();
            }
            return islemciid;
        }

        public int CpuKarakterToplam()
        {
            int toplam = 0;
            foreach (char item in CpuNo().ToCharArray())
            {
                toplam += (int)item;
            }
            return toplam;
         }

        public string gunkarakter = "WRIXCLKXCIOWELKSDKADFHLFXOGWCPSOELMAAOTKDKYFAKUDOIGSDBXMONKDSKRU";
        public string aykarakter = "BHRUYLSXYPOSAIWBKDRYHABKFG";
        public string yilkarakter = "DFYRJBKLZABIRYGLPZXCSASTHBMLREYGPHEVOYBHSDAKOTTDSR";

        public bool TarihKontrol(DateTime baslangic, DateTime bitis)
        {
            return baslangic < DateTime.Now && DateTime.Now < bitis;
        }

        public int  GirileniLisansiKontrolEt(string girilenlisansbilgisi)
        {
            Cursor.Current = Cursors.WaitCursor;
            double girilen = Convert.ToDouble(girilenlisansbilgisi);
            bool demomu = girilen == CpuKarakterToplam() * TarihFonksiyon() * 4;
            bool yillikmi = girilen == CpuKarakterToplam() * TarihFonksiyon() * 14;
            int durum = 0;

            if (demomu) 
            {
                durum = 1;
            }
            else if (yillikmi)
            {
                durum = 2;
            }
            else 
            { 
                durum = 0;
            }
            Cursor.Current = Cursors.Default;
            return durum;
        }

        public DateTime DemoTarihOlustur()
        {
            DateTime tarih = DateTime.Now.AddDays(10);
            return tarih;
        }

        public DateTime YillikTarihOlustur()
        {
            DateTime tarih = DateTime.Now.AddYears(1);
            return tarih;
        }

        public long EkrandaGoster()
        {
            long gosterilecekno = CpuKarakterToplam() * TarihFonksiyon();
            return gosterilecekno;

        }

        public long TarihFonksiyon()
        {
            return (DateTime.Now.Day + DateTime.Now.Month) * DateTime.Now.Year;
        }

        public DateTime TarihCoz(string sifrelitarih)
        {
            string strgun = sifrelitarih.Substring(0, 2);
            string stray = sifrelitarih.Substring(2, 2);
            string stryil = sifrelitarih.Substring(4, 2);
            int gun = gunler().Where(x=> x.Ad==strgun).FirstOrDefault().Numara;
            int ay = aylar().Where(x=> x.Ad==stray).FirstOrDefault().Numara;
            int yil = yillar().Where(x=> x.Ad==stryil).FirstOrDefault().Numara;
            DateTime tarih = new DateTime(yil, ay, gun);
            return tarih;
        }

        public String TarihSifrele (DateTime tarih)
        {
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;
            string strgun = gunler().Where(x => x.Numara == gun).FirstOrDefault().Ad;
            string stray = aylar().Where(x => x.Numara == ay).FirstOrDefault().Ad;
            string stryil = yillar().Where(x=> x.Numara== yil).FirstOrDefault().Ad;
            string olusansifrelitarih = strgun + stray + stryil;
            return olusansifrelitarih;
        }

        public List<Sablon> gunler()
        {
            List<Sablon> listGun = new List<Sablon>();
            for (int i = 0; i < 31; i++)
            {
                listGun.Add(new Sablon { Numara = i + 1, Ad = gunkarakter.ToString().Substring(i * 2, 2) });
            }
            return listGun;
        }

        public List<Sablon> aylar()
        {
            List<Sablon> listAy = new List<Sablon>();
            for (int i = 0; i < 12; i++)
            {
                listAy.Add(new Sablon { Numara = i + 1, Ad = aykarakter.ToString().Substring(i * 2, 2) });
            }
            return listAy;
                
        }
         
        public List<Sablon> yillar ()
        {
            List<Sablon> listYil = new List<Sablon>();
            int karaktersayisi = 0;
            for (int i = 2024; i < 2030; i++)
            {
                   listYil.Add(new Sablon { Numara=i,Ad=yilkarakter.ToString().Substring(karaktersayisi*2,2) });
                    karaktersayisi += 2;
            }
            return listYil;
        }

        public class Sablon
        {
            public int Numara { get; set; }
            public string Ad { get; set; }
        }
    }
}
