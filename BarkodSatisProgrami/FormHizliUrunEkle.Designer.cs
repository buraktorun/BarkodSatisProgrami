namespace BarkodSatisProgrami
{
    partial class FormHizliUrunEkle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHizliUrunEkle));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lbBtnNo = new System.Windows.Forms.Label();
            this.cbTumunuGetir = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txUrunArama = new System.Windows.Forms.TextBox();
            this.gridUrunListesi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbBtnNo);
            this.splitContainer1.Panel1.Controls.Add(this.cbTumunuGetir);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txUrunArama);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridUrunListesi);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buton Numarası:";
            // 
            // lbBtnNo
            // 
            this.lbBtnNo.AutoSize = true;
            this.lbBtnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBtnNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbBtnNo.Location = new System.Drawing.Point(154, 9);
            this.lbBtnNo.Name = "lbBtnNo";
            this.lbBtnNo.Size = new System.Drawing.Size(84, 20);
            this.lbBtnNo.TabIndex = 7;
            this.lbBtnNo.Text = "Buton No";
            // 
            // cbTumunuGetir
            // 
            this.cbTumunuGetir.AutoSize = true;
            this.cbTumunuGetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTumunuGetir.ForeColor = System.Drawing.Color.SteelBlue;
            this.cbTumunuGetir.Location = new System.Drawing.Point(428, 62);
            this.cbTumunuGetir.Name = "cbTumunuGetir";
            this.cbTumunuGetir.Size = new System.Drawing.Size(152, 24);
            this.cbTumunuGetir.TabIndex = 6;
            this.cbTumunuGetir.Text = "Tümünü Göster";
            this.cbTumunuGetir.UseVisualStyleBackColor = true;
            this.cbTumunuGetir.CheckedChanged += new System.EventHandler(this.cbTumunuGetir_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(16, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ürün Ara";
            // 
            // txUrunArama
            // 
            this.txUrunArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txUrunArama.Location = new System.Drawing.Point(16, 61);
            this.txUrunArama.Name = "txUrunArama";
            this.txUrunArama.Size = new System.Drawing.Size(395, 26);
            this.txUrunArama.TabIndex = 4;
            this.txUrunArama.TextChanged += new System.EventHandler(this.txUrunArama_TextChanged);
            // 
            // gridUrunListesi
            // 
            this.gridUrunListesi.AllowUserToAddRows = false;
            this.gridUrunListesi.AllowUserToDeleteRows = false;
            this.gridUrunListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUrunListesi.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridUrunListesi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUrunListesi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUrunListesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUrunListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUrunListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUrunListesi.EnableHeadersVisualStyles = false;
            this.gridUrunListesi.Location = new System.Drawing.Point(0, 0);
            this.gridUrunListesi.Name = "gridUrunListesi";
            this.gridUrunListesi.ReadOnly = true;
            this.gridUrunListesi.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            this.gridUrunListesi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUrunListesi.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.gridUrunListesi.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridUrunListesi.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridUrunListesi.RowTemplate.Height = 32;
            this.gridUrunListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUrunListesi.Size = new System.Drawing.Size(800, 351);
            this.gridUrunListesi.TabIndex = 2;
            this.gridUrunListesi.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUrunListesi_CellContentDoubleClick);
            // 
            // FormHizliUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHizliUrunEkle";
            this.Text = "HIZLI ÜRÜN EKLEME";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUrunListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridUrunListesi;
        private System.Windows.Forms.CheckBox cbTumunuGetir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txUrunArama;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbBtnNo;
    }
}