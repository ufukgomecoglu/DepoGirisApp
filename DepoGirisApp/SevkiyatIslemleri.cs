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
        int sevkiyatdetayid = 0;
        List<SevkiyatDetay> sevkiyatDetaylar = new List<SevkiyatDetay>();
        public SevkiyatIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_sevkiyatolustur_Click(object sender, EventArgs e)
        {
            Sevkiyat s = new Sevkiyat();
            s.Musteri_ID = Convert.ToInt32(cb_musteri.SelectedValue);
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
            SevkiyatDetay sd = new SevkiyatDetay();
            sd.Urun_ID = Convert.ToInt32(cb_urun.SelectedValue);
            UrunKod u = dm.UrunGetir(sd.Urun_ID);
            sd.UrunKodu = u.tanim;
            sd.UrunAciklama = u.Aciklama;
            sd.Renk_ID = Convert.ToByte(cb_renk.SelectedValue);
            Renk r = dm.RenkGetir(sd.Renk_ID);
            sd.Renk_Isim = r.renkad;
            sd.Kalite_ID = Convert.ToByte(cb_kalite.SelectedValue);
            KaliteTipi k = dm.KaliteGetir(sd.Kalite_ID);
            sd.Kalite_Isim = k.kaliteAd;
            sd.Miktar = Convert.ToInt32(tb_miktar.Text);
            sevkiyatDetaylar.Add(sd);
            GridDoldur();
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
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = sevkiyatDetaylar;
            if (dataGridView2.DataSource!= null)
            {
                dataGridView2.Columns["ID"].Visible = dataGridView2.Columns["Urun_ID"].Visible = dataGridView2.Columns["Renk_ID"].Visible = dataGridView2.Columns["Kalite_ID"].Visible = dataGridView2.Columns["Sevkiyat_ID"].Visible = false;
            }
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

        private void CMSMI_detaygoster_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource= dm.SevkiyatDetayGöster(sevkiyatid);
        }

        private void CMSMI_SevkiyatDetayEkle_Click(object sender, EventArgs e)
        {
            if (sevkiyatDetaylar.Count != 0)
            {
                dm.SevkiyatDetayEkle(sevkiyatDetaylar, sevkiyatid);
                MessageBox.Show("Ekleme İşlemi Başarılı", "Bilgi");
                sevkiyatDetaylar = null;
                tb_miktar.Text = "";
                GridDoldur();
            }
            else
            {
                MessageBox.Show("Ürün eklemeniz gerekir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CMSMI_Sil_Click(object sender, EventArgs e)
        {

        }

        private void CMSMI_Düzenle_Click(object sender, EventArgs e)
        {

        }

        private void CMSMI_Sil2_Click(object sender, EventArgs e)
        {
            if (sevkiyatDetaylar.Count!=0)
            {
                sevkiyatDetaylar.Remove(sevkiyatDetaylar[sevkiyatdetayid]);
                GridDoldur();
            }
            else
            {
                dm.SevkiyatDetaySil(sevkiyatdetayid);
                dataGridView2.DataSource = dm.SevkiyatDetayGöster(sevkiyatid);
            }
        }

        private void CMSMI_Düzenle2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    if (sevkiyatDetaylar.Count != 0)
                    {
                        dataGridView2.Rows[hit.RowIndex].Selected = true;
                        sevkiyatdetayid = hit.RowIndex;
                        contextMenuStrip2.Show(dataGridView2, new Point(e.X, e.Y));
                    }
                    else
                    {
                        dataGridView2.Rows[hit.RowIndex].Selected = true;
                        sevkiyatdetayid = Convert.ToInt32(dataGridView2.Rows[hit.RowIndex].Cells["ID"].Value);
                        contextMenuStrip2.Show(dataGridView2, new Point(e.X, e.Y));
                    }
                }
            }
        }
    }
}
