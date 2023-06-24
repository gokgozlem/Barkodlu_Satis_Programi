namespace Barkodlu_Satis_Programi
{
    partial class fUrunGrubuEkle
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
            this.listUrunGrup = new System.Windows.Forms.ListBox();
            this.bStandart1 = new Barkodlu_Satis_Programi.bStandart();
            this.txtUrunGrubuAdi = new Barkodlu_Satis_Programi.tStandart();
            this.lStandart1 = new Barkodlu_Satis_Programi.lStandart();
            this.bSil = new Barkodlu_Satis_Programi.bStandart();
            this.SuspendLayout();
            // 
            // listUrunGrup
            // 
            this.listUrunGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listUrunGrup.FormattingEnabled = true;
            this.listUrunGrup.ItemHeight = 25;
            this.listUrunGrup.Location = new System.Drawing.Point(29, 84);
            this.listUrunGrup.Name = "listUrunGrup";
            this.listUrunGrup.Size = new System.Drawing.Size(250, 179);
            this.listUrunGrup.TabIndex = 2;
            // 
            // bStandart1
            // 
            this.bStandart1.BackColor = System.Drawing.Color.SeaGreen;
            this.bStandart1.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.bStandart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bStandart1.ForeColor = System.Drawing.Color.White;
            this.bStandart1.Location = new System.Drawing.Point(159, 272);
            this.bStandart1.Margin = new System.Windows.Forms.Padding(1);
            this.bStandart1.Name = "bStandart1";
            this.bStandart1.Size = new System.Drawing.Size(120, 68);
            this.bStandart1.TabIndex = 0;
            this.bStandart1.Text = "Ekle";
            this.bStandart1.UseVisualStyleBackColor = false;
            this.bStandart1.Click += new System.EventHandler(this.bStandart1_Click);
            // 
            // txtUrunGrubuAdi
            // 
            this.txtUrunGrubuAdi.BackColor = System.Drawing.Color.White;
            this.txtUrunGrubuAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUrunGrubuAdi.Location = new System.Drawing.Point(29, 52);
            this.txtUrunGrubuAdi.Name = "txtUrunGrubuAdi";
            this.txtUrunGrubuAdi.Size = new System.Drawing.Size(250, 30);
            this.txtUrunGrubuAdi.TabIndex = 1;
            // 
            // lStandart1
            // 
            this.lStandart1.AutoSize = true;
            this.lStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart1.ForeColor = System.Drawing.Color.Black;
            this.lStandart1.Location = new System.Drawing.Point(25, 29);
            this.lStandart1.Name = "lStandart1";
            this.lStandart1.Size = new System.Drawing.Size(158, 25);
            this.lStandart1.TabIndex = 0;
            this.lStandart1.Text = "Ürün Grubu Adı :";
            // 
            // bSil
            // 
            this.bSil.BackColor = System.Drawing.Color.LightSlateGray;
            this.bSil.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.bSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSil.ForeColor = System.Drawing.Color.White;
            this.bSil.Location = new System.Drawing.Point(29, 272);
            this.bSil.Margin = new System.Windows.Forms.Padding(1);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(124, 68);
            this.bSil.TabIndex = 0;
            this.bSil.Text = "Sil";
            this.bSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSil.UseVisualStyleBackColor = false;
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // fUrunGrubuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(305, 367);
            this.Controls.Add(this.bSil);
            this.Controls.Add(this.bStandart1);
            this.Controls.Add(this.listUrunGrup);
            this.Controls.Add(this.txtUrunGrubuAdi);
            this.Controls.Add(this.lStandart1);
            this.Name = "fUrunGrubuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Grubu İşlemleri";
            this.Load += new System.EventHandler(this.fUrunGrubuEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lStandart lStandart1;
        private tStandart txtUrunGrubuAdi;
        private System.Windows.Forms.ListBox listUrunGrup;
        private bStandart bStandart1;
        private bStandart bSil;
    }
}