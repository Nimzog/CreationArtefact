namespace CreationArtefact
{
    partial class FormFacetteAugmentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacetteAugmentation));
            this.LabelPres = new System.Windows.Forms.Label();
            this.labelLBLPres = new System.Windows.Forms.Label();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.LabelPP = new System.Windows.Forms.Label();
            this.labelLBLNiveau = new System.Windows.Forms.Label();
            this.labelLBLPP = new System.Windows.Forms.Label();
            this.CheckBoxConfrontation = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ComboBoxSelectBonus = new System.Windows.Forms.ComboBox();
            this.ComboBoxSelectPouv = new System.Windows.Forms.ComboBox();
            this.LabelModificateur = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCompChamp = new System.Windows.Forms.Label();
            this.ComboBoxChampSec = new System.Windows.Forms.ComboBox();
            this.TextBoxCompetence = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelPres
            // 
            this.LabelPres.AutoSize = true;
            this.LabelPres.Location = new System.Drawing.Point(326, 68);
            this.LabelPres.Name = "LabelPres";
            this.LabelPres.Size = new System.Drawing.Size(22, 13);
            this.LabelPres.TabIndex = 76;
            this.LabelPres.Text = "NA";
            // 
            // labelLBLPres
            // 
            this.labelLBLPres.AutoSize = true;
            this.labelLBLPres.Location = new System.Drawing.Point(326, 28);
            this.labelLBLPres.Name = "labelLBLPres";
            this.labelLBLPres.Size = new System.Drawing.Size(52, 13);
            this.labelLBLPres.TabIndex = 75;
            this.labelLBLPres.Text = "Présence";
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(290, 68);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(22, 13);
            this.LabelNiveau.TabIndex = 74;
            this.LabelNiveau.Text = "NA";
            // 
            // LabelPP
            // 
            this.LabelPP.AutoSize = true;
            this.LabelPP.Location = new System.Drawing.Point(267, 68);
            this.LabelPP.Name = "LabelPP";
            this.LabelPP.Size = new System.Drawing.Size(22, 13);
            this.LabelPP.TabIndex = 73;
            this.LabelPP.Text = "NA";
            // 
            // labelLBLNiveau
            // 
            this.labelLBLNiveau.AutoSize = true;
            this.labelLBLNiveau.Location = new System.Drawing.Point(289, 28);
            this.labelLBLNiveau.Name = "labelLBLNiveau";
            this.labelLBLNiveau.Size = new System.Drawing.Size(41, 13);
            this.labelLBLNiveau.TabIndex = 72;
            this.labelLBLNiveau.Text = "Niveau";
            // 
            // labelLBLPP
            // 
            this.labelLBLPP.AutoSize = true;
            this.labelLBLPP.Location = new System.Drawing.Point(267, 28);
            this.labelLBLPP.Name = "labelLBLPP";
            this.labelLBLPP.Size = new System.Drawing.Size(21, 13);
            this.labelLBLPP.TabIndex = 71;
            this.labelLBLPP.Text = "PP";
            // 
            // CheckBoxConfrontation
            // 
            this.CheckBoxConfrontation.AutoSize = true;
            this.CheckBoxConfrontation.Enabled = false;
            this.CheckBoxConfrontation.Location = new System.Drawing.Point(15, 105);
            this.CheckBoxConfrontation.Name = "CheckBoxConfrontation";
            this.CheckBoxConfrontation.Size = new System.Drawing.Size(152, 17);
            this.CheckBoxConfrontation.TabIndex = 70;
            this.CheckBoxConfrontation.Text = "Confrontations uniquement";
            this.CheckBoxConfrontation.UseVisualStyleBackColor = true;
            this.CheckBoxConfrontation.Visible = false;
            this.CheckBoxConfrontation.CheckedChanged += new System.EventHandler(this.CheckBoxConfrontation_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(127, 191);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 23);
            this.buttonCancel.TabIndex = 69;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(10, 191);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(111, 23);
            this.ButtonSave.TabIndex = 68;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ComboBoxSelectBonus
            // 
            this.ComboBoxSelectBonus.Enabled = false;
            this.ComboBoxSelectBonus.FormattingEnabled = true;
            this.ComboBoxSelectBonus.Location = new System.Drawing.Point(12, 65);
            this.ComboBoxSelectBonus.Name = "ComboBoxSelectBonus";
            this.ComboBoxSelectBonus.Size = new System.Drawing.Size(249, 21);
            this.ComboBoxSelectBonus.TabIndex = 67;
            this.ComboBoxSelectBonus.Text = "Choisir...";
            this.ComboBoxSelectBonus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectBonus_SelectedIndexChanged);
            // 
            // ComboBoxSelectPouv
            // 
            this.ComboBoxSelectPouv.FormattingEnabled = true;
            this.ComboBoxSelectPouv.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxSelectPouv.Name = "ComboBoxSelectPouv";
            this.ComboBoxSelectPouv.Size = new System.Drawing.Size(249, 21);
            this.ComboBoxSelectPouv.TabIndex = 66;
            this.ComboBoxSelectPouv.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectPouv_SelectedIndexChanged);
            // 
            // LabelModificateur
            // 
            this.LabelModificateur.AutoSize = true;
            this.LabelModificateur.Location = new System.Drawing.Point(12, 89);
            this.LabelModificateur.Name = "LabelModificateur";
            this.LabelModificateur.Size = new System.Drawing.Size(65, 13);
            this.LabelModificateur.TabIndex = 65;
            this.LabelModificateur.Text = "Modificateur";
            this.LabelModificateur.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Selectionnez le bonus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Selectionnez le bonus";
            // 
            // LabelCompChamp
            // 
            this.LabelCompChamp.AutoSize = true;
            this.LabelCompChamp.Location = new System.Drawing.Point(12, 89);
            this.LabelCompChamp.Name = "LabelCompChamp";
            this.LabelCompChamp.Size = new System.Drawing.Size(160, 13);
            this.LabelCompChamp.TabIndex = 77;
            this.LabelCompChamp.Text = "Compétence/Champ secondaire";
            this.LabelCompChamp.Visible = false;
            // 
            // ComboBoxChampSec
            // 
            this.ComboBoxChampSec.Enabled = false;
            this.ComboBoxChampSec.FormattingEnabled = true;
            this.ComboBoxChampSec.Location = new System.Drawing.Point(15, 105);
            this.ComboBoxChampSec.Name = "ComboBoxChampSec";
            this.ComboBoxChampSec.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxChampSec.TabIndex = 78;
            this.ComboBoxChampSec.Visible = false;
            this.ComboBoxChampSec.SelectedIndexChanged += new System.EventHandler(this.ComboBoxChampSec_SelectedIndexChanged);
            // 
            // TextBoxCompetence
            // 
            this.TextBoxCompetence.Enabled = false;
            this.TextBoxCompetence.Location = new System.Drawing.Point(15, 105);
            this.TextBoxCompetence.Name = "TextBoxCompetence";
            this.TextBoxCompetence.Size = new System.Drawing.Size(121, 20);
            this.TextBoxCompetence.TabIndex = 79;
            this.TextBoxCompetence.Visible = false;
            // 
            // FormFacetteAugmentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 238);
            this.Controls.Add(this.LabelCompChamp);
            this.Controls.Add(this.LabelPres);
            this.Controls.Add(this.labelLBLPres);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelPP);
            this.Controls.Add(this.labelLBLNiveau);
            this.Controls.Add(this.labelLBLPP);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ComboBoxSelectBonus);
            this.Controls.Add(this.ComboBoxSelectPouv);
            this.Controls.Add(this.LabelModificateur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxChampSec);
            this.Controls.Add(this.CheckBoxConfrontation);
            this.Controls.Add(this.TextBoxCompetence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFacetteAugmentation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facette d\'augmentation";
            this.Load += new System.EventHandler(this.FormFacetteAugmentation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelPres;
        private System.Windows.Forms.Label labelLBLPres;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Label LabelPP;
        private System.Windows.Forms.Label labelLBLNiveau;
        private System.Windows.Forms.Label labelLBLPP;
        private System.Windows.Forms.CheckBox CheckBoxConfrontation;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox ComboBoxSelectBonus;
        private System.Windows.Forms.ComboBox ComboBoxSelectPouv;
        private System.Windows.Forms.Label LabelModificateur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCompChamp;
        private System.Windows.Forms.ComboBox ComboBoxChampSec;
        private System.Windows.Forms.TextBox TextBoxCompetence;
    }
}