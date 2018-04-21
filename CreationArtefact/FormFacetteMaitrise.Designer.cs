namespace CreationArtefact
{
    partial class FormFacetteMaitrise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacetteMaitrise));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CheckBoxIllimite = new System.Windows.Forms.CheckBox();
            this.NumericUpDownUtilisation = new System.Windows.Forms.NumericUpDown();
            this.LabelUtilisation = new System.Windows.Forms.Label();
            this.labelLBLPres = new System.Windows.Forms.Label();
            this.LabelPP = new System.Windows.Forms.Label();
            this.labelLBLNiveau = new System.Windows.Forms.Label();
            this.labelLBLPP = new System.Windows.Forms.Label();
            this.ComboBoxSelectBonus = new System.Windows.Forms.ComboBox();
            this.ComboBoxSelectPouv = new System.Windows.Forms.ComboBox();
            this.LabelModificateur = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxConsomation = new System.Windows.Forms.CheckBox();
            this.CheckBoxModRecharge = new System.Windows.Forms.CheckBox();
            this.CheckBoxModFiltre = new System.Windows.Forms.CheckBox();
            this.CheckBoxModFuite = new System.Windows.Forms.CheckBox();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.LabelPres = new System.Windows.Forms.Label();
            this.LabelCarac = new System.Windows.Forms.Label();
            this.ComboBoxCarac = new System.Windows.Forms.ComboBox();
            this.NumericUpDownPrep = new System.Windows.Forms.NumericUpDown();
            this.LabelPrep = new System.Windows.Forms.Label();
            this.TextBoxNomTech = new System.Windows.Forms.TextBox();
            this.LabelNom = new System.Windows.Forms.Label();
            this.LabelDI = new System.Windows.Forms.Label();
            this.NumericUpDownDI = new System.Windows.Forms.NumericUpDown();
            this.RadioButtonAucune = new System.Windows.Forms.RadioButton();
            this.RadioButtonBadRecup = new System.Windows.Forms.RadioButton();
            this.RadioButtonRecupOnly = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownUtilisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPrep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDI)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(132, 228);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 23);
            this.buttonCancel.TabIndex = 103;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(15, 228);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(111, 23);
            this.ButtonSave.TabIndex = 102;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CheckBoxIllimite
            // 
            this.CheckBoxIllimite.AutoSize = true;
            this.CheckBoxIllimite.Enabled = false;
            this.CheckBoxIllimite.Location = new System.Drawing.Point(187, 129);
            this.CheckBoxIllimite.Name = "CheckBoxIllimite";
            this.CheckBoxIllimite.Size = new System.Drawing.Size(54, 17);
            this.CheckBoxIllimite.TabIndex = 98;
            this.CheckBoxIllimite.Text = "Illimité";
            this.CheckBoxIllimite.UseVisualStyleBackColor = true;
            this.CheckBoxIllimite.Visible = false;
            this.CheckBoxIllimite.CheckedChanged += new System.EventHandler(this.CheckBoxIllimite_CheckedChanged);
            // 
            // NumericUpDownUtilisation
            // 
            this.NumericUpDownUtilisation.Enabled = false;
            this.NumericUpDownUtilisation.Location = new System.Drawing.Point(120, 127);
            this.NumericUpDownUtilisation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDownUtilisation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownUtilisation.Name = "NumericUpDownUtilisation";
            this.NumericUpDownUtilisation.Size = new System.Drawing.Size(61, 20);
            this.NumericUpDownUtilisation.TabIndex = 97;
            this.NumericUpDownUtilisation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownUtilisation.Visible = false;
            this.NumericUpDownUtilisation.ValueChanged += new System.EventHandler(this.NumericUpDownUtilisation_ValueChanged);
            // 
            // LabelUtilisation
            // 
            this.LabelUtilisation.AutoSize = true;
            this.LabelUtilisation.Location = new System.Drawing.Point(13, 129);
            this.LabelUtilisation.Name = "LabelUtilisation";
            this.LabelUtilisation.Size = new System.Drawing.Size(101, 13);
            this.LabelUtilisation.TabIndex = 96;
            this.LabelUtilisation.Text = "Nombre d\'utilistation";
            this.LabelUtilisation.Visible = false;
            // 
            // labelLBLPres
            // 
            this.labelLBLPres.AutoSize = true;
            this.labelLBLPres.Location = new System.Drawing.Point(323, 9);
            this.labelLBLPres.Name = "labelLBLPres";
            this.labelLBLPres.Size = new System.Drawing.Size(52, 13);
            this.labelLBLPres.TabIndex = 111;
            this.labelLBLPres.Text = "Présence";
            // 
            // LabelPP
            // 
            this.LabelPP.AutoSize = true;
            this.LabelPP.Location = new System.Drawing.Point(243, 49);
            this.LabelPP.Name = "LabelPP";
            this.LabelPP.Size = new System.Drawing.Size(22, 13);
            this.LabelPP.TabIndex = 109;
            this.LabelPP.Text = "NA";
            // 
            // labelLBLNiveau
            // 
            this.labelLBLNiveau.AutoSize = true;
            this.labelLBLNiveau.Location = new System.Drawing.Point(276, 9);
            this.labelLBLNiveau.Name = "labelLBLNiveau";
            this.labelLBLNiveau.Size = new System.Drawing.Size(41, 13);
            this.labelLBLNiveau.TabIndex = 108;
            this.labelLBLNiveau.Text = "Niveau";
            // 
            // labelLBLPP
            // 
            this.labelLBLPP.AutoSize = true;
            this.labelLBLPP.Location = new System.Drawing.Point(243, 9);
            this.labelLBLPP.Name = "labelLBLPP";
            this.labelLBLPP.Size = new System.Drawing.Size(21, 13);
            this.labelLBLPP.TabIndex = 107;
            this.labelLBLPP.Text = "PP";
            // 
            // ComboBoxSelectBonus
            // 
            this.ComboBoxSelectBonus.Enabled = false;
            this.ComboBoxSelectBonus.FormattingEnabled = true;
            this.ComboBoxSelectBonus.Location = new System.Drawing.Point(12, 65);
            this.ComboBoxSelectBonus.Name = "ComboBoxSelectBonus";
            this.ComboBoxSelectBonus.Size = new System.Drawing.Size(228, 21);
            this.ComboBoxSelectBonus.TabIndex = 93;
            this.ComboBoxSelectBonus.Text = "Choisir...";
            this.ComboBoxSelectBonus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectBonus_SelectedIndexChanged);
            // 
            // ComboBoxSelectPouv
            // 
            this.ComboBoxSelectPouv.FormattingEnabled = true;
            this.ComboBoxSelectPouv.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxSelectPouv.Name = "ComboBoxSelectPouv";
            this.ComboBoxSelectPouv.Size = new System.Drawing.Size(228, 21);
            this.ComboBoxSelectPouv.TabIndex = 92;
            this.ComboBoxSelectPouv.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectPouv_SelectedIndexChanged);
            // 
            // LabelModificateur
            // 
            this.LabelModificateur.AutoSize = true;
            this.LabelModificateur.Location = new System.Drawing.Point(12, 89);
            this.LabelModificateur.Name = "LabelModificateur";
            this.LabelModificateur.Size = new System.Drawing.Size(65, 13);
            this.LabelModificateur.TabIndex = 106;
            this.LabelModificateur.Text = "Modificateur";
            this.LabelModificateur.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Selectionnez le bonus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Selectionnez le bonus";
            // 
            // CheckBoxConsomation
            // 
            this.CheckBoxConsomation.AutoSize = true;
            this.CheckBoxConsomation.Enabled = false;
            this.CheckBoxConsomation.Location = new System.Drawing.Point(15, 195);
            this.CheckBoxConsomation.Name = "CheckBoxConsomation";
            this.CheckBoxConsomation.Size = new System.Drawing.Size(124, 17);
            this.CheckBoxConsomation.TabIndex = 119;
            this.CheckBoxConsomation.Text = "Comsommation de Ki";
            this.CheckBoxConsomation.UseVisualStyleBackColor = true;
            this.CheckBoxConsomation.Visible = false;
            this.CheckBoxConsomation.CheckedChanged += new System.EventHandler(this.CheckBoxConsomation_CheckedChanged);
            // 
            // CheckBoxModRecharge
            // 
            this.CheckBoxModRecharge.AutoSize = true;
            this.CheckBoxModRecharge.Enabled = false;
            this.CheckBoxModRecharge.Location = new System.Drawing.Point(15, 151);
            this.CheckBoxModRecharge.Name = "CheckBoxModRecharge";
            this.CheckBoxModRecharge.Size = new System.Drawing.Size(108, 17);
            this.CheckBoxModRecharge.TabIndex = 118;
            this.CheckBoxModRecharge.Text = "Recharge réduite";
            this.CheckBoxModRecharge.UseVisualStyleBackColor = true;
            this.CheckBoxModRecharge.Visible = false;
            this.CheckBoxModRecharge.CheckedChanged += new System.EventHandler(this.CheckBoxModRecharge_CheckedChanged);
            // 
            // CheckBoxModFiltre
            // 
            this.CheckBoxModFiltre.AutoSize = true;
            this.CheckBoxModFiltre.Location = new System.Drawing.Point(15, 128);
            this.CheckBoxModFiltre.Name = "CheckBoxModFiltre";
            this.CheckBoxModFiltre.Size = new System.Drawing.Size(111, 17);
            this.CheckBoxModFiltre.TabIndex = 117;
            this.CheckBoxModFiltre.Text = "Filtre affaiblisssant";
            this.CheckBoxModFiltre.UseVisualStyleBackColor = true;
            this.CheckBoxModFiltre.Visible = false;
            this.CheckBoxModFiltre.CheckedChanged += new System.EventHandler(this.CheckBoxModFiltre_CheckedChanged);
            // 
            // CheckBoxModFuite
            // 
            this.CheckBoxModFuite.AutoSize = true;
            this.CheckBoxModFuite.Enabled = false;
            this.CheckBoxModFuite.Location = new System.Drawing.Point(15, 105);
            this.CheckBoxModFuite.Name = "CheckBoxModFuite";
            this.CheckBoxModFuite.Size = new System.Drawing.Size(102, 17);
            this.CheckBoxModFuite.TabIndex = 116;
            this.CheckBoxModFuite.Text = "Fuite de pouvoir";
            this.CheckBoxModFuite.UseVisualStyleBackColor = true;
            this.CheckBoxModFuite.Visible = false;
            this.CheckBoxModFuite.CheckedChanged += new System.EventHandler(this.CheckBoxModfuite_CheckedChanged);
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(277, 49);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(22, 13);
            this.LabelNiveau.TabIndex = 110;
            this.LabelNiveau.Text = "NA";
            // 
            // LabelPres
            // 
            this.LabelPres.AutoSize = true;
            this.LabelPres.Location = new System.Drawing.Point(323, 49);
            this.LabelPres.Name = "LabelPres";
            this.LabelPres.Size = new System.Drawing.Size(22, 13);
            this.LabelPres.TabIndex = 112;
            this.LabelPres.Text = "NA";
            // 
            // LabelCarac
            // 
            this.LabelCarac.AutoSize = true;
            this.LabelCarac.Location = new System.Drawing.Point(13, 106);
            this.LabelCarac.Name = "LabelCarac";
            this.LabelCarac.Size = new System.Drawing.Size(77, 13);
            this.LabelCarac.TabIndex = 121;
            this.LabelCarac.Text = "Caractéristique";
            this.LabelCarac.Visible = false;
            // 
            // ComboBoxCarac
            // 
            this.ComboBoxCarac.Enabled = false;
            this.ComboBoxCarac.FormattingEnabled = true;
            this.ComboBoxCarac.Location = new System.Drawing.Point(95, 103);
            this.ComboBoxCarac.Name = "ComboBoxCarac";
            this.ComboBoxCarac.Size = new System.Drawing.Size(145, 21);
            this.ComboBoxCarac.TabIndex = 122;
            this.ComboBoxCarac.Visible = false;
            this.ComboBoxCarac.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCarac_SelectedIndexChanged);
            // 
            // NumericUpDownPrep
            // 
            this.NumericUpDownPrep.Enabled = false;
            this.NumericUpDownPrep.Location = new System.Drawing.Point(130, 174);
            this.NumericUpDownPrep.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownPrep.Name = "NumericUpDownPrep";
            this.NumericUpDownPrep.Size = new System.Drawing.Size(61, 20);
            this.NumericUpDownPrep.TabIndex = 124;
            this.NumericUpDownPrep.Visible = false;
            this.NumericUpDownPrep.ValueChanged += new System.EventHandler(this.NumericUpDownPrep_ValueChanged);
            // 
            // LabelPrep
            // 
            this.LabelPrep.AutoSize = true;
            this.LabelPrep.Location = new System.Drawing.Point(14, 176);
            this.LabelPrep.Name = "LabelPrep";
            this.LabelPrep.Size = new System.Drawing.Size(110, 13);
            this.LabelPrep.TabIndex = 123;
            this.LabelPrep.Text = "Round de préparation";
            this.LabelPrep.Visible = false;
            // 
            // TextBoxNomTech
            // 
            this.TextBoxNomTech.Enabled = false;
            this.TextBoxNomTech.Location = new System.Drawing.Point(48, 103);
            this.TextBoxNomTech.Name = "TextBoxNomTech";
            this.TextBoxNomTech.Size = new System.Drawing.Size(102, 20);
            this.TextBoxNomTech.TabIndex = 125;
            this.TextBoxNomTech.Visible = false;
            this.TextBoxNomTech.TextChanged += new System.EventHandler(this.TextBoxNomTech_TextChanged);
            // 
            // LabelNom
            // 
            this.LabelNom.AutoSize = true;
            this.LabelNom.Location = new System.Drawing.Point(13, 106);
            this.LabelNom.Name = "LabelNom";
            this.LabelNom.Size = new System.Drawing.Size(29, 13);
            this.LabelNom.TabIndex = 126;
            this.LabelNom.Text = "Nom";
            this.LabelNom.Visible = false;
            // 
            // LabelDI
            // 
            this.LabelDI.AutoSize = true;
            this.LabelDI.Location = new System.Drawing.Point(156, 106);
            this.LabelDI.Name = "LabelDI";
            this.LabelDI.Size = new System.Drawing.Size(18, 13);
            this.LabelDI.TabIndex = 127;
            this.LabelDI.Text = "DI";
            this.LabelDI.Visible = false;
            // 
            // NumericUpDownDI
            // 
            this.NumericUpDownDI.Enabled = false;
            this.NumericUpDownDI.Location = new System.Drawing.Point(180, 103);
            this.NumericUpDownDI.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDownDI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownDI.Name = "NumericUpDownDI";
            this.NumericUpDownDI.Size = new System.Drawing.Size(60, 20);
            this.NumericUpDownDI.TabIndex = 128;
            this.NumericUpDownDI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownDI.Visible = false;
            this.NumericUpDownDI.ValueChanged += new System.EventHandler(this.NumericUpDownDI_ValueChanged);
            // 
            // RadioButtonAucune
            // 
            this.RadioButtonAucune.AutoSize = true;
            this.RadioButtonAucune.Enabled = false;
            this.RadioButtonAucune.Location = new System.Drawing.Point(15, 128);
            this.RadioButtonAucune.Name = "RadioButtonAucune";
            this.RadioButtonAucune.Size = new System.Drawing.Size(62, 17);
            this.RadioButtonAucune.TabIndex = 129;
            this.RadioButtonAucune.TabStop = true;
            this.RadioButtonAucune.Text = "Aucune";
            this.RadioButtonAucune.UseVisualStyleBackColor = true;
            this.RadioButtonAucune.Visible = false;
            this.RadioButtonAucune.CheckedChanged += new System.EventHandler(this.RadioButtonAucune_CheckedChanged);
            // 
            // RadioButtonBadRecup
            // 
            this.RadioButtonBadRecup.AutoSize = true;
            this.RadioButtonBadRecup.Location = new System.Drawing.Point(15, 151);
            this.RadioButtonBadRecup.Name = "RadioButtonBadRecup";
            this.RadioButtonBadRecup.Size = new System.Drawing.Size(133, 17);
            this.RadioButtonBadRecup.TabIndex = 130;
            this.RadioButtonBadRecup.TabStop = true;
            this.RadioButtonBadRecup.Text = "Mauvaise récupération";
            this.RadioButtonBadRecup.UseVisualStyleBackColor = true;
            this.RadioButtonBadRecup.CheckedChanged += new System.EventHandler(this.RadioButtonBadRecup_CheckedChanged);
            // 
            // RadioButtonRecupOnly
            // 
            this.RadioButtonRecupOnly.AutoSize = true;
            this.RadioButtonRecupOnly.Location = new System.Drawing.Point(15, 174);
            this.RadioButtonRecupOnly.Name = "RadioButtonRecupOnly";
            this.RadioButtonRecupOnly.Size = new System.Drawing.Size(147, 17);
            this.RadioButtonRecupOnly.TabIndex = 131;
            this.RadioButtonRecupOnly.TabStop = true;
            this.RadioButtonRecupOnly.Text = "Récupération uniquement";
            this.RadioButtonRecupOnly.UseVisualStyleBackColor = true;
            this.RadioButtonRecupOnly.CheckedChanged += new System.EventHandler(this.RadioButtonRecupOnly_CheckedChanged);
            // 
            // FormFacetteMaitrise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 297);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.NumericUpDownPrep);
            this.Controls.Add(this.LabelPres);
            this.Controls.Add(this.labelLBLPres);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelPP);
            this.Controls.Add(this.labelLBLNiveau);
            this.Controls.Add(this.labelLBLPP);
            this.Controls.Add(this.ComboBoxSelectBonus);
            this.Controls.Add(this.ComboBoxSelectPouv);
            this.Controls.Add(this.LabelModificateur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxConsomation);
            this.Controls.Add(this.RadioButtonBadRecup);
            this.Controls.Add(this.RadioButtonRecupOnly);
            this.Controls.Add(this.CheckBoxModFuite);
            this.Controls.Add(this.LabelNom);
            this.Controls.Add(this.NumericUpDownDI);
            this.Controls.Add(this.LabelDI);
            this.Controls.Add(this.TextBoxNomTech);
            this.Controls.Add(this.ComboBoxCarac);
            this.Controls.Add(this.LabelCarac);
            this.Controls.Add(this.CheckBoxIllimite);
            this.Controls.Add(this.NumericUpDownUtilisation);
            this.Controls.Add(this.RadioButtonAucune);
            this.Controls.Add(this.LabelPrep);
            this.Controls.Add(this.CheckBoxModRecharge);
            this.Controls.Add(this.CheckBoxModFiltre);
            this.Controls.Add(this.LabelUtilisation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFacetteMaitrise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facette de maitrîse";
            this.Load += new System.EventHandler(this.FormFacetteMaitrise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownUtilisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPrep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.CheckBox CheckBoxIllimite;
        private System.Windows.Forms.NumericUpDown NumericUpDownUtilisation;
        private System.Windows.Forms.Label LabelUtilisation;
        private System.Windows.Forms.Label labelLBLPres;
        private System.Windows.Forms.Label LabelPP;
        private System.Windows.Forms.Label labelLBLNiveau;
        private System.Windows.Forms.Label labelLBLPP;
        private System.Windows.Forms.ComboBox ComboBoxSelectBonus;
        private System.Windows.Forms.ComboBox ComboBoxSelectPouv;
        private System.Windows.Forms.Label LabelModificateur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxConsomation;
        private System.Windows.Forms.CheckBox CheckBoxModRecharge;
        private System.Windows.Forms.CheckBox CheckBoxModFiltre;
        private System.Windows.Forms.CheckBox CheckBoxModFuite;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Label LabelPres;
        private System.Windows.Forms.Label LabelCarac;
        private System.Windows.Forms.ComboBox ComboBoxCarac;
        private System.Windows.Forms.NumericUpDown NumericUpDownPrep;
        private System.Windows.Forms.Label LabelPrep;
        private System.Windows.Forms.TextBox TextBoxNomTech;
        private System.Windows.Forms.Label LabelNom;
        private System.Windows.Forms.Label LabelDI;
        private System.Windows.Forms.NumericUpDown NumericUpDownDI;
        private System.Windows.Forms.RadioButton RadioButtonAucune;
        private System.Windows.Forms.RadioButton RadioButtonBadRecup;
        private System.Windows.Forms.RadioButton RadioButtonRecupOnly;
    }
}