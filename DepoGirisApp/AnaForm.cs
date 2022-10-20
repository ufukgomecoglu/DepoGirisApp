using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoGirisApp
{
    public partial class AnaForm : Form
    {
        public static kullanici_listeLogin LoginUser;
        DataModel dm = new DataModel();
        public AnaForm()
        {
            KullaniciGiris frm = new KullaniciGiris();
            frm.ShowDialog();
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        

        private void TSMI_TIRYuklemesi_Click_1(object sender, EventArgs e)
        {
            TIRYuklemesi ty = new TIRYuklemesi();
            if (Application.OpenForms.OfType<TIRYuklemesi>().Count() == 0)
            {
                ty.ShowDialog();
            }
        }

        private void TSMI_PaletBarkoduCikar_Click(object sender, EventArgs e)
        {
            PaletlemeIslemleri pi = new PaletlemeIslemleri();
            if (Application.OpenForms.OfType<PaletlemeIslemleri>().Count() == 0)
            {
                pi.ShowDialog();
            }
        }

        

        private void btn_urungir_Click(object sender, EventArgs e)
        {
            DepoGirisIslemleri dgi = new DepoGirisIslemleri();
            if (Application.OpenForms.OfType<DepoGirisIslemleri>().Count() == 0)
            {
                dgi.ShowDialog();
            }
        }

        private void btn_uruntakip_Click(object sender, EventArgs e)
        {
            UrunTakip ut = new UrunTakip();
            if (Application.OpenForms.OfType<UrunTakip>().Count() == 0)
            {
                ut.ShowDialog();
            }
        }

        private void btn_sevkiyatolustur_Click(object sender, EventArgs e)
        {
            SevkiyatIslemleri si = new SevkiyatIslemleri();
            if (Application.OpenForms.OfType<SevkiyatIslemleri>().Count() == 0)
            {
                si.ShowDialog();
            }
        }

        private void btn_depostok_Click(object sender, EventArgs e)
        {
            DepoStokTakip pi = new DepoStokTakip();
            if (Application.OpenForms.OfType<DepoStokTakip>().Count() == 0)
            {
                pi.ShowDialog();
            }
        }
    }
}
