namespace BarkodSatisProgrami
{
    partial class FormLisans
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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txLisansNo = new System.Windows.Forms.TextBox();
            this.lbStandart2 = new BarkodSatisProgrami.lbStandart();
            this.lbLisansNo = new BarkodSatisProgrami.lbStandart();
            this.btnTamam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(345, 59);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(26, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 47);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lisans Etkinleştirme";
            // 
            // txLisansNo
            // 
            this.txLisansNo.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txLisansNo.Location = new System.Drawing.Point(66, 127);
            this.txLisansNo.Multiline = true;
            this.txLisansNo.Name = "txLisansNo";
            this.txLisansNo.Size = new System.Drawing.Size(217, 32);
            this.txLisansNo.TabIndex = 7;
            // 
            // lbStandart2
            // 
            this.lbStandart2.AutoSize = true;
            this.lbStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStandart2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbStandart2.Location = new System.Drawing.Point(44, 85);
            this.lbStandart2.Name = "lbStandart2";
            this.lbStandart2.Size = new System.Drawing.Size(102, 20);
            this.lbStandart2.TabIndex = 4;
            this.lbStandart2.Text = "Kullanıcı No";
            // 
            // lbLisansNo
            // 
            this.lbLisansNo.AutoSize = true;
            this.lbLisansNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbLisansNo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbLisansNo.Location = new System.Drawing.Point(180, 85);
            this.lbLisansNo.Name = "lbLisansNo";
            this.lbLisansNo.Size = new System.Drawing.Size(103, 20);
            this.lbLisansNo.TabIndex = 3;
            this.lbLisansNo.Text = "lbStandart1";
            // 
            // btnTamam
            // 
            this.btnTamam.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTamam.FlatAppearance.BorderSize = 0;
            this.btnTamam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamam.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTamam.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTamam.Location = new System.Drawing.Point(118, 181);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(97, 50);
            this.btnTamam.TabIndex = 8;
            this.btnTamam.Text = "ONAYLA";
            this.btnTamam.UseVisualStyleBackColor = false;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // FormLisans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(345, 257);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.txLisansNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbStandart2);
            this.Controls.Add(this.lbLisansNo);
            this.Name = "FormLisans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private lbStandart lbStandart2;
        internal lbStandart lbLisansNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txLisansNo;
        private System.Windows.Forms.Button btnTamam;
    }
}