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
    public partial class FormHizliUrunEkle : Form
    {
        public FormHizliUrunEkle()
        {
            InitializeComponent();
        }
        BarkodluSatisDbEntities3 db = new BarkodluSatisDbEntities3();

        private void txUrunArama_TextChanged(object sender, EventArgs e)
        {
            if (txUrunArama.Text!="")
            {
                string urunad = txUrunArama.Text;
                var urunler = db.Urun.Where(u=> u.UrunAd.Contains(urunad))  .ToList();
                gridUrunListesi.DataSource = urunler;
                Islemler.GridDuzenleme(gridUrunListesi);
            }
        }

        private void gridUrunListesi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUrunListesi.Rows.Count>0) 
            {
                string barkod = gridUrunListesi.CurrentRow.Cells["Barkod"].Value.ToString();
                string urunad = gridUrunListesi.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble (gridUrunListesi.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                int id = Convert.ToInt32(lbBtnNo.Text);
                var guncelleme = db.HizliUrunler.Find(id);

                guncelleme.Barkod= barkod;
                guncelleme.UrunAd = urunad;
                guncelleme.Fiyat = fiyat;
                db.SaveChanges();
                MessageBox.Show("buton atanmıştır");

                FormSatis s = (FormSatis)Application.OpenForms["FormSatis"];
                if (s!= null) 
                {
                    Button b = s.Controls.Find("btnH" + id, true).FirstOrDefault() as Button;
                    b.Text = urunad + "\n" + fiyat.ToString("C2");
                }

            }
        }

        private void cbTumunuGetir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTumunuGetir.Checked)
            {
                gridUrunListesi.DataSource = db.Urun.ToList();
                gridUrunListesi.Columns["AlisFiyat"].Visible = false;
                gridUrunListesi.Columns["SatisFiyat"].Visible = false;
                gridUrunListesi.Columns["KdvOrani"].Visible = false;
                gridUrunListesi.Columns["KdvTutari"].Visible = false;
                gridUrunListesi.Columns["Aciklama"].Visible = false;
                gridUrunListesi.Columns["Miktar"].Visible = false;


                Islemler.GridDuzenleme(gridUrunListesi);
            }
            else
            {
                gridUrunListesi.DataSource = null;
            }
        }
    }
}
