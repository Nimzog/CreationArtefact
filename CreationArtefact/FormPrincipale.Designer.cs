namespace CreationArtefact
{
    partial class FormPrincipale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipale));
            this.LabelPouvoir = new System.Windows.Forms.Label();
            this.ButtonAjouterPouvoir = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonQuit = new System.Windows.Forms.Button();
            this.MenuStripArtefact = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SauvegarderSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileDialogArtefact = new System.Windows.Forms.SaveFileDialog();
            this.LabelConteneur = new System.Windows.Forms.Label();
            this.ButtonContenant = new System.Windows.Forms.Button();
            this.richTextBoxDescArtefact = new System.Windows.Forms.RichTextBox();
            this.ComboBoxFacette = new System.Windows.Forms.ComboBox();
            this.ListBoxArtefact = new System.Windows.Forms.ListBox();
            this.ButtonModifier = new System.Windows.Forms.Button();
            this.MenuStripArtefact.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelPouvoir
            // 
            this.LabelPouvoir.AutoSize = true;
            this.LabelPouvoir.Location = new System.Drawing.Point(12, 69);
            this.LabelPouvoir.Name = "LabelPouvoir";
            this.LabelPouvoir.Size = new System.Drawing.Size(93, 13);
            this.LabelPouvoir.TabIndex = 1;
            this.LabelPouvoir.Text = "Ajouter un pouvoir";
            // 
            // ButtonAjouterPouvoir
            // 
            this.ButtonAjouterPouvoir.Enabled = false;
            this.ButtonAjouterPouvoir.Location = new System.Drawing.Point(15, 114);
            this.ButtonAjouterPouvoir.Name = "ButtonAjouterPouvoir";
            this.ButtonAjouterPouvoir.Size = new System.Drawing.Size(121, 23);
            this.ButtonAjouterPouvoir.TabIndex = 2;
            this.ButtonAjouterPouvoir.Text = "Ajouter";
            this.ButtonAjouterPouvoir.UseVisualStyleBackColor = true;
            this.ButtonAjouterPouvoir.Click += new System.EventHandler(this.ButtonAjouterPouvoir_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(265, 528);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(157, 23);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Sauvegarder sous...";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonQuit
            // 
            this.ButtonQuit.Location = new System.Drawing.Point(501, 528);
            this.ButtonQuit.Name = "ButtonQuit";
            this.ButtonQuit.Size = new System.Drawing.Size(157, 23);
            this.ButtonQuit.TabIndex = 5;
            this.ButtonQuit.Text = "Quitter";
            this.ButtonQuit.UseVisualStyleBackColor = true;
            this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // MenuStripArtefact
            // 
            this.MenuStripArtefact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.AProposToolStripMenuItem});
            this.MenuStripArtefact.Location = new System.Drawing.Point(0, 0);
            this.MenuStripArtefact.Name = "MenuStripArtefact";
            this.MenuStripArtefact.Size = new System.Drawing.Size(668, 24);
            this.MenuStripArtefact.TabIndex = 7;
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NouveauToolStripMenuItem,
            this.SauvegarderToolStripMenuItem,
            this.SauvegarderSousToolStripMenuItem,
            this.QuitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // NouveauToolStripMenuItem
            // 
            this.NouveauToolStripMenuItem.Enabled = false;
            this.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem";
            this.NouveauToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.NouveauToolStripMenuItem.Text = "Nouveau";
            this.NouveauToolStripMenuItem.Click += new System.EventHandler(this.NouveauToolStripMenuItem_Click);
            // 
            // SauvegarderToolStripMenuItem
            // 
            this.SauvegarderToolStripMenuItem.Enabled = false;
            this.SauvegarderToolStripMenuItem.Name = "SauvegarderToolStripMenuItem";
            this.SauvegarderToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.SauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.SauvegarderToolStripMenuItem.Click += new System.EventHandler(this.SauvegarderToolStripMenuItem_Click);
            // 
            // SauvegarderSousToolStripMenuItem
            // 
            this.SauvegarderSousToolStripMenuItem.Enabled = false;
            this.SauvegarderSousToolStripMenuItem.Name = "SauvegarderSousToolStripMenuItem";
            this.SauvegarderSousToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.SauvegarderSousToolStripMenuItem.Text = "Sauvegarder sous";
            this.SauvegarderSousToolStripMenuItem.Click += new System.EventHandler(this.SauvegarderSousToolStripMenuItem_Click);
            // 
            // QuitterToolStripMenuItem
            // 
            this.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem";
            this.QuitterToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.QuitterToolStripMenuItem.Text = "Quitter";
            this.QuitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // AProposToolStripMenuItem
            // 
            this.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem";
            this.AProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.AProposToolStripMenuItem.Text = "À propos";
            this.AProposToolStripMenuItem.Click += new System.EventHandler(this.AProposToolStripMenuItem_Click);
            // 
            // SaveFileDialogArtefact
            // 
            this.SaveFileDialogArtefact.CheckFileExists = true;
            this.SaveFileDialogArtefact.CreatePrompt = true;
            this.SaveFileDialogArtefact.InitialDirectory = "c:\\";
            this.SaveFileDialogArtefact.RestoreDirectory = true;
            this.SaveFileDialogArtefact.Title = "Sauvegarder Artéfact sous...";
            this.SaveFileDialogArtefact.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogArtefact_FileOk);
            // 
            // LabelConteneur
            // 
            this.LabelConteneur.AutoSize = true;
            this.LabelConteneur.Location = new System.Drawing.Point(12, 27);
            this.LabelConteneur.Name = "LabelConteneur";
            this.LabelConteneur.Size = new System.Drawing.Size(56, 13);
            this.LabelConteneur.TabIndex = 8;
            this.LabelConteneur.Text = "Contenant";
            // 
            // ButtonContenant
            // 
            this.ButtonContenant.Location = new System.Drawing.Point(15, 43);
            this.ButtonContenant.Name = "ButtonContenant";
            this.ButtonContenant.Size = new System.Drawing.Size(244, 23);
            this.ButtonContenant.TabIndex = 0;
            this.ButtonContenant.Text = "Créer";
            this.ButtonContenant.UseVisualStyleBackColor = true;
            this.ButtonContenant.Click += new System.EventHandler(this.ButtonContenant_Click);
            // 
            // richTextBoxDescArtefact
            // 
            this.richTextBoxDescArtefact.Location = new System.Drawing.Point(265, 24);
            this.richTextBoxDescArtefact.Name = "richTextBoxDescArtefact";
            this.richTextBoxDescArtefact.ReadOnly = true;
            this.richTextBoxDescArtefact.Size = new System.Drawing.Size(393, 498);
            this.richTextBoxDescArtefact.TabIndex = 10;
            this.richTextBoxDescArtefact.Text = "";
            this.richTextBoxDescArtefact.TextChanged += new System.EventHandler(this.richTextBoxDescArtefact_TextChanged);
            // 
            // ComboBoxFacette
            // 
            this.ComboBoxFacette.Enabled = false;
            this.ComboBoxFacette.FormattingEnabled = true;
            this.ComboBoxFacette.Location = new System.Drawing.Point(15, 86);
            this.ComboBoxFacette.Name = "ComboBoxFacette";
            this.ComboBoxFacette.Size = new System.Drawing.Size(244, 21);
            this.ComboBoxFacette.TabIndex = 1;
            this.ComboBoxFacette.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFacette_SelectedIndexChanged);
            // 
            // ListBoxArtefact
            // 
            this.ListBoxArtefact.Enabled = false;
            this.ListBoxArtefact.FormattingEnabled = true;
            this.ListBoxArtefact.Location = new System.Drawing.Point(265, 24);
            this.ListBoxArtefact.Name = "ListBoxArtefact";
            this.ListBoxArtefact.Size = new System.Drawing.Size(393, 498);
            this.ListBoxArtefact.TabIndex = 11;
            this.ListBoxArtefact.Visible = false;
            this.ListBoxArtefact.SelectedIndexChanged += new System.EventHandler(this.ListBoxArtefact_SelectedIndexChanged);
            // 
            // ButtonModifier
            // 
            this.ButtonModifier.Enabled = false;
            this.ButtonModifier.Location = new System.Drawing.Point(142, 113);
            this.ButtonModifier.Name = "ButtonModifier";
            this.ButtonModifier.Size = new System.Drawing.Size(117, 23);
            this.ButtonModifier.TabIndex = 12;
            this.ButtonModifier.Text = "Modifier";
            this.ButtonModifier.UseVisualStyleBackColor = true;
            this.ButtonModifier.Click += new System.EventHandler(this.ButtonModifier_Click);
            // 
            // FormPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 563);
            this.Controls.Add(this.ButtonModifier);
            this.Controls.Add(this.ComboBoxFacette);
            this.Controls.Add(this.ButtonContenant);
            this.Controls.Add(this.LabelConteneur);
            this.Controls.Add(this.ButtonQuit);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonAjouterPouvoir);
            this.Controls.Add(this.LabelPouvoir);
            this.Controls.Add(this.MenuStripArtefact);
            this.Controls.Add(this.ListBoxArtefact);
            this.Controls.Add(this.richTextBoxDescArtefact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripArtefact;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipale";
            this.Text = "Création d\'artefact";
            this.MenuStripArtefact.ResumeLayout(false);
            this.MenuStripArtefact.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelPouvoir;
        private System.Windows.Forms.Button ButtonAjouterPouvoir;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonQuit;
        private System.Windows.Forms.MenuStrip MenuStripArtefact;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SauvegarderSousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitterToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogArtefact;
        private System.Windows.Forms.Label LabelConteneur;
        private System.Windows.Forms.Button ButtonContenant;
        private System.Windows.Forms.RichTextBox richTextBoxDescArtefact;
        private System.Windows.Forms.ComboBox ComboBoxFacette;
        private System.Windows.Forms.ToolStripMenuItem NouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AProposToolStripMenuItem;
        private System.Windows.Forms.ListBox ListBoxArtefact;
        private System.Windows.Forms.Button ButtonModifier;
    }
}

