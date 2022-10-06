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
        private void GridDoldur(string barkodno)
        {
            dataGridView1.DataSource= dm.BarkodNoGöreProductBul(barkodno);
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
            tb_barkodno.Select();
        }
        private void FornTemizle()
        {
            tb_barkodno.Text = "";
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            GridDoldur(tb_barkodno.Text);
            Product p = dm.BarkodNoGöreProductBul(tb_barkodno.Text);
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
            tb_barkodno.Select();
        }
    }
}
