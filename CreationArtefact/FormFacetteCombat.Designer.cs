namespace CreationArtefact
{
    partial class FormFacetteCombat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacetteCombat));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelModificateur = new System.Windows.Forms.Label();
            this.ComboBoxSelectPouv = new System.Windows.Forms.ComboBox();
            this.ComboBoxSelectBonus = new System.Windows.Forms.ComboBox();
            this.RadioButtonMod1 = new System.Windows.Forms.RadioButton();
            this.RadioButtonMod2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonMod3 = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CheckBoxMod1 = new System.Windows.Forms.CheckBox();
            this.CheckBoxMod2 = new System.Windows.Forms.CheckBox();
            this.TextBoxExterminateur = new System.Windows.Forms.TextBox();
            this.LabelExterminateur = new System.Windows.Forms.Label();
            this.RadioButtonMod4 = new System.Windows.Forms.RadioButton();
            this.LabelPres = new System.Windows.Forms.Label();
            this.labelLBLPres = new System.Windows.Forms.Label();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.LabelPP = new System.Windows.Forms.Label();
            this.labelLBLNiveau = new System.Windows.Forms.Label();
            this.labelLBLPP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selectionnez le bonus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selectionnez le bonus";
            // 
            // LabelModificateur
            // 
            this.LabelModificateur.AutoSize = true;
            this.LabelModificateur.Location = new System.Drawing.Point(12, 89);
            this.LabelModificateur.Name = "LabelModificateur";
            this.LabelModificateur.Size = new System.Drawing.Size(65, 13);
            this.LabelModificateur.TabIndex = 2;
            this.LabelModificateur.Text = "Modificateur";
            this.LabelModificateur.Visible = false;
            // 
            // ComboBoxSelectPouv
            // 
            this.ComboBoxSelectPouv.FormattingEnabled = true;
            this.ComboBoxSelectPouv.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxSelectPouv.Name = "ComboBoxSelectPouv";
            this.ComboBoxSelectPouv.Size = new System.Drawing.Size(228, 21);
            this.ComboBoxSelectPouv.TabIndex = 5;
            this.ComboBoxSelectPouv.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectPouv_SelectedIndexChanged);
            // 
            // ComboBoxSelectBonus
            // 
            this.ComboBoxSelectBonus.Enabled = false;
            this.ComboBoxSelectBonus.FormattingEnabled = true;
            this.ComboBoxSelectBonus.Location = new System.Drawing.Point(12, 65);
            this.ComboBoxSelectBonus.Name = "ComboBoxSelectBonus";
            this.ComboBoxSelectBonus.Size = new System.Drawing.Size(228, 21);
            this.ComboBoxSelectBonus.TabIndex = 6;
            this.ComboBoxSelectBonus.Text = "Choisir...";
            this.ComboBoxSelectBonus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectBonus_SelectedIndexChanged);
            // 
            // RadioButtonMod1
            // 
            this.RadioButtonMod1.AutoSize = true;
            this.RadioButtonMod1.Enabled = false;
            this.RadioButtonMod1.Location = new System.Drawing.Point(12, 105);
            this.RadioButtonMod1.Name = "RadioButtonMod1";
            this.RadioButtonMod1.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonMod1.TabIndex = 7;
            this.RadioButtonMod1.TabStop = true;
            this.RadioButtonMod1.Text = "Modificateur 1";
            this.RadioButtonMod1.UseVisualStyleBackColor = true;
            this.RadioButtonMod1.Visible = false;
            this.RadioButtonMod1.CheckedChanged += new System.EventHandler(this.RadioButtonMod1_CheckedChanged);
            // 
            // RadioButtonMod2
            // 
            this.RadioButtonMod2.AutoSize = true;
            this.RadioButtonMod2.Enabled = false;
            this.RadioButtonMod2.Location = new System.Drawing.Point(12, 128);
            this.RadioButtonMod2.Name = "RadioButtonMod2";
            this.RadioButtonMod2.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonMod2.TabIndex = 8;
            this.RadioButtonMod2.TabStop = true;
            this.RadioButtonMod2.Text = "Modificateur 2";
            this.RadioButtonMod2.UseVisualStyleBackColor = true;
            this.RadioButtonMod2.Visible = false;
            this.RadioButtonMod2.CheckedChanged += new System.EventHandler(this.RadioButtonMod2_CheckedChanged);
            // 
            // RadioButtonMod3
            // 
            this.RadioButtonMod3.AutoSize = true;
            this.RadioButtonMod3.Enabled = false;
            this.RadioButtonMod3.Location = new System.Drawing.Point(12, 151);
            this.RadioButtonMod3.Name = "RadioButtonMod3";
            this.RadioButtonMod3.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonMod3.TabIndex = 9;
            this.RadioButtonMod3.TabStop = true;
            this.RadioButtonMod3.Text = "Modificateur 3";
            this.RadioButtonMod3.UseVisualStyleBackColor = true;
            this.RadioButtonMod3.Visible = false;
            this.RadioButtonMod3.CheckedChanged += new System.EventHandler(this.RadioButtonMod3_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(129, 92);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(12, 92);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(111, 23);
            this.ButtonSave.TabIndex = 10;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CheckBoxMod1
            // 
            this.CheckBoxMod1.AutoSize = true;
            this.CheckBoxMod1.Enabled = false;
            this.CheckBoxMod1.Location = new System.Drawing.Point(11, 106);
            this.CheckBoxMod1.Name = "CheckBoxMod1";
            this.CheckBoxMod1.Size = new System.Drawing.Size(80, 17);
            this.CheckBoxMod1.TabIndex = 12;
            this.CheckBoxMod1.Text = "checkBox1";
            this.CheckBoxMod1.UseVisualStyleBackColor = true;
            this.CheckBoxMod1.Visible = false;
            this.CheckBoxMod1.CheckedChanged += new System.EventHandler(this.CheckBoxMod1_CheckedChanged);
            // 
            // CheckBoxMod2
            // 
            this.CheckBoxMod2.AutoSize = true;
            this.CheckBoxMod2.Enabled = false;
            this.CheckBoxMod2.Location = new System.Drawing.Point(11, 128);
            this.CheckBoxMod2.Name = "CheckBoxMod2";
            this.CheckBoxMod2.Size = new System.Drawing.Size(80, 17);
            this.CheckBoxMod2.TabIndex = 13;
            this.CheckBoxMod2.Text = "checkBox2";
            this.CheckBoxMod2.UseVisualStyleBackColor = true;
            this.CheckBoxMod2.Visible = false;
            this.CheckBoxMod2.CheckedChanged += new System.EventHandler(this.CheckBoxMod2_CheckedChanged);
            // 
            // TextBoxExterminateur
            // 
            this.TextBoxExterminateur.Enabled = false;
            this.TextBoxExterminateur.Location = new System.Drawing.Point(11, 148);
            this.TextBoxExterminateur.Name = "TextBoxExterminateur";
            this.TextBoxExterminateur.Size = new System.Drawing.Size(227, 20);
            this.TextBoxExterminateur.TabIndex = 14;
            this.TextBoxExterminateur.Visible = false;
            // 
            // LabelExterminateur
            // 
            this.LabelExterminateur.AutoSize = true;
            this.LabelExterminateur.Location = new System.Drawing.Point(9, 125);
            this.LabelExterminateur.Name = "LabelExterminateur";
            this.LabelExterminateur.Size = new System.Drawing.Size(79, 13);
            this.LabelExterminateur.TabIndex = 15;
            this.LabelExterminateur.Text = "Cible/Condition";
            this.LabelExterminateur.Visible = false;
            // 
            // RadioButtonMod4
            // 
            this.RadioButtonMod4.AutoSize = true;
            this.RadioButtonMod4.Enabled = false;
            this.RadioButtonMod4.Location = new System.Drawing.Point(12, 174);
            this.RadioButtonMod4.Name = "RadioButtonMod4";
            this.RadioButtonMod4.Size = new System.Drawing.Size(92, 17);
            this.RadioButtonMod4.TabIndex = 16;
            this.RadioButtonMod4.TabStop = true;
            this.RadioButtonMod4.Text = "Modificateur 4";
            this.RadioButtonMod4.UseVisualStyleBackColor = true;
            this.RadioButtonMod4.Visible = false;
            this.RadioButtonMod4.CheckedChanged += new System.EventHandler(this.RadioButtonMod4_CheckedChanged);
            // 
            // LabelPres
            // 
            this.LabelPres.AutoSize = true;
            this.LabelPres.Location = new System.Drawing.Point(326, 68);
            this.LabelPres.Name = "LabelPres";
            this.LabelPres.Size = new System.Drawing.Size(22, 13);
            this.LabelPres.TabIndex = 22;
            this.LabelPres.Text = "NA";
            // 
            // labelLBLPres
            // 
            this.labelLBLPres.AutoSize = true;
            this.labelLBLPres.Location = new System.Drawing.Point(326, 28);
            this.labelLBLPres.Name = "labelLBLPres";
            this.labelLBLPres.Size = new System.Drawing.Size(52, 13);
            this.labelLBLPres.TabIndex = 21;
            this.labelLBLPres.Text = "Présence";
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(280, 68);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(22, 13);
            this.LabelNiveau.TabIndex = 20;
            this.LabelNiveau.Text = "NA";
            // 
            // LabelPP
            // 
            this.LabelPP.AutoSize = true;
            this.LabelPP.Location = new System.Drawing.Point(246, 68);
            this.LabelPP.Name = "LabelPP";
            this.LabelPP.Size = new System.Drawing.Size(22, 13);
            this.LabelPP.TabIndex = 19;
            this.LabelPP.Text = "NA";
            // 
            // labelLBLNiveau
            // 
            this.labelLBLNiveau.AutoSize = true;
            this.labelLBLNiveau.Location = new System.Drawing.Point(279, 28);
            this.labelLBLNiveau.Name = "labelLBLNiveau";
            this.labelLBLNiveau.Size = new System.Drawing.Size(41, 13);
            this.labelLBLNiveau.TabIndex = 18;
            this.labelLBLNiveau.Text = "Niveau";
            // 
            // labelLBLPP
            // 
            this.labelLBLPP.AutoSize = true;
            this.labelLBLPP.Location = new System.Drawing.Point(246, 28);
            this.labelLBLPP.Name = "labelLBLPP";
            this.labelLBLPP.Size = new System.Drawing.Size(21, 13);
            this.labelLBLPP.TabIndex = 17;
            this.labelLBLPP.Text = "PP";
            // 
            // FormFacetteCombat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 122);
            this.Controls.Add(this.LabelPres);
            this.Controls.Add(this.labelLBLPres);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelPP);
            this.Controls.Add(this.labelLBLNiveau);
            this.Controls.Add(this.labelLBLPP);
            this.Controls.Add(this.RadioButtonMod4);
            this.Controls.Add(this.LabelExterminateur);
            this.Controls.Add(this.TextBoxExterminateur);
            this.Controls.Add(this.CheckBoxMod2);
            this.Controls.Add(this.CheckBoxMod1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.RadioButtonMod3);
            this.Controls.Add(this.RadioButtonMod2);
            this.Controls.Add(this.RadioButtonMod1);
            this.Controls.Add(this.ComboBoxSelectBonus);
            this.Controls.Add(this.ComboBoxSelectPouv);
            this.Controls.Add(this.LabelModificateur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFacetteCombat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facette offensive";
            this.Load += new System.EventHandler(this.FormFacetteCombat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelModificateur;
        private System.Windows.Forms.ComboBox ComboBoxSelectPouv;
        private System.Windows.Forms.ComboBox ComboBoxSelectBonus;
        private System.Windows.Forms.RadioButton RadioButtonMod1;
        private System.Windows.Forms.RadioButton RadioButtonMod2;
        private System.Windows.Forms.RadioButton RadioButtonMod3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.CheckBox CheckBoxMod1;
        private System.Windows.Forms.CheckBox CheckBoxMod2;
        private System.Windows.Forms.TextBox TextBoxExterminateur;
        private System.Windows.Forms.Label LabelExterminateur;
        private System.Windows.Forms.RadioButton RadioButtonMod4;
        private System.Windows.Forms.Label LabelPres;
        private System.Windows.Forms.Label labelLBLPres;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Label LabelPP;
        private System.Windows.Forms.Label labelLBLNiveau;
        private System.Windows.Forms.Label labelLBLPP;
    }
}