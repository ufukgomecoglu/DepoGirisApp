using DataAccessLayer.Model;
using DataAccessLayer;
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
    public partial class DepoGirisIslemleri : Form
    {
        DataModel dm = new DataModel();
        public DepoGirisIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void DepoGirisIslemleri_Load(object sender, EventArgs e)
        {
            GridDoldur();
            mtb_barkodno.Select();
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
            d.Sicil = AnaForm.LoginUser.Kimlik;
            d.KayitTarih = DateTime.Now;
            d.Product_ID = p.Id;
            if (dm.DepoGirisUniqBarkod(mtb_barkodno.Text))
            {
                if (dm.DepoGirisEkle(d))
                {
                    dm.DepoStokEkleBulGuncelle(p.ProductCode, p.Color, p.Quality);
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Barkod No Stokta vardır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FornTemizle();
            mtb_barkodno.Select();
            GridDoldur();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = dm.DepogirisListReader(AnaForm.LoginUser.Kimlik);
            dataGridView1.Columns["Product_Id"].Visible = dataGridView1.Columns["KaliteHata_Id"].Visible = dataGridView1.Columns["Urun_ID"].Visible = dataGridView1.Columns["Renk_ID"].Visible = dataGridView1.Columns["Kalite_ID"].Visible = dataGridView1.Columns["DepoPalet_ID"].Visible = dataGridView1.Columns["Sevkiyat_ID"].Visible = dataGridView1.Columns["DepoHata_ID"].Visible = dataGridView1.Columns["Sicil"].Visible = false;
            dataGridView1.Columns["UrunAciklama"].Width = 500;
        }
    }
}
