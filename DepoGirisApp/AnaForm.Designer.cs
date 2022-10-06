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
            this.btn_ekle = new System.Windows.Forms.Button();
            this.tb_barkodno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_hata = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iŞLEMLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuelGirişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletBarkoduÇıkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIRYüklemesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünTakipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_ekle);
            this.groupBox1.Controls.Add(this.tb_barkodno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_hata);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1304, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPO-SEVKİYAT";
            // 
            // btn_ekle
            // 
            this.btn_ekle.AutoSize = true;
            this.btn_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ekle.Location = new System.Drawing.Point(1110, 22);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(142, 49);
            this.btn_ekle.TabIndex = 6;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // tb_barkodno
            // 
            this.tb_barkodno.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_barkodno.Location = new System.Drawing.Point(202, 22);
            this.tb_barkodno.Name = "tb_barkodno";
            this.tb_barkodno.Size = new System.Drawing.Size(358, 47);
            this.tb_barkodno.TabIndex = 5;
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
            this.cb_hata.Location = new System.Drawing.Point(662, 22);
            this.cb_hata.Name = "cb_hata";
            this.cb_hata.Size = new System.Drawing.Size(422, 47);
            this.cb_hata.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(566, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hata";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1304, 256);
            this.dataGridView1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iŞLEMLERToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iŞLEMLERToolStripMenuItem
            // 
            this.iŞLEMLERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuelGirişToolStripMenuItem,
            this.paletBarkoduÇıkartToolStripMenuItem,
            this.tIRYüklemesiToolStripMenuItem,
            this.ürünTakipToolStripMenuItem});
            this.iŞLEMLERToolStripMenuItem.Name = "iŞLEMLERToolStripMenuItem";
            this.iŞLEMLERToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.iŞLEMLERToolStripMenuItem.Text = "İŞLEMLER";
            // 
            // manuelGirişToolStripMenuItem
            // 
            this.manuelGirişToolStripMenuItem.Name = "manuelGirişToolStripMenuItem";
            this.manuelGirişToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.manuelGirişToolStripMenuItem.Text = "Manuel Giriş";
            // 
            // paletBarkoduÇıkartToolStripMenuItem
            // 
            this.paletBarkoduÇıkartToolStripMenuItem.Name = "paletBarkoduÇıkartToolStripMenuItem";
            this.paletBarkoduÇıkartToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.paletBarkoduÇıkartToolStripMenuItem.Text = "Palet barkodu çıkart";
            // 
            // tIRYüklemesiToolStripMenuItem
            // 
            this.tIRYüklemesiToolStripMenuItem.Name = "tIRYüklemesiToolStripMenuItem";
            this.tIRYüklemesiToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tIRYüklemesiToolStripMenuItem.Text = "TIR Yüklemesi";
            // 
            // ürünTakipToolStripMenuItem
            // 
            this.ürünTakipToolStripMenuItem.Name = "ürünTakipToolStripMenuItem";
            this.ürünTakipToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ürünTakipToolStripMenuItem.Text = "Ürün Takip";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_hata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iŞLEMLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuelGirişToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paletBarkoduÇıkartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIRYüklemesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünTakipToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_barkodno;
        private System.Windows.Forms.Button btn_ekle;
    }
}