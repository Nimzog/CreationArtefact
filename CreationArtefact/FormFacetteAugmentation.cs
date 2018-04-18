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
        public ClassFacetteAugmentation Augmentation;

        public FormFacetteAugmentation()
        {
            InitializeComponent();

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteAugmentation;
            ComboBoxChampSec.DataSource = Properties.Settings.Default.ChampSec;

            Modification = false;
        }

        public DialogResult ShowDialog(ClassFacetteAugmentation augmentation)
        {
            DialogResult result;

            Modification = true;

            Augmentation = augmentation;

            result = ShowDialog();
            
            return result;
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
        }

        private void majForm()
        {
            if (!Modification)
            {
                ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

                if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
                {
                    ButtonSave.Enabled = true;
                    creerPouvoir();

                    //calculer les coûts du pouvoir à ajouter
                    coutPouvoir = Augmentation.GenererCoutPouvoir();

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
        }

        private void FormFacetteAugmentation_Load(object sender, EventArgs e)
        {
            if (Modification)
            {
                if (Augmentation.Initiative != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.Initiative;
                }
                else if (Augmentation.Regeneration !=0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.Regeneration;
                }
                else if (Augmentation.AugDeplacement != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.AugDeplacement;
                }
                else if (Augmentation.AugCompSec != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.AugCompSec;
                    if (ComboBoxSelectBonus.SelectedIndex < 5 && ComboBoxSelectBonus.SelectedIndex > 0)
                    {
                        TextBoxCompetence.Text = Augmentation.Competence;
                    }
                    else
                    {
                        if (Augmentation.Competence.CompareTo("Athlétique") == 0)
                            ComboBoxChampSec.SelectedIndex = 1;
                        else if (Augmentation.Competence.CompareTo("Sociale") == 0)
                            ComboBoxChampSec.SelectedIndex = 2;
                        else if (Augmentation.Competence.CompareTo("Sensorielle") == 0)
                            ComboBoxChampSec.SelectedIndex = 3;
                        else if (Augmentation.Competence.CompareTo("Intellectuelle") == 0)
                            ComboBoxChampSec.SelectedIndex = 4;
                        else if (Augmentation.Competence.CompareTo("Vitale") == 0)
                            ComboBoxChampSec.SelectedIndex = 5;
                        else if (Augmentation.Competence.CompareTo("Clandestine") == 0)
                            ComboBoxChampSec.SelectedIndex = 6;
                        else if (Augmentation.Competence.CompareTo("Créative") == 0)
                            ComboBoxChampSec.SelectedIndex = 7;
                    }
                }
                else if (Augmentation.AugCarac != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 5;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.AugCarac;
                    if (Augmentation.Confontation)
                    {
                        CheckBoxConfrontation.Checked = true;
                    }
                }
                else if (Augmentation.SubstiCarac != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 6;
                    ComboBoxSelectBonus.SelectedIndex = Augmentation.SubstiCarac;
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
            }
        }

        private void ComboBoxChampSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }
    }
}
