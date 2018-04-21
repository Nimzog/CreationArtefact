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
    public partial class FormFacetteCombat : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel, Modification;
        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteCombat Combat, importCombat;

        /// <summary>
        /// 
        /// </summary>
        public FormFacetteCombat()
        {
            InitializeComponent();

            Combat = new ClassFacetteCombat();

            CloseSaveCancel = false;
            Modification = false;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteCombat;
        }

        public DialogResult ShowDialog(ClassFacetteCombat combat)
        {
            Modification = true;

            importCombat = combat;

            return ShowDialog();
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

        private void ComboBoxSelectPouv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectPouv.SelectedIndex != 0)
            {
                switch (ComboBoxSelectPouv.SelectedIndex)
                {
                    case 1:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 2:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc520;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusDegat;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Enchantee;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        RadioButtonMod1.Enabled = true;
                        RadioButtonMod1.Visible = true;
                        RadioButtonMod1.Text = "Aucun modificateur";
                        RadioButtonMod1.Checked = true;
                        RadioButtonMod2.Enabled = true;
                        RadioButtonMod2.Visible = true;
                        RadioButtonMod2.Text = "Variable";
                        RadioButtonMod3.Enabled = true;
                        RadioButtonMod3.Visible = true;
                        RadioButtonMod3.Text = "Combiné";
                        RadioButtonMod4.Enabled = true;
                        RadioButtonMod4.Visible = true;
                        RadioButtonMod4.Text = "Primaire";

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = true;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Elementaire;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 197);
                        ButtonSave.Location = new Point(12, 197);
                        this.Size = new Size(400, 270);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = true;
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Text = "Grand exterminateur";
                        CheckBoxMod1.Checked = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;
                        CheckBoxMod2.Checked = false;

                        LabelModificateur.Visible = true;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = true;
                        TextBoxExterminateur.Visible = true;

                        LabelExterminateur.Visible = true;
                        TextBoxExterminateur.Enabled = true;
                        TextBoxExterminateur.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Exterminateur;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 170);
                        ButtonSave.Location = new Point(12, 170);
                        this.Size = new Size(400, 241);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 7:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Assaut;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 8:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = true;
                        CheckBoxMod1.Visible = true;
                        CheckBoxMod1.Text = "Arme à feu";
                        CheckBoxMod1.Checked = false;
                        CheckBoxMod2.Enabled = true;
                        CheckBoxMod2.Visible = true;
                        CheckBoxMod2.Text = "Munitions combinables";
                        CheckBoxMod2.Checked = false;

                        LabelModificateur.Visible = true;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Munition;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 151);
                        ButtonSave.Location = new Point(12, 151);
                        this.Size = new Size(400, 220);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 9:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Critique;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 10:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.Recuperation;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 11:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.DestArmure;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 12:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.AutreCompSpec;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    default:
                        RadioButtonMod1.Enabled = false;
                        RadioButtonMod1.Visible = false;
                        RadioButtonMod2.Enabled = false;
                        RadioButtonMod2.Visible = false;
                        RadioButtonMod3.Enabled = false;
                        RadioButtonMod3.Visible = false;
                        RadioButtonMod4.Enabled = false;
                        RadioButtonMod4.Visible = false;

                        CheckBoxMod1.Enabled = false;
                        CheckBoxMod1.Visible = false;
                        CheckBoxMod2.Enabled = false;
                        CheckBoxMod2.Visible = false;

                        LabelModificateur.Visible = false;
                        ComboBoxSelectBonus.Enabled = false;
                        
                        LabelModificateur.Visible = false;

                        LabelExterminateur.Visible = false;
                        TextBoxExterminateur.Enabled = false;
                        TextBoxExterminateur.Visible = false;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 165);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                }
            }
            else
            {
                RadioButtonMod1.Enabled = false;
                RadioButtonMod1.Visible = false;
                RadioButtonMod2.Enabled = false;
                RadioButtonMod2.Visible = false;
                RadioButtonMod3.Enabled = false;
                RadioButtonMod3.Visible = false;
                RadioButtonMod4.Enabled = false;
                RadioButtonMod4.Visible = false;

                CheckBoxMod1.Enabled = false;
                CheckBoxMod1.Visible = false;
                CheckBoxMod2.Enabled = false;
                CheckBoxMod2.Visible = false;

                LabelModificateur.Visible = false;
                ComboBoxSelectBonus.Enabled = false;

                LabelModificateur.Visible = false;

                LabelExterminateur.Visible = false;
                TextBoxExterminateur.Enabled = false;
                TextBoxExterminateur.Visible = false;

                buttonCancel.Location = new Point(129, 92);
                ButtonSave.Location = new Point(12, 92);
                this.Size = new Size(400, 165);

                //generer les couts et mettre a jour les labels
                majForm();
            }
        }

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxMod1_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void creerPouvoir()
        {
            Combat = new ClassFacetteCombat();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Combat.Attaque = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 2:
                    Combat.Offensif = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 3:
                    Combat.BonusDegat = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 4:
                    Combat.Enchantee = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 5:
                    Combat.Element = ComboBoxSelectBonus.SelectedIndex;
                    if (RadioButtonMod2.Checked)
                    {
                        Combat.ElemVariable = true;
                        Combat.ElemCombine = false;
                        Combat.ElemPrime = false;
                    }
                    else if (RadioButtonMod3.Checked)
                    {
                        Combat.ElemVariable = false;
                        Combat.ElemCombine = true;
                        Combat.ElemPrime = false;
                    }
                    else if (RadioButtonMod4.Checked)
                    {
                        Combat.ElemVariable = false;
                        Combat.ElemCombine = false;
                        Combat.ElemPrime = true;
                    }
                    else
                    {
                        Combat.ElemVariable = false;
                        Combat.ElemCombine = false;
                        Combat.ElemPrime = false;
                    }
                    break;
                case 6:
                    Combat.Exterminateur = ComboBoxSelectBonus.SelectedIndex;
                    Combat.DescExterminateur = TextBoxExterminateur.Text;
                    if (CheckBoxMod1.Checked)
                    {
                        Combat.GrandExterminateur = true;
                    }
                    break;
                case 7:
                    Combat.Assaut = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 8:
                    Combat.Munition = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxMod1.Checked)
                    {
                        Combat.Firearm = true;
                    }
                    if (CheckBoxMod2.Checked)
                    {
                        Combat.MuniCombi = true;
                    }
                    break;
                case 9:
                    Combat.Critique = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 10:
                    Combat.Recuperation = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 11:
                    Combat.DestArmure = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 12:
                    Combat.AutreComp = ComboBoxSelectBonus.SelectedIndex;
                    break;
            }
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectBonus.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = Combat.GetCoutPouvoir();

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

        private void RadioButtonMod2_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonMod1_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void RadioButtonMod3_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void FormFacetteCombat_Load(object sender, EventArgs e)
        {
            if (Modification)
            {
                if (importCombat.Attaque != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Attaque;
                }
                else if (importCombat.Offensif != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Offensif;
                }
                else if (importCombat.BonusDegat != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.BonusDegat;
                }
                else if (importCombat.Enchantee != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Enchantee;
                }
                else if (importCombat.Element != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 5;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Element;
                    if (importCombat.ElemVariable)
                    {
                        RadioButtonMod2.Checked = true;
                    }
                    else if (importCombat.ElemCombine)
                    {
                        RadioButtonMod3.Checked = true;
                    }
                    else  if (importCombat.ElemPrime)
                    {
                        RadioButtonMod4.Checked = true;
                    }
                    else
                    {
                        RadioButtonMod1.Checked = true;
                    }
                }
                else if (importCombat.Exterminateur != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 6;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Exterminateur;
                    if (importCombat.GrandExterminateur)
                    {
                        CheckBoxMod1.Checked = true;
                    }
                    TextBoxExterminateur.Text = importCombat.DescExterminateur;
                }
                else if (importCombat.Assaut != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 7;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Assaut;
                }
                else if (importCombat.Munition != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 8;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Munition;
                    if (importCombat.Firearm)
                    {
                        CheckBoxMod1.Checked = true;
                    }
                    if (importCombat.MuniCombi)
                    {
                        CheckBoxMod2.Checked = true;
                    }
                }
                else if (importCombat.Critique != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 9;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Critique;
                }
                else if (importCombat.Recuperation != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 10;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.Recuperation;
                }
                else if (importCombat.DestArmure != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 11;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.DestArmure;
                }
                else if (importCombat.AutreComp != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 12;
                    ComboBoxSelectBonus.SelectedIndex = importCombat.AutreComp;
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
                ComboBoxSelectPouv.Enabled = false;
            }
        }

        private void RadioButtonMod4_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxMod2_CheckedChanged(object sender, EventArgs e)
        {
            majForm();
        }
    }
}
