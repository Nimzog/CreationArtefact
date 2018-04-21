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
    public partial class FormFacetteEsoterique : Form
    {
        public bool CloseSaveCancel;
        public ClassFacetteEsoterique Esoterique, importEsoterique;
        bool modification;

        public FormFacetteEsoterique()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            Esoterique = new ClassFacetteEsoterique();

            ComboBoxNBUtil.DataSource = Properties.Settings.Default.NBUtilsPortal;
            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteEsoterique;

            modification = false;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = true;
                        //modificateur générique
                        CheckBoxMod1.Text = "Toucher";
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Text = "Arme naturelle";
                        CheckBoxMod2.Visible = true;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Prothese;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 151);
                        ButtonSave.Location = new Point(12, 151);
                        this.Size = new Size(400, 221);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = true;
                        //modificateur générique
                        CheckBoxMod1.Text = "Utilisation réduite";
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = true;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Destin;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 198);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = false;
                        //modificateur générique
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Dissimulation;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        LabelModificateur.Visible = false;
                        //modificateur générique
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Vision;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        LabelModificateur.Visible = false;
                        //modificateur générique
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.EffetMineur;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        LabelModificateur.Visible = true;
                        //modificateur générique
                        CheckBoxMod1.Text = "Communication";
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Text = "Génie";
                        CheckBoxMod2.Visible = true;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = true;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = true;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Ego;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 197);
                        ButtonSave.Location = new Point(12, 197);
                        this.Size = new Size(400, 267);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 7:
                        LabelModificateur.Visible = true;
                        //modificateur générique
                        CheckBoxMod1.Text = "Objet divisé";
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = true;
                        ComboBoxNBUtil.Visible = true;
                        ComboBoxNBUtil.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Portal;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 153);
                        ButtonSave.Location = new Point(12, 153);
                        this.Size = new Size(400, 223);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        LabelModificateur.Visible = false;
                        //modificateur générique
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Visible = false;
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Visible = false;
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Visible = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        LabelNBUtil.Visible = false;
                        ComboBoxNBUtil.Visible = false;
                        ComboBoxNBUtil.Enabled = false;

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
                //modificateur générique
                CheckBoxMod1.Visible = false;
                CheckBoxMod1.Enabled = false;
                CheckBoxMod2.Visible = false;
                CheckBoxMod2.Enabled = false;
                //modificateur alteration du destin
                TextBoxConditon.Visible = false;
                TextBoxConditon.Enabled = false;
                //modificateur ego
                CheckBoxModPersDetermine.Visible = false;
                CheckBoxModPersDetermine.Enabled = false;
                CheckBoxOrdre.Visible = false;
                CheckBoxOrdre.Enabled = false;
                //modificateur portail
                LabelNBUtil.Visible = false;
                ComboBoxNBUtil.Visible = false;
                ComboBoxNBUtil.Enabled = false;

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
                        if (ComboBoxSelectBonus.SelectedIndex <= 3)
                        {
                            //modificateur générique
                            CheckBoxMod1.Enabled = true;
                            CheckBoxMod2.Enabled = true;
                        }
                        else
                        {
                            //modificateur générique
                            CheckBoxMod1.Enabled = false;
                            CheckBoxMod2.Enabled = false;
                        }
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        //modificateur générique
                        CheckBoxMod1.Enabled = true;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = true;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        //modificateur générique
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        //modificateur générique
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        //modificateur générique
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        //modificateur générique
                        CheckBoxMod1.Enabled = true;
                        CheckBoxMod2.Enabled = true;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = true;
                        CheckBoxOrdre.Enabled = true;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 7:
                        //modificateur générique
                        CheckBoxMod1.Enabled = true;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = true;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        //modificateur générique
                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod2.Enabled = false;
                        //modificateur alteration du destin
                        TextBoxConditon.Enabled = false;
                        //modificateur ego
                        CheckBoxModPersDetermine.Enabled = false;
                        CheckBoxOrdre.Enabled = false;
                        //modificateur portail
                        ComboBoxNBUtil.Enabled = false;

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                }
            }
            else
            {
                //modificateur générique
                CheckBoxMod1.Enabled = false;
                CheckBoxMod2.Enabled = false;
                //modificateur alteration du destin
                TextBoxConditon.Enabled = false;
                //modificateur ego
                CheckBoxModPersDetermine.Enabled = false;
                CheckBoxOrdre.Enabled = false;
                //modificateur portail
                ComboBoxNBUtil.Enabled = false;

                //generer les couts et mettre a jour les labels
                majForm();
            }
        }

        private void CheckBoxMod1_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxMod2_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxModPersDetermine_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxOrdre_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxNBUtil_SelectedIndexChanged(object sender, EventArgs e)
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
            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Esoterique.Prothese = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxMod1.Checked)
                    {
                        Esoterique.Toucher = true;
                    }
                    if (CheckBoxMod2.Checked)
                    {
                        Esoterique.ArmeNauturel = true;
                    }
                    break;
                case 2:
                    Esoterique.AlterationDestion = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxMod1.Checked)
                    {
                        Esoterique.UtilReduite = true;
                        if (TextBoxConditon.Text.Count() > 0)
                        {
                            Esoterique.Condition = TextBoxConditon.Text;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une condition.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TextBoxConditon.Focus();
                        }
                    }
                    break;
                case 3:
                    Esoterique.Dissimulation = ComboBoxSelectBonus.SelectedIndex;

                    /**/
                    break;
                case 4:
                    Esoterique.Vision = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 5:
                    Esoterique.EffetMineur = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 6:
                    Esoterique.Ego = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxMod1.Checked)
                    {
                        Esoterique.Communication = true;
                    }
                    if (CheckBoxMod2.Checked)
                    {
                        Esoterique.Genie = true;
                    }
                    if (CheckBoxMod1.Checked)
                    {
                        Esoterique.PersoDetermine = true;
                    }
                    if (CheckBoxMod2.Checked)
                    {
                        Esoterique.Ordre = true;
                    }
                    break;
                case 7:
                    Esoterique.Portal = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxMod1.Checked)
                    {
                        Esoterique.Divise = true;
                    }
                    Esoterique.NBUtil = ComboBoxNBUtil.SelectedIndex;
                    break;
                default:
                    break;
            }
            //calculer les coûts du pouvoir à ajouter
            if (ComboBoxSelectPouv.SelectedIndex == 3)
            {
                Esoterique.GenererCoutPouvoir(((FormPrincipale)this.Owner).artefact);
            }
            else
            {
                Esoterique.GenererCoutPouvoir();
            }
        }

        private void FormFacetteEsoterique_Load(object sender, EventArgs e)
        {
            if (modification)
            {
                if (importEsoterique.Prothese != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.Prothese;
                    if (importEsoterique.Toucher)
                    {
                        CheckBoxMod1.Enabled = true;
                    }
                    if (importEsoterique.ArmeNauturel)
                    {
                        CheckBoxMod2.Enabled = true;
                    }
                }
                else if (importEsoterique.AlterationDestion != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.AlterationDestion;
                    if (importEsoterique.UtilReduite)
                    {
                        CheckBoxMod1.Enabled = true;
                    }
                }
                else if (importEsoterique.Dissimulation != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.Dissimulation;
                }
                else if (importEsoterique.Vision != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.Vision;
                }
                else if (importEsoterique.EffetMineur != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 5;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.EffetMineur;
                }
                else if (importEsoterique.Ego != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 6;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.Ego;
                    if (importEsoterique.Communication)
                    {
                        CheckBoxMod1.Enabled = true;
                    }
                    if (importEsoterique.Genie)
                    {
                        CheckBoxMod2.Enabled = true;
                    }
                    if (importEsoterique.PersoDetermine)
                    {
                        CheckBoxModPersDetermine.Enabled = true;
                    }
                    if (importEsoterique.Ordre)
                    {
                        CheckBoxOrdre.Enabled = true;
                    }
                }
                else if (importEsoterique.Portal != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 7;
                    ComboBoxSelectBonus.SelectedIndex = importEsoterique.Portal;
                    if (importEsoterique.Divise)
                    {
                        CheckBoxMod1.Enabled = true;
                    }
                    if (importEsoterique.NBUtil != 0)
                    {
                        ComboBoxNBUtil.SelectedIndex = importEsoterique.NBUtil;
                    }
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
                ComboBoxSelectPouv.Enabled = false;
            }
        }

        public DialogResult ShowDialog(ClassFacetteEsoterique facette)
        {
            modification = true;

            importEsoterique = facette;

            return ShowDialog();
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
               coutPouvoir = Esoterique.GetCoutPouvoir();

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
    }
}
