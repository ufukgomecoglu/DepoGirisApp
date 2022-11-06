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
    public partial class MusteriGecmisi : Form
    {
        DataModel dm= new DataModel();
        public MusteriGecmisi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        

        private void MusteriGecmisi_Load(object sender, EventArgs e)
        {
            cb_musteri.ValueMember = "ID";
            cb_musteri.DisplayMember = "Isim";
            cb_musteri.DataSource = dm.MusteriListele();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.MusteriGecmisiListele(Convert.ToInt32(cb_musteri.SelectedValue), tb_barkod.Text, dateTimePicker1.Value.Date,dateTimePicker2.Value.Date);
            dataGridView1.Columns["Sicil"].Visible = dataGridView1.Columns["Kullanici_Isim"].Visible = dataGridView1.Columns["KayitTarih"].Visible = dataGridView1.Columns["Product_ID"].Visible = dataGridView1.Columns["KaliteHata_Id"].Visible = dataGridView1.Columns["KaliteHata_Isim"].Visible = dataGridView1.Columns["KaliteHata_Kod"].Visible = dataGridView1.Columns["Urun_ID"].Visible = dataGridView1.Columns["Renk_ID"].Visible = dataGridView1.Columns["Kalite_ID"].Visible = dataGridView1.Columns["DepoPalet_ID"].Visible =
                dataGridView1.Columns["Sevkiyat_ID"].Visible = dataGridView1.Columns["DepoHata_ID"].Visible = dataGridView1.Columns["DepoStok_ID"].Visible = dataGridView1.Columns["Musteri_ID"].Visible = false;
        }
    }
}
