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
            }
            FornTemizle();
            mtb_barkodno.Select();
            GridDoldur();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = dm.DepogirisListReader(LoginUser.Kimlik);
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
            if (Application.OpenForms.OfType<UrunTakip>().Count() == 0)
            {
                so.ShowDialog();
            }

        }
    }
}
