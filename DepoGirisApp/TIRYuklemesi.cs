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
        public TIRYuklemesi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TIRYuklemesi_Load(object sender, EventArgs e)
        {

        }
        private void GridDoldur()
        {

        }

        
    }
}
