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
                coutPouvoir = Qualite.GenererCoutPouvoir();

                LabelNiveau.Text = "" + coutPouvoir.Niveau;
                LabelPP.Text = "" + coutPouvoir.PP;
                switch (coutPouvoir.Niveau)
                {
                    case 1:
                        LabelPres.Text = "10";
                        break;
                    case 2:
                        LabelPres.Text = "15";
                        break;
                    case 3:
                        LabelPres.Text = "25";
                        break;
                    case 4:
                        LabelPres.Text = "60";
                        break;
                    case 5:
                        LabelPres.Text = "100";
                        break;
                    default:
                        break;
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
    }
}
