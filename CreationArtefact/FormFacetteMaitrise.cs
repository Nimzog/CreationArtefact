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
    public partial class FormFacetteMaitrise : Form
    {
        public bool CloseSaveCancel;
        public ClassFacetteMaitrise Maitrise;

        public FormFacetteMaitrise()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            Maitrise = new ClassFacetteMaitrise();

            ComboBoxCarac.DataSource = Properties.Settings.Default.LienAccumulation;
            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteMaitrise;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = true;
                        //modificateur accumulation
                        ComboBoxCarac.Visible = true;
                        ComboBoxCarac.Enabled = false;
                        LabelCarac.Visible = true;
                        RadioButtonAucune.Visible = true;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Visible = true;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Visible = true;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        LabelNom.Visible = false;
                        TextBoxNomTech.Visible = false;
                        TextBoxNomTech.Enabled = false;
                        LabelDI.Visible = false;
                        NumericUpDownDI.Visible = false;
                        NumericUpDownDI.Enabled = false;
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        CheckBoxModRecharge.Visible = false;
                        LabelPrep.Visible = false;
                        NumericUpDownPrep.Visible = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        CheckBoxConsomation.Visible = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFuite.Visible = false;
                        CheckBoxModFiltre.Enabled = false;
                        CheckBoxModFiltre.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.AccumulationKi;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 197);
                        ButtonSave.Location = new Point(12, 197);
                        this.Size = new Size(400, 267);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = true;
                        //modificateur accumulation
                        ComboBoxCarac.Visible = false;
                        ComboBoxCarac.Enabled = false;
                        LabelCarac.Visible = false;
                        RadioButtonAucune.Visible = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Visible = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Visible = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        LabelNom.Visible = true;
                        TextBoxNomTech.Visible = true;
                        TextBoxNomTech.Enabled = false;
                        LabelDI.Visible = true;
                        NumericUpDownDI.Visible = true;
                        NumericUpDownDI.Enabled = false;
                        LabelUtilisation.Visible = true;
                        NumericUpDownUtilisation.Visible = true;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = true;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        CheckBoxModRecharge.Visible = true;
                        LabelPrep.Visible = true;
                        NumericUpDownPrep.Visible = true;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        CheckBoxConsomation.Visible = true;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFuite.Visible = false;
                        CheckBoxModFiltre.Enabled = false;
                        CheckBoxModFiltre.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.TechKi;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 218);
                        ButtonSave.Location = new Point(12, 218);
                        this.Size = new Size(400, 288);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = true;
                        //modificateur accumulation
                        ComboBoxCarac.Visible = false;
                        ComboBoxCarac.Enabled = false;
                        LabelCarac.Visible = false;
                        RadioButtonAucune.Visible = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Visible = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Visible = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        LabelNom.Visible = false;
                        TextBoxNomTech.Visible = false;
                        TextBoxNomTech.Enabled = false;
                        LabelDI.Visible = false;
                        NumericUpDownDI.Visible = false;
                        NumericUpDownDI.Enabled = false;
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        CheckBoxModRecharge.Visible = false;
                        LabelPrep.Visible = false;
                        NumericUpDownPrep.Visible = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        CheckBoxConsomation.Visible = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFuite.Visible = true;
                        CheckBoxModFiltre.Enabled = false;
                        CheckBoxModFiltre.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ReserveKi;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 145);
                        ButtonSave.Location = new Point(12, 145);
                        this.Size = new Size(400, 215);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        LabelModificateur.Visible = false;
                        //modificateur accumulation
                        ComboBoxCarac.Visible = false;
                        ComboBoxCarac.Enabled = false;
                        LabelCarac.Visible = false;
                        RadioButtonAucune.Visible = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Visible = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Visible = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        LabelNom.Visible = false;
                        TextBoxNomTech.Visible = false;
                        TextBoxNomTech.Enabled = false;
                        LabelDI.Visible = false;
                        NumericUpDownDI.Visible = false;
                        NumericUpDownDI.Enabled = false;
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        CheckBoxModRecharge.Visible = false;
                        LabelPrep.Visible = false;
                        NumericUpDownPrep.Visible = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        CheckBoxConsomation.Visible = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFuite.Visible = false;
                        CheckBoxModFiltre.Enabled = false;
                        CheckBoxModFiltre.Visible = false;

                        ComboBoxSelectBonus.Enabled = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                }
            }
            else
            {
                LabelModificateur.Visible = false;
                //modificateur accumulation
                ComboBoxCarac.Visible = false;
                ComboBoxCarac.Enabled = false;
                LabelCarac.Visible = false;
                RadioButtonAucune.Visible = false;
                RadioButtonAucune.Enabled = false;
                RadioButtonBadRecup.Visible = false;
                RadioButtonBadRecup.Enabled = false;
                RadioButtonRecupOnly.Visible = false;
                RadioButtonRecupOnly.Enabled = false;
                //modificateur technique de Ki
                LabelNom.Visible = false;
                TextBoxNomTech.Visible = false;
                TextBoxNomTech.Enabled = false;
                LabelDI.Visible = false;
                NumericUpDownDI.Visible = false;
                NumericUpDownDI.Enabled = false;
                LabelUtilisation.Visible = false;
                NumericUpDownUtilisation.Visible = false;
                NumericUpDownUtilisation.Enabled = false;
                CheckBoxIllimite.Visible = false;
                CheckBoxIllimite.Enabled = false;
                CheckBoxModRecharge.Enabled = false;
                CheckBoxModRecharge.Visible = false;
                LabelPrep.Visible = false;
                NumericUpDownPrep.Visible = false;
                NumericUpDownPrep.Enabled = false;
                CheckBoxConsomation.Enabled = false;
                CheckBoxConsomation.Visible = false;
                //modificateur réserve ki
                CheckBoxModFuite.Enabled = false;
                CheckBoxModFuite.Visible = false;
                CheckBoxModFiltre.Enabled = false;
                CheckBoxModFiltre.Visible = false;

                ComboBoxSelectBonus.Enabled = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 162);

                //generer les couts et mettre a jour les labels
                majForm();
            }
        }

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectBonus.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        //modificateur accumulation
                        ComboBoxCarac.Enabled = true;
                        RadioButtonAucune.Enabled = true;
                        RadioButtonAucune.Checked = true;
                        RadioButtonBadRecup.Enabled = true;
                        RadioButtonRecupOnly.Enabled = true;
                        //modificateur technique de Ki
                        TextBoxNomTech.Enabled = false;
                        NumericUpDownDI.Enabled = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFiltre.Enabled = false;
                        majForm();
                        break;
                    case 2:
                        //modificateur accumulation
                        ComboBoxCarac.Enabled = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        TextBoxNomTech.Enabled = true;
                        NumericUpDownDI.Enabled = true;
                        NumericUpDownUtilisation.Enabled = true;
                        CheckBoxIllimite.Enabled = true;
                        CheckBoxModRecharge.Enabled = true;
                        NumericUpDownPrep.Enabled = true;
                        CheckBoxConsomation.Enabled = true;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFiltre.Enabled = false;
                        majForm();
                        break;
                    case 3:
                        //modificateur accumulation
                        ComboBoxCarac.Enabled = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        TextBoxNomTech.Enabled = false;
                        NumericUpDownDI.Enabled = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = true;
                        CheckBoxModFiltre.Enabled = true;
                        majForm();
                        break;
                    default:
                        //modificateur accumulation
                        ComboBoxCarac.Enabled = false;
                        RadioButtonAucune.Enabled = false;
                        RadioButtonBadRecup.Enabled = false;
                        RadioButtonRecupOnly.Enabled = false;
                        //modificateur technique de Ki
                        TextBoxNomTech.Enabled = false;
                        NumericUpDownDI.Enabled = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxModRecharge.Enabled = false;
                        NumericUpDownPrep.Enabled = false;
                        CheckBoxConsomation.Enabled = false;
                        //modificateur réserve ki
                        CheckBoxModFuite.Enabled = false;
                        CheckBoxModFiltre.Enabled = false;
                        majForm();
                        break;
                }
            }
            else
            {
                //modificateur accumulation
                ComboBoxCarac.Enabled = false;
                RadioButtonAucune.Enabled = false;
                RadioButtonBadRecup.Enabled = false;
                RadioButtonRecupOnly.Enabled = false;
                //modificateur technique de Ki
                TextBoxNomTech.Enabled = false;
                NumericUpDownDI.Enabled = false;
                NumericUpDownUtilisation.Enabled = false;
                CheckBoxIllimite.Enabled = false;
                CheckBoxModRecharge.Enabled = false;
                NumericUpDownPrep.Enabled = false;
                CheckBoxConsomation.Enabled = false;
                //modificateur réserve ki
                CheckBoxModFuite.Enabled = false;
                CheckBoxModFiltre.Enabled = false;
                majForm();
            }
        }

        private void NumericUpDownUtilisation_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDownUtilisation.Value > 1)
            {
                CheckBoxIllimite.Enabled = false;
            }
            else
            {
                CheckBoxIllimite.Enabled = true;
            }
            majForm();
        }

        private void CheckBoxIllimite_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxIllimite.Checked)
            {
                NumericUpDownUtilisation.Enabled = false;
            }
            else
            {
                NumericUpDownUtilisation.Enabled = true;
            }
            majForm();
        }

        private void NumericUpDownPrep_ValueChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxModfuite_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxModFiltre_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxModRecharge_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxConsomation_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
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

        private void ComboBoxCarac_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void creerPouvoir()
        {
            Maitrise = new ClassFacetteMaitrise();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Maitrise.AccumulationKi = ComboBoxSelectBonus.SelectedIndex;
                    if (ComboBoxCarac.SelectedIndex != 0)
                    {
                        Maitrise.CaracLie = ComboBoxCarac.SelectedIndex;
                    }
                    else
                    {
                        MessageBox.Show("Choisissez une(des) caractéristique(s) valide.", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ComboBoxCarac.Focus();
                    }
                    if (RadioButtonBadRecup.Checked)
                    {
                        Maitrise.BadRecuperate = true;
                    }
                    else if (RadioButtonRecupOnly.Checked)
                    {
                        Maitrise.RecupOnly = true;
                    }
                    break;
                case 2:
                    if (ComboBoxSelectBonus.SelectedIndex != 0)
                    {
                        Maitrise.TechKi = new ClassTechKi();
                        if (TextBoxNomTech.Text.Count() > 0)
                        {
                            Maitrise.TechKi.Nom = TextBoxNomTech.Text;
                        }
                        else
                        {
                            MessageBox.Show("Donné un nom à la technique.", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TextBoxNomTech.Focus();
                        }
                        Maitrise.TechKi.Niveau = ComboBoxSelectBonus.SelectedIndex;
                        Maitrise.TechKi.DI = (int)NumericUpDownDI.Value;
                    }
                    if (CheckBoxIllimite.Checked)
                    {
                        Maitrise.Illimite = true;
                    }
                    else
                    {
                        Maitrise.NBUtil = (int)NumericUpDownUtilisation.Value - 1;
                    }
                    if (CheckBoxModRecharge.Checked)
                    {
                        Maitrise.RechargeReduite = true;
                    }
                    if (NumericUpDownPrep.Value > 0)
                    {
                        Maitrise.Prep = (int)NumericUpDownPrep.Value;
                    }
                    if (CheckBoxConsomation.Checked)
                    {
                        Maitrise.Consommation = true;
                    }
                    break;
                case 3:
                    Maitrise.ReserveKi = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxModFuite.Checked)
                    {
                        Maitrise.Fuite = true;
                    }
                    if (CheckBoxModFiltre.Checked)
                    {
                        Maitrise.Filtre = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = Maitrise.GenererCoutPouvoir();

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

        private void TextBoxNomTech_TextChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void NumericUpDownDI_ValueChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonRecupOnly_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonBadRecup_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonAucune_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }
    }
}
