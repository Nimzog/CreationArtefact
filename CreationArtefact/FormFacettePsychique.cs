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
    public partial class FormFacettePsychique : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel;
        /// <summary>
        /// 
        /// </summary>
        public ClassFacettePsychique Psychique;
        bool modification;
        ClassFacettePsychique importPsy;


        public FormFacettePsychique()
        {
            InitializeComponent();

            Psychique = new ClassFacettePsychique();
            CloseSaveCancel = false;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacettePsychique;
            ComboBoxDiscipline.DataSource = Properties.Settings.Default.DiscplinePsy;

            modification = false;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = true;

                        ComboBoxDiscipline.Visible = true;
                        ComboBoxDiscipline.Enabled = false;
                        LabelDiscipline.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc530;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = true;

                        ComboBoxDiscipline.Visible = true;
                        ComboBoxDiscipline.Enabled = false;
                        LabelDiscipline.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = true;

                        ComboBoxDiscipline.Visible = true;
                        ComboBoxDiscipline.Enabled = false;
                        LabelDiscipline.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc510to30;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = false;

                        ComboBoxDiscipline.Visible = false;
                        ComboBoxDiscipline.Enabled = false;
                        LabelDiscipline.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc1010to50;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;

                        LabelModificateur.Visible = false;
                        ComboBoxSelectBonus.Enabled = false;

                        ComboBoxDiscipline.Visible = false;
                        ComboBoxDiscipline.Enabled = false;
                        LabelDiscipline.Visible = false;

                        LabelModificateur.Visible = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

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
                CheckBoxLimite.Enabled = false;
                CheckBoxLimite.Visible = false;

                LabelModificateur.Visible = false;
                ComboBoxSelectBonus.Enabled = false;

                ComboBoxDiscipline.Visible = false;
                ComboBoxDiscipline.Enabled = false;
                LabelDiscipline.Visible = false;

                LabelModificateur.Visible = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 165);

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

        private void CheckBoxLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxLimite.Checked)
            {
                ComboBoxDiscipline.Enabled = true;
                ComboBoxDiscipline.SelectedIndex = 0;
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        if (ComboBoxSelectBonus.SelectedIndex <= 1)
                        {
                            MessageBox.Show("Combinaison de pouvoir et faiblesse non compatible.", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxSelectBonus.Focus();
                        }
                        else
                            majForm();
                        break;
                    default:
                        majForm();
                        break;
                }
            }
            else
            {
                ComboBoxDiscipline.Enabled = false;
                majForm();
            }
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
            Psychique = new ClassFacettePsychique();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Psychique.Talent = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Psychique.Limite = true;
                        if (ComboBoxDiscipline.SelectedIndex != 0)
                        {
                            Psychique.Discipline = ComboBoxDiscipline.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxDiscipline.Focus();
                        }
                    }
                    break;
                case 2:
                    Psychique.ProjectionPsy = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Psychique.Limite = true;
                        if (ComboBoxDiscipline.SelectedIndex != 0)
                        {
                            Psychique.Discipline = ComboBoxDiscipline.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxDiscipline.Focus();
                        }
                    }
                    break;
                case 3:
                    Psychique.TestResPsyAccrus = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Psychique.Limite = true;
                        if (ComboBoxDiscipline.SelectedIndex != 0)
                        {
                            Psychique.Discipline = ComboBoxDiscipline.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxDiscipline.Focus();
                        }
                    }
                    break;
                case 4:
                    Psychique.MaintPouvoir = ComboBoxSelectBonus.SelectedIndex;
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
                coutPouvoir = Psychique.GetCoutPouvoir();

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

        private void FormFacettePsychique_Load(object sender, EventArgs e)
        {
            if (modification)
            {
                if (importPsy.Talent != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importPsy.Talent;
                    if (importPsy.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxDiscipline.SelectedIndex = importPsy.Discipline;
                    }
                }
                else if (importPsy.ProjectionPsy != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importPsy.ProjectionPsy;
                    if (importPsy.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxDiscipline.SelectedIndex = importPsy.Discipline;
                    }
                }
                else if (importPsy.TestResPsyAccrus != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = importPsy.TestResPsyAccrus;
                    if (importPsy.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxDiscipline.SelectedIndex = importPsy.Discipline;
                    }
                }
                else if (importPsy.MaintPouvoir != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = importPsy.MaintPouvoir;
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
                ComboBoxSelectPouv.Enabled = false;
            }
        }

        public DialogResult ShowDialog(ClassFacettePsychique facette)
        {
            modification = true;

            importPsy = facette;

            return ShowDialog();
        }
    }
}
