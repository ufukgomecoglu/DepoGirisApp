﻿namespace DepoGirisApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iŞLEMLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_PaletBarkoduCikar = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_TIRYuklemesi = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_DepoStokTakip = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_uruntakip = new System.Windows.Forms.Button();
            this.btn_urungir = new System.Windows.Forms.Button();
            this.btn_sevkiyatolustur = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iŞLEMLERToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iŞLEMLERToolStripMenuItem
            // 
            this.iŞLEMLERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_PaletBarkoduCikar,
            this.TSMI_TIRYuklemesi,
            this.TSMI_DepoStokTakip});
            this.iŞLEMLERToolStripMenuItem.Name = "iŞLEMLERToolStripMenuItem";
            this.iŞLEMLERToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.iŞLEMLERToolStripMenuItem.Text = "İŞLEMLER";
            // 
            // TSMI_PaletBarkoduCikar
            // 
            this.TSMI_PaletBarkoduCikar.Name = "TSMI_PaletBarkoduCikar";
            this.TSMI_PaletBarkoduCikar.Size = new System.Drawing.Size(180, 22);
            this.TSMI_PaletBarkoduCikar.Text = "Paletleme İşlemleri";
            this.TSMI_PaletBarkoduCikar.Click += new System.EventHandler(this.TSMI_PaletBarkoduCikar_Click);
            // 
            // TSMI_TIRYuklemesi
            // 
            this.TSMI_TIRYuklemesi.Name = "TSMI_TIRYuklemesi";
            this.TSMI_TIRYuklemesi.Size = new System.Drawing.Size(180, 22);
            this.TSMI_TIRYuklemesi.Text = "TIR Yüklemesi ";
            this.TSMI_TIRYuklemesi.Click += new System.EventHandler(this.TSMI_TIRYuklemesi_Click_1);
            // 
            // TSMI_DepoStokTakip
            // 
            this.TSMI_DepoStokTakip.Name = "TSMI_DepoStokTakip";
            this.TSMI_DepoStokTakip.Size = new System.Drawing.Size(180, 22);
            this.TSMI_DepoStokTakip.Text = "Depo Stok Takip";
            this.TSMI_DepoStokTakip.Click += new System.EventHandler(this.TSMI_DepoStokTakip_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_sevkiyatolustur);
            this.groupBox1.Controls.Add(this.btn_uruntakip);
            this.groupBox1.Controls.Add(this.btn_urungir);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 279);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btn_uruntakip
            // 
            this.btn_uruntakip.Location = new System.Drawing.Point(88, 18);
            this.btn_uruntakip.Name = "btn_uruntakip";
            this.btn_uruntakip.Size = new System.Drawing.Size(75, 23);
            this.btn_uruntakip.TabIndex = 1;
            this.btn_uruntakip.Text = "Ürün Takip";
            this.btn_uruntakip.UseVisualStyleBackColor = true;
            this.btn_uruntakip.Click += new System.EventHandler(this.btn_uruntakip_Click);
            // 
            // btn_urungir
            // 
            this.btn_urungir.Location = new System.Drawing.Point(6, 19);
            this.btn_urungir.Name = "btn_urungir";
            this.btn_urungir.Size = new System.Drawing.Size(75, 23);
            this.btn_urungir.TabIndex = 0;
            this.btn_urungir.Text = "Ürün Gir";
            this.btn_urungir.UseVisualStyleBackColor = true;
            this.btn_urungir.Click += new System.EventHandler(this.btn_urungir_Click);
            // 
            // btn_sevkiyatolustur
            // 
            this.btn_sevkiyatolustur.AutoSize = true;
            this.btn_sevkiyatolustur.Location = new System.Drawing.Point(170, 17);
            this.btn_sevkiyatolustur.Name = "btn_sevkiyatolustur";
            this.btn_sevkiyatolustur.Size = new System.Drawing.Size(94, 23);
            this.btn_sevkiyatolustur.TabIndex = 2;
            this.btn_sevkiyatolustur.Text = "Sevkiyat Oluştur";
            this.btn_sevkiyatolustur.UseVisualStyleBackColor = true;
            this.btn_sevkiyatolustur.Click += new System.EventHandler(this.btn_sevkiyatolustur_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iŞLEMLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_PaletBarkoduCikar;
        private System.Windows.Forms.ToolStripMenuItem TSMI_TIRYuklemesi;
        private System.Windows.Forms.ToolStripMenuItem TSMI_DepoStokTakip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_urungir;
        private System.Windows.Forms.Button btn_uruntakip;
        private System.Windows.Forms.Button btn_sevkiyatolustur;
    }
}