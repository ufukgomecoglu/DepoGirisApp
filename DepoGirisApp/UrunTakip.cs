using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoGirisApp
{
    public partial class UrunTakip : Form
    {
        DataModel dm = new DataModel();
        public UrunTakip()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void UrunTakip_Load(object sender, EventArgs e)
        {
            GridDoldur();
            CbDoldur();
        }

        private void btn_tumunugoster_Click(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

        }
        private void CbDoldur()
        {
            cb_urunkod.DataSource = dm.UrunKodListele();
            cb_urunkod.ValueMember = "Kimlik";
            cb_urunkod.DisplayMember = "tanim";
            cb_renk.DataSource = dm.RenkListele();
            cb_renk.ValueMember = "Kimlik";
            cb_renk.DisplayMember = "renkad";
            cb_kalite.DataSource = dm.KaliteTipiListele();
            cb_kalite.ValueMember = "Kimlik";
            cb_kalite.DisplayMember = "kaliteAd";
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = dm.DepogirisListReader();
            dataGridView1.Columns["Product_Id"].Visible = dataGridView1.Columns["KaliteHata_Id"].Visible = dataGridView1.Columns["Urun_ID"].Visible = dataGridView1.Columns["Renk_ID"].Visible = dataGridView1.Columns["Kalite_ID"].Visible = dataGridView1.Columns["DepoPalet_ID"].Visible = dataGridView1.Columns["Sevkiyat_ID"].Visible = dataGridView1.Columns["DepoHata_ID"].Visible = false;
            dataGridView1.Columns["UrunAciklama"].Width = 500;
        }
    }
}
