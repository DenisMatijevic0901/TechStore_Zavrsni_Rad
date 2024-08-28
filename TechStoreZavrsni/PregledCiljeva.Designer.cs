namespace TechStoreZavrsni
{
    partial class PregledCiljeva
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
            this.dgvGoals = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.btnNazad = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetdecimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualdecimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGoals
            // 
            this.dgvGoals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.targetdecimal,
            this.actualdecimal,
            this.percentage,
            this.status,
            this.goalid});
            this.dgvGoals.Location = new System.Drawing.Point(57, 71);
            this.dgvGoals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGoals.Name = "dgvGoals";
            this.dgvGoals.RowHeadersWidth = 51;
            this.dgvGoals.Size = new System.Drawing.Size(737, 224);
            this.dgvGoals.TabIndex = 23;
            this.dgvGoals.SelectionChanged += new System.EventHandler(this.dgvGoals_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(564, 362);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Unesi cilj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(695, 362);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Obriši";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.Controls.Add(this.pictureBox1);
            this.panel.Controls.Add(this.label10);
            this.panel.Location = new System.Drawing.Point(-3, 4);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1072, 44);
            this.panel.TabIndex = 25;
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
            this.label10.Size = new System.Drawing.Size(214, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tech Store I Pregled ciljeva";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(351, 454);
            this.tbID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(132, 22);
            this.tbID.TabIndex = 24;
            this.tbID.Visible = false;
            // 
            // btnNazad
            // 
            this.btnNazad.Location = new System.Drawing.Point(57, 362);
            this.btnNazad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(100, 28);
            this.btnNazad.TabIndex = 27;
            this.btnNazad.Text = "Nazad";
            this.btnNazad.UseVisualStyleBackColor = true;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // name
            // 
            this.name.HeaderText = "Naziv";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // targetdecimal
            // 
            this.targetdecimal.HeaderText = "Cilj";
            this.targetdecimal.MinimumWidth = 6;
            this.targetdecimal.Name = "targetdecimal";
            this.targetdecimal.ReadOnly = true;
            this.targetdecimal.Width = 75;
            // 
            // actualdecimal
            // 
            this.actualdecimal.HeaderText = "Ostvareno";
            this.actualdecimal.MinimumWidth = 6;
            this.actualdecimal.Name = "actualdecimal";
            this.actualdecimal.ReadOnly = true;
            this.actualdecimal.Width = 125;
            // 
            // percentage
            // 
            this.percentage.HeaderText = "Postotak izvršenosti";
            this.percentage.MinimumWidth = 6;
            this.percentage.Name = "percentage";
            this.percentage.ReadOnly = true;
            this.percentage.Width = 85;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 75;
            // 
            // goalid
            // 
            this.goalid.HeaderText = "Id";
            this.goalid.MinimumWidth = 6;
            this.goalid.Name = "goalid";
            this.goalid.ReadOnly = true;
            this.goalid.Visible = false;
            this.goalid.Width = 125;
            // 
            // PregledCiljeva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 421);
            this.Controls.Add(this.dgvGoals);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNazad);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PregledCiljeva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tech Store";
            this.Load += new System.EventHandler(this.PregledCiljeva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoals)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoals;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Button btnNazad;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetdecimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualdecimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalid;
    }
}