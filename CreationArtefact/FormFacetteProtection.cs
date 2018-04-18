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
    public partial class FormFacetteProtection : Form
    {
        public ClassFacetteProtection Protection;
        public bool CloseSaveCancel;

        public FormFacetteProtection()
        {
            InitializeComponent();

            Protection = new ClassFacetteProtection();
            CloseSaveCancel = false;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteProtection;
            ComboBoxResistance.DataSource = Properties.Settings.Default.TypeAmelioRes;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = false;

                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Immunite;
                        ComboBoxSelectBonus.Enabled = true;
                        
                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 159);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = true;

                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Text = "Voie unique";
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = true;
                        LabelVoieDisciplineElement.Text = "Voie de magie";
                        ComboBoxVoieDisciplineElementaire.Visible = true;
                        ComboBoxVoieDisciplineElementaire.DataSource = Properties.Settings.Default.VoieDeMagie;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ImmuniteMag;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 168);
                        ButtonSave.Location = new Point(12, 168);
                        this.Size = new Size(400, 238);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = true;

                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Text = "Discipline unique";
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = true;
                        LabelVoieDisciplineElement.Text = "Discipline psychique";
                        ComboBoxVoieDisciplineElementaire.Visible = true;
                        ComboBoxVoieDisciplineElementaire.DataSource = Properties.Settings.Default.DiscplinePsy;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ImmunitePsy;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 168);
                        ButtonSave.Location = new Point(12, 168);
                        this.Size = new Size(400, 238);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        LabelModificateur.Visible = true;

                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = true;
                        LabelVoieDisciplineElement.Text = "Element(s)";
                        ComboBoxVoieDisciplineElementaire.Visible = true;
                        ComboBoxVoieDisciplineElementaire.DataSource = Properties.Settings.Default.TypeImmuniteElem;
                        ComboBoxVoieDisciplineElementaire.Enabled = true;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ImmuniteElem;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 168);
                        ButtonSave.Location = new Point(12, 168);
                        this.Size = new Size(400, 238);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        LabelModificateur.Visible = true;

                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Text = "Limité";
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = true;
                        LabelResistance.Text = "Type d'attaque";
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = true;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ReducDegats;
                        ComboBoxSelectBonus.Enabled = true;
                        
                        buttonCancel.Location = new Point(129, 207);
                        ButtonSave.Location = new Point(12, 207);
                        this.Size = new Size(400, 280);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        LabelModificateur.Visible = false;

                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Invulnerabilite;
                        ComboBoxSelectBonus.Enabled = true;

                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 159);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 7:
                        LabelModificateur.Visible = true;

                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Text = "Face à un(e) type de magie/discipline psychique";
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = true;
                        LabelVoieDisciplineElement.Text = "Discipline psychique ou Voie de magie";
                        ComboBoxVoieDisciplineElementaire.Visible = true;
                        ComboBoxVoieDisciplineElementaire.Text = "Choisir...";
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = true;
                        LabelResistance.Text = "Résistance";
                        ComboBoxResistance.Visible = true;
                        ComboBoxResistance.Enabled = true;
                        ComboBoxResistance.SelectedIndex = 0;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.AmelioRes;
                        ComboBoxSelectBonus.Enabled = true;

                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        buttonCancel.Location = new Point(129, 207);
                        ButtonSave.Location = new Point(12, 207);
                        this.Size = new Size(400, 280);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        LabelModificateur.Visible = false;

                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelVoieDisciplineElement.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Visible = false;
                        ComboBoxVoieDisciplineElementaire.Enabled = false;

                        LabelResistance.Visible = false;
                        ComboBoxResistance.Visible = false;
                        ComboBoxResistance.Enabled = false;
                        TextBoxAttaque.Visible = false;
                        TextBoxAttaque.Enabled = false;

                        ComboBoxSelectBonus.Enabled = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 159);

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
                LabelModificateur.Visible = false;

                CheckBoxLimite.Enabled = false;
                CheckBoxLimite.Visible = false;
                CheckBoxLimite.Checked = false;

                LabelVoieDisciplineElement.Visible = false;
                ComboBoxVoieDisciplineElementaire.Visible = false;
                ComboBoxVoieDisciplineElementaire.Enabled = false;

                LabelResistance.Visible = false;
                ComboBoxResistance.Visible = false;
                ComboBoxResistance.Enabled = false;
                TextBoxAttaque.Visible = false;
                TextBoxAttaque.Enabled = false;

                ComboBoxSelectBonus.Enabled = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(413, 159);

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
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 2:
                    case 3:
                        ComboBoxVoieDisciplineElementaire.Enabled = true;
                        break;
                    case 7:
                        if (ComboBoxResistance.SelectedIndex == 4)
                        {
                            ComboBoxVoieDisciplineElementaire.DataSource = Properties.Settings.Default.VoieDeMagie;
                        }
                        else if (ComboBoxResistance.SelectedIndex == 5)
                        {
                            ComboBoxVoieDisciplineElementaire.DataSource = Properties.Settings.Default.DiscplinePsy;
                        }
                        ComboBoxVoieDisciplineElementaire.Enabled = true;
                        break;
                    case 5:
                        TextBoxAttaque.Enabled = true;
                        break;
                    default:
                        break;
                }
                
            }
            else
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 2:
                    case 3:
                    case 7:
                        ComboBoxVoieDisciplineElementaire.Enabled = false;
                        break;
                    case 5:
                        TextBoxAttaque.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            majForm();
        }

        private void ComboBoxVoieDisciplineElementaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxResistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxLimite.Enabled = false;
            CheckBoxLimite.Checked = false;
            if (ComboBoxResistance.SelectedIndex == 4 || ComboBoxResistance.SelectedIndex == 5)
            {
                CheckBoxLimite.Enabled = true;
            }
            majForm();
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = Protection.GenererCoutPouvoir();

                if (coutPouvoir.PP <= 0)
                {
                    ButtonSave.Enabled = false;

                    MessageBox.Show("Combinaison de pouvoir et de modificateur invalide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
            Protection = new ClassFacetteProtection();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Protection.Immunite = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 2:
                    Protection.ImmuniteMagique = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Protection.Limite = true;
                        if (ComboBoxVoieDisciplineElementaire.SelectedIndex != 0)
                        {
                            Protection.VoieDisciplineElement = ComboBoxVoieDisciplineElementaire.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieDisciplineElementaire.Focus();
                        }
                    }
                    break;
                case 3:
                    Protection.ImmunitePsychique = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Protection.Limite = true;
                        if (ComboBoxVoieDisciplineElementaire.SelectedIndex != 0)
                        {
                            Protection.VoieDisciplineElement = ComboBoxVoieDisciplineElementaire.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une discipline valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieDisciplineElementaire.Focus();
                        }
                    }
                    break;
                case 4:
                    Protection.ImmuniteElementaire = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Protection.Limite = true;
                        if (ComboBoxVoieDisciplineElementaire.SelectedIndex != 0)
                        {
                            Protection.VoieDisciplineElement = ComboBoxVoieDisciplineElementaire.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez un(des) élément(s) valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieDisciplineElementaire.Focus();
                        }
                    }
                    break;
                case 5:
                    Protection.ReductionDegat = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Protection.Limite = true;
                        if (TextBoxAttaque.Text.Length != 0)
                        {
                            Protection.TypeAtt = TextBoxAttaque.Text;
                        }
                        else
                        {
                            MessageBox.Show("Décrivez le type d'attaque.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TextBoxAttaque.Focus();
                        }
                    }
                    break;
                case 6:
                    Protection.SeuilInvul = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 7:
                    Protection.AugmentRes = ComboBoxSelectBonus.SelectedIndex;
                    if (ComboBoxResistance.SelectedIndex != 0)
                    {
                        Protection.TypeResistance = ComboBoxResistance.SelectedIndex;
                        if (Protection.TypeResistance == 4)
                        {
                            if (CheckBoxLimite.Checked)
                            {
                                Protection.TypeMagieUnique = true;
                                if (ComboBoxVoieDisciplineElementaire.SelectedIndex != 0)
                                {
                                    Protection.VoieDisciplineElement = ComboBoxVoieDisciplineElementaire.SelectedIndex;
                                }
                                else
                                {
                                    MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ComboBoxVoieDisciplineElementaire.Focus();
                                }
                            }
                        }
                        else if (Protection.TypeResistance == 5)
                        {
                            if (CheckBoxLimite.Checked)
                            {
                                Protection.TypePsyUnique = true;
                                if (ComboBoxVoieDisciplineElementaire.SelectedIndex != 0)
                                {
                                    Protection.VoieDisciplineElement = ComboBoxVoieDisciplineElementaire.SelectedIndex;
                                }
                                else
                                {
                                    MessageBox.Show("Choisissez une discipline valide.", "Avertissement",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ComboBoxVoieDisciplineElementaire.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choisissez un(des) type(s) de résistance(s) valide.", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ComboBoxResistance.Focus();
                    }
                    break;
                default:
                    break;
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
    }
}
