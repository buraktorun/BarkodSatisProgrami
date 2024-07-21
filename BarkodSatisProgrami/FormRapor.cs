using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSatisProgrami
{
    public partial class FormRapor : Form
    {
        public FormRapor()
        {
            InitializeComponent();
        }

        public void btnGoster_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangic = DateTime.Parse(dateBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dateBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);

            using (var db = new BarkodluSatisDbEntities3())
            {
                if (ListeTuru.SelectedIndex==0) // Tümünü
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).OrderByDescending(x => x.Tarih).Load();
                    var islemozet = db.IslemOzet.Local.ToBindingList();
                    GridListe.DataSource = islemozet;

                    txSatisNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Nakit)).ToString("C2");
                    txSatisKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Kart)).ToString("C2");

                    txIadeNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    txIadeKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");

                    txGelirNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Gelir == true).Sum(x => x.Nakit)).ToString("C2");
                    txGelirKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gelir == true).Sum(x => x.Kart)).ToString("C2");

                    txGiderNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(x => x.Nakit)).ToString("C2");
                    txGiderKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(x => x.Kart)).ToString("C2");

                    db.Satis.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                    var satistablosu = db.Satis.Local.ToBindingList();
                    double kdvtutarsatis = Islemler.doubleYap(satistablosu.Where(x => x.Iade == false).Sum(x => x.KdvTutar).ToString());
                    double kdvtutariade = Islemler.doubleYap(satistablosu.Where(x=> x.Iade==true).Sum(x=> x.KdvTutar).ToString());
                    txKdvToplam.Text = (kdvtutarsatis - kdvtutariade).ToString("C2");


                }
                else if (ListeTuru.SelectedIndex == 1) // Satışlar
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == false && x.Gelir == false && x.Gider == false).Load();
                    var islemozet = db.IslemOzet.Local.ToBindingList();
                    GridListe.DataSource = islemozet;
                }
                else if (ListeTuru.SelectedIndex == 2 ) // iadeler
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == true).Load();
                    GridListe.DataSource = db.IslemOzet.Local.ToBindingList();
                }
                else if (ListeTuru.SelectedIndex == 3) // Gelir
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gelir == true).Load();
                    GridListe.DataSource = db.IslemOzet.Local.ToBindingList();
                }
                else if (ListeTuru.SelectedIndex == 4) // Gider
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gider == true).Load();
                    GridListe.DataSource = db.IslemOzet.Local.ToBindingList();
                }
            }
            Islemler.GridDuzenleme(GridListe);
            Cursor.Current = Cursors.Default;
        }

        private void FormRapor_Load(object sender, EventArgs e)
        {
            ListeTuru.SelectedIndex = 0;
            txKomisyon.Text = Islemler.KartKomisyon().ToString();
            btnGoster_Click(null, null);
        }

        private void GridListe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex==6 || e.ColumnIndex==7) 
            { 
                if (e.Value is bool )
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnGelirEkle_Click(object sender, EventArgs e)
        {
            FormGelirGider f = new FormGelirGider();
            f.gelirgider = "GELİR";
            f.kullanici = lbKullanici.Text;
            f.ShowDialog();
        }

        private void btnGiderEkle_Click(object sender, EventArgs e)
        {
            FormGelirGider f = new FormGelirGider();
            f.gelirgider = "GİDER";
            f.kullanici = lbKullanici.Text;
            f.ShowDialog();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridListe.Rows.Count>0)
            {
                int islemno = Convert.ToInt32(GridListe.CurrentRow.Cells["IslemNo"].Value.ToString());
                string  tarih = GridListe.CurrentRow.Cells["Tarih"].Value.ToString();
                if (islemno != 0) 
                {
                    FormDetayGöster f = new FormDetayGöster();
                    f.islemno = islemno;
                    f.datetarih = tarih;
                    f.ShowDialog();
                }
            }
        }

        private void btnRaporAl_Click_1(object sender, EventArgs e)
        {
            Raporlar.Baslik = "GENEL RAPOR";
            Raporlar.SatisKart = txSatisKart.Text;
            Raporlar.SatisNakit = txSatisNakit.Text;
            Raporlar.IadeKart = txIadeKart.Text;
            Raporlar.IadeNakit = txIadeNakit.Text;
            Raporlar.GelirKart = txGelirKart.Text;
            Raporlar.GelirNakit = txGelirNakit.Text;
            Raporlar.GiderNakit = txGiderNakit.Text;
            Raporlar.GiderKart = txGiderKart.Text;
            Raporlar.TarihBaslangic = dateBaslangic.Value.ToShortDateString();
            Raporlar.TarihBitis = dateBitis.Value.ToShortDateString();
            Raporlar.KdvToplam = txKdvToplam.Text;
            Raporlar.KartKomisyon = txKomisyon.Text;
            Raporlar.RaporSayfasiRaporu(GridListe);
        }
    }
}
