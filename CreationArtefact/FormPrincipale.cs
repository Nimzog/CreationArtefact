using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CreationArtefact
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormPrincipale : Form
    {
        FormContenant formContenant = null;
        FormFacetteQualite formFacetteQualite = null;
        FormFacetteCombat formFacetteCombat = null;
        FormAttaqueSpeciale formAttaqueSpeciale = null;
        FormFacetteDefensive formFacetteDefensive = null;
        FormFacetteProtection formFacetteProtection = null;
        FormFacetteMagique formFacetteMagique = null;
        FormFacettePsychique formFacettePsychique = null;
        FormFacetteConvocation formFacetteConvocation = null;
        FormFacetteMagieInnee formFacetteMagieInnee = null;
        FormFacetteAugmentation formFacetteAugmentation = null;
        FormFacetteMaitrise formFacetteMaitrise = null;
        FormFacetteEsoterique formFacetteEsoterique = null;
        FormEffetMystique formEffetMystique = null;

        public ClassArtefact artefact = null;
        List<string> descriptionLigne;
        bool saved;
        //bool DissimulationAdded = false;
        bool modificationActive = false;
        bool modificationContenant = false;
        
        /// <summary>
        /// 
        /// </summary>
        public FormPrincipale()
        {
            InitializeComponent();
            formContenant = new FormContenant();
            artefact = new ClassArtefact();
            ComboBoxFacette.DataSource = Properties.Settings.Default.Facette;
            descriptionLigne = new List<string>();
            saved = false;
        }

        private void MAJRichTextBoxDescArtefact()
        {
            string tempdesc = "";

            descriptionLigne = new List<string>();
            artefact.MAJPpointPouvoirPresence();
            artefact.DescriptionArtefact(descriptionLigne);

            foreach (string ligne in descriptionLigne)
            {
                tempdesc += ligne + "\n";
            }

            richTextBoxDescArtefact.Text = tempdesc;
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveFileDialogArtefact_FileOk(object sender, CancelEventArgs e)
        {
            ButtonSave.Text = "Sauvegarder";
            SauvegarderSousToolStripMenuItem.Enabled = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveArtefactToFile();
        }

        private void ButtonAjouterPouvoir_Click(object sender, EventArgs e)
        {
            bool isSavedAdded = false;
            bool wasSavePressed = false;

            if (!modificationActive)
            {
                switch (ComboBoxFacette.SelectedIndex)
                {
                    case 1:
                        if (formFacetteQualite != null)
                        {
                            formFacetteQualite.Dispose();
                        }
                        formFacetteQualite = new FormFacetteQualite();
                        formFacetteQualite.ShowDialog(this);
                        wasSavePressed = formFacetteQualite.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteQualite.Qualite);
                        }
                        break;
                    case 2:
                        if (formFacetteCombat != null)
                        {
                            formFacetteCombat.Dispose();
                        }
                        formFacetteCombat = new FormFacetteCombat();
                        formFacetteCombat.ShowDialog(this);
                        wasSavePressed = formFacetteCombat.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteCombat.Combat);
                        }
                        break;
                    case 3:
                        if (formAttaqueSpeciale != null)
                        {
                            formAttaqueSpeciale.Dispose();
                        }
                        formAttaqueSpeciale = new FormAttaqueSpeciale();
                        formAttaqueSpeciale.ShowDialog(this);
                        wasSavePressed = formAttaqueSpeciale.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formAttaqueSpeciale.AttaqueSpec);
                        }
                        break;
                    case 4:
                        if (formFacetteDefensive != null)
                        {
                            formFacetteDefensive.Dispose();
                        }
                        formFacetteDefensive = new FormFacetteDefensive();
                        formFacetteDefensive.ShowDialog(this);
                        wasSavePressed = formFacetteDefensive.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteDefensive.Defense);
                        }
                        break;
                    case 5:
                        if (formFacetteProtection != null)
                        {
                            formFacetteProtection.Dispose();
                        }
                        formFacetteProtection = new FormFacetteProtection();
                        formFacetteProtection.ShowDialog(this);
                        wasSavePressed = formFacetteProtection.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteProtection.Protection);
                        }
                        break;
                    case 6:
                        if (formFacetteMagique != null)
                        {
                            formFacetteMagique.Dispose();
                        }
                        formFacetteMagique = new FormFacetteMagique();
                        formFacetteMagique.ShowDialog(this);
                        wasSavePressed = formFacetteMagique.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteMagique.Magique);
                        }
                        break;
                    case 7:
                        if (formFacettePsychique != null)
                        {
                            formFacettePsychique.Dispose();
                        }
                        formFacettePsychique = new FormFacettePsychique();
                        formFacettePsychique.ShowDialog(this);
                        wasSavePressed = formFacettePsychique.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacettePsychique.Psychique);
                        }
                        break;
                    case 8:
                        if (formFacetteConvocation != null)
                        {
                            formFacetteConvocation.Dispose();
                        }
                        formFacetteConvocation = new FormFacetteConvocation();
                        formFacetteConvocation.ShowDialog(this);
                        wasSavePressed = formFacetteConvocation.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteConvocation.Convocation);
                        }
                        break;
                    case 9:
                        if (formFacetteMagieInnee != null)
                        {
                            formFacetteMagieInnee.Dispose();
                        }
                        formFacetteMagieInnee = new FormFacetteMagieInnee();
                        formFacetteMagieInnee.ShowDialog(this);
                        wasSavePressed = formFacetteMagieInnee.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteMagieInnee.MagieInnee);
                        }
                        break;
                    case 10:
                        if (formFacetteAugmentation != null)
                        {
                            formFacetteAugmentation.Dispose();
                        }
                        formFacetteAugmentation = new FormFacetteAugmentation();
                        formFacetteAugmentation.ShowDialog(this);
                        wasSavePressed = formFacetteAugmentation.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteAugmentation.Augmentation);
                        }
                        break;
                    case 11:
                        if (formFacetteMaitrise != null)
                        {
                            formFacetteMaitrise.Dispose();
                        }
                        formFacetteMaitrise = new FormFacetteMaitrise();
                        formFacetteMaitrise.ShowDialog(this);
                        wasSavePressed = formFacetteMaitrise.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteMaitrise.Maitrise);
                        }
                        break;
                    case 12:
                        if (formFacetteEsoterique != null)
                        {
                            formFacetteEsoterique.Dispose();
                        }
                        formFacetteEsoterique = new FormFacetteEsoterique();
                        formFacetteEsoterique.ShowDialog(this);
                        wasSavePressed = formFacetteEsoterique.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formFacetteEsoterique.Esoterique);
                            /*if (formFacetteEsoterique.Esoterique.Dissimulation != 0)
                            {
                                DissimulationAdded = true;
                            }
                            if (DissimulationAdded)
                            {
                                if (MessageBox.Show("En ajoutant le pouvoir de dissimulation \nvous ne pourrez plus ajouter d'autre pouvoir.",
                                    "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    isSavedAdded = artefact.AddPouvoir(formFacetteEsoterique.Esoterique, true);
                                }
                                else
                                {
                                    DissimulationAdded = false;
                                }
                            }
                            else
                            {
                                isSavedAdded = artefact.AddPouvoir(formFacetteEsoterique.Esoterique);
                            }*/
                        }
                        break;
                    case 13:
                        if (formEffetMystique != null)
                        {
                            formEffetMystique.Dispose();
                        }
                        formEffetMystique = new FormEffetMystique();
                        formEffetMystique.ShowDialog(this);
                        wasSavePressed = formEffetMystique.CloseSaveCancel;
                        if (wasSavePressed)
                        {
                            isSavedAdded = artefact.AddPouvoir(formEffetMystique.EffetMystique);
                        }
                        break;
                    default:
                        break;
                }
                /*if (!isSavedAdded && wasSavePressed)
                {
                    MessageBox.Show("Ajout de pouvoir impossible.\nPrésence potentiellement insufisante.",
                        Properties.Settings.Default.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (DissimulationAdded)
                    {
                        DissimulationAdded = false;
                    }
                }
                else*/ if (wasSavePressed)
                {
                    MAJRichTextBoxDescArtefact();
                    RemplirListBox();
                    ButtonModifier.Enabled = true;
                    if (artefact.GetPresence() < 0)
                    {
                        ButtonSave.Enabled = false;
                        SauvegarderSousToolStripMenuItem.Enabled = false;
                        SauvegarderToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        ButtonSave.Enabled = true;
                        SauvegarderToolStripMenuItem.Enabled = true;
                        if (!saved)
                        {
                            SauvegarderSousToolStripMenuItem.Enabled = true;
                        }
                    }
                }

                ComboBoxFacette.SelectedIndex = 0;
                ComboBoxFacette.Focus();
                ButtonContenant.Enabled = false;                
            }
            else
            {
                if (ListBoxArtefact.SelectedIndex == 0)
                {
                    formContenant.ShowDialog(artefact.Contenant);

                    if (formContenant.CloseSaveCancel)
                    {
                        artefact.SetContenant(formContenant.Contenant);                        
                    }
                }
                else
                {
                    switch (artefact.Pouvoirs[ListBoxArtefact.SelectedIndex-1].TypePouvoir)
                    {
                        case TypeFacette.FacetteAugmentation:
                            if (formFacetteAugmentation != null)
                            {
                                formFacetteAugmentation.Dispose();
                            }
                            formFacetteAugmentation = new FormFacetteAugmentation();
                            formFacetteAugmentation.ShowDialog((ClassFacetteAugmentation)(artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]));
                            wasSavePressed = formFacetteAugmentation.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteAugmentation.Augmentation, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteCombat:
                            if (formFacetteCombat != null)
                            {
                                formFacetteCombat.Dispose();
                            }
                            formFacetteCombat = new FormFacetteCombat();
                            formFacetteCombat.ShowDialog((ClassFacetteCombat)(artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]));
                            wasSavePressed = formFacetteCombat.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteCombat.Combat, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteConvocation:
                            if (formFacetteConvocation != null)
                            {
                                formFacetteConvocation.Dispose();
                            }
                            formFacetteConvocation = new FormFacetteConvocation();
                            formFacetteConvocation.ShowDialog((ClassFacetteConvocation)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteConvocation.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteConvocation.Convocation, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteDefensive:
                            if (formFacetteDefensive != null)
                            {
                                formFacetteDefensive.Dispose();
                            }
                            formFacetteDefensive = new FormFacetteDefensive();
                            formFacetteDefensive.ShowDialog((ClassFacetteDefensive)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteDefensive.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteDefensive.Defense, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteEsoterique:
                            if (artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1].SubType != SubTypeFacette.EffetMystique)
                            {
                                if (formFacetteEsoterique != null)
                                {
                                    formFacetteEsoterique.Dispose();
                                }
                                formFacetteEsoterique = new FormFacetteEsoterique();
                                formFacetteEsoterique.ShowDialog((ClassFacetteEsoterique)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                                wasSavePressed = formFacetteEsoterique.CloseSaveCancel;
                                if (wasSavePressed)
                                {
                                    artefact.UpdatePouvoir(formFacetteEsoterique.Esoterique, ListBoxArtefact.SelectedIndex - 1);
                                }
                            }
                            else
                            {
                                if (formEffetMystique != null)
                                {
                                    formEffetMystique.Dispose();
                                }
                                formEffetMystique = new FormEffetMystique();
                                formEffetMystique.ShowDialog((ClassEffetMystique)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                                wasSavePressed = formEffetMystique.CloseSaveCancel;
                                if (wasSavePressed)
                                {
                                    artefact.UpdatePouvoir(formEffetMystique.EffetMystique, ListBoxArtefact.SelectedIndex - 1);
                                }
                            }
                            break;
                        case TypeFacette.FacetteInnee:
                            if (formFacetteMagieInnee != null)
                            {
                                formFacetteMagieInnee.Dispose();
                            }
                            formFacetteMagieInnee = new FormFacetteMagieInnee();
                            formFacetteMagieInnee.ShowDialog((ClassFacetteMagieInnee)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteMagieInnee.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteMagieInnee.MagieInnee, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteMagique:
                            if (formFacetteMagique != null)
                            {
                                formFacetteMagique.Dispose();
                            }
                            formFacetteMagique = new FormFacetteMagique();
                            formFacetteMagique.ShowDialog((ClassFacetteMagique)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteMagique.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteMagique.Magique, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteMaitrise:
                            if (formFacetteMaitrise != null)
                            {
                                formFacetteMaitrise.Dispose();
                            }
                            formFacetteMaitrise = new FormFacetteMaitrise();
                            formFacetteMaitrise.ShowDialog((ClassFacetteMaitrise)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteMaitrise.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteMaitrise.Maitrise, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteProtection:
                            if (formFacetteProtection != null)
                            {
                                formFacetteProtection.Dispose();
                            }
                            formFacetteProtection = new FormFacetteProtection();
                            formFacetteProtection.ShowDialog((ClassFacetteProtection)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteProtection.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteProtection.Protection, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacettePsychique:
                            if (formFacettePsychique != null)
                            {
                                formFacettePsychique.Dispose();
                            }
                            formFacettePsychique = new FormFacettePsychique();
                            formFacettePsychique.ShowDialog((ClassFacettePsychique)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteProtection.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacettePsychique.Psychique, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        case TypeFacette.FacetteQualite:
                            if (formFacetteQualite != null)
                            {
                                formFacetteQualite.Dispose();
                            }
                            formFacetteQualite = new FormFacetteQualite();
                            formFacetteQualite.ShowDialog((ClassFacetteQualite)artefact.Pouvoirs[ListBoxArtefact.SelectedIndex - 1]);
                            wasSavePressed = formFacetteQualite.CloseSaveCancel;
                            if (wasSavePressed)
                            {
                                artefact.UpdatePouvoir(formFacetteQualite.Qualite, ListBoxArtefact.SelectedIndex - 1);
                            }
                            break;
                        default:
                            break;
                    }
                }
                artefact.RecalculePresence();
                MAJRichTextBoxDescArtefact();
                RemplirListBox();
                ListBoxArtefact.ClearSelected();
            }
        }

        private void ButtonContenant_Click(object sender, EventArgs e)
        {
            formContenant.ShowDialog(artefact.Contenant);

            if (formContenant.CloseSaveCancel)
            {
                artefact.SetContenant(formContenant.Contenant);
                MAJRichTextBoxDescArtefact();
                RemplirListBox();
                ComboBoxFacette.Enabled = true;
                NouveauToolStripMenuItem.Enabled = true;
                ButtonContenant.Text = "Modifier";
                modificationContenant = true;
            }
            if (modificationContenant)
            {
                artefact.RecalculePresence();
            }
        }

        private void ComboBoxFacette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxFacette.SelectedIndex != 0)
                ButtonAjouterPouvoir.Enabled = true;
            else
                ButtonAjouterPouvoir.Enabled = false;
        }

        private void NouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formContenant.IsDisposed)
            {
                formContenant.Dispose();
            }
            formContenant = new FormContenant();

            artefact = new ClassArtefact();
            richTextBoxDescArtefact.Text = "";
            ListBoxArtefact.Items.Clear();

            ComboBoxFacette.Enabled = false;
            ButtonAjouterPouvoir.Enabled = false;
            ButtonContenant.Enabled = true;
            ButtonContenant.Text = "Créer";
            modificationActive = false;
            NouveauToolStripMenuItem.Enabled = false;
            SauvegarderSousToolStripMenuItem.Enabled = false;
            SauvegarderToolStripMenuItem.Enabled = false;
            ButtonSave.Enabled = false;
            ButtonSave.Text = "Sauvegarder sous...";
            ButtonModifier.Enabled = false;
            saved = false;
            //DissimulationAdded = false;
        }

        private void SauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveArtefactToFile();
        }

        private void SauvegarderSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveArtefactToFile();
        }

        private void SaveArtefactToFile()
        {
            DialogResult result = DialogResult.Cancel;
            string tmpDir;

            if (!saved)
            {
                SaveFileDialogArtefact.InitialDirectory = Properties.Settings.Default.RepertoireInit;
                //SaveFileDialogArtefact.RestoreDirectory = true;
                //SaveFileDialogArtefact.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml|All files (*.*)|*.*";
                SaveFileDialogArtefact.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                SaveFileDialogArtefact.FilterIndex = 1;
                result = SaveFileDialogArtefact.ShowDialog();
            }

            if (result == DialogResult.OK)
            {
                string invertFile = "", invertDir = "";
                tmpDir = SaveFileDialogArtefact.FileName;
                for (int i = SaveFileDialogArtefact.FileName.Length-1; i >= 0; i--)
                {
                    invertFile += SaveFileDialogArtefact.FileName[i];
                }
                bool dirFound = false;
                foreach (char c in invertFile)
                {
                    if (dirFound)
                        invertDir += c;
                    else
                    {
                        if (c == '\\')
                        {
                            dirFound = true;
                            invertDir += c;
                        }
                    }
                }
                tmpDir = "";
                for (int i = invertDir.Length - 1; i >= 0; i--)
                {
                    tmpDir += invertDir[i];
                }
                Properties.Settings.Default.RepertoireInit = tmpDir;
                Properties.Settings.Default.Save();                
            }

            if (result == DialogResult.OK || saved)
            {
                if (SaveFileDialogArtefact.FilterIndex == 1)
                {
                    File.WriteAllLines(SaveFileDialogArtefact.FileName, descriptionLigne);
                }
                /*else if (SaveFileDialogArtefact.FilterIndex == 2)
                {
                    XmlWriter writer = XmlWriter.Create(SaveFileDialogArtefact.FileName/*, settings*);

                    artefact.ExportXML(writer);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }*/
                else
                {
                    File.WriteAllLines(SaveFileDialogArtefact.FileName, descriptionLigne);
                }

                saved = true;                

                SauvegarderToolStripMenuItem.Enabled = false;
                ButtonSave.Enabled = false;
            }
        }

        private void AProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxArtefact aboutBoxArtefact = new AboutBoxArtefact();

            aboutBoxArtefact.ShowDialog();
        }

        private void ListBoxArtefact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxArtefact.SelectedIndex >= 0)
            {
                ButtonAjouterPouvoir.Enabled = true;
                if (ListBoxArtefact.SelectedIndex > 0)
                    ButtonSupprimer.Enabled = true;
                else
                    ButtonSupprimer.Enabled = false;

            }
            else
            {
                ButtonAjouterPouvoir.Enabled = false;
                ButtonSupprimer.Enabled = false;
            }
        }

        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            if (!modificationActive)
            {
                ListBoxArtefact.Enabled = true;
                ListBoxArtefact.Visible = true;
                richTextBoxDescArtefact.Visible = false;
                richTextBoxDescArtefact.Enabled = false;

                ButtonAjouterPouvoir.Enabled = false;
                ButtonAjouterPouvoir.Text = "Modifier";
                ButtonModifier.Text = "Terminer";
                ButtonSupprimer.Enabled = false;
                ButtonSupprimer.Visible = true;

                ButtonSave.Enabled = false;
                ButtonContenant.Enabled = false;

                ComboBoxFacette.Enabled = false;

                modificationActive = true;

                RemplirListBox();
            }
            else
            {
                ListBoxArtefact.Enabled = false;
                ListBoxArtefact.Visible = false;
                richTextBoxDescArtefact.Visible = true;
                richTextBoxDescArtefact.Enabled = true;

                ButtonAjouterPouvoir.Enabled = true;
                ButtonAjouterPouvoir.Text = "Ajouter";
                ButtonModifier.Text = "Modifier";
                ButtonSupprimer.Enabled = false;
                ButtonSupprimer.Visible = false;

                ButtonSave.Enabled = true;
                ButtonContenant.Enabled = true;

                ComboBoxFacette.Enabled = true;

                modificationActive = false;

                MAJRichTextBoxDescArtefact();
            }
        }

        private void RemplirListBox()
        {
            ListBoxArtefact.Items.Clear();

            artefact.MAJPpointPouvoirPresence();

            ListBoxArtefact.Items.Add(artefact.Contenant.DescriptionObjetUneLigne());

            foreach (ClassFacette pouvoir in artefact.Pouvoirs)
            {
                ListBoxArtefact.Items.Add(pouvoir.DescriptionPouvoirUneLigne());
            }
        }

        private void richTextBoxDescArtefact_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (ListBoxArtefact.SelectedIndex != 0)
            {
                artefact.Pouvoirs.RemoveAt(ListBoxArtefact.SelectedIndex - 1);
                RemplirListBox();
                MAJRichTextBoxDescArtefact();
            }
        }
    }
}
