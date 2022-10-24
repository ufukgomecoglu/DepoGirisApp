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
        int sevkiyatid = 0;
        int sevkmiktar = 0;
        public TIRYuklemesi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hit = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    dataGridView2.Rows[hit.RowIndex].Selected = true;
                    sevkiyatid = Convert.ToInt32(dataGridView2.Rows[hit.RowIndex].Cells["ID"].Value);
                    sevkmiktar = Convert.ToInt32(dataGridView2.Rows[hit.RowIndex].Cells["Miktar"].Value);
                    lbl_kalansevkiyatmiktar.Text = sevkmiktar.ToString();
                }
            }
        }

        private void TIRYuklemesi_Load(object sender, EventArgs e)
        {
            lbl_kalansevkiyatmiktar.Text = "";
        }
        private void GridDoldur()
        {
            
        }

        private void dtp_sevkiyagunu_ValueChanged(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void tb_barkodno_TextChanged(object sender, EventArgs e)
        {
            if (tb_barkodno.Text.Length==10)
            {

            }
        }
    }
}
