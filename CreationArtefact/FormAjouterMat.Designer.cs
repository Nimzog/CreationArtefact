namespace CreationArtefact
{
    partial class FormAjouterMat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjouterMat));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxMat = new System.Windows.Forms.TextBox();
            this.NumericUpDownPresence = new System.Windows.Forms.NumericUpDown();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonAnnuler = new System.Windows.Forms.Button();
            this.ListBoxMateriel = new System.Windows.Forms.ListBox();
            this.ButtonSupprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPresence)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom du matériel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Présence";
            // 
            // TextBoxMat
            // 
            this.TextBoxMat.Location = new System.Drawing.Point(101, 289);
            this.TextBoxMat.Name = "TextBoxMat";
            this.TextBoxMat.Size = new System.Drawing.Size(100, 20);
            this.TextBoxMat.TabIndex = 2;
            this.TextBoxMat.TextChanged += new System.EventHandler(this.TextBoxMat_TextChanged);
            // 
            // NumericUpDownPresence
            // 
            this.NumericUpDownPresence.Enabled = false;
            this.NumericUpDownPresence.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumericUpDownPresence.Location = new System.Drawing.Point(265, 290);
            this.NumericUpDownPresence.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NumericUpDownPresence.Name = "NumericUpDownPresence";
            this.NumericUpDownPresence.Size = new System.Drawing.Size(57, 20);
            this.NumericUpDownPresence.TabIndex = 3;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(12, 315);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(99, 23);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Sauvegarder";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonAnnuler
            // 
            this.ButtonAnnuler.Location = new System.Drawing.Point(223, 316);
            this.ButtonAnnuler.Name = "ButtonAnnuler";
            this.ButtonAnnuler.Size = new System.Drawing.Size(99, 23);
            this.ButtonAnnuler.TabIndex = 5;
            this.ButtonAnnuler.Text = "Annuler";
            this.ButtonAnnuler.UseVisualStyleBackColor = true;
            this.ButtonAnnuler.Click += new System.EventHandler(this.ButtonAnnuler_Click);
            // 
            // ListBoxMateriel
            // 
            this.ListBoxMateriel.FormattingEnabled = true;
            this.ListBoxMateriel.Location = new System.Drawing.Point(12, 12);
            this.ListBoxMateriel.Name = "ListBoxMateriel";
            this.ListBoxMateriel.Size = new System.Drawing.Size(310, 264);
            this.ListBoxMateriel.TabIndex = 6;
            this.ListBoxMateriel.SelectedIndexChanged += new System.EventHandler(this.ListBoxMateriel_SelectedIndexChanged);
            // 
            // ButtonSupprimer
            // 
            this.ButtonSupprimer.Enabled = false;
            this.ButtonSupprimer.Location = new System.Drawing.Point(117, 315);
            this.ButtonSupprimer.Name = "ButtonSupprimer";
            this.ButtonSupprimer.Size = new System.Drawing.Size(99, 23);
            this.ButtonSupprimer.TabIndex = 7;
            this.ButtonSupprimer.Text = "Ajouter";
            this.ButtonSupprimer.UseVisualStyleBackColor = true;
            this.ButtonSupprimer.Click += new System.EventHandler(this.ButtonSupprimer_Click);
            // 
            // FormAjouterMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 350);
            this.Controls.Add(this.ButtonSupprimer);
            this.Controls.Add(this.ButtonAnnuler);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.NumericUpDownPresence);
            this.Controls.Add(this.TextBoxMat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBoxMateriel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAjouterMat";
            this.Text = "Nouveau matériel";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPresence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxMat;
        private System.Windows.Forms.NumericUpDown NumericUpDownPresence;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonAnnuler;
        private System.Windows.Forms.ListBox ListBoxMateriel;
        private System.Windows.Forms.Button ButtonSupprimer;
    }
}