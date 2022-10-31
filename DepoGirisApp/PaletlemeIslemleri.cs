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
        int depoGirisId = 0;
        int depoPaletId = 0;
        public PaletlemeIslemleri()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void PaletlemeIslemleri_Load(object sender, EventArgs e)
        {
            mtb_UrunBarkodNo.Select();
            GridDoldur();
        }

        private void mtb_UrunBarkodNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                DepoGiris dp = dm.DepoGirisGetir(mtb_UrunBarkodNo.Text);
                string urunBarkod = "";
                foreach (DepoGiris item in depoGirisler)
                {
                    if (mtb_UrunBarkodNo.Text == item.Barkod)
                    {
                        urunBarkod = item.Barkod;
                    }
                }
                if (dp.DepoPalet_ID==0 && mtb_UrunBarkodNo.Text!=urunBarkod )
                {
                    depoGirisler.Add(dp);
                }
                else
                {
                    MessageBox.Show("Bu ürün palet eklenmiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GridDoldur();
                mtb_UrunBarkodNo.Text = "";
                mtb_UrunBarkodNo.Select();
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            DepoPalet dp = new DepoPalet();
            dp.BarkodNo = (dm.DepoPaletSonIDBulma()+1).ToString("D10");
            dp.Kullanici_ID = AnaForm.LoginUser.Kimlik;
            int id = dm.DepoPaletEkle(dp);
            if (id != -1)
            {
                dm.DepoGirisDepoPaletIDGuncelle(depoGirisler, id);
                depoGirisler = new List<DepoGiris>();
                printDoc(dp.BarkodNo);
                mtb_UrunBarkodNo.Select();
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GridDoldur();
        }

        private void CMSMI_Sil_Click(object sender, EventArgs e)
        {
            if (depoGirisler.Count != 0)
            {
                depoGirisler.Remove(depoGirisler[depoGirisId]);
                GridDoldur();
            }
            else
            {
                dm.DepoGirisDepoPaletIDGuncelle(depoGirisId);
                dataGridView1.DataSource = dm.DepoGirisDepoPaletDetayGöster(depoPaletId);
            }
        }

        private void CMSMI_PaletDetay_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dm.DepoGirisDepoPaletDetayGöster(depoPaletId);
        }

        private void CMSMI_PaletSil_Click(object sender, EventArgs e)
        {
            dm.DepoPaletSil(depoPaletId);
            GridDoldur();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    if (depoGirisler.Count != 0)
                    {
                        dataGridView1.Rows[hit.RowIndex].Selected = true;
                        depoGirisId = hit.RowIndex;
                        contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                    else
                    {
                        dataGridView1.Rows[hit.RowIndex].Selected = true;
                        depoGirisId = Convert.ToInt32(dataGridView1.Rows[hit.RowIndex].Cells["ID"].Value);
                        depoPaletId = Convert.ToInt32(dataGridView1.Rows[hit.RowIndex].Cells["DepoPalet_ID"].Value);
                        contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.ClearSelection();
                if (hit.RowIndex != -1)
                {
                    dataGridView2.Rows[hit.RowIndex].Selected = true;
                    depoPaletId = Convert.ToInt32(dataGridView2.Rows[hit.RowIndex].Cells["ID"].Value);
                    contextMenuStrip2.Show(dataGridView2, new Point(e.X, e.Y));
                }
            }
        }

        private void GridDoldur()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = depoGirisler;
            dataGridView1.Columns["Sicil"].Visible = dataGridView1.Columns["Kullanici_Isim"].Visible = dataGridView1.Columns["Product_ID"].Visible = dataGridView1.Columns["KaliteHata_Id"].Visible = dataGridView1.Columns["Urun_ID"].Visible = dataGridView1.Columns["Renk_ID"].Visible = dataGridView1.Columns["Kalite_ID"].Visible = dataGridView1.Columns["Sevkiyat_ID"].Visible = dataGridView1.Columns["DepoHata_ID"].Visible = false;
            dataGridView2.DataSource = dm.DepoPaletReader();
        }
        private void printDoc(string barkod)
        {
            PrintDocument document = new PrintDocument();
            BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
            Image barcodeImage = bdraw.Draw(barkod, 50);
            document.PrinterSettings.Copies = 1;
            //document.PrinterSettings.PrinterName = "ZDesigner TLP 2844";
            document.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                e.Graphics.DrawImage(barcodeImage, 50, 20);
                e.Graphics.DrawString(barkod, new Font("arial", 8), new SolidBrush(Color.Black), 50, 70);
            };
            document.Print();
        }

        private void CMSMI_Ekle_Click(object sender, EventArgs e)
        {
            dm.DepoGirisDepoPaletIDGuncelle(depoGirisler,depoPaletId);
            depoGirisler = new List<DepoGiris>();
            GridDoldur();
        }
    }
}
