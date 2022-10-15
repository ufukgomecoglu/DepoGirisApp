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
    public partial class PaletlemeIslemleri : Form
    {
        DataModel dm = new DataModel();
        List<DepoGiris> depoGirisler = new List<DepoGiris>();
        int sayi = 0;
        public PaletlemeIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PaletlemeIslemleri_Load(object sender, EventArgs e)
        {
            tb_barkodno.Select();
            label2.Text = "";
        }

        private void FormTemizle()
        {
            tb_barkodno.Text = "";
        }
        private void GridDoldur(List<DepoGiris> depoGirisler)
        {
            dataGridView1.DataSource = depoGirisler;
            dataGridView1.Columns["Product_Id"].Visible = dataGridView1.Columns["DepoPaletliUrun_ID"].Visible = dataGridView1.Columns["UrunKodu"].Visible = false;
        }

        private void tb_barkodno_TextChanged(object sender, EventArgs e)
        {
            if (tb_barkodno.Text.Length == 10)
            {
                DepoGiris dg = dm.DepoGirisGetir(tb_barkodno.Text);
                if (dg.DepoPaletliUrun_ID == 0)
                {
                    sayi = sayi + 1;
                    depoGirisler.Add(dg);
                }
                label2.Text = sayi.ToString();
                dataGridView1.DataSource = null;
                GridDoldur(depoGirisler);
                FormTemizle();
                tb_barkodno.Select();
            }
        }

        private void btn_paletbarkodnocıkart_Click(object sender, EventArgs e)
        {

        }
        private void PaletBarkodNoOlustur()
        { 
        
        }
    }
}
