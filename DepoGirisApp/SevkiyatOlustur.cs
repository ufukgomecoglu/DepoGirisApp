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
    public partial class SevkiyatOlustur : Form
    {
        DataModel dm = new DataModel();
        int sevkiyatid = 0;
        public SevkiyatOlustur()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Sevkiyat s = new Sevkiyat()
            {
                Musteri_ID = Convert.ToInt32(cb_musteri.SelectedValue),
                Kod_liste_Kimlik = Convert.ToInt32(cb_kod.SelectedValue),
                Miktar = Convert.ToInt32(tb_miktar.Text),
                SevkTarih = dtp_tarih.Value,
                Renk_liste_kimlik = Convert.ToByte(cb_renk.SelectedValue),
                Kalite_liste_kimlik = Convert.ToByte(cb_kalite.SelectedValue),
                Kullanici_ID = AnaForm.LoginUser.Kimlik
            };
            if (dm.SevkiyatEkle(s))
            {
                GridDoldur();
                FormTemizle();
                MessageBox.Show("Ekleme İşlemi Başarılı", "Bilgi");

            }
            else
            {
                MessageBox.Show("Ekleme İşlemi Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_yeniekle_Click(object sender, EventArgs e)
        {

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {

        }

        private void CMSMI_guncelle_Click(object sender, EventArgs e)
        {

        }

        private void CMSMI_sil_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    sevkiyatid = Convert.ToInt32(dataGridView1.Rows[hit.RowIndex].Cells["ID"].Value);
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }
        private void CBDoldur()
        {
            cb_kod.DataSource = dm.UrunKodListele();
            cb_kod.ValueMember = "Kimlik";
            cb_kod.DisplayMember = "tanim";
            cb_musteri.DataSource = dm.MusteriListele();
            cb_musteri.ValueMember = "ID";
            cb_musteri.DisplayMember = "Isim";
            cb_renk.DataSource = dm.RenkListele();
            cb_renk.ValueMember = "Kimlik";
            cb_renk.DisplayMember = "renkad";
            cb_kalite.DataSource = dm.KaliteTipiListele();
            cb_kalite.ValueMember = "Kimlik";
            cb_kalite.DisplayMember = "kaliteAd";
        }

        private void SevkiyatOlustur_Load(object sender, EventArgs e)
        {
            btn_guncelle.Visible = false;
            btn_yeniekle.Enabled = false;
            CBDoldur();
            GridDoldur();
        }
        public void FormTemizle()
        {
            tb_miktar.Text = "";
            CBDoldur();
            GridDoldur();
        }
        public void GridDoldur()
        {
            dataGridView1.DataSource = dm.SevkiyatListele();
        }

    }
}
