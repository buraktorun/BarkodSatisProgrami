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
    public partial class FormUrunGrubuEkle : Form
    {
        public FormUrunGrubuEkle()
        {
            InitializeComponent();
        }

        BarkodluSatisDbEntities3 db = new BarkodluSatisDbEntities3();
        private void FormUrunGrubuEkle_Load(object sender, EventArgs e)
        {
            GrupDoldur();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txUrunGrupAdi.Text !="")
            {
                UrunGrup ug = new UrunGrup();
                ug.UrunGrupAd=txUrunGrupAdi.Text;
                db.UrunGrup.Add(ug);
                db.SaveChanges();
                GrupDoldur();
                txUrunGrupAdi.Clear();
                MessageBox.Show("Ürün Grubu Eklenmiştir.");

                FormUrunGiris f = (FormUrunGiris)Application.OpenForms["FormUrunGiris"];
                if (f != null)
                { 
                    f.GrupDoldur();
                }
            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz.");
            }
        }
        private void GrupDoldur()
        {
            listUrunGrup.DisplayMember = "UrunGrupAd";
            listUrunGrup.ValueMember = "Id";
            listUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(listUrunGrup.SelectedValue.ToString());
            string grupad = listUrunGrup.Text;
            DialogResult onay = MessageBox.Show(grupad + " Grubunu Silmek İstiyor Musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes) 
            {
                var grup = db.UrunGrup.FirstOrDefault(x => x.Id == grupid);
                db.UrunGrup.Remove(grup);
                db.SaveChanges();
                GrupDoldur();
                txUrunGrupAdi.Focus();
                MessageBox.Show(grupad + " Ürün Grubu Silindi");

                FormUrunGiris f = (FormUrunGiris)Application.OpenForms["FormUrunGiris"];
                if (f != null) 
                {
                    f.GrupDoldur();
                }
            }
            
        }
    }
}
