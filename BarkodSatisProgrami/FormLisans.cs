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
    public partial class FormLisans : Form
    {
        public FormLisans()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (txLisansNo.Text!="")
            {
                Kontrol k = new Kontrol();
                k.Lisansla(txLisansNo.Text);
            }
        }
    }
}
