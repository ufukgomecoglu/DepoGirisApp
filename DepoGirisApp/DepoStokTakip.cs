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
    public partial class DepoStokTakip : Form
    {
        DataModel dm = new DataModel();
        public DepoStokTakip()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void DepoStokTakip_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepoStokListele();
        }
    }
}
