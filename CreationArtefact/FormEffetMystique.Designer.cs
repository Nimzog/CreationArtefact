namespace CreationArtefact
{
    partial class FormEffetMystique
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEffetMystique));
            this.LabelCondition = new System.Windows.Forms.Label();
            this.LabelPres = new System.Windows.Forms.Label();
            this.labelLBLPres = new System.Windows.Forms.Label();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.LabelPP = new System.Windows.Forms.Label();
            this.labelLBLNiveau = new System.Windows.Forms.Label();
            this.labelLBLPP = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ComboBoxSelectResistance = new System.Windows.Forms.ComboBox();
            this.ComboBoxSelectEffet = new System.Windows.Forms.ComboBox();
            this.LabelRes = new System.Windows.Forms.Label();
            this.LabelEffet = new System.Windows.Forms.Label();
            this.ComboBoxSelectCondition = new System.Windows.Forms.ComboBox();
            this.LabelFaiblesse = new System.Windows.Forms.Label();
            this.CheckBoxLimite = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LabelCondition
            // 
            this.LabelCondition.AutoSize = true;
            this.LabelCondition.Location = new System.Drawing.Point(12, 89);
            this.LabelCondition.Name = "LabelCondition";
            this.LabelCondition.Size = new System.Drawing.Size(51, 13);
            this.LabelCondition.TabIndex = 94;
            this.LabelCondition.Text = "Condition";
            // 
            // LabelPres
            // 
            this.LabelPres.AutoSize = true;
            this.LabelPres.Location = new System.Drawing.Point(326, 68);
            this.LabelPres.Name = "LabelPres";
            this.LabelPres.Size = new System.Drawing.Size(22, 13);
            this.LabelPres.TabIndex = 93;
            this.LabelPres.Text = "NA";
            // 
            // labelLBLPres
            // 
            this.labelLBLPres.AutoSize = true;
            this.labelLBLPres.Location = new System.Drawing.Point(326, 28);
            this.labelLBLPres.Name = "labelLBLPres";
            this.labelLBLPres.Size = new System.Drawing.Size(52, 13);
            this.labelLBLPres.TabIndex = 92;
            this.labelLBLPres.Text = "Présence";
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(290, 68);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(22, 13);
            this.LabelNiveau.TabIndex = 91;
            this.LabelNiveau.Text = "NA";
            // 
            // LabelPP
            // 
            this.LabelPP.AutoSize = true;
            this.LabelPP.Location = new System.Drawing.Point(267, 68);
            this.LabelPP.Name = "LabelPP";
            this.LabelPP.Size = new System.Drawing.Size(22, 13);
            this.LabelPP.TabIndex = 90;
            this.LabelPP.Text = "NA";
            // 
            // labelLBLNiveau
            // 
            this.labelLBLNiveau.AutoSize = true;
            this.labelLBLNiveau.Location = new System.Drawing.Point(289, 28);
            this.labelLBLNiveau.Name = "labelLBLNiveau";
            this.labelLBLNiveau.Size = new System.Drawing.Size(41, 13);
            this.labelLBLNiveau.TabIndex = 89;
            this.labelLBLNiveau.Text = "Niveau";
            // 
            // labelLBLPP
            // 
            this.labelLBLPP.AutoSize = true;
            this.labelLBLPP.Location = new System.Drawing.Point(267, 28);
            this.labelLBLPP.Name = "labelLBLPP";
            this.labelLBLPP.Size = new System.Drawing.Size(21, 13);
            this.labelLBLPP.TabIndex = 88;
            this.labelLBLPP.Text = "PP";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(129, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 23);
            this.buttonCancel.TabIndex = 86;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(12, 168);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(111, 23);
            this.ButtonSave.TabIndex = 85;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ComboBoxSelectResistance
            // 
            this.ComboBoxSelectResistance.Enabled = false;
            this.ComboBoxSelectResistance.FormattingEnabled = true;
            this.ComboBoxSelectResistance.Location = new System.Drawing.Point(12, 65);
            this.ComboBoxSelectResistance.Name = "ComboBoxSelectResistance";
            this.ComboBoxSelectResistance.Size = new System.Drawing.Size(249, 21);
            this.ComboBoxSelectResistance.TabIndex = 84;
            this.ComboBoxSelectResistance.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectResistance_SelectedIndexChanged);
            // 
            // ComboBoxSelectEffet
            // 
            this.ComboBoxSelectEffet.FormattingEnabled = true;
            this.ComboBoxSelectEffet.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxSelectEffet.Name = "ComboBoxSelectEffet";
            this.ComboBoxSelectEffet.Size = new System.Drawing.Size(249, 21);
            this.ComboBoxSelectEffet.TabIndex = 83;
            this.ComboBoxSelectEffet.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectEffet_SelectedIndexChanged);
            // 
            // LabelRes
            // 
            this.LabelRes.AutoSize = true;
            this.LabelRes.Location = new System.Drawing.Point(12, 49);
            this.LabelRes.Name = "LabelRes";
            this.LabelRes.Size = new System.Drawing.Size(60, 13);
            this.LabelRes.TabIndex = 81;
            this.LabelRes.Text = "Résistance";
            // 
            // LabelEffet
            // 
            this.LabelEffet.AutoSize = true;
            this.LabelEffet.Location = new System.Drawing.Point(12, 9);
            this.LabelEffet.Name = "LabelEffet";
            this.LabelEffet.Size = new System.Drawing.Size(29, 13);
            this.LabelEffet.TabIndex = 80;
            this.LabelEffet.Text = "Effet";
            // 
            // ComboBoxSelectCondition
            // 
            this.ComboBoxSelectCondition.Enabled = false;
            this.ComboBoxSelectCondition.FormattingEnabled = true;
            this.ComboBoxSelectCondition.Location = new System.Drawing.Point(12, 105);
            this.ComboBoxSelectCondition.Name = "ComboBoxSelectCondition";
            this.ComboBoxSelectCondition.Size = new System.Drawing.Size(249, 21);
            this.ComboBoxSelectCondition.TabIndex = 95;
            this.ComboBoxSelectCondition.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectCondition_SelectedIndexChanged);
            // 
            // LabelFaiblesse
            // 
            this.LabelFaiblesse.AutoSize = true;
            this.LabelFaiblesse.Location = new System.Drawing.Point(12, 129);
            this.LabelFaiblesse.Name = "LabelFaiblesse";
            this.LabelFaiblesse.Size = new System.Drawing.Size(51, 13);
            this.LabelFaiblesse.TabIndex = 97;
            this.LabelFaiblesse.Text = "Faiblesse";
            // 
            // CheckBoxLimite
            // 
            this.CheckBoxLimite.AutoSize = true;
            this.CheckBoxLimite.Enabled = false;
            this.CheckBoxLimite.Location = new System.Drawing.Point(15, 145);
            this.CheckBoxLimite.Name = "CheckBoxLimite";
            this.CheckBoxLimite.Size = new System.Drawing.Size(84, 17);
            this.CheckBoxLimite.TabIndex = 96;
            this.CheckBoxLimite.Text = "Temps limité";
            this.CheckBoxLimite.UseVisualStyleBackColor = true;
            this.CheckBoxLimite.CheckedChanged += new System.EventHandler(this.CheckBoxLimite_CheckedChanged);
            // 
            // FormEffetMystique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 195);
            this.Controls.Add(this.LabelFaiblesse);
            this.Controls.Add(this.CheckBoxLimite);
            this.Controls.Add(this.LabelCondition);
            this.Controls.Add(this.LabelPres);
            this.Controls.Add(this.labelLBLPres);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelPP);
            this.Controls.Add(this.labelLBLNiveau);
            this.Controls.Add(this.labelLBLPP);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ComboBoxSelectResistance);
            this.Controls.Add(this.ComboBoxSelectEffet);
            this.Controls.Add(this.LabelRes);
            this.Controls.Add(this.LabelEffet);
            this.Controls.Add(this.ComboBoxSelectCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEffetMystique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facette ésotérique: Effet mystique";
            this.Load += new System.EventHandler(this.FormEffetMystique_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelCondition;
        private System.Windows.Forms.Label LabelPres;
        private System.Windows.Forms.Label labelLBLPres;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Label LabelPP;
        private System.Windows.Forms.Label labelLBLNiveau;
        private System.Windows.Forms.Label labelLBLPP;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox ComboBoxSelectResistance;
        private System.Windows.Forms.ComboBox ComboBoxSelectEffet;
        private System.Windows.Forms.Label LabelRes;
        private System.Windows.Forms.Label LabelEffet;
        private System.Windows.Forms.ComboBox ComboBoxSelectCondition;
        private System.Windows.Forms.Label LabelFaiblesse;
        private System.Windows.Forms.CheckBox CheckBoxLimite;
    }
}