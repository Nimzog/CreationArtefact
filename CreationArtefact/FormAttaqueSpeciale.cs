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
    public partial class FormAttaqueSpeciale : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel = false;
        /// <summary>
        /// 
        /// </summary>
        public ClassAttaqueSpec AttaqueSpec;

        /// <summary>
        /// 
        /// </summary>
        public FormAttaqueSpeciale()
        {
            InitializeComponent();

            CloseSaveCancel = false;

            //initialisation des combos boxes
            ComboBoxCompOffensive.DataSource = Properties.Settings.Default.CompOffAttSpec;
            ComboBoxDegat.DataSource = Properties.Settings.Default.DegatAttSpec;
            ComboBoxDistance.DataSource = Properties.Settings.Default.DistanceAttSpec;
            ComboBoxPreparation.DataSource = Properties.Settings.Default.PrepAttSpec;
            ComboBoxUtilisation.DataSource = Properties.Settings.Default.NBJourAttSpec;
            ComboBoxZone.DataSource = Properties.Settings.Default.ZoneAttSpec;

            AttaqueSpec = new ClassAttaqueSpec();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            MAJCoutPouvoir();

            CloseSaveCancel = true;

            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseSaveCancel = false;

            this.Close();
        }

        private void ComboBoxEnchantee_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxElementaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxExterminateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxAssaut_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxCritique_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxDegat_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxCompOffensive_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxDestArmure_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void CreerSpecAtt()
        {
            AttaqueSpec = new ClassAttaqueSpec();

            AttaqueSpec.CompOff = ComboBoxCompOffensive.SelectedIndex;
            AttaqueSpec.Degat = ComboBoxDegat.SelectedIndex;
            AttaqueSpec.Distance = ComboBoxDistance.SelectedIndex;
            AttaqueSpec.NbJour = ComboBoxUtilisation.SelectedIndex;
            AttaqueSpec.Nom = TextBoxNomAttaque.Text;
            AttaqueSpec.Prep = ComboBoxPreparation.SelectedIndex;
            AttaqueSpec.ResFinal = CheckBoxResFinal.Checked;
            AttaqueSpec.Zone = ComboBoxZone.SelectedIndex;
        }

        private void MAJCoutPouvoir()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();
            

            if (ComboBoxDegat.SelectedIndex != 0 || ComboBoxDistance.SelectedIndex != 0 ||
                ComboBoxZone.SelectedIndex != 0 || ComboBoxCompOffensive.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;

                CreerSpecAtt();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = AttaqueSpec.GetCoutPouvoir();

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
                if (coutPouvoir.PP <= 0 && this.Visible)
                {
                    ButtonSave.Enabled = false;
                    MessageBox.Show("Cout en points de pouvoirs(PP) nul ou négatif.", Properties.Settings.Default.Erreur,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComboBoxPreparation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void ComboBoxUtilisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void CheckBoxExterminateur_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void CheckBoxResFinal_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void RadioButtonAucunMod_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void RadioButtonVariable_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void RadioButtonCombine_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void RadioButtonPrimaire_CheckedChanged(object sender, EventArgs e)
        {
            MAJCoutPouvoir();
        }

        private void FormAttaqueSpeciale_Load(object sender, EventArgs e)
        {

        }
    }
}
