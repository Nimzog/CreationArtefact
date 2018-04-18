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
    public partial class FormFacetteMagieInnee : Form
    {
        public bool CloseSaveCancel;
        public ClassFacetteMagieInnee MagieInnee;
        FormAjoutSortMagieInnee ajoutSortMagieInnee = null;
        int previousIndexPouv;

        public FormFacetteMagieInnee()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            MagieInnee = new ClassFacetteMagieInnee();
            previousIndexPouv = 0;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteMagieInnee;

            LabelModificateur.Visible = false;

            //mod de compétence de lancement
            CheckBoxResultat.Visible = false;
            CheckBoxResultat.Enabled = false;

            //mod de lanceur de sort
            CheckBoxSansLeDon.Visible = false;
            CheckBoxSansLeDon.Enabled = false;
            CheckBoxAMRDouble.Visible = false;
            CheckBoxAMRDouble.Enabled = false;
            CheckBoxInne.Visible = false;
            CheckBoxInne.Enabled = false;
            CheckBoxCoutReduit.Visible = false;
            CheckBoxCoutReduit.Enabled = false;
            CheckBoxAutonomie.Visible = false;
            CheckBoxAutonomie.Enabled = false;

            //mod de sort automatique
            LabelUtilisation.Visible = false;
            NumericUpDownUtilisation.Visible = false;
            NumericUpDownUtilisation.Enabled = false;
            CheckBoxIllimite.Visible = false;
            CheckBoxIllimite.Enabled = false;
            CheckBoxRechargeReduite.Visible = false;
            CheckBoxRechargeReduite.Enabled = false;
            LabelCondition.Visible = false;
            TextBoxCondition.Visible = false;
            TextBoxCondition.Enabled = false;
            NumericUpDownCondition.Visible = false;
            NumericUpDownCondition.Enabled = false;

            //commun sort auto et lanceur
            LabelListeSorts.Visible = false;
            RichTextBoxListeSort.Visible = false;
            RichTextBoxListeSort.Text = "";
            ButtonAjoutSort.Visible = false;
            ButtonAjoutSort.Enabled = false;

            ComboBoxSelectBonus.Text = "Choisir...";
            ComboBoxSelectBonus.Enabled = false;

            buttonCancel.Location = new Point(129, 92);
            ButtonSave.Location = new Point(12, 92);
            this.Size = new Size(400, 163);

            //generer les couts et mettre a jour les labels
            ButtonSave.Enabled = false;

            LabelNiveau.Text = "NA";
            LabelPP.Text = "NA";
            LabelPres.Text = "NA";
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                if (ComboBoxSelectPouv.SelectedIndex != previousIndexPouv)
                {
                    MagieInnee = new ClassFacetteMagieInnee();
                    previousIndexPouv = ComboBoxSelectPouv.SelectedIndex;
                }
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = true;

                        //mod de compétence de lancement
                        CheckBoxResultat.Visible = false;
                        CheckBoxResultat.Enabled = false;

                        //mod de lanceur de sort
                        CheckBoxSansLeDon.Visible = false;
                        CheckBoxSansLeDon.Enabled = false;
                        CheckBoxAMRDouble.Visible = false;
                        CheckBoxAMRDouble.Enabled = false;
                        CheckBoxInne.Visible = false;
                        CheckBoxInne.Enabled = false;
                        CheckBoxCoutReduit.Visible = false;
                        CheckBoxCoutReduit.Enabled = false;
                        CheckBoxAutonomie.Visible = false;
                        CheckBoxAutonomie.Enabled = false;

                        //mod de sort automatique
                        LabelUtilisation.Visible = true;
                        NumericUpDownUtilisation.Visible = true;
                        NumericUpDownUtilisation.Enabled = true;
                        CheckBoxIllimite.Visible = true;
                        CheckBoxIllimite.Enabled = true;
                        CheckBoxRechargeReduite.Visible = true;
                        CheckBoxRechargeReduite.Enabled = true;
                        LabelCondition.Visible = true;
                        TextBoxCondition.Visible = true;
                        TextBoxCondition.Enabled = true;
                        NumericUpDownCondition.Visible = true;
                        NumericUpDownCondition.Enabled = true;

                        //commun sort auto et lanceur
                        LabelListeSorts.Visible = true;
                        RichTextBoxListeSort.Visible = true;
                        RichTextBoxListeSort.Text = "";
                        ButtonAjoutSort.Visible = true;
                        ButtonAjoutSort.Enabled = true;

                        ComboBoxSelectBonus.Text = "Choisir...";
                        ComboBoxSelectBonus.Enabled = false;

                        buttonCancel.Location = new Point(129, 214);
                        ButtonSave.Location = new Point(12, 214);
                        this.Size = new Size(554, 285);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = true;

                        //mod de compétence de lancement
                        CheckBoxResultat.Visible = false;
                        CheckBoxResultat.Enabled = false;

                        //mod de lanceur de sort
                        CheckBoxSansLeDon.Visible = true;
                        CheckBoxSansLeDon.Enabled = true;
                        CheckBoxAMRDouble.Visible = true;
                        CheckBoxAMRDouble.Enabled = true;
                        CheckBoxInne.Visible = true;
                        CheckBoxInne.Enabled = true;
                        CheckBoxCoutReduit.Visible = true;
                        CheckBoxCoutReduit.Enabled = true;
                        CheckBoxAutonomie.Visible = true;
                        CheckBoxAutonomie.Enabled = true;

                        //mod de sort automatique
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxRechargeReduite.Visible = false;
                        CheckBoxRechargeReduite.Enabled = false;
                        LabelCondition.Visible = false;
                        TextBoxCondition.Visible = false;
                        TextBoxCondition.Enabled = false;
                        NumericUpDownCondition.Visible = false;
                        NumericUpDownCondition.Enabled = false;

                        //commun sort auto et lanceur
                        LabelListeSorts.Visible = true;
                        RichTextBoxListeSort.Visible = true;
                        RichTextBoxListeSort.Text = "";
                        ButtonAjoutSort.Visible = true;
                        ButtonAjoutSort.Enabled = true;

                        ComboBoxSelectBonus.Text = "Choisir...";
                        ComboBoxSelectBonus.Enabled = false;

                        buttonCancel.Location = new Point(129, 249);
                        ButtonSave.Location = new Point(12, 249);
                        this.Size = new Size(554, 320);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = true;

                        //mod de compétence de lancement
                        CheckBoxResultat.Visible = true;
                        CheckBoxResultat.Enabled = true;

                        //mod de lanceur de sort
                        CheckBoxSansLeDon.Visible = false;
                        CheckBoxSansLeDon.Enabled = false;
                        CheckBoxAMRDouble.Visible = false;
                        CheckBoxAMRDouble.Enabled = false;
                        CheckBoxInne.Visible = false;
                        CheckBoxInne.Enabled = false;
                        CheckBoxCoutReduit.Visible = false;
                        CheckBoxCoutReduit.Enabled = false;
                        CheckBoxAutonomie.Visible = false;
                        CheckBoxAutonomie.Enabled = false;

                        //mod de sort automatique
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxRechargeReduite.Visible = false;
                        CheckBoxRechargeReduite.Enabled = false;
                        LabelCondition.Visible = false;
                        TextBoxCondition.Visible = false;
                        TextBoxCondition.Enabled = false;
                        NumericUpDownCondition.Visible = false;
                        NumericUpDownCondition.Enabled = false;

                        //commun sort auto et lanceur
                        LabelListeSorts.Visible = false;
                        RichTextBoxListeSort.Visible = false;
                        RichTextBoxListeSort.Text = "";
                        ButtonAjoutSort.Visible = false;
                        ButtonAjoutSort.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.CompLancement;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 122);
                        ButtonSave.Location = new Point(12, 122);
                        this.Size = new Size(400, 199);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        LabelModificateur.Visible = false;

                        //mod de compétence de lancement
                        CheckBoxResultat.Visible = false;
                        CheckBoxResultat.Enabled = false;

                        //mod de lanceur de sort
                        CheckBoxSansLeDon.Visible = false;
                        CheckBoxSansLeDon.Enabled = false;
                        CheckBoxAMRDouble.Visible = false;
                        CheckBoxAMRDouble.Enabled = false;
                        CheckBoxInne.Visible = false;
                        CheckBoxInne.Enabled = false;
                        CheckBoxCoutReduit.Visible = false;
                        CheckBoxCoutReduit.Enabled = false;
                        CheckBoxAutonomie.Visible = false;
                        CheckBoxAutonomie.Enabled = false;

                        //mod de sort automatique
                        LabelUtilisation.Visible = false;
                        NumericUpDownUtilisation.Visible = false;
                        NumericUpDownUtilisation.Enabled = false;
                        CheckBoxIllimite.Visible = false;
                        CheckBoxIllimite.Enabled = false;
                        CheckBoxRechargeReduite.Visible = false;
                        CheckBoxRechargeReduite.Enabled = false;
                        LabelCondition.Visible = false;
                        TextBoxCondition.Visible = false;
                        TextBoxCondition.Enabled = false;
                        NumericUpDownCondition.Visible = false;
                        NumericUpDownCondition.Enabled = false;

                        //commun sort auto et lanceur
                        LabelListeSorts.Visible = false;
                        RichTextBoxListeSort.Visible = false;
                        RichTextBoxListeSort.Text = "";
                        ButtonAjoutSort.Visible = false;
                        ButtonAjoutSort.Enabled = false;

                        ComboBoxSelectBonus.Text = "Choisir...";
                        ComboBoxSelectBonus.Enabled = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 163);

                        //generer les couts et mettre a jour les labels
                        ButtonSave.Enabled = false;

                        LabelNiveau.Text = "NA";
                        LabelPP.Text = "NA";
                        LabelPres.Text = "NA";
                        break;
                }
            }
            else
            {
                previousIndexPouv = ComboBoxSelectPouv.SelectedIndex;

                LabelModificateur.Visible = false;

                //mod de compétence de lancement
                CheckBoxResultat.Visible = false;
                CheckBoxResultat.Enabled = false;

                //mod de lanceur de sort
                CheckBoxSansLeDon.Visible = false;
                CheckBoxSansLeDon.Enabled = false;
                CheckBoxAMRDouble.Visible = false;
                CheckBoxAMRDouble.Enabled = false;
                CheckBoxInne.Visible = false;
                CheckBoxInne.Enabled = false;
                CheckBoxCoutReduit.Visible = false;
                CheckBoxCoutReduit.Enabled = false;
                CheckBoxAutonomie.Visible = false;
                CheckBoxAutonomie.Enabled = false;

                //mod de sort automatique
                LabelUtilisation.Visible = false;
                NumericUpDownUtilisation.Visible = false;
                NumericUpDownUtilisation.Enabled = false;
                CheckBoxIllimite.Visible = false;
                CheckBoxIllimite.Enabled = false;
                CheckBoxRechargeReduite.Visible = false;
                CheckBoxRechargeReduite.Enabled = false;
                LabelCondition.Visible = false;
                TextBoxCondition.Visible = false;
                TextBoxCondition.Enabled = false;
                NumericUpDownCondition.Visible = false;
                NumericUpDownCondition.Enabled = false;

                //commun sort auto et lanceur
                LabelListeSorts.Visible = false;
                RichTextBoxListeSort.Visible = false;
                RichTextBoxListeSort.Text = "";
                ButtonAjoutSort.Visible = false;
                ButtonAjoutSort.Enabled = false;

                ComboBoxSelectBonus.Text = "Choisir...";
                ComboBoxSelectBonus.Enabled = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 163);

                //generer les couts et mettre a jour les labels
                ButtonSave.Enabled = false;

                LabelNiveau.Text = "NA";
                LabelPP.Text = "NA";
                LabelPres.Text = "NA";
            }
        }

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxResultat_CheckedChanged(object sender, EventArgs e)
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

        private void CheckBoxRechargeReduite_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
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

        private void TextBoxCondition_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCondition.Text.Count() != 0)
            {
                NumericUpDownCondition.Enabled = true;
            }
            else
            {
                NumericUpDownCondition.Enabled = false;
            }
            majForm();
        }

        private void NumericUpDownCondition_ValueChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void creerPouvoir()
        {
            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    if (CheckBoxIllimite.Checked)
                    {
                        MagieInnee.Illimite = true;
                        MagieInnee.NBUtil = -1;
                    }
                    else
                    {
                        MagieInnee.Illimite = false;
                        MagieInnee.NBUtil = (int)NumericUpDownUtilisation.Value - 1;
                    }
                    if (CheckBoxRechargeReduite.Checked)
                    {
                        MagieInnee.RechargeReduite = true;
                    }
                    break;
                case 2:
                    if (CheckBoxAMRDouble.Checked)
                    {
                        MagieInnee.AMRDouble = true;
                    }
                    else
                    {
                        MagieInnee.AMRDouble = false;
                    }
                    if (CheckBoxAutonomie.Checked)
                    {
                        MagieInnee.Autonomie = true;
                    }
                    else
                    {
                        MagieInnee.Autonomie = false;
                    }
                    if (CheckBoxCoutReduit.Checked)
                    {
                        MagieInnee.CoutReduit = true;
                    }
                    if (CheckBoxInne.Checked)
                    {
                        MagieInnee.Inne = true;
                    }
                    else
                    {
                        MagieInnee.Inne = false;
                    }
                    if (CheckBoxSansLeDon.Checked)
                    {
                        MagieInnee.SansDon = true;
                    }
                    else
                    {
                        MagieInnee.SansDon = false;
                    }
                    break;
                case 3:
                    MagieInnee.CompLancement = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxResultat.Checked)
                    {
                        MagieInnee.ResulatFinal = true;
                    }
                    else
                    {
                        MagieInnee.ResulatFinal = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = MagieInnee.GenererCoutPouvoir();

                if (coutPouvoir.PP > 0 && coutPouvoir.Niveau > 0)
                {
                    ButtonSave.Enabled = true;

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

                    if (ComboBoxSelectPouv.SelectedIndex == 1)
                    {
                        RichTextBoxListeSort.Text = "";
                        foreach (ClassSort sort in MagieInnee.SortAutomatique)
                        {
                            RichTextBoxListeSort.Text += sort.DescriptionSort() + "\n";
                        }
                    }
                    else if (ComboBoxSelectPouv.SelectedIndex == 2)
                    {
                        RichTextBoxListeSort.Text = "";
                        foreach (ClassSort sort in MagieInnee.LanceurSort)
                        {
                            RichTextBoxListeSort.Text += sort.DescriptionSort() + "\n";
                        }
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
            else
            {
                ButtonSave.Enabled = false;

                LabelNiveau.Text = "NA";
                LabelPP.Text = "NA";
                LabelPres.Text = "NA";
            }
        }

        private void CheckBoxSansLeDon_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxAMRDouble_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxInne_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxCoutReduit_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxAutonomie_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ButtonAjoutSort_Click(object sender, EventArgs e)
        {
            if (ajoutSortMagieInnee != null)
            {
                ajoutSortMagieInnee.Dispose();
            }
            ajoutSortMagieInnee = new FormAjoutSortMagieInnee();
            ajoutSortMagieInnee.ShowDialog(this);
            if (ajoutSortMagieInnee.CloseSaveCancel)
            {
                if (ComboBoxSelectPouv.SelectedIndex == 1)
                {
                    MagieInnee.SortAutomatique.Add(ajoutSortMagieInnee.Sort);
                }
                else if (ComboBoxSelectPouv.SelectedIndex == 2)
                {
                    MagieInnee.LanceurSort.Add(ajoutSortMagieInnee.Sort);
                }
            }
            majForm();
        }
    }
}
