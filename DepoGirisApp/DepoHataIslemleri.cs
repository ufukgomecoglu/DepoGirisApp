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
    public partial class DepoHataIslemleri : Form
    {
        DataModel dm = new DataModel();
        public DepoHataIslemleri()
        {
            InitializeComponent();
        }

        private void DepoHataIslemleri_Load(object sender, EventArgs e)
        {
            mtb_barkodno.Select();
            CBDoldur();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            DepoGiris dg = dm.DepoGirisGetir(mtb_barkodno.Text);
            dm.DepoStokMiktarGuncelle(dg.DepoStok_ID);
            dm.DepoGirisGuncelle(dg.Id,Convert.ToInt32(cb_hata.SelectedValue));
            mtb_barkodno.Text = "";
        }
        private void CBDoldur()
        {
            cb_hata.DataSource = dm.DepoHataListele();
            cb_hata.ValueMember = "ID";
            cb_hata.DisplayMember = "Isim";
        }
    }
}
