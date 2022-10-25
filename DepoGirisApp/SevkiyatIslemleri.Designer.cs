namespace DepoGirisApp
{
    partial class SevkiyatIslemleri
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_sevkiyatolustur = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.tb_miktar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_kalite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_renk = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_urun = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_sevkiyattarih = new System.Windows.Forms.DateTimePicker();
            this.cb_musteri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSMI_detaygoster = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSMI_SevkiyatDetayEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_sevkiyatolustur);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtp_sevkiyattarih);
            this.groupBox1.Controls.Add(this.cb_musteri);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sevkiyat Bilgileri";
            // 
            // btn_sevkiyatolustur
            // 
            this.btn_sevkiyatolustur.AutoSize = true;
            this.btn_sevkiyatolustur.Location = new System.Drawing.Point(654, 18);
            this.btn_sevkiyatolustur.Name = "btn_sevkiyatolustur";
            this.btn_sevkiyatolustur.Size = new System.Drawing.Size(94, 23);
            this.btn_sevkiyatolustur.TabIndex = 4;
            this.btn_sevkiyatolustur.Text = "Sevkiyat Oluştur";
            this.btn_sevkiyatolustur.UseVisualStyleBackColor = true;
            this.btn_sevkiyatolustur.Click += new System.EventHandler(this.btn_sevkiyatolustur_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ekle);
            this.groupBox2.Controls.Add(this.tb_miktar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_kalite);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_renk);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_urun);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 153);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürun Bilgileri";
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(666, 81);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 8;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // tb_miktar
            // 
            this.tb_miktar.Location = new System.Drawing.Point(373, 49);
            this.tb_miktar.Name = "tb_miktar";
            this.tb_miktar.Size = new System.Drawing.Size(383, 20);
            this.tb_miktar.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Miktar";
            // 
            // cb_kalite
            // 
            this.cb_kalite.FormattingEnabled = true;
            this.cb_kalite.Location = new System.Drawing.Point(49, 77);
            this.cb_kalite.Name = "cb_kalite";
            this.cb_kalite.Size = new System.Drawing.Size(273, 21);
            this.cb_kalite.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kalite";
            // 
            // cb_renk
            // 
            this.cb_renk.FormattingEnabled = true;
            this.cb_renk.Location = new System.Drawing.Point(49, 49);
            this.cb_renk.Name = "cb_renk";
            this.cb_renk.Size = new System.Drawing.Size(273, 21);
            this.cb_renk.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Renk:";
            // 
            // cb_urun
            // 
            this.cb_urun.FormattingEnabled = true;
            this.cb_urun.Location = new System.Drawing.Point(49, 20);
            this.cb_urun.Name = "cb_urun";
            this.cb_urun.Size = new System.Drawing.Size(273, 21);
            this.cb_urun.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ürün :";
            // 
            // dtp_sevkiyattarih
            // 
            this.dtp_sevkiyattarih.Location = new System.Drawing.Point(447, 21);
            this.dtp_sevkiyattarih.Name = "dtp_sevkiyattarih";
            this.dtp_sevkiyattarih.Size = new System.Drawing.Size(200, 20);
            this.dtp_sevkiyattarih.TabIndex = 2;
            // 
            // cb_musteri
            // 
            this.cb_musteri.FormattingEnabled = true;
            this.cb_musteri.Location = new System.Drawing.Point(56, 19);
            this.cb_musteri.Name = "cb_musteri";
            this.cb_musteri.Size = new System.Drawing.Size(315, 21);
            this.cb_musteri.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sevk Tarihi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(794, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 218);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sevkiyat Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(358, 192);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(13, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1152, 219);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sevkiyat Detay";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1139, 193);
            this.dataGridView2.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSMI_detaygoster,
            this.CMSMI_SevkiyatDetayEkle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // CMSMI_detaygoster
            // 
            this.CMSMI_detaygoster.Name = "CMSMI_detaygoster";
            this.CMSMI_detaygoster.Size = new System.Drawing.Size(180, 22);
            this.CMSMI_detaygoster.Text = "Detay Göster";
            this.CMSMI_detaygoster.Click += new System.EventHandler(this.CMSMI_detaygoster_Click);
            // 
            // CMSMI_SevkiyatDetayEkle
            // 
            this.CMSMI_SevkiyatDetayEkle.Name = "CMSMI_SevkiyatDetayEkle";
            this.CMSMI_SevkiyatDetayEkle.Size = new System.Drawing.Size(180, 22);
            this.CMSMI_SevkiyatDetayEkle.Text = "Sevkiyat Detay Ekle";
            this.CMSMI_SevkiyatDetayEkle.Click += new System.EventHandler(this.CMSMI_SevkiyatDetayEkle_Click);
            // 
            // SevkiyatIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "SevkiyatIslemleri";
            this.Text = "Sevkiyat Oluştur";
            this.Load += new System.EventHandler(this.SevkiyatIslemleri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_sevkiyatolustur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_sevkiyattarih;
        private System.Windows.Forms.ComboBox cb_musteri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_miktar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_kalite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_renk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_urun;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_detaygoster;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_SevkiyatDetayEkle;
    }
}