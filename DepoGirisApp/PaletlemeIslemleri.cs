using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace DepoGirisApp
{
    public partial class PaletlemeIslemleri : Form
    {
        DataModel dm = new DataModel();
        List<DepoGiris> depoGirisler = new List<DepoGiris>();
        int sayi = 0;
        int kod_liste_kimlik = 0;
        byte renk_liste_kimlik = 0;
        public PaletlemeIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        

        private void PaletlemeIslemleri_Load(object sender, EventArgs e)
        {
            tb_barkodno.Select();
            label2.Text = "";
            GridDoldur();
        }

        private void FormTemizle()
        {
            tb_barkodno.Text = "";
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = depoGirisler;
            dataGridView1.Columns["Product_Id"].Visible = dataGridView1.Columns["DepoPaletliUrun_ID"].Visible = dataGridView1.Columns["UrunKodu"].Visible = false;
            dataGridView2.DataSource = dm.DepoPaletListele();
            dataGridView2.Columns["Kod_liste_Kimlik"].Visible = dataGridView2.Columns["Renk_liste_kimlik"].Visible = dataGridView2.Columns["kullanici_liste_kimlik"].Visible = false;
        }

        private void tb_barkodno_TextChanged(object sender, EventArgs e)
        {
            if (tb_barkodno.Text.Length == 10)
            {
                DepoGiris dg = dm.DepoGirisGetir(tb_barkodno.Text);
                Product p = dm.BarkodNoGöreProductBul(tb_barkodno.Text);
                if (dg.DepoPaletliUrun_ID == 0)
                {
                    sayi = sayi + 1;
                    kod_liste_kimlik = p.ProductCode;
                    renk_liste_kimlik = p.Color;
                    depoGirisler.Add(dg);
                }
                label2.Text = sayi.ToString();
                GridDoldur();
                FormTemizle();
                tb_barkodno.Select();
            }
        }

        private void btn_paletbarkodnocıkart_Click(object sender, EventArgs e)
        {
            DepoPaletliUrun dpu = new DepoPaletliUrun();
            int barkodno = dm.DepoPaletListele().Count;
            dpu.BarkodNo = PaletBarkodNoOlustur(barkodno);
            dpu.Adet = sayi;
            dpu.Kod_liste_Kimlik = kod_liste_kimlik;
            dpu.Renk_liste_kimlik= renk_liste_kimlik;
            dpu.kullanici_liste_kimlik = AnaForm.LoginUser.Kimlik;
            if (dm.DepoPaletEkle(dpu))
            {
                if (dm.DepoGirisDepoPaletIDGuncelle(depoGirisler, dm.DepoPaletListele().Count))
                {
                    depoGirisler.Clear();
                    sayi = 0;
                    kod_liste_kimlik = 0;
                    renk_liste_kimlik = 0;
                    printDoc(dpu.BarkodNo);
                    GridDoldur();
                    FormTemizle();
                    tb_barkodno.Select();
                }
            }
        }
        private string PaletBarkodNoOlustur(int barkodno)
        {
            string barkod = (barkodno+1).ToString("D10");
            return barkod;
        }
        private void printDoc(string barkod)
        {

            PrintDocument document = new PrintDocument();
            BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
            Image barcodeImage = bdraw.Draw(barkod, 50);

            document.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                e.Graphics.DrawImage(barcodeImage, 0, 0);
                e.Graphics.DrawString(barkod, new Font("arial", 8), new SolidBrush(Color.Black), 0, 50);
            };
            document.Print();
        }
    }
}
