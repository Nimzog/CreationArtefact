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
    public partial class FormAjouterMat : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel { get; set; }
        bool modEnCour, isInit;
        BindingList<string> bindinglist;
        BindingSource bSource;
        string matOriginal;
        int presOriginal;

        public FormAjouterMat()
        {
            InitializeComponent();
            isInit = true;
            CloseSaveCancel = false;
            modEnCour = false;
            bindinglist = new BindingList<string>();
            foreach (string mat in Properties.Settings.Default.Materiel)
            {
                bindinglist.Add(mat);
            }
            bSource = new BindingSource();
            bSource.DataSource = bindinglist;
            ListBoxMateriel.DataSource = bSource;
            ListBoxMateriel.ClearSelected();
            isInit = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //ButtonSave.Text = "Sauvegarder";
            //ButtonSupprimer.Text = "Ajouter";
            if (!modEnCour)
            {
                CloseSaveCancel = true;

                this.Close();
            }
            //ButtonSave.Text = "Modifier";
            //ButtonSupprimer.Text = "Supprimer";
            else
            {
                Properties.Settings.Default.Materiel[ListBoxMateriel.SelectedIndex] = TextBoxMat.Text;
                Properties.Settings.Default.PresenceMateriel[ListBoxMateriel.SelectedIndex] = "" + NumericUpDownPresence.Value;
                Properties.Settings.Default.Save();
                matOriginal = "";
                presOriginal = 0;
                MAJListBoxMat();
            }
        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxMat_TextChanged(object sender, EventArgs e)
        {
            if (!isInit)
            {//ButtonSave.Text = "Modifier";
             //ButtonSupprimer.Text = "Supprimer";
                if (modEnCour)
                {
                    if (!matOriginal.Equals(TextBoxMat.Text) || presOriginal != (int)NumericUpDownPresence.Value)
                    {
                        ButtonSave.Enabled = true;
                        ButtonSupprimer.Enabled = false;
                    }
                    else
                    {
                        ButtonSave.Enabled = false;
                        ButtonSupprimer.Enabled = true;
                    }
                }
                //ButtonSave.Text = "Sauvegarder";
                //ButtonSupprimer.Text = "Ajouter";
                else
                {
                    if (TextBoxMat.Text.Length > 0)
                    {
                        ButtonSupprimer.Enabled = true;
                        NumericUpDownPresence.Enabled = true;
                    }
                    else
                    {
                        ButtonSupprimer.Enabled = false;
                        NumericUpDownPresence.Enabled = false;
                    }
                }
            }
        }

        private void ListBoxMateriel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInit)
            {
                if (ListBoxMateriel.SelectedIndex >= 0)
                {
                    ButtonSave.Text = "Modifier";
                    ButtonSupprimer.Text = "Supprimer";
                    ButtonSupprimer.Enabled = true;
                    NumericUpDownPresence.Enabled = true;
                    isInit = true;
                    TextBoxMat.Text = Properties.Settings.Default.Materiel[ListBoxMateriel.SelectedIndex];
                    matOriginal = string.Copy(Properties.Settings.Default.Materiel[ListBoxMateriel.SelectedIndex]);
                    int number;
                    bool res = int.TryParse(Properties.Settings.Default.PresenceMateriel[ListBoxMateriel.SelectedIndex], out number);

                    if (res)
                    {
                        NumericUpDownPresence.Value = number;
                        presOriginal = number;
                    }
                    else
                    {
                        NumericUpDownPresence.Value = 0;
                        presOriginal = 0;
                    }
                    modEnCour = true;
                    isInit = false;
                }
                else
                {
                    ButtonSave.Text = "Sauvegarder";
                    ButtonSupprimer.Text = "Ajouter";
                    TextBoxMat.Text = "";
                    ButtonSupprimer.Enabled = false;
                    modEnCour = false;
                }
            }
        }

        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            //ButtonSave.Text = "Modifier";
            //ButtonSupprimer.Text = "Supprimer";
            if (modEnCour)
            {
                if (MessageBox.Show("Attention, la suppression est définitive!!\nÊtes-vous certain de vouloir supprimer ce materiel?", "ATTENTION!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Materiel.RemoveAt(ListBoxMateriel.SelectedIndex);
                    Properties.Settings.Default.PresenceMateriel.RemoveAt(ListBoxMateriel.SelectedIndex);
                    Properties.Settings.Default.Save();
                    matOriginal = "";
                    presOriginal = 0;
                    ButtonSave.Enabled = true;
                    ButtonSave.Text = "Sauvegarder";
                    ButtonAnnuler.Enabled = false;
                }
            }
            //ButtonSave.Text = "Sauvegarder";
            //ButtonSupprimer.Text = "Ajouter";
            else
            {
                Properties.Settings.Default.Materiel.Add(TextBoxMat.Text);
                Properties.Settings.Default.PresenceMateriel.Add("" + NumericUpDownPresence.Value);
                Properties.Settings.Default.Save();
                ButtonSave.Enabled = true;
                ButtonSave.Text = "Sauvegarder";
                ButtonSupprimer.Enabled = false;
            }
            MAJListBoxMat();
        }

        private void MAJListBoxMat()
        {
            modEnCour = false;
            TextBoxMat.Text = "";
            isInit = true;
            bindinglist = new BindingList<string>();
            foreach (string mat in Properties.Settings.Default.Materiel)
            {
                bindinglist.Add(mat);
            }
            bSource = new BindingSource();
            bSource.DataSource = bindinglist;
            ListBoxMateriel.DataSource = bSource;
            ListBoxMateriel.ClearSelected();
            isInit = false;
        }
    }
}
