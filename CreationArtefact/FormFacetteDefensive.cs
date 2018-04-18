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
    public partial class FormFacetteDefensive : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel;
        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteDefensive Defense;

        public FormFacetteDefensive()
        {
            InitializeComponent();

            Defense = new ClassFacetteDefensive();
            CloseSaveCancel = false;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteDefensive;
            ComboBoxType.DataSource = Properties.Settings.Default.TypeArmure;
        }

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        CheckBoxOuverture.Enabled = true;
                        CheckBoxOuverture.Visible = true;

                        LabelModificateur.Visible = true;
                        
                        ComboBoxType.Visible = false;
                        ComboBoxType.Enabled = false;
                        LabelType.Visible = false;
                        RadioButtonNormal.Visible = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Visible = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Visible = false;
                        RadioButtonComplete.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 198);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        CheckBoxOuverture.Enabled = false;
                        CheckBoxOuverture.Visible = false;

                        LabelModificateur.Visible = true;
;
                        ComboBoxType.Visible = true;
                        ComboBoxType.Enabled = false;
                        ComboBoxType.SelectedIndex = 0;
                        LabelType.Visible = true;
                        RadioButtonNormal.Visible = true;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Visible = true;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Visible = true;
                        RadioButtonComplete.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ArmureInnee;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 175);
                        ButtonSave.Location = new Point(12, 175);
                        this.Size = new Size(400, 245);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        CheckBoxOuverture.Enabled = false;
                        CheckBoxOuverture.Visible = false;

                        LabelModificateur.Visible = false;
                        
                        ComboBoxType.Visible = false;
                        ComboBoxType.Enabled = false;
                        LabelType.Visible = false;
                        RadioButtonNormal.Visible = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Visible = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Visible = false;
                        RadioButtonComplete.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc520;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        CheckBoxOuverture.Enabled = false;
                        CheckBoxOuverture.Visible = false;

                        LabelModificateur.Visible = false;

                        ComboBoxType.Visible = false;
                        ComboBoxType.Enabled = false;
                        LabelType.Visible = false;
                        RadioButtonNormal.Visible = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Visible = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Visible = false;
                        RadioButtonComplete.Enabled = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        CheckBoxOuverture.Enabled = false;
                        CheckBoxOuverture.Visible = false;

                        LabelModificateur.Visible = false;
                        ComboBoxSelectBonus.Enabled = false;

                        ComboBoxType.Visible = false;
                        ComboBoxType.Enabled = false;
                        LabelType.Visible = false;
                        RadioButtonNormal.Visible = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Visible = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Visible = false;
                        RadioButtonComplete.Enabled = false;

                        LabelModificateur.Visible = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        majForm();
                        break;
                }
            }
            else
            {
                CheckBoxOuverture.Enabled = false;
                CheckBoxOuverture.Visible = false;

                LabelModificateur.Visible = false;
                ComboBoxSelectBonus.Enabled = false;

                ComboBoxType.Visible = false;
                ComboBoxType.Enabled = false;
                LabelType.Visible = false;
                RadioButtonNormal.Visible = false;
                RadioButtonNormal.Enabled = false;
                RadioButtonConcentre.Visible = false;
                RadioButtonConcentre.Enabled = false;
                RadioButtonComplete.Visible = false;
                RadioButtonComplete.Enabled = false;

                LabelModificateur.Visible = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 165);

                majForm();
            }
        }

        private void creerPouvoir()
        {
            Defense = new ClassFacetteDefensive();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Defense.QualiteArmure = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxOuverture.Checked)
                    {
                        Defense.Ouverture = true;
                    }
                    break;
                case 2:
                    Defense.ArmureInnee = ComboBoxSelectBonus.SelectedIndex;
                    Defense.TypeArmure = ComboBoxType.SelectedIndex;
                    if (RadioButtonConcentre.Checked)
                        Defense.ArmureConcentre = true;
                    else if (RadioButtonComplete.Checked)
                        Defense.ArmureComplete = true;
                    break;
                case 3:
                    Defense.RenforcementDef = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 4:
                    Defense.ArmeDefAccrue = ComboBoxSelectBonus.SelectedIndex;
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
                coutPouvoir = Defense.GenererCoutPouvoir();

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

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectBonus.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        CheckBoxOuverture.Enabled = true;
                        
                        ComboBoxType.Enabled = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Enabled = false;
                        break;
                    case 2:
                        CheckBoxOuverture.Enabled = false;
                        
                        ComboBoxType.Enabled = true;
                        ComboBoxType.SelectedIndex = 0;
                        RadioButtonNormal.Enabled = true;
                        RadioButtonConcentre.Enabled = true;
                        RadioButtonComplete.Enabled = true;
                        break;
                    case 3:
                        CheckBoxOuverture.Enabled = false;
                        
                        ComboBoxType.Enabled = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Enabled = false;
                        break;
                    case 4:
                        CheckBoxOuverture.Enabled = false;
                        
                        ComboBoxType.Enabled = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Enabled = false;
                        break;
                    default:
                        CheckBoxOuverture.Enabled = false;
                        
                        ComboBoxType.Enabled = false;
                        RadioButtonNormal.Enabled = false;
                        RadioButtonConcentre.Enabled = false;
                        RadioButtonComplete.Enabled = false;
                        break;
                }
            }
            else
            {
                CheckBoxOuverture.Enabled = false;
                
                ComboBoxType.Enabled = false;
                RadioButtonNormal.Enabled = false;
                RadioButtonConcentre.Enabled = false;
                RadioButtonComplete.Enabled = false;
            }
            majForm();
        }

        private void CheckBoxMod1_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxModArmureInnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxOuverture_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonConcentre_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonComplete_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }
    }
}
