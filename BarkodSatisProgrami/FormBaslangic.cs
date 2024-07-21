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
    public partial class FormBaslangic : Form
    {
        public FormBaslangic()
        {
            InitializeComponent();
        }

        private void btnSatisIslemi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormSatis f = new FormSatis();
            f.LbKullanici.Text = lbKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnGenelRapor_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormRapor f = new FormRapor();
            f.lbKullanici.Text = lbKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormStokTakip f = new FormStokTakip();
            f.lbKullanici.Text = lbKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnUrunGiris_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormUrunGiris f = new FormUrunGiris();
            f.lbKullanici.Text = lbKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFiyatGuncelle_Click(object sender, EventArgs e)
        {
            FormFiyatGuncelle f = new FormFiyatGuncelle();
            f.lbKullanici.Text=lbKullanici.Text;
            f.ShowDialog();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormAyarlar f = new FormAyarlar();
            f.lbKullanici.Text = lbKullanici.Text;
            f.ShowDialog();
        }

        private void btnYedekleme_Click(object sender, EventArgs e)
        {
            Islemler.Backup();
        }

        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }
    }
}
