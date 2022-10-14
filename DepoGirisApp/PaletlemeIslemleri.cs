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
        public PaletlemeIslemleri()
        {
            InitializeComponent();
        }

       

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PaletlemeIslemleri_Load(object sender, EventArgs e)
        {
            mtb_barkodno.Select();
        }

        private void mtb_barkodno_TextChanged(object sender, EventArgs e)
       {
            if (mtb_barkodno.Text.Length == 10)
            {
                FormTemizle();
                mtb_barkodno.Select();
            }
        }
        private void FormTemizle()
        {
            mtb_barkodno.Text = "";
        }

       
    }
}
