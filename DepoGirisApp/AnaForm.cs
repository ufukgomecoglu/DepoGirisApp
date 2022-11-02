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

        private void btn_urungir_Click(object sender, EventArgs e)
        {
            DepoGirisIslemleri dgi = new DepoGirisIslemleri();
            dgi.ShowDialog();
        }

        private void btn_uruntakip_Click(object sender, EventArgs e)
        {
            UrunTakip ut = new UrunTakip();
            ut.ShowDialog();
        }

        private void btn_sevkiyatolustur_Click(object sender, EventArgs e)
        {
            SevkiyatIslemleri si = new SevkiyatIslemleri();
            si.ShowDialog();
        }

        private void btn_depostok_Click(object sender, EventArgs e)
        {
            DepoStokTakip pi = new DepoStokTakip();
            pi.ShowDialog();
        }

        private void btn_paletlemeislemleri_Click(object sender, EventArgs e)
        {
            PaletlemeIslemleri pi = new PaletlemeIslemleri();
            pi.ShowDialog();
        }

        private void btn_TIRyukleme_Click(object sender, EventArgs e)
        {
            TIRYuklemesi ty = new TIRYuklemesi();
            ty.ShowDialog();
        }

        private void btn_depohata_Click(object sender, EventArgs e)
        {

        }
    }
}
