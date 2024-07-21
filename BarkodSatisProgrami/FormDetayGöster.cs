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
    public partial class FormDetayGöster : Form
    {
        public FormDetayGöster()
        {
            InitializeComponent();
        }

        public int islemno { get; set; }
        public string datetarih { get; set; }

        private void FormDetayGöster_Load(object sender, EventArgs e)
        {
            lbIslem.Text = "İşlem No : " + islemno.ToString();
            lbTarih.Text = "İşlem Tarihi : " + datetarih.ToString();
            using (var db = new BarkodluSatisDbEntities3())
            {
              
                GridListe.DataSource = db.Satis.Select(x=> new {x.IslemNo,x.UrunAd,x.UrunGrup,x.Miktar,x.Birim,x.Toplam}).Where(x => x.IslemNo == islemno).ToList();
                Islemler.GridDuzenleme(GridListe);
            }
        }
    }
}
