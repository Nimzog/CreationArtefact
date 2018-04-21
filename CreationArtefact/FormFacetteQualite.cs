using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreationArtefact
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormFacetteQualite : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteQualite Qualite;
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel;
        bool modification;
        ClassFacetteQualite importQualite;

        /// <summary>
        /// 
        /// </summary>
        public FormFacetteQualite()
        {
            InitializeComponent();

            Qualite = new ClassFacetteQualite();

            CloseSaveCancel = false;

            ComboBoxSelectPouvoir.DataSource = Properties.Settings.Default.FacetteQualite;
            ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            creerPouvoir();

            CloseSaveCancel = true;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseSaveCancel = false;

            this.Close();
        }

        private void ComboBoxSelectPouvoir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouvoir.SelectedIndex != 0)
            {
                ComboBoxSelectBonus.Enabled = true;
            }
            else
            {
                ComboBoxSelectBonus.Enabled = false;
                ComboBoxSelectBonus.SelectedIndex = 0;
                /*ButtonSave.Enabled = false;

                LabelNiveau.Text = "NA";
                LabelPP.Text = "NA";
                LabelPres.Text = "NA";*/
            }
        }

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = Qualite.GetCoutPouvoir();

                LabelNiveau.Text = "" + coutPouvoir.Niveau;
                LabelPP.Text = "" + coutPouvoir.PP;
                if (coutPouvoir.GeneratePresence() > 0)
                {
                    LabelPres.Text = "" + coutPouvoir.Presence;
                }
                else
                {
                    LabelPres.Text = "NA";
                }
            }
            else
            {
                ButtonSave.Enabled = false;

                LabelNiveau.Text = "NA";
                LabelPP.Text = "NA";
                LabelPres.Text = "NA";
            }

            
        }

        private void creerPouvoir()
        {
            switch (ComboBoxSelectPouvoir.SelectedIndex)
            {
                case 1:
                    Qualite.Combat = ComboBoxSelectBonus.SelectedIndex;
                    Qualite.Generale = 0;
                    break;
                case 2:
                    Qualite.Generale = ComboBoxSelectBonus.SelectedIndex;
                    Qualite.Combat = 0;
                    break;
            }
        }

        private void FormFacetteQualite_Load(object sender, EventArgs e)
        {
            if (modification)
            {
                if (importQualite.Combat != 0)
                {
                    ComboBoxSelectPouvoir.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importQualite.Combat;
                }
                else if (importQualite.Generale != 0)
                {
                    ComboBoxSelectPouvoir.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importQualite.Generale;
                }
                else
                {
                    ComboBoxSelectPouvoir.SelectedIndex = 0;
                }
                ComboBoxSelectPouvoir.Enabled = false;
            }
        }

        public DialogResult ShowDialog(ClassFacetteQualite facette)
        {
            modification = true;

            importQualite = facette;

            return ShowDialog();
        }
    }
}
