namespace CreationArtefact
{
    partial class FormFacetteQualite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacetteQualite));
            this.labelSelectPouvoir = new System.Windows.Forms.Label();
            this.labelSelectBonus = new System.Windows.Forms.Label();
            this.ComboBoxSelectPouvoir = new System.Windows.Forms.ComboBox();
            this.ComboBoxSelectBonus = new System.Windows.Forms.ComboBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLBLPP = new System.Windows.Forms.Label();
            this.labelLBLNiveau = new System.Windows.Forms.Label();
            this.LabelPP = new System.Windows.Forms.Label();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.labelLBLPres = new System.Windows.Forms.Label();
            this.LabelPres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSelectPouvoir
            // 
            this.labelSelectPouvoir.AutoSize = true;
            this.labelSelectPouvoir.Location = new System.Drawing.Point(12, 9);
            this.labelSelectPouvoir.Name = "labelSelectPouvoir";
            this.labelSelectPouvoir.Size = new System.Drawing.Size(117, 13);
            this.labelSelectPouvoir.TabIndex = 0;
            this.labelSelectPouvoir.Text = "Sélectionnez le pouvoir";
            // 
            // labelSelectBonus
            // 
            this.labelSelectBonus.AutoSize = true;
            this.labelSelectBonus.Location = new System.Drawing.Point(12, 49);
            this.labelSelectBonus.Name = "labelSelectBonus";
            this.labelSelectBonus.Size = new System.Drawing.Size(111, 13);
            this.labelSelectBonus.TabIndex = 1;
            this.labelSelectBonus.Text = "Sélectionnez le bonus";
            // 
            // ComboBoxSelectPouvoir
            // 
            this.ComboBoxSelectPouvoir.FormattingEnabled = true;
            this.ComboBoxSelectPouvoir.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxSelectPouvoir.Name = "ComboBoxSelectPouvoir";
            this.ComboBoxSelectPouvoir.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxSelectPouvoir.TabIndex = 2;
            this.ComboBoxSelectPouvoir.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectPouvoir_SelectedIndexChanged);
            // 
            // ComboBoxSelectBonus
            // 
            this.ComboBoxSelectBonus.Enabled = false;
            this.ComboBoxSelectBonus.FormattingEnabled = true;
            this.ComboBoxSelectBonus.Location = new System.Drawing.Point(12, 65);
            this.ComboBoxSelectBonus.Name = "ComboBoxSelectBonus";
            this.ComboBoxSelectBonus.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxSelectBonus.TabIndex = 3;
            this.ComboBoxSelectBonus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectBonus_SelectedIndexChanged);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(12, 92);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(121, 23);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(139, 92);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelLBLPP
            // 
            this.labelLBLPP.AutoSize = true;
            this.labelLBLPP.Location = new System.Drawing.Point(139, 28);
            this.labelLBLPP.Name = "labelLBLPP";
            this.labelLBLPP.Size = new System.Drawing.Size(21, 13);
            this.labelLBLPP.TabIndex = 6;
            this.labelLBLPP.Text = "PP";
            // 
            // labelLBLNiveau
            // 
            this.labelLBLNiveau.AutoSize = true;
            this.labelLBLNiveau.Location = new System.Drawing.Point(172, 28);
            this.labelLBLNiveau.Name = "labelLBLNiveau";
            this.labelLBLNiveau.Size = new System.Drawing.Size(41, 13);
            this.labelLBLNiveau.TabIndex = 7;
            this.labelLBLNiveau.Text = "Niveau";
            // 
            // LabelPP
            // 
            this.LabelPP.AutoSize = true;
            this.LabelPP.Location = new System.Drawing.Point(139, 68);
            this.LabelPP.Name = "LabelPP";
            this.LabelPP.Size = new System.Drawing.Size(22, 13);
            this.LabelPP.TabIndex = 8;
            this.LabelPP.Text = "NA";
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(173, 68);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(22, 13);
            this.LabelNiveau.TabIndex = 9;
            this.LabelNiveau.Text = "NA";
            // 
            // labelLBLPres
            // 
            this.labelLBLPres.AutoSize = true;
            this.labelLBLPres.Location = new System.Drawing.Point(219, 28);
            this.labelLBLPres.Name = "labelLBLPres";
            this.labelLBLPres.Size = new System.Drawing.Size(52, 13);
            this.labelLBLPres.TabIndex = 10;
            this.labelLBLPres.Text = "Présence";
            // 
            // LabelPres
            // 
            this.LabelPres.AutoSize = true;
            this.LabelPres.Location = new System.Drawing.Point(219, 68);
            this.LabelPres.Name = "LabelPres";
            this.LabelPres.Size = new System.Drawing.Size(22, 13);
            this.LabelPres.TabIndex = 11;
            this.LabelPres.Text = "NA";
            // 
            // FormFacetteQualite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 126);
            this.Controls.Add(this.LabelPres);
            this.Controls.Add(this.labelLBLPres);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelPP);
            this.Controls.Add(this.labelLBLNiveau);
            this.Controls.Add(this.labelLBLPP);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ComboBoxSelectBonus);
            this.Controls.Add(this.ComboBoxSelectPouvoir);
            this.Controls.Add(this.labelSelectBonus);
            this.Controls.Add(this.labelSelectPouvoir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFacetteQualite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facette générale de qualité";
            this.Load += new System.EventHandler(this.FormFacetteQualite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectPouvoir;
        private System.Windows.Forms.Label labelSelectBonus;
        private System.Windows.Forms.ComboBox ComboBoxSelectPouvoir;
        private System.Windows.Forms.ComboBox ComboBoxSelectBonus;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelLBLPP;
        private System.Windows.Forms.Label labelLBLNiveau;
        private System.Windows.Forms.Label LabelPP;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Label labelLBLPres;
        private System.Windows.Forms.Label LabelPres;
    }
}