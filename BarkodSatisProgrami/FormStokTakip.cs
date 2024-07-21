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
    public partial class FormStokTakip : Form
    {
        public FormStokTakip()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            GridListe.DataSource = null;
            using (var db = new BarkodluSatisDbEntities3())
            {
                string urungrubu = cmbUrunGrubu.Text;
                if (cmbIslemTuru.Text !="")
                {
                   if (cmbIslemTuru.SelectedIndex== 0) 
                    { 
                        if (rdTumu.Checked) 
                        {
                            db.Urun.OrderBy(x => x.Miktar).Load();
                            GridListe.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else if (rdUrunGrubunaGore.Checked) 
                        { 
                            db.Urun.Where(x=> x.UrunGrup== urungrubu).OrderBy(x=> x.Miktar).Load();
                            GridListe.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else 
                        {
                            MessageBox.Show("Lütfen Filtreleme Türünü Seçiniz.");
                        }
                    }
                   else if (cmbIslemTuru.SelectedIndex == 1)
                    {
                        DateTime baslangic = DateTime.Parse(dateBaslangic.Value.ToShortDateString());
                        DateTime bitis = DateTime.Parse(dateBitis.Value.ToShortDateString());
                        bitis = bitis.AddDays(1);
                        if(rdTumu.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                            GridListe.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else if (rdUrunGrubunaGore.Checked)
                        {
                            db.StokHareket.OrderByDescending(x=>x.Tarih).Where(x=> x.Tarih >= baslangic && x.Tarih<= bitis && x.UrunGrup.Contains(urungrubu)).Load();
                            GridListe.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Fitleleme Türünü Seçiniz.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen İşlem Türünü Seçiniz.");
                }
            }
            Islemler.GridDuzenleme(GridListe);
        }
        BarkodluSatisDbEntities3 dbx = new BarkodluSatisDbEntities3();
        private void FormStokTakip_Load(object sender, EventArgs e)
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "Id";
            cmbUrunGrubu.DataSource = dbx.UrunGrup.ToList();
        }

        private void txUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txUrunAra.Text.Length >= 1) 
            {
                string urunad = txUrunAra.Text;
                using (var db = new BarkodluSatisDbEntities3())
                {
                    if (cmbIslemTuru.SelectedIndex == 0)
                    {
                        db.Urun.Where(x=> x.UrunAd.Contains(urunad)).Load();
                        GridListe.DataSource = db.Urun.Local.ToBindingList();
                    }
                    else if (cmbIslemTuru.SelectedIndex==1)
                    {
                        db.StokHareket.Where(x => x.UrunAd.Contains(urunad)).Load();
                        GridListe.DataSource = db.StokHareket.Local.ToBindingList();

                    }
                }
            }
            Islemler.GridDuzenleme(GridListe);
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            if (cmbIslemTuru.SelectedIndex==0)
            {
                Raporlar.Baslik = cmbIslemTuru.Text + " RAPORU";
                Raporlar.TarihBaslangic = dateBaslangic.Value.ToShortDateString();
                Raporlar.TarihBitis = dateBitis.Value.ToShortDateString();
                Raporlar.StokRaporu(GridListe);
            }
            else if (cmbIslemTuru.SelectedIndex==1)
            {
                Raporlar.Baslik = cmbIslemTuru.Text + " RAPORU";
                Raporlar.TarihBaslangic = dateBaslangic.Value.ToShortDateString();
                Raporlar.TarihBitis = dateBitis.Value.ToShortDateString();
                Raporlar.StokIzlemeRaporu(GridListe);
            }

        }
    }
}
