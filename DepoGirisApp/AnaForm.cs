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
    public partial class AnaForm : Form
    {
        public static kullanici_listeLogin LoginUser;
        public AnaForm()
        {
            KullaniciGiris frm = new KullaniciGiris();
            frm.ShowDialog();
            InitializeComponent();
        }
    }
}
