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
    public partial class SevkiyatIslemleri : Form
    {
        DataModel dm = new DataModel();
        int sevkiyatid = 0;

        public SevkiyatIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_sevkiyatolustur_Click(object sender, EventArgs e)
        {
            Sevkiyat s = new Sevkiyat();
            s.Musteri_ID =Convert.ToInt32(cb_musteri.SelectedValue);
            s.SevkTarih = dtp_sevkiyattarih.Value.Date;
            s.Kullanici_ID = AnaForm.LoginUser.Kimlik;
            if (dm.SevkiyatEkle(s))
            {
                MessageBox.Show("Ekleme İşlemi Başarılı", "Bilgi");
                GridDoldur();
            }
            else
            {
                MessageBox.Show("Ekleme İşlemi Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SevkiyatIslemleri_Load(object sender, EventArgs e)
        {
            CBDoldur();
            GridDoldur();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

        }
        private void CBDoldur()
        {
            cb_musteri.DataSource = dm.MusteriListele();
            cb_musteri.DisplayMember = "Isim";
            cb_musteri.ValueMember = "ID";
            cb_urun.DataSource = dm.UrunKodListele();
            cb_urun.DisplayMember = "tanim";
            cb_urun.ValueMember = "Kimlik";
            cb_renk.DataSource = dm.RenkListele();
            cb_renk.DisplayMember = "renkad";
            cb_renk.ValueMember = "Kimlik";
            cb_kalite.DataSource = dm.KaliteTipiListele();
            cb_kalite.DisplayMember = "kaliteAd";
            cb_kalite.ValueMember = "Kimlik";
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dm.SevkiyatListReader();
            dataGridView1.Columns["Musteri_ID"].Visible = dataGridView1.Columns["Durum"].Visible = dataGridView1.Columns["SevkEdilenTarih"].Visible =
                dataGridView1.Columns["Kullanici_ID"].Visible = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                //MessageBox.Show(hit.RowIndex.ToString());
                dataGridView1.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    sevkiyatid = Convert.ToInt32(dataGridView1.Rows[hit.RowIndex].Cells["ID"].Value);
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }

        private void CMSMI_detaygoster_Click(object sender, EventArgs e)
        {

        }

        private void CMSMI_SevkiyatDetayEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
