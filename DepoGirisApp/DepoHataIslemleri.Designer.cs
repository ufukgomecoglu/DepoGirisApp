namespace DepoGirisApp
{
    partial class DepoHataIslemleri
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
            this.label1 = new System.Windows.Forms.Label();
            this.mtb_barkodno = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_hata = new System.Windows.Forms.ComboBox();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ekle);
            this.groupBox1.Controls.Add(this.cb_hata);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mtb_barkodno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No";
            // 
            // mtb_barkodno
            // 
            this.mtb_barkodno.Location = new System.Drawing.Point(70, 31);
            this.mtb_barkodno.Mask = "9999999999";
            this.mtb_barkodno.Name = "mtb_barkodno";
            this.mtb_barkodno.Size = new System.Drawing.Size(100, 20);
            this.mtb_barkodno.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hata Tipi";
            // 
            // cb_hata
            // 
            this.cb_hata.FormattingEnabled = true;
            this.cb_hata.Location = new System.Drawing.Point(233, 31);
            this.cb_hata.Name = "cb_hata";
            this.cb_hata.Size = new System.Drawing.Size(121, 21);
            this.cb_hata.TabIndex = 3;
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(360, 28);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 4;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // DepoHataIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 110);
            this.Controls.Add(this.groupBox1);
            this.Name = "DepoHataIslemleri";
            this.Text = "DepoHataIslemleri";
            this.Load += new System.EventHandler(this.DepoHataIslemleri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.ComboBox cb_hata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtb_barkodno;
        private System.Windows.Forms.Label label1;
    }
}