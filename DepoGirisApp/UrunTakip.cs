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
            dataGridView1.DataSource = dm.DepogirisListReader();
        }

        private void btn_kodara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepogirisListReader(tb_kod.Text);
        }

        private void btn_sicilnoara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepogirisListReaderSicilAra(Convert.ToByte(tb_sicil.Text));
        }

        private void btn_tarihara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepogirisListReader(dtp_baslangic.Value, dtp_bitis.Value);
        }

        private void btn_sifirla_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepogirisListReader();
        }
    }
}
