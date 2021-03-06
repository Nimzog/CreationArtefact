﻿using System;
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
    public partial class FormFacetteMagique : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel;
        /// <summary>
        /// 
        /// </summary>
        public ClassFacetteMagique Magique;
        bool modification;
        ClassFacetteMagique importMagique;

        public FormFacetteMagique()
        {
            InitializeComponent();

            Magique = new ClassFacetteMagique();
            CloseSaveCancel = false;

            ComboBoxSelectPouv.DataSource = Properties.Settings.Default.FacetteMagique;
            ComboBoxVoieMagie.DataSource = Properties.Settings.Default.VoieDeMagie;

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

                        ComboBoxVoieMagie.Visible = true;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = true;

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

                        ComboBoxVoieMagie.Visible = true;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc525;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 3:
                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = false;

                        ComboBoxVoieMagie.Visible = false;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.ReceptZeon;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 92);
                        ButtonSave.Location = new Point(12, 92);
                        this.Size = new Size(400, 162);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 4:
                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = true;

                        ComboBoxVoieMagie.Visible = true;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.PuisAjoute;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 5:
                        CheckBoxLimite.Enabled = true;
                        CheckBoxLimite.Visible = true;
                        CheckBoxLimite.Checked = false;

                        LabelModificateur.Visible = true;

                        ComboBoxVoieMagie.Visible = true;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = true;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.BonusInc510to30;
                        ComboBoxSelectBonus.Enabled = true;

                        buttonCancel.Location = new Point(129, 128);
                        ButtonSave.Location = new Point(12, 128);
                        this.Size = new Size(400, 196);

                        //generer les couts et mettre a jour les labels
                        majForm();
                        break;
                    case 6:
                        CheckBoxLimite.Enabled = false;
                        CheckBoxLimite.Visible = false;

                        LabelModificateur.Visible = false;

                        ComboBoxVoieMagie.Visible = false;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = false;

                        ComboBoxSelectBonus.DataSource = Properties.Settings.Default.RegenMag;
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

                        ComboBoxVoieMagie.Visible = false;
                        ComboBoxVoieMagie.Enabled = false;
                        LabelVoieMagie.Visible = false;

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

                ComboBoxVoieMagie.Visible = false;
                ComboBoxVoieMagie.Enabled = false;
                LabelVoieMagie.Visible = false;

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

        private void creerPouvoir()
        {
            Magique = new ClassFacetteMagique();

            switch (ComboBoxSelectPouv.SelectedIndex)
            {
                case 1:
                    Magique.AmpliAMR = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Magique.Limite = true;
                        if (ComboBoxVoieMagie.SelectedIndex != 0)
                        {
                            Magique.VoieMagie = ComboBoxVoieMagie.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieMagie.Focus();
                        }
                    }
                    break;
                case 2:
                    Magique.ProjMagique = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Magique.Limite = true;
                        if (ComboBoxVoieMagie.SelectedIndex != 0)
                        {
                            Magique.VoieMagie = ComboBoxVoieMagie.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieMagie.Focus();
                        }
                    }
                    break;
                case 3:
                    Magique.ReceptZeon = ComboBoxSelectBonus.SelectedIndex;
                    break;
                case 4:
                    Magique.PuissAjout = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Magique.Limite = true;
                        if (ComboBoxVoieMagie.SelectedIndex != 0)
                        {
                            Magique.VoieMagie = ComboBoxVoieMagie.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieMagie.Focus();
                        }
                    }
                    break;
                case 5:
                    Magique.TestResMysAcc = ComboBoxSelectBonus.SelectedIndex;
                    if (CheckBoxLimite.Checked)
                    {
                        Magique.Limite = true;
                        if (ComboBoxVoieMagie.SelectedIndex != 0)
                        {
                            Magique.VoieMagie = ComboBoxVoieMagie.SelectedIndex;
                        }
                        else
                        {
                            MessageBox.Show("Choisissez une voie de magie valide.", "Avertissement",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ComboBoxVoieMagie.Focus();
                        }
                    }
                    break;
                case 6:
                    Magique.RegenZeon = ComboBoxSelectBonus.SelectedIndex;
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
                coutPouvoir = Magique.GetCoutPouvoir();

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

        private void ComboBoxSelectBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxModLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxLimite.Checked)
            {
                ComboBoxVoieMagie.Enabled = true;
                ComboBoxVoieMagie.SelectedIndex = 0;
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
                    case 4:
                        if (ComboBoxSelectBonus.SelectedIndex == 2)
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
                ComboBoxVoieMagie.Enabled = false;
                majForm();
            }
        }

        private void ComboBoxVoieMagie_SelectedIndexChanged(object sender, EventArgs e)
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

        private void FormFacetteMagique_Load(object sender, EventArgs e)
        {
            if (modification)
            {
                if (importMagique.AmpliAMR != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 1;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.AmpliAMR;
                    if (importMagique.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxVoieMagie.SelectedIndex = importMagique.VoieMagie;
                    }
                }
                else if (importMagique.ProjMagique != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 2;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.ProjMagique;
                    if (importMagique.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxVoieMagie.SelectedIndex = importMagique.VoieMagie;
                    }
                }
                else if (importMagique.ReceptZeon != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 3;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.ReceptZeon;
                }
                else if (importMagique.PuissAjout != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 4;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.PuissAjout;
                    if (importMagique.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxVoieMagie.SelectedIndex = importMagique.VoieMagie;
                    }
                }
                else if (importMagique.TestResMysAcc != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 5;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.TestResMysAcc;
                    if (importMagique.Limite)
                    {
                        CheckBoxLimite.Checked = true;
                        ComboBoxVoieMagie.SelectedIndex = importMagique.VoieMagie;
                    }
                }
                else if (importMagique.RegenZeon != 0)
                {
                    ComboBoxSelectPouv.SelectedIndex = 6;
                    ComboBoxSelectBonus.SelectedIndex = importMagique.RegenZeon;
                }
                else
                {
                    ComboBoxSelectPouv.SelectedIndex = 0;
                }
                ComboBoxSelectPouv.Enabled = false;
            }
        }

        public DialogResult ShowDialog(ClassFacetteMagique facette)
        {
            modification = true;

            importMagique = facette;

            return ShowDialog();
        }
    }
}
