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
    public partial class FormEffetMystique : Form
    {
        public bool CloseSaveCancel;
        public ClassEffetMystique EffetMystique, importEffet;
        bool modification;

        public FormEffetMystique()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            EffetMystique = new ClassEffetMystique();

            ComboBoxSelectEffet.DataSource = Properties.Settings.Default.EffetMystique;
            ComboBoxSelectResistance.DataSource = Properties.Settings.Default.ResistanceEffet;
            ComboBoxSelectCondition.DataSource = Properties.Settings.Default.ConditionEffet;
            modification = false;
        }

        private void ComboBoxSelectEffet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectEffet.SelectedIndex != 0)
            {
                ComboBoxSelectResistance.Enabled = true;
                ComboBoxSelectCondition.Enabled = true;
                CheckBoxLimite.Enabled = true;

                majForm();
            }
            else
            {
                ComboBoxSelectResistance.Enabled = false;
                ComboBoxSelectCondition.Enabled = false;
                CheckBoxLimite.Enabled = true;

                majForm();
            }

        }

        private void ComboBoxSelectResistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void ComboBoxSelectCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CheckBoxLimite_CheckedChanged(object sender, EventArgs e)
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
            if (ComboBoxSelectEffet.SelectedIndex != 0)
            {
                EffetMystique = new ClassEffetMystique();

                EffetMystique.Effet = ComboBoxSelectEffet.SelectedIndex;
                EffetMystique.Resistance = ComboBoxSelectResistance.SelectedIndex;
                EffetMystique.Condition = ComboBoxSelectCondition.SelectedIndex;
                EffetMystique.Limite = CheckBoxLimite.Checked;
            }
        }

        private void majForm()
        {
            ClassCoutPouvoir coutPouvoir = new ClassCoutPouvoir();

            if (ComboBoxSelectEffet.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
                creerPouvoir();

                //calculer les coûts du pouvoir à ajouter
                coutPouvoir = EffetMystique.GetCoutPouvoir();

                if (coutPouvoir.PP <= 0)
                {
                    MessageBox.Show("Combinaison d'effet, résistance," +
                                  "\ncondition ou faiblesse invalide.",
                        "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ButtonSave.Enabled = false;
                }

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

        private void FormEffetMystique_Load(object sender, EventArgs e)
        {
            if (modification)
            {
                ComboBoxSelectEffet.SelectedIndex = importEffet.Effet;
                ComboBoxSelectCondition.SelectedIndex = importEffet.Condition;
                ComboBoxSelectResistance.SelectedIndex = importEffet.Resistance;
                CheckBoxLimite.Enabled = importEffet.Limite;

            }
        }

        public DialogResult ShowDialog(ClassEffetMystique facette)
        {
            modification = true;

            importEffet = facette;

            return ShowDialog();
        }
    }
}
