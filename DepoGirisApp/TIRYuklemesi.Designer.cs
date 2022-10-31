namespace DepoGirisApp
{
    partial class TIRYuklemesi
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
            this.mtb_barkod = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_sevkiyatgoster = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgv_sevkiyatdetay = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgv_gunluksevkiyat = new System.Windows.Forms.DataGridView();
            this.dtp_sevkiyagunu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_eklenenpalet = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv_eklenenurunler = new System.Windows.Forms.DataGridView();
            this.contexMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSMI_DetayGoster = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSMI_Yukle = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sevkiyatdetay)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gunluksevkiyat)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eklenenpalet)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eklenenurunler)).BeginInit();
            this.contexMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.mtb_barkod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1213, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // mtb_barkod
            // 
            this.mtb_barkod.Location = new System.Drawing.Point(71, 20);
            this.mtb_barkod.Mask = "9999999999";
            this.mtb_barkod.Name = "mtb_barkod";
            this.mtb_barkod.Size = new System.Drawing.Size(100, 20);
            this.mtb_barkod.TabIndex = 5;
            this.mtb_barkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtb_barkod_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_sevkiyatgoster);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.dtp_sevkiyagunu);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1213, 308);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Günlük sevkiyat listesi ";
            // 
            // btn_sevkiyatgoster
            // 
            this.btn_sevkiyatgoster.AutoSize = true;
            this.btn_sevkiyatgoster.Location = new System.Drawing.Point(324, 14);
            this.btn_sevkiyatgoster.Name = "btn_sevkiyatgoster";
            this.btn_sevkiyatgoster.Size = new System.Drawing.Size(92, 23);
            this.btn_sevkiyatgoster.TabIndex = 4;
            this.btn_sevkiyatgoster.Text = "Sevkiyat Göster";
            this.btn_sevkiyatgoster.UseVisualStyleBackColor = true;
            this.btn_sevkiyatgoster.Click += new System.EventHandler(this.btn_sevkiyatgoster_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgv_sevkiyatdetay);
            this.groupBox6.Location = new System.Drawing.Point(591, 40);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(616, 262);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sevkiyat Detayı";
            // 
            // dgv_sevkiyatdetay
            // 
            this.dgv_sevkiyatdetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sevkiyatdetay.Location = new System.Drawing.Point(6, 19);
            this.dgv_sevkiyatdetay.Name = "dgv_sevkiyatdetay";
            this.dgv_sevkiyatdetay.Size = new System.Drawing.Size(604, 237);
            this.dgv_sevkiyatdetay.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgv_gunluksevkiyat);
            this.groupBox5.Location = new System.Drawing.Point(7, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(578, 262);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Günlük Sevkiyat Listesi";
            // 
            // dgv_gunluksevkiyat
            // 
            this.dgv_gunluksevkiyat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gunluksevkiyat.Location = new System.Drawing.Point(6, 19);
            this.dgv_gunluksevkiyat.Name = "dgv_gunluksevkiyat";
            this.dgv_gunluksevkiyat.Size = new System.Drawing.Size(566, 237);
            this.dgv_gunluksevkiyat.TabIndex = 0;
            this.dgv_gunluksevkiyat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_gunluksevkiyat_MouseClick);
            // 
            // dtp_sevkiyagunu
            // 
            this.dtp_sevkiyagunu.Location = new System.Drawing.Point(117, 14);
            this.dtp_sevkiyagunu.Name = "dtp_sevkiyagunu";
            this.dtp_sevkiyagunu.Size = new System.Drawing.Size(200, 20);
            this.dtp_sevkiyagunu.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sevkiyat Günü Seç:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dgv_eklenenpalet);
            this.groupBox3.Location = new System.Drawing.Point(12, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 237);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eklenen Palet Bilgisi";
            // 
            // dgv_eklenenpalet
            // 
            this.dgv_eklenenpalet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_eklenenpalet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_eklenenpalet.Location = new System.Drawing.Point(7, 20);
            this.dgv_eklenenpalet.Name = "dgv_eklenenpalet";
            this.dgv_eklenenpalet.Size = new System.Drawing.Size(536, 211);
            this.dgv_eklenenpalet.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgv_eklenenurunler);
            this.groupBox4.Location = new System.Drawing.Point(567, 396);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(658, 237);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Eklenen ürünler";
            // 
            // dgv_eklenenurunler
            // 
            this.dgv_eklenenurunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_eklenenurunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_eklenenurunler.Location = new System.Drawing.Point(6, 19);
            this.dgv_eklenenurunler.Name = "dgv_eklenenurunler";
            this.dgv_eklenenurunler.Size = new System.Drawing.Size(646, 211);
            this.dgv_eklenenurunler.TabIndex = 0;
            // 
            // contexMenuStrip1
            // 
            this.contexMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSMI_DetayGoster,
            this.CMSMI_Yukle});
            this.contexMenuStrip1.Name = "contexMenuStrip1";
            this.contexMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // CMSMI_DetayGoster
            // 
            this.CMSMI_DetayGoster.Name = "CMSMI_DetayGoster";
            this.CMSMI_DetayGoster.Size = new System.Drawing.Size(180, 22);
            this.CMSMI_DetayGoster.Text = "Detay Göster";
            this.CMSMI_DetayGoster.Click += new System.EventHandler(this.CMSMI_DetayGoster_Click);
            // 
            // CMSMI_Yukle
            // 
            this.CMSMI_Yukle.Name = "CMSMI_Yukle";
            this.CMSMI_Yukle.Size = new System.Drawing.Size(180, 22);
            this.CMSMI_Yukle.Text = "Yükle";
            this.CMSMI_Yukle.Click += new System.EventHandler(this.CMSMI_Yukle_Click);
            // 
            // TIRYuklemesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 645);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TIRYuklemesi";
            this.Text = "TIR Yüklemesi";
            this.Load += new System.EventHandler(this.TIRYuklemesi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sevkiyatdetay)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gunluksevkiyat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eklenenpalet)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_eklenenurunler)).EndInit();
            this.contexMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_eklenenpalet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_eklenenurunler;
        private System.Windows.Forms.DateTimePicker dtp_sevkiyagunu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgv_sevkiyatdetay;
        private System.Windows.Forms.DataGridView dgv_gunluksevkiyat;
        private System.Windows.Forms.MaskedTextBox mtb_barkod;
        private System.Windows.Forms.ContextMenuStrip contexMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_DetayGoster;
        private System.Windows.Forms.ToolStripMenuItem CMSMI_Yukle;
        private System.Windows.Forms.Button btn_sevkiyatgoster;
    }
}