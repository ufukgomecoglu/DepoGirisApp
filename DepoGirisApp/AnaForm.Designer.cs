namespace DepoGirisApp
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtb_barkodno = new System.Windows.Forms.MaskedTextBox();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_hata = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iŞLEMLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_PaletBarkoduCikar = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SevkiyatOlustur = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_UrunTakip = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_TIRYuklemesi = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_EklenenUrunSayisi = new System.Windows.Forms.Label();
            this.btn_paletbarkod = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_paletbarkod);
            this.groupBox1.Controls.Add(this.lbl_EklenenUrunSayisi);
            this.groupBox1.Controls.Add(this.mtb_barkodno);
            this.groupBox1.Controls.Add(this.btn_ekle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_hata);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1456, 271);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPO-SEVKİYAT";
            // 
            // mtb_barkodno
            // 
            this.mtb_barkodno.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mtb_barkodno.Location = new System.Drawing.Point(240, 19);
            this.mtb_barkodno.Mask = "9999999999";
            this.mtb_barkodno.Name = "mtb_barkodno";
            this.mtb_barkodno.Size = new System.Drawing.Size(216, 47);
            this.mtb_barkodno.TabIndex = 7;
            // 
            // btn_ekle
            // 
            this.btn_ekle.AutoSize = true;
            this.btn_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ekle.Location = new System.Drawing.Point(688, 108);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(142, 49);
            this.btn_ekle.TabIndex = 6;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // cb_hata
            // 
            this.cb_hata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_hata.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_hata.FormattingEnabled = true;
            this.cb_hata.Location = new System.Drawing.Point(240, 108);
            this.cb_hata.Name = "cb_hata";
            this.cb_hata.Size = new System.Drawing.Size(422, 47);
            this.cb_hata.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kalite Hatası:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iŞLEMLERToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1456, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iŞLEMLERToolStripMenuItem
            // 
            this.iŞLEMLERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_PaletBarkoduCikar,
            this.TSMI_SevkiyatOlustur,
            this.TSMI_UrunTakip,
            this.TSMI_TIRYuklemesi});
            this.iŞLEMLERToolStripMenuItem.Name = "iŞLEMLERToolStripMenuItem";
            this.iŞLEMLERToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.iŞLEMLERToolStripMenuItem.Text = "İŞLEMLER";
            // 
            // TSMI_PaletBarkoduCikar
            // 
            this.TSMI_PaletBarkoduCikar.Name = "TSMI_PaletBarkoduCikar";
            this.TSMI_PaletBarkoduCikar.Size = new System.Drawing.Size(179, 22);
            this.TSMI_PaletBarkoduCikar.Text = "Palet barkodu çıkart";
            // 
            // TSMI_SevkiyatOlustur
            // 
            this.TSMI_SevkiyatOlustur.Name = "TSMI_SevkiyatOlustur";
            this.TSMI_SevkiyatOlustur.Size = new System.Drawing.Size(179, 22);
            this.TSMI_SevkiyatOlustur.Text = "Sevkiyat Oluştur";
            this.TSMI_SevkiyatOlustur.Click += new System.EventHandler(this.TSMI_TirYuklemesi_Click);
            // 
            // TSMI_UrunTakip
            // 
            this.TSMI_UrunTakip.Name = "TSMI_UrunTakip";
            this.TSMI_UrunTakip.Size = new System.Drawing.Size(179, 22);
            this.TSMI_UrunTakip.Text = "Ürün Takip";
            this.TSMI_UrunTakip.Click += new System.EventHandler(this.TSMI_UrunTakip_Click);
            // 
            // TSMI_TIRYuklemesi
            // 
            this.TSMI_TIRYuklemesi.Name = "TSMI_TIRYuklemesi";
            this.TSMI_TIRYuklemesi.Size = new System.Drawing.Size(179, 22);
            this.TSMI_TIRYuklemesi.Text = "TIR Yüklemesi ";
            this.TSMI_TIRYuklemesi.Click += new System.EventHandler(this.TSMI_TIRYuklemesi_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 304);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1431, 249);
            this.dataGridView1.TabIndex = 2;
            // 
            // lbl_EklenenUrunSayisi
            // 
            this.lbl_EklenenUrunSayisi.AutoSize = true;
            this.lbl_EklenenUrunSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_EklenenUrunSayisi.Location = new System.Drawing.Point(1114, 27);
            this.lbl_EklenenUrunSayisi.Name = "lbl_EklenenUrunSayisi";
            this.lbl_EklenenUrunSayisi.Size = new System.Drawing.Size(0, 39);
            this.lbl_EklenenUrunSayisi.TabIndex = 8;
            // 
            // btn_paletbarkod
            // 
            this.btn_paletbarkod.AutoSize = true;
            this.btn_paletbarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_paletbarkod.Location = new System.Drawing.Point(1009, 111);
            this.btn_paletbarkod.Name = "btn_paletbarkod";
            this.btn_paletbarkod.Size = new System.Drawing.Size(335, 49);
            this.btn_paletbarkod.TabIndex = 9;
            this.btn_paletbarkod.Text = "Palet Barkodu Çıkar";
            this.btn_paletbarkod.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 565);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_hata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iŞLEMLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_PaletBarkoduCikar;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SevkiyatOlustur;
        private System.Windows.Forms.ToolStripMenuItem TSMI_UrunTakip;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.MaskedTextBox mtb_barkodno;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_TIRYuklemesi;
        private System.Windows.Forms.Button btn_paletbarkod;
        private System.Windows.Forms.Label lbl_EklenenUrunSayisi;
    }
}