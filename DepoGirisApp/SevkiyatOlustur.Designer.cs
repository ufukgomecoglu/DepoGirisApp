namespace DepoGirisApp
{
    partial class SevkiyatOlustur
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
            this.btn_yeniekle = new System.Windows.Forms.Button();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.cb_kalite = new System.Windows.Forms.ComboBox();
            this.cb_renk = new System.Windows.Forms.ComboBox();
            this.dtp_tarih = new System.Windows.Forms.DateTimePicker();
            this.tb_miktar = new System.Windows.Forms.TextBox();
            this.cb_kod = new System.Windows.Forms.ComboBox();
            this.cb_musteri = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSMI_guncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSMI_sil = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_yeniekle);
            this.groupBox1.Controls.Add(this.btn_guncelle);
            this.groupBox1.Controls.Add(this.btn_ekle);
            this.groupBox1.Controls.Add(this.cb_kalite);
            this.groupBox1.Controls.Add(this.cb_renk);
            this.groupBox1.Controls.Add(this.dtp_tarih);
            this.groupBox1.Controls.Add(this.tb_miktar);
            this.groupBox1.Controls.Add(this.cb_kod);
            this.groupBox1.Controls.Add(this.cb_musteri);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Siparis Bilgileri";
            // 
            // btn_yeniekle
            // 
            this.btn_yeniekle.Location = new System.Drawing.Point(540, 104);
            this.btn_yeniekle.Name = "btn_yeniekle";
            this.btn_yeniekle.Size = new System.Drawing.Size(75, 23);
            this.btn_yeniekle.TabIndex = 14;
            this.btn_yeniekle.Text = "Yeni Ekle";
            this.btn_yeniekle.UseVisualStyleBackColor = true;
            this.btn_yeniekle.Click += new System.EventHandler(this.btn_yeniekle_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(621, 104);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(75, 23);
            this.btn_guncelle.TabIndex = 13;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(621, 103);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 12;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // cb_kalite
            // 
            this.cb_kalite.FormattingEnabled = true;
            this.cb_kalite.Location = new System.Drawing.Point(444, 76);
            this.cb_kalite.Name = "cb_kalite";
            this.cb_kalite.Size = new System.Drawing.Size(252, 21);
            this.cb_kalite.TabIndex = 11;
            // 
            // cb_renk
            // 
            this.cb_renk.FormattingEnabled = true;
            this.cb_renk.Location = new System.Drawing.Point(444, 48);
            this.cb_renk.Name = "cb_renk";
            this.cb_renk.Size = new System.Drawing.Size(252, 21);
            this.cb_renk.TabIndex = 10;
            // 
            // dtp_tarih
            // 
            this.dtp_tarih.Location = new System.Drawing.Point(444, 21);
            this.dtp_tarih.Name = "dtp_tarih";
            this.dtp_tarih.Size = new System.Drawing.Size(159, 20);
            this.dtp_tarih.TabIndex = 9;
            // 
            // tb_miktar
            // 
            this.tb_miktar.Location = new System.Drawing.Point(135, 76);
            this.tb_miktar.Name = "tb_miktar";
            this.tb_miktar.Size = new System.Drawing.Size(200, 20);
            this.tb_miktar.TabIndex = 8;
            // 
            // cb_kod
            // 
            this.cb_kod.FormattingEnabled = true;
            this.cb_kod.Location = new System.Drawing.Point(135, 48);
            this.cb_kod.Name = "cb_kod";
            this.cb_kod.Size = new System.Drawing.Size(200, 21);
            this.cb_kod.TabIndex = 7;
            // 
            // cb_musteri
            // 
            this.cb_musteri.FormattingEnabled = true;
            this.cb_musteri.Location = new System.Drawing.Point(135, 20);
            this.cb_musteri.Name = "cb_musteri";
            this.cb_musteri.Size = new System.Drawing.Size(200, 21);
            this.cb_musteri.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kalite Tipi ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Renk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sevk Edilcek Tarih";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sipariş Edilen Miktar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "İstenen Ürün(ürün kodu)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 259);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSMI_guncelle,
            this.CMSMI_sil});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // CMSMI_guncelle
            // 
            this.CMSMI_guncelle.Name = "CMSMI_guncelle";
            this.CMSMI_guncelle.Size = new System.Drawing.Size(120, 22);
            this.CMSMI_guncelle.Text = "Güncelle";
            this.CMSMI_guncelle.Click += new System.EventHandler(this.CMSMI_guncelle_Click);
            // 
            // CMSMI_sil
            // 
            this.CMSMI_sil.Name = "CMSMI_sil";
            this.CMSMI_sil.Size = new System.Drawing.Size(120, 22);
            this.CMSMI_sil.Text = "Sil";
            this.CMSMI_sil.Click += new System.EventHandler(this.CMSMI_sil_Click);
            // 
            // SevkiyatOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SevkiyatOlustur";
            this.Text = "Sevkiyat Oluştur";
            this.Load += new System.EventHandler(this.SevkiyatOlustur_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_tarih;
        private System.Windows.Forms.TextBox tb_miktar;
        private System.Windows.Forms.ComboBox cb_kod;
        private System.Windows.Forms.ComboBox cb_musteri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_kalite;
        private System.Windows.Forms.ComboBox cb_renk;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.Button btn_yeniekle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_guncelle;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_sil;
    }
}