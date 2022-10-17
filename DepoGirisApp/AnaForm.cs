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
        private void cb_doldur()
        {
            cb_hata.DataSource = dm.HataListesi();
            cb_hata.DisplayMember = "tanim";
            cb_hata.ValueMember = "Kimlik";
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            cb_doldur();
            mtb_barkodno.Select();
            GridDoldur();
        }
        private void FornTemizle()
        {
            mtb_barkodno.Text = "";
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Product p = dm.BarkodNoGöreProductBul(mtb_barkodno.Text);
            DepoGiris d = new DepoGiris();
            d.Barkod = p.Barcode;
            d.Sicil = LoginUser.Kimlik;
            d.KayitTarih = DateTime.Now;
            d.Product_ID = p.Id;
            d.Hata_Id = Convert.ToByte(cb_hata.SelectedValue);
            if (!dm.DepoGirisEkle(d))
            {
                MessageBox.Show("Ekleme İşlemi Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dm.DepoStokEkleBulGuncelle(p.ProductCode, p.Color);
            }
            FornTemizle();
            mtb_barkodno.Select();
            GridDoldur();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = dm.DepogirisListReader(LoginUser.Kimlik);
            dataGridView1.Columns["Product_Id"].Visible = dataGridView1.Columns["DepoPaletliUrun_ID"].Visible = false;
        }

        private void TSMI_UrunTakip_Click(object sender, EventArgs e)
        {
            UrunTakip ut = new UrunTakip();
            if (Application.OpenForms.OfType<UrunTakip>().Count() == 0)
            {
                ut.ShowDialog();
            }
        }

        private void TSMI_TirYuklemesi_Click(object sender, EventArgs e)
        {
            SevkiyatOlustur so = new SevkiyatOlustur();
            if (Application.OpenForms.OfType<SevkiyatOlustur>().Count() == 0)
            {
                so.ShowDialog();
            }

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

        private void TSMI_DepoStokTakip_Click(object sender, EventArgs e)
        {
            DepoStokTakip pi = new DepoStokTakip();
            if (Application.OpenForms.OfType<DepoStokTakip>().Count() == 0)
            {
                pi.ShowDialog();
            }
        }
    }
}
