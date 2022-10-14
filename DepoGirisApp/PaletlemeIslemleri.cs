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
            mtb_barkodno.Select();
            label2.Text = "";
        }

        private void mtb_barkodno_TextChanged(object sender, EventArgs e)
       {
            if (mtb_barkodno.Text.Length == 10)
            {
                DepoGiris dg = dm.DepoGirisGetir(mtb_barkodno.Text);
                if (dg.DepoPaletliUrun_ID==0)
                {
                    sayi = sayi + 1;
                    depoGirisler.Add(dg);
                }
                label2.Text = sayi.ToString();
                dataGridView1.DataSource = null;
                GridDoldur(depoGirisler);
                FormTemizle();
            }
        }
        private void FormTemizle()
        {
            mtb_barkodno.Text="" ;
        }
        private void GridDoldur(List<DepoGiris> depoGirisler)
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = depoGirisler;
        }

       
    }
}
