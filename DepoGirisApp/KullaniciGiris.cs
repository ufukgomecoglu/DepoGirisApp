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
    public partial class KullaniciGiris : Form
    {
        bool girisvar = false;
        DataModel db = new DataModel();
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                kullanici_listeLogin model = db.KullaniciGiris(tb_kullaniciAdi.Text, tb_sifre.Text);
                if (model != null)
                {
                    if (model.Kimlik != 0)
                    {
                        AnaForm.LoginUser = model;
                        girisvar = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Bulunamadı veya silinmiş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bir Hata Oluştu. Lütfen sistem yöneticiniz ile iletişime geçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ve şifre Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KullaniciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (girisvar == false)
            {
                Application.Exit();
            }
        }
    }
}
