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
    public partial class TIRYuklemesi : Form
    {
        DataModel dm = new DataModel();
        List<DepoGiris> depoGirisler = new List<DepoGiris>();
        List<DepoPalet> depoPaletler = new List<DepoPalet>();
        int sevkiyatid = 0;
        public TIRYuklemesi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TIRYuklemesi_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }
        private void GridDoldur()
        {
            dgv_eklenenpalet.DataSource = null;
            dgv_eklenenpalet.DataSource = depoPaletler;
            dgv_eklenenpalet.Columns["Kullanici_ID"].Visible = dgv_eklenenpalet.Columns["Kullanici_Isim"].Visible = false;
            dgv_eklenenurunler.DataSource = null;
            dgv_eklenenurunler.DataSource = depoGirisler;
            dgv_eklenenurunler.Columns["Sicil"].Visible = dgv_eklenenurunler.Columns["Product_ID"].Visible = dgv_eklenenurunler.Columns["KaliteHata_Id"].Visible = dgv_eklenenurunler.Columns["Urun_ID"].Visible = dgv_eklenenurunler.Columns["Renk_ID"].Visible = dgv_eklenenurunler.Columns["DepoPalet_ID"].Visible = dgv_eklenenurunler.Columns["DepoHata_ID"].Visible = dgv_eklenenurunler.Columns["Kalite_ID"].Visible = false;
            dgv_gunluksevkiyat.DataSource = dm.SevkiyatListReader(dtp_sevkiyagunu.Value.Date);

        }

        private void dgv_gunluksevkiyat_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgv_gunluksevkiyat.HitTest(e.X, e.Y);
                dgv_gunluksevkiyat.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    dgv_gunluksevkiyat.Rows[hit.RowIndex].Selected = true;
                    sevkiyatid = Convert.ToInt32(dgv_gunluksevkiyat.Rows[hit.RowIndex].Cells["ID"].Value);
                    contexMenuStrip1.Show(dgv_gunluksevkiyat, new Point(e.X, e.Y));
                }
            }
        }

        private void CMSMI_Yukle_Click(object sender, EventArgs e)
        {
            
        }

        private void mtb_barkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DepoGiris dg = dm.DepoGirisGetir(mtb_barkod.Text);
                DepoPalet dp = dm.DepoPaletGetir(mtb_barkod.Text);
                if (dg.Barkod!=null && dg.Sevkiyat_ID==0)
                {
                    depoGirisler.Add(dg);
                }
                if (dp.BarkodNo!=null)
                {
                    depoPaletler.Add(dp);
                    dm.DepoGirisDepoPaletDetayGöster(dp.ID);
                    depoGirisler.AddRange(dm.DepoGirisDepoPaletDetayGöster(dp.ID));
                }
                GridDoldur();
            }
        }

        private void btn_sevkiyatgoster_Click(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void CMSMI_DetayGoster_Click(object sender, EventArgs e)
        {
            dgv_sevkiyatdetay.DataSource= dm.SevkiyatDetayGöster(sevkiyatid);
            dgv_sevkiyatdetay.Columns["Urun_ID"].Visible = dgv_sevkiyatdetay.Columns["Renk_ID"].Visible = dgv_sevkiyatdetay.Columns["Kalite_ID"].Visible = dgv_sevkiyatdetay.Columns["Sevkiyat_ID"].Visible = false;
        }
    }
}
