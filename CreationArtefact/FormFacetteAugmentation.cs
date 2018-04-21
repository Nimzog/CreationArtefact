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
    public partial class FormFacetteAugmentation : Form
    {
        public bool CloseSaveCancel,
            Modification;
        public ClassFacetteAugmentation Augmentation,
            importAgmentation;

        public FormFacetteAugmentation()
        {
            InitializeComponent();

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteAugmentation;
            ComboBoxChampSec.DataSource = Properties.Settings.Default.ChampSec;

            Modification = false;
        }

        public DialogResult ShowDialog(ClassFacetteAugmentation augmentation)
        {
            Modification = true;

            importAgmentation = augmentation;
            
            return ShowDialog();
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = false;

                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = false;
                        TextBoxCompetence.Visible = false;
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc530;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = false;

                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = false;
                        TextBoxCompetence.Visible = false;
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Regeneration;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = false;

                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = false;
                        TextBoxCompetence.Visible = false;
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Mouvement;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        LabelModificateur.Visible = false;

                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = true;
                        TextBoxCompetence.Visible = true;
                        TextBoxCompetence.Text = "";
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.AugCompSec;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        LabelModificateur.Visible = true;

                        CheckBoxConfrontation.Enabled = true;
                        CheckBoxConfrontation.Visible = true;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = false;
                        TextBoxCompetence.Visible = false;
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.AugCarac;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        LabelModificateur.Visible = false;

                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;
                        CheckBoxConfrontation.Checked = false;

                        LabelCompChamp.Visible = false;
                        TextBoxCompetence.Visible = false;
                        TextBoxCompetence.Enabled = false;
                        ComboBoxChampSec.Visible = false;
                        ComboBoxChampSec.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.SubstiCarac;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        CheckBoxConfrontation.Enabled = false;
                        CheckBoxConfrontation.Visible = false;

                        LabelModificateur.Visible = false;
                        ComboBoxSelectBonus.Enabled = false;

                        LabelModificateur.Visible = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

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
                CheckBoxConfrontation.Enabled = false;
                CheckBoxConfrontation.Visible = false;

                LabelModificateur.Visible = false;
                ComboBoxSelectBonus.Enabled = false;

                LabelModificateur.Visible = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 162);

                //generer les couts et mettre a jour les labels
                ButtonSave.Enabled = false;

                LabelNiveau.Text = "NA";
                LabelPP.Text = "NA";
                LabelPres.Text = "NA";
            }
        }

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex == 4)
            {
                if (ComboBoxSelectBonus.SelectedIndex > 5)
                {
                    TextBoxCompetence.Visible = false;
                    TextBoxCompetence.Enabled = false;
                    ComboBoxChampSec.Visible = true;
                    ComboBoxChampSec.Enabled = true;
                }
                else if (ComboBoxSelectBonus.SelectedIndex <= 5 && ComboBoxSelectBonus.SelectedIndex > 0)
                {
                    TextBoxCompetence.Visible = true;
                    TextBoxCompetence.Enabled = true;
                    ComboBoxChampSec.Visible = false;
                    ComboBoxChampSec.Enabled = false;
                }
                else
                {
                    TextBoxCompetence.Visible = true;
                    TextBoxCompetence.Enabled = false;
                    ComboBoxChampSec.Visible = false;
                    ComboBoxChampSec.Enabled = false;
                }
            }
            majForm();
        }

        private void CheckBoxConfrontation_CheckedChanged(object sender, EventArgs e)
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

        private void creerPouvoir()
        {
            Augmentation = new ClassFacetteAugmentation();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Augmentation.Initiative = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 2:
                    Augmentation.Regeneration = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 3:
                    Augmentation.AugDeplacement = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 4:
                    Augmentation.AugCompSec = ComboBoxSelectBonus.SelectedIndex;
                    if (ComboBoxSelectBonus.SelectedIndex > 5 && ComboBoxChampSec.SelectedIndex != 0)
                    {
                        switch (ComboBoxChampSec.SelectedIndex)
                        {
                            case 1:
                                Augmentation.Competence = "Athlétique";
                                break;
                            case 2:
                                Augmentation.Competence = "Sociale";
                                break;
                            case 3:
                                Augmentation.Competence = "Sensorielle";
                                break;
                            case 4:
                                Augmentation.Competence = "Intellectuelle";
                                break;
                            case 5:
                                Augmentation.Competence = "Vitale";
                                break;
                            case 6:
                                Augmentation.Competence = "Clandestine";
                                break;
                            case 7:
                                Augmentation.Competence = "Créative";
                                break;

                        }
                    }
                    else if (ComboBoxSelectBonus.SelectedIndex < 5 && ComboBoxSelectBonus.SelectedIndex > 0 &&
                        TextBoxCompetence.Text.Count() != 0)
                    {
                        Augmentation.Competence = TextBoxCompetence.Text;
                    }
                    else
                    {
                        if (ComboBoxSelectBonus.SelectedIndex > 5)
                        {
                            MessageBox.Show("Choisissez un champ secondaire.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxChampSec.Focus();
                        }
                        else if (ComboBoxSelectBonus.SelectedIndex <= 5 && ComboBoxSelectBonus.SelectedIndex > 0)
                        {
                            MessageBox.Show("Choisissez une compétence secondaire.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TextBoxCompetence.Focus();
                        }
                        
                    }
                    break;
                case 5:
                    Augmentation.AugCarac = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxConfrontation.Checked)
                    {
                        Augmentation.Confontation = true;
                    }
                    break;
                case 6:
                    Augmentation.SubstiCarac = ComboBoxSelectBonus.SelectedIndex;
                    break;
                default:
                    break;
            }

            Augmentation.GenererCoutPouvoir();
        }

        private void majForm()
        {
            if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                LabelNiveau.Text = "" + Augmentation.CoutPouvoir.Niveau;
                LabelPP.Text = "" + Augmentation.CoutPouvoir.PP;
                if (Augmentation.CoutPouvoir.GeneratePresence() > 0)
                {
                    LabelPres.Text = "" + Augmentation.CoutPouvoir.Presence;
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

        private void FormFacetteAugmentation_Load(object sender, EventArgs e)
        {
            if (Modification)
            {
                if (importAgmentation.Initiative != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.Initiative;
                }
                else if (importAgmentation.Regeneration !=0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.Regeneration;
                }
                else if (importAgmentation.AugDeplacement != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.AugDeplacement;
                }
                else if (importAgmentation.AugCompSec != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.AugCompSec;
                    if (ComboBoxSelectBonus.SelectedIndex < 5 && ComboBoxSelectBonus.SelectedIndex > 0)
                    {
                        TextBoxCompetence.Text = importAgmentation.Competence;
                    }
                    else
                    {
                        if (importAgmentation.Competence.CompareTo("Athlétique") == 0)
                            ComboBoxChampSec.SelectedIndex = 1;
                        else if (importAgmentation.Competence.CompareTo("Sociale") == 0)
                            ComboBoxChampSec.SelectedIndex = 2;
                        else if (importAgmentation.Competence.CompareTo("Sensorielle") == 0)
                            ComboBoxChampSec.SelectedIndex = 3;
                        else if (importAgmentation.Competence.CompareTo("Intellectuelle") == 0)
                            ComboBoxChampSec.SelectedIndex = 4;
                        else if (importAgmentation.Competence.CompareTo("Vitale") == 0)
                            ComboBoxChampSec.SelectedIndex = 5;
                        else if (importAgmentation.Competence.CompareTo("Clandestine") == 0)
                            ComboBoxChampSec.SelectedIndex = 6;
                        else if (importAgmentation.Competence.CompareTo("Créative") == 0)
                            ComboBoxChampSec.SelectedIndex = 7;
                    }
                }
                else if (importAgmentation.AugCarac != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 5;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.AugCarac;
                    if (importAgmentation.Confontation)
                    {
                        CheckBoxConfrontation.Checked = true;
                    }
                }
                else if (importAgmentation.SubstiCarac != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 6;
                    ComboBoxSelectBonus.SelectedIndex = importAgmentation.SubstiCarac;
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
                ComboBoxSelectPouv.Enabled = false;
            }
        }

        private void ComboBoxChampSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }
    }
}
