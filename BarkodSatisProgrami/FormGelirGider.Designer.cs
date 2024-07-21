namespace BarkodSatisProgrami
{
    partial class FormGelirGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGelirGider));
            this.lbGelirGider = new BarkodSatisProgrami.lbStandart();
            this.cmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.lbStandart2 = new BarkodSatisProgrami.lbStandart();
            this.txNakit = new BarkodSatisProgrami.txNumaratik();
            this.txKart = new BarkodSatisProgrami.txNumaratik();
            this.lbStandart3 = new BarkodSatisProgrami.lbStandart();
            this.lbStandart4 = new BarkodSatisProgrami.lbStandart();
            this.txAciklama = new BarkodSatisProgrami.txStandart();
            this.lbStandart5 = new BarkodSatisProgrami.lbStandart();
            this.dateTarih = new System.Windows.Forms.DateTimePicker();
            this.lbStandart6 = new BarkodSatisProgrami.lbStandart();
            this.btnEkle = new BarkodSatisProgrami.btnStandart();
            this.SuspendLayout();
            // 
            // lbGelirGider
            // 
            this.lbGelirGider.AutoSize = true;
            this.lbGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbGelirGider.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbGelirGider.Location = new System.Drawing.Point(21, 14);
            this.lbGelirGider.Name = "lbGelirGider";
            this.lbGelirGider.Size = new System.Drawing.Size(127, 20);
            this.lbGelirGider.TabIndex = 0;
            this.lbGelirGider.Text = "GELİR GİDER";
            // 
            // cmbOdemeTuru
            // 
            this.cmbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOdemeTuru.FormattingEnabled = true;
            this.cmbOdemeTuru.Items.AddRange(new object[] {
            "NAKİT",
            "KART",
            "KART - NAKİT"});
            this.cmbOdemeTuru.Location = new System.Drawing.Point(21, 72);
            this.cmbOdemeTuru.Name = "cmbOdemeTuru";
            this.cmbOdemeTuru.Size = new System.Drawing.Size(229, 28);
            this.cmbOdemeTuru.TabIndex = 2;
            this.cmbOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.cmbOdemeTuru_SelectedIndexChanged);
            // 
            // lbStandart2
            // 
            this.lbStandart2.AutoSize = true;
            this.lbStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart2.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbStandart2.Location = new System.Drawing.Point(21, 49);
            this.lbStandart2.Name = "lbStandart2";
            this.lbStandart2.Size = new System.Drawing.Size(107, 20);
            this.lbStandart2.TabIndex = 3;
            this.lbStandart2.Text = "Ödeme Türü";
            // 
            // txNakit
            // 
            this.txNakit.BackColor = System.Drawing.Color.White;
            this.txNakit.Enabled = false;
            this.txNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txNakit.Location = new System.Drawing.Point(21, 141);
            this.txNakit.Name = "txNakit";
            this.txNakit.Size = new System.Drawing.Size(106, 26);
            this.txNakit.TabIndex = 4;
            this.txNakit.Text = "0";
            this.txNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txKart
            // 
            this.txKart.BackColor = System.Drawing.Color.White;
            this.txKart.Enabled = false;
            this.txKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txKart.Location = new System.Drawing.Point(142, 140);
            this.txKart.Name = "txKart";
            this.txKart.Size = new System.Drawing.Size(108, 26);
            this.txKart.TabIndex = 5;
            this.txKart.Text = "0";
            this.txKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbStandart3
            // 
            this.lbStandart3.AutoSize = true;
            this.lbStandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart3.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbStandart3.Location = new System.Drawing.Point(21, 115);
            this.lbStandart3.Name = "lbStandart3";
            this.lbStandart3.Size = new System.Drawing.Size(50, 20);
            this.lbStandart3.TabIndex = 6;
            this.lbStandart3.Text = "Nakit";
            // 
            // lbStandart4
            // 
            this.lbStandart4.AutoSize = true;
            this.lbStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart4.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbStandart4.Location = new System.Drawing.Point(142, 114);
            this.lbStandart4.Name = "lbStandart4";
            this.lbStandart4.Size = new System.Drawing.Size(42, 20);
            this.lbStandart4.TabIndex = 7;
            this.lbStandart4.Text = "Kart";
            // 
            // txAciklama
            // 
            this.txAciklama.BackColor = System.Drawing.Color.White;
            this.txAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txAciklama.Location = new System.Drawing.Point(21, 206);
            this.txAciklama.Multiline = true;
            this.txAciklama.Name = "txAciklama";
            this.txAciklama.Size = new System.Drawing.Size(229, 139);
            this.txAciklama.TabIndex = 8;
            // 
            // lbStandart5
            // 
            this.lbStandart5.AutoSize = true;
            this.lbStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart5.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbStandart5.Location = new System.Drawing.Point(21, 183);
            this.lbStandart5.Name = "lbStandart5";
            this.lbStandart5.Size = new System.Drawing.Size(81, 20);
            this.lbStandart5.TabIndex = 9;
            this.lbStandart5.Text = "Açıklama";
            // 
            // dateTarih
            // 
            this.dateTarih.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTarih.Location = new System.Drawing.Point(21, 380);
            this.dateTarih.Name = "dateTarih";
            this.dateTarih.Size = new System.Drawing.Size(229, 26);
            this.dateTarih.TabIndex = 10;
            this.dateTarih.Value = new System.DateTime(2024, 4, 24, 0, 0, 0, 0);
            // 
            // lbStandart6
            // 
            this.lbStandart6.AutoSize = true;
            this.lbStandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart6.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbStandart6.Location = new System.Drawing.Point(21, 356);
            this.lbStandart6.Name = "lbStandart6";
            this.lbStandart6.Size = new System.Drawing.Size(49, 20);
            this.lbStandart6.TabIndex = 11;
            this.lbStandart6.Text = "Tarih";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEkle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.Image")));
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.Location = new System.Drawing.Point(80, 421);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(1);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(116, 60);
            this.btnEkle.TabIndex = 12;
            this.btnEkle.Text = " EKLE";
            this.btnEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // FormGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(280, 496);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lbStandart6);
            this.Controls.Add(this.dateTarih);
            this.Controls.Add(this.lbStandart5);
            this.Controls.Add(this.txAciklama);
            this.Controls.Add(this.lbStandart4);
            this.Controls.Add(this.lbStandart3);
            this.Controls.Add(this.txKart);
            this.Controls.Add(this.txNakit);
            this.Controls.Add(this.lbStandart2);
            this.Controls.Add(this.cmbOdemeTuru);
            this.Controls.Add(this.lbGelirGider);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(296, 535);
            this.MinimumSize = new System.Drawing.Size(296, 535);
            this.Name = "FormGelirGider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GELİR GİDER İŞLEMLERİ";
            this.Load += new System.EventHandler(this.FormGelirGider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lbStandart lbGelirGider;
        private System.Windows.Forms.ComboBox cmbOdemeTuru;
        private lbStandart lbStandart2;
        private txNumaratik txNakit;
        private txNumaratik txKart;
        private lbStandart lbStandart3;
        private lbStandart lbStandart4;
        private txStandart txAciklama;
        private lbStandart lbStandart5;
        private System.Windows.Forms.DateTimePicker dateTarih;
        private lbStandart lbStandart6;
        private btnStandart btnEkle;
    }
}