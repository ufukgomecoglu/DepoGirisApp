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
            FormTemizle();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Sevkiyat s = dm.SevkiyatGetir(sevkiyatid);
            s.Musteri_ID = Convert.ToInt32(cb_musteri.SelectedValue);
            s.Kod_liste_Kimlik = Convert.ToInt32(cb_kod.SelectedValue);
            s.Miktar = Convert.ToInt32(tb_miktar.Text);
            s.SevkTarih = dtp_tarih.Value;
            s.Renk_liste_kimlik = Convert.ToByte(cb_renk.SelectedValue);
            s.Kalite_liste_kimlik = Convert.ToByte(cb_kalite.SelectedValue);
            s.Kullanici_ID = AnaForm.LoginUser.Kimlik;
            if (dm.SevkiyatGuncelle(s))
            {
                MessageBox.Show("Başardık Dorothy", "Başarılı");
            }
            else
            {
                MessageBox.Show("Ne Oldu Anlamadık.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FormTemizle();
            GridDoldur();
        }

        private void CMSMI_guncelle_Click(object sender, EventArgs e)
        {
            Sevkiyat s = dm.SevkiyatGetir(sevkiyatid);
            cb_musteri.SelectedValue = s.Musteri_ID;
            cb_kod.SelectedValue = s.Kod_liste_Kimlik;
            tb_miktar.Text = s.Miktar.ToString();
            dtp_tarih.Value = s.SevkTarih;
            cb_renk.SelectedValue = s.Renk_liste_kimlik;
            cb_kalite.SelectedValue = s.Kalite_liste_kimlik;
            btn_guncelle.Visible = true;
            btn_yeniekle.Enabled = true;
        }

        private void CMSMI_sil_Click(object sender, EventArgs e)
        {
            string isim = dm.SevkiyatGetir(sevkiyatid).MusteriIsim;
            if (MessageBox.Show(isim + "\nFirma Silinecek. Emin misin?", "Tedarikçi Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dm.SevkiyatSil(sevkiyatid);
            }
            else
            {
                MessageBox.Show("Kullanıcı Silme İşlemini İptal Etti", "İptal");
            }
            GridDoldur();
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
            btn_guncelle.Visible = false;
            btn_yeniekle.Enabled = false;
            tb_miktar.Text = "";
            CBDoldur();
            GridDoldur();
        }
        public void GridDoldur()
        {
            dataGridView1.DataSource = dm.SevkiyatListele();
            dataGridView1.Columns["Musteri_ID"].Visible = dataGridView1.Columns["Kod_liste_Kimlik"].Visible = dataGridView1.Columns["Renk_liste_kimlik"].Visible = dataGridView1.Columns["Kalite_liste_kimlik"].Visible = dataGridView1.Columns["DepoGiris_Id"].Visible = dataGridView1.Columns["Durum"].Visible = dataGridView1.Columns["SevkEdielenTarih"].Visible = dataGridView1.Columns["Kullanici_ID"].Visible = false;
        }

    }
}
