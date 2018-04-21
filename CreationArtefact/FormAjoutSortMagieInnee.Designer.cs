namespace CreationArtefact
{
    partial class FormAjoutSortMagieInnee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjoutSortMagieInnee));
            this.NumericUpDownNiveau = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxVoieMagie = new System.Windows.Forms.ComboBox();
            this.TextBoxNomSort = new System.Windows.Forms.TextBox();
            this.LabelNom = new System.Windows.Forms.Label();
            this.LabelVoie = new System.Windows.Forms.Label();
            this.LabelNiveau = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelCout = new System.Windows.Forms.Label();
            this.NumericUpDownZeon = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownZeon)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDownNiveau
            // 
            this.NumericUpDownNiveau.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericUpDownNiveau.Location = new System.Drawing.Point(92, 71);
            this.NumericUpDownNiveau.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumericUpDownNiveau.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericUpDownNiveau.Name = "NumericUpDownNiveau";
            this.NumericUpDownNiveau.Size = new System.Drawing.Size(139, 20);
            this.NumericUpDownNiveau.TabIndex = 94;
            this.NumericUpDownNiveau.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ComboBoxVoieMagie
            // 
            this.ComboBoxVoieMagie.FormattingEnabled = true;
            this.ComboBoxVoieMagie.Location = new System.Drawing.Point(92, 42);
            this.ComboBoxVoieMagie.Name = "ComboBoxVoieMagie";
            this.ComboBoxVoieMagie.Size = new System.Drawing.Size(139, 21);
            this.ComboBoxVoieMagie.TabIndex = 93;
            this.ComboBoxVoieMagie.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVoieMagie_SelectedIndexChanged);
            // 
            // TextBoxNomSort
            // 
            this.TextBoxNomSort.Location = new System.Drawing.Point(92, 12);
            this.TextBoxNomSort.Name = "TextBoxNomSort";
            this.TextBoxNomSort.Size = new System.Drawing.Size(139, 20);
            this.TextBoxNomSort.TabIndex = 95;
            this.TextBoxNomSort.TextChanged += new System.EventHandler(this.TextBoxNomSort_TextChanged);
            // 
            // LabelNom
            // 
            this.LabelNom.AutoSize = true;
            this.LabelNom.Location = new System.Drawing.Point(12, 15);
            this.LabelNom.Name = "LabelNom";
            this.LabelNom.Size = new System.Drawing.Size(64, 13);
            this.LabelNom.TabIndex = 96;
            this.LabelNom.Text = "Nom du sort";
            // 
            // LabelVoie
            // 
            this.LabelVoie.AutoSize = true;
            this.LabelVoie.Location = new System.Drawing.Point(12, 45);
            this.LabelVoie.Name = "LabelVoie";
            this.LabelVoie.Size = new System.Drawing.Size(74, 13);
            this.LabelVoie.TabIndex = 97;
            this.LabelVoie.Text = "Voie de magie";
            // 
            // LabelNiveau
            // 
            this.LabelNiveau.AutoSize = true;
            this.LabelNiveau.Location = new System.Drawing.Point(12, 73);
            this.LabelNiveau.Name = "LabelNiveau";
            this.LabelNiveau.Size = new System.Drawing.Size(41, 13);
            this.LabelNiveau.TabIndex = 98;
            this.LabelNiveau.Text = "Niveau";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(126, 123);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(105, 23);
            this.ButtonCancel.TabIndex = 100;
            this.ButtonCancel.Text = "Annuler";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(15, 123);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(105, 23);
            this.ButtonSave.TabIndex = 99;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelCout
            // 
            this.LabelCout.AutoSize = true;
            this.LabelCout.Location = new System.Drawing.Point(12, 99);
            this.LabelCout.Name = "LabelCout";
            this.LabelCout.Size = new System.Drawing.Size(72, 13);
            this.LabelCout.TabIndex = 101;
            this.LabelCout.Text = "Coût en Zéon";
            // 
            // NumericUpDownZeon
            // 
            this.NumericUpDownZeon.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownZeon.Location = new System.Drawing.Point(92, 97);
            this.NumericUpDownZeon.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumericUpDownZeon.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownZeon.Name = "NumericUpDownZeon";
            this.NumericUpDownZeon.Size = new System.Drawing.Size(139, 20);
            this.NumericUpDownZeon.TabIndex = 102;
            this.NumericUpDownZeon.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FormAjoutSortMagieInnee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 154);
            this.Controls.Add(this.NumericUpDownZeon);
            this.Controls.Add(this.LabelCout);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelNiveau);
            this.Controls.Add(this.LabelVoie);
            this.Controls.Add(this.LabelNom);
            this.Controls.Add(this.TextBoxNomSort);
            this.Controls.Add(this.NumericUpDownNiveau);
            this.Controls.Add(this.ComboBoxVoieMagie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAjoutSortMagieInnee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAjoutSortMagieInnee";
            this.Load += new System.EventHandler(this.FormAjoutSortMagieInnee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownZeon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDownNiveau;
        private System.Windows.Forms.ComboBox ComboBoxVoieMagie;
        private System.Windows.Forms.TextBox TextBoxNomSort;
        private System.Windows.Forms.Label LabelNom;
        private System.Windows.Forms.Label LabelVoie;
        private System.Windows.Forms.Label LabelNiveau;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label LabelCout;
        private System.Windows.Forms.NumericUpDown NumericUpDownZeon;
    }
}