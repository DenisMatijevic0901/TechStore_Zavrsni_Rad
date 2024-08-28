namespace TechStoreZavrsni
{
    partial class PocetnaForma
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
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnProizvod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNarudzba = new System.Windows.Forms.Button();
            this.btnKupnja = new System.Windows.Forms.Button();
            this.btnGoal = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnFakture = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.Controls.Add(this.pictureBox1);
            this.panel.Controls.Add(this.label10);
            this.panel.Location = new System.Drawing.Point(-3, -2);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1084, 46);
            this.panel.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TechStoreZavrsni.Properties.Resources.Screenshot_2_removebg_preview;
            this.pictureBox1.Image = global::TechStoreZavrsni.Properties.Resources.techstore;
            this.pictureBox1.Location = new System.Drawing.Point(19, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(72, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tech Store I Početna";
            // 
            // btnProizvod
            // 
            this.btnProizvod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProizvod.Location = new System.Drawing.Point(371, 366);
            this.btnProizvod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProizvod.Name = "btnProizvod";
            this.btnProizvod.Size = new System.Drawing.Size(331, 39);
            this.btnProizvod.TabIndex = 22;
            this.btnProizvod.Text = "Pregled proizvoda";
            this.btnProizvod.UseVisualStyleBackColor = true;
            this.btnProizvod.Click += new System.EventHandler(this.btnProizvod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(492, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 67);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tech Store";
            // 
            // btnNarudzba
            // 
            this.btnNarudzba.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNarudzba.Location = new System.Drawing.Point(371, 427);
            this.btnNarudzba.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNarudzba.Name = "btnNarudzba";
            this.btnNarudzba.Size = new System.Drawing.Size(331, 39);
            this.btnNarudzba.TabIndex = 23;
            this.btnNarudzba.Text = "Pregled narudžbi";
            this.btnNarudzba.UseVisualStyleBackColor = true;
            this.btnNarudzba.Click += new System.EventHandler(this.btnNarudzba_Click);
            // 
            // btnKupnja
            // 
            this.btnKupnja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKupnja.Location = new System.Drawing.Point(371, 304);
            this.btnKupnja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKupnja.Name = "btnKupnja";
            this.btnKupnja.Size = new System.Drawing.Size(331, 39);
            this.btnKupnja.TabIndex = 24;
            this.btnKupnja.Text = "Kupnja proizvoda";
            this.btnKupnja.UseVisualStyleBackColor = true;
            this.btnKupnja.Click += new System.EventHandler(this.btnKupnja_Click);
            // 
            // btnGoal
            // 
            this.btnGoal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoal.Location = new System.Drawing.Point(371, 552);
            this.btnGoal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGoal.Name = "btnGoal";
            this.btnGoal.Size = new System.Drawing.Size(331, 39);
            this.btnGoal.TabIndex = 25;
            this.btnGoal.Text = "Pregled ciljeva";
            this.btnGoal.UseVisualStyleBackColor = true;
            this.btnGoal.Click += new System.EventHandler(this.btnGoal_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TechStoreZavrsni.Properties.Resources.Screenshot_2_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(305, 76);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(179, 187);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnFakture
            // 
            this.btnFakture.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFakture.Location = new System.Drawing.Point(371, 492);
            this.btnFakture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFakture.Name = "btnFakture";
            this.btnFakture.Size = new System.Drawing.Size(331, 39);
            this.btnFakture.TabIndex = 26;
            this.btnFakture.Text = "Pregled faktura";
            this.btnFakture.UseVisualStyleBackColor = true;
            this.btnFakture.Click += new System.EventHandler(this.btnFakture_Click);
            // 
            // PocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 630);
            this.Controls.Add(this.btnFakture);
            this.Controls.Add(this.btnGoal);
            this.Controls.Add(this.btnKupnja);
            this.Controls.Add(this.btnNarudzba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnProizvod);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PocetnaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tech Store";
            this.Load += new System.EventHandler(this.PocetnaForma_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnProizvod;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNarudzba;
        private System.Windows.Forms.Button btnKupnja;
        private System.Windows.Forms.Button btnGoal;
        private System.Windows.Forms.Button btnFakture;
    }
}