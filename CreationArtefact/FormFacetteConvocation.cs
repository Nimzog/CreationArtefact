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
    public partial class FormFacetteConvocation : Form
    {
        public bool CloseSaveCancel;

        public ClassFacetteConvocation Convocation = null;

        public FormFacetteConvocation()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            Convocation = new ClassFacetteConvocation();

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteConvocation;
            ComboBoxElement.DataSource = Properties.Settings.Default.ElementLie;
            ComboBoxConvocation.DataSource = Properties.Settings.Default.ConvoLie;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        LabelModificateur.Visible = false;

                        CheckBoxLienElementaire.Enabled = false;
                        CheckBoxLienElementaire.Visible = false;
                        CheckBoxLienElementaire.Checked = false;

                        LabelElement.Visible = false;
                        ComboBoxElement.Visible = false;
                        ComboBoxElement.Enabled = false;
                        
                        LabelConvoquer.Visible = false;
                        ComboBoxConvocation.Visible = false;
                        ComboBoxConvocation.Enabled = false;

                        LabelLimiteConvoInvo.Visible = false;
                        RadioButtonAucun.Visible = false;
                        RadioButtonConvo.Visible = false;
                        RadioButtonInvoke.Visible = false;
                        RadioButtonAucun.Enabled = false;
                        RadioButtonConvo.Enabled = false;
                        RadioButtonInvoke.Enabled = false;

                        LabelRituel.Visible = false;
                        CheckBoxRituel.Visible = false;
                        CheckBoxRituel.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Presence;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 166);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        LabelModificateur.Visible = true;

                        CheckBoxLienElementaire.Enabled = true;
                        CheckBoxLienElementaire.Visible = true;
                        CheckBoxLienElementaire.Checked = false;

                        LabelElement.Visible = true;
                        ComboBoxElement.Visible = true;
                        ComboBoxElement.Enabled = false;

                        LabelConvoquer.Visible = false;
                        ComboBoxConvocation.Visible = false;
                        ComboBoxConvocation.Enabled = false;

                        LabelLimiteConvoInvo.Visible = false;
                        RadioButtonAucun.Visible = false;
                        RadioButtonConvo.Visible = false;
                        RadioButtonInvoke.Visible = false;
                        RadioButtonAucun.Enabled = false;
                        RadioButtonConvo.Enabled = false;
                        RadioButtonInvoke.Enabled = false;

                        LabelRituel.Visible = false;
                        CheckBoxRituel.Visible = false;
                        CheckBoxRituel.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.LienEconome;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 132);
                        ButtonSave.Location = new Point(12, 132);
                        this.Size = new Size(400, 204);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        LabelModificateur.Visible = true;

                        CheckBoxLienElementaire.Enabled = true;
                        CheckBoxLienElementaire.Visible = true;
                        CheckBoxLienElementaire.Checked = false;

                        LabelElement.Visible = true;
                        ComboBoxElement.Visible = true;
                        ComboBoxElement.Enabled = false;

                        LabelConvoquer.Visible = true;
                        ComboBoxConvocation.Visible = true;
                        ComboBoxConvocation.Enabled = true;

                        LabelLimiteConvoInvo.Visible = true;
                        RadioButtonAucun.Visible = true;
                        RadioButtonConvo.Visible = true;
                        RadioButtonInvoke.Visible = true;
                        RadioButtonAucun.Enabled = false;
                        RadioButtonConvo.Enabled = false;
                        RadioButtonInvoke.Enabled = false;

                        LabelRituel.Visible = true;
                        CheckBoxRituel.Visible = true;
                        CheckBoxRituel.Enabled = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ConvoAccrue;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 210);
                        ButtonSave.Location = new Point(12, 210);
                        this.Size = new Size(400, 284);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        LabelModificateur.Visible = false;

                        CheckBoxLienElementaire.Enabled = false;
                        CheckBoxLienElementaire.Visible = false;
                        CheckBoxLienElementaire.Checked = false;

                        LabelElement.Visible = false;
                        ComboBoxElement.Visible = false;
                        ComboBoxElement.Enabled = false;

                        LabelConvoquer.Visible = false;
                        ComboBoxConvocation.Visible = false;
                        ComboBoxConvocation.Enabled = false;

                        LabelLimiteConvoInvo.Visible = false;
                        RadioButtonAucun.Visible = false;
                        RadioButtonConvo.Visible = false;
                        RadioButtonInvoke.Visible = false;

                        LabelRituel.Visible = false;
                        CheckBoxRituel.Visible = false;
                        CheckBoxRituel.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Presence;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 166);

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

                CheckBoxLienElementaire.Enabled = false;
                CheckBoxLienElementaire.Visible = false;
                CheckBoxLienElementaire.Checked = false;

                LabelElement.Visible = false;
                ComboBoxElement.Visible = false;
                ComboBoxElement.Enabled = false;

                LabelConvoquer.Visible = false;
                ComboBoxConvocation.Visible = false;
                ComboBoxConvocation.Enabled = false;

                LabelLimiteConvoInvo.Visible = false;
                RadioButtonAucun.Visible = false;
                RadioButtonConvo.Visible = false;
                RadioButtonInvoke.Visible = false;

                LabelRituel.Visible = false;
                CheckBoxRituel.Visible = false;
                CheckBoxRituel.Enabled = false;

                ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Presence;
                ComboBoxSelectBonus.Enabled = true;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 166);

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

        private void CheckBoxLienElementaire_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxLienElementaire.Checked)
            {
                ComboBoxElement.Enabled = true;
            }
            else
            {
                ComboBoxElement.Enabled = false;
            }
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

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0 && ComboBoxSelectPouv.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = Convocation.GenererCoutPouvoir();

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
            Convocation = new ClassFacetteConvocation();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Convocation.PresenceAccrue = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 2:
                    Convocation.LienEconome = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLienElementaire.Checked)
                    {
                        Convocation.LienElem = true;
                        if (ComboBoxElement.SelectedIndex != 0)
                        {
                            Convocation.ElementLie = ComboBoxElement.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez un élément valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxElement.Focus();
                        }
                    }
                    break;
                case 3:
                    Convocation.ConvoAccrue = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLienElementaire.Checked)
                    {
                        Convocation.LienElem = true;
                        if (ComboBoxElement.SelectedIndex != 0)
                        {
                            Convocation.ElementLie = ComboBoxElement.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez un élément valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxElement.Focus();
                        }
                    }
                    if (ComboBoxConvocation.SelectedIndex != 0)
                    {
                        Convocation.ConvoLie = ComboBoxConvocation.SelectedIndex;
                    }
                    else
                    {
                        MessageBox.Show("Choisissez une compétence valide.", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ComboBoxElement.Focus();
                    }
                    if (RadioButtonConvo.Checked)
                    {
                        Convocation.ConvoSeul = true;
                    }
                    else if (RadioButtonInvoke.Checked)
                    {
                        Convocation.Invocation = true;
                    }
                    if (CheckBoxRituel.Checked)
                    {
                        Convocation.RituelReq = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RadioButtonConvo_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonInvoke_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonAucun_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxRituel_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxConvocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxConvocation.SelectedIndex == 1)
            {
                RadioButtonAucun.Enabled = true;
                RadioButtonAucun.Checked = true;
                RadioButtonConvo.Enabled = true;
                RadioButtonInvoke.Enabled = true;
            }
            else
            {

                RadioButtonAucun.Enabled = false;
                RadioButtonConvo.Enabled = false;
                RadioButtonInvoke.Enabled = false;
            }
        }        

        private void ComboBoxElement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
