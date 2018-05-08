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
    public partial class FormContenant : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ClassContenant Contenant { get; set; }
        int presBase, presTotal;
        bool init;
        BindingList<string> bindinglist;
        BindingSource bSource;

        /// <summary>
        /// 
        /// </summary>
        public FormContenant()
        {
            init = true;
            InitializeComponent();
            Contenant = new ClassContenant();
            CloseSaveCancel = false;
            presBase = 0;
            presTotal = 0;
            ComboBoxQualite.DataSource = Properties.Settings.Default.BonusQualiteItem;
            ComboBoxQualite.SelectedIndex = 1;
            bindinglist = new BindingList<string>();
            foreach (string mat in Properties.Settings.Default.Materiel)
            {
                bindinglist.Add(mat);
            }
            bSource = new BindingSource();
            bSource.DataSource = bindinglist;
            ComboBoxMateriel.DataSource = bSource;
            ComboBoxMateriel.SelectedIndex = 3;
            if (!init)
                CalculerPresenceTotal();
            init = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="contenant"></param>
        /// <returns></returns>
        public System.Windows.Forms.DialogResult ShowDialog(ClassContenant contenant)
        {
            System.Windows.Forms.DialogResult result;

            Contenant = contenant;

            result = this.ShowDialog();

            if (!init)
                CalculerPresenceTotal();

            return result;
        }

        private void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            CloseSaveCancel = false;
            this.Dispose();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (CheckBoxAltDestin.Checked)
                Contenant.AffiniteAltDestin.SetAffinite(20);
            if (CheckBoxAmelioMaintPouvoir.Checked)
                Contenant.AffiniteAmelioMaintPouvoir.SetAffinite(20);
            if (CheckBoxAmelorationRes.Checked)
                Contenant.AffiniteAmelorationRes.SetAffinite(20);
            if (CheckBoxAmpliAMR.Checked)
                Contenant.AffiniteAmpliAMR.SetAffinite(20);
            if (CheckBoxAttElem.Checked)
                Contenant.AffiniteAttElement.SetAffinite(20);
            if (CheckBoxAttSpec.Checked)
                Contenant.AffiniteAttSpec.SetAffinite(20);
            if (CheckBoxAugmentCharac.Checked)
                Contenant.AffiniteAugmentCharac.SetAffinite(20);
            if (CheckBoxAugmentComSec.Checked)
                Contenant.AffiniteAugmentCompSec.SetAffinite(20);
            if (CheckBoxAugmentDep.Checked)
                Contenant.AffiniteAugmentDeplacement.SetAffinite(20);
            if (CheckBoxCompLancement.Checked)
                Contenant.AffiniteCompLancement.SetAffinite(20);
            if (CheckBoxConvoAccrue.Checked)
                Contenant.AffiniteConvoAccrue.SetAffinite(20);
            if (CheckBoxCreateProtail.Checked)
                Contenant.AffiniteCreatePortail.SetAffinite(20);
            if (CheckBoxEffetMystique.Checked)
                Contenant.AffiniteEffetMystique.SetAffinite(20);
            if (CheckBoxImmunite.Checked)
                Contenant.AffiniteImmunite.SetAffinite(20);
            if (CheckBoxImmuniteElem.Checked)
                Contenant.AffiniteImmuniteElem.SetAffinite(20);
            if (CheckBoxImmunitePsy.Checked)
                Contenant.AffiniteImmunitePsy.SetAffinite(20);
            if (CheckBoxImmuniteMag.Checked)
                Contenant.AffiniteImmuniteMystique.SetAffinite(20);
            if (CheckBoxLanceurSort.Checked)
                Contenant.AffiniteLanceurSort.SetAffinite(20);
            if (CheckBoxMagieInnee.Checked)
                Contenant.AffiniteMagieInnee.SetAffinite(20);
            if (CheckBoxPresAccru.Checked)
                Contenant.AffinitePresAccru.SetAffinite(20);
            if (CheckBoxProjMag.Checked)
                Contenant.AffiniteProjMag.SetAffinite(20);
            if (CheckBoxPuisAjoutee.Checked)
                Contenant.AffinitePuissAjoutee.SetAffinite(20);
            if (CheckBoxReceptacleZeon.Checked)
                Contenant.AffiniteReceptacleZeon.SetAffinite(20);
            if (CheckBoxRechargeMag.Checked)
                Contenant.AffiniteRechargeMag.SetAffinite(20);
            if (CheckBoxReserveKi.Checked)
                Contenant.AffiniteReserveKi.SetAffinite(20);
            if (CheckBoxSeuilInvul.Checked)
                Contenant.AffiniteSeuilInvul.SetAffinite(20);
            if (CheckBoxSortAuto.Checked)
                Contenant.AffiniteSortsAuto.SetAffinite(20);
            if (CheckBoxSubstiCarac.Checked)
                Contenant.AffiniteSubstiCarac.SetAffinite(20);
            if (CheckBoxTalent.Checked)
                Contenant.AffiniteTalent.SetAffinite(20);
            if (CheckBoxTestResAccru1.Checked || CheckBoxTestResAccru2.Checked)
                Contenant.AffiniteTestResAccrus.SetAffinite(20);
            if (CheckBoxVision.Checked)
                Contenant.AffiniteVision.SetAffinite(20);
            Contenant.Exclusif = CheckBoxExclusif.Checked;

            Contenant.Materiel = ComboBoxMateriel.SelectedIndex;
            Contenant.PresenceBase = presBase;
            Contenant.PresenceTotal = presTotal;
            Contenant.Qualite = ComboBoxQualite.SelectedIndex;
            Contenant.TypeObjet = TextBoxTypeObjet.Text;

            CloseSaveCancel = true;

            this.Close();
        }

        private void TextBoxPresBase_TextChanged(object sender, EventArgs e)
        {
            int j;

            if ((Int32.TryParse(TextBoxPresBase.Text, out j)) == true)
            {
                presBase = j;
                if (!init)
                    CalculerPresenceTotal();
            }
            else if (TextBoxPresBase.Text.Length > 0)
            {
                MessageBox.Show(Properties.Settings.Default.ErreurPresenceBase, Properties.Settings.Default.Erreur,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                presBase = 0;
            }
            if (TextBoxPresBase.Text.Length == 0)
                presBase = 0;

                majForm();
        }

        private void CheckBoxExclusif_CheckedChanged(object sender, EventArgs e)
        {
            if (!init)
                CalculerPresenceTotal();
        }

        private void ComboBoxMateriel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init)
                CalculerPresenceTotal();
        }

        private void ComboBoxQualite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init)
                CalculerPresenceTotal();
        }

        private void CheckBoxTestResAccru2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxTypeObjet_TextChanged(object sender, EventArgs e)
        {
            majForm();
        }

        private void CalculerPresenceTotal()
        {
            int presTemp = presBase;

            if (CheckBoxExclusif.Checked)
            {
                presTemp += 40;
            }

            switch (ComboBoxQualite.SelectedIndex)
            {
                case 0:
                    presTemp -= 10;
                    break;
                case 2:
                    presTemp += 50;
                    break;
                case 3:
                    presTemp += 100;
                    break;
                default:
                    break;
            }

            int number;
            bool res = int.TryParse(Properties.Settings.Default.PresenceMateriel[ComboBoxMateriel.SelectedIndex], out number);

            if (res)
            {
                presTemp += number;
            }

            /*switch (ComboBoxMateriel.SelectedIndex)
            {
                case 2:
                case 4:
                    presTemp += 5;
                    break;
                case 5:
                case 6:
                case 7:
                    presTemp += 10;
                    break;
                case 8:
                case 9:
                    presTemp += 15;
                    break;
                case 10:
                    presTemp += 30;
                    break;
                case 11:
                case 12:
                    presTemp += 20;
                    break;
                case 13:
                case 15:
                    presTemp += 50;
                    break;
                case 14:
                    presTemp -= 10;
                    break;
                default:
                    break;
            }*/

            presTotal = presTemp;

            TextBoxPresTotal.Text = "" + presTotal;
        }

        private void ButtonAjouterMat_Click(object sender, EventArgs e)
        {
            FormAjouterMat formAjouterMat = new FormAjouterMat();

            formAjouterMat.ShowDialog();

            if (formAjouterMat.CloseSaveCancel)
            {
                bindinglist = new BindingList<string>();
                foreach (string mat in Properties.Settings.Default.Materiel)
                {
                    bindinglist.Add(mat);
                }
                bSource.DataSource = bindinglist;
                ComboBoxMateriel.DataSource = bSource;
            }
        }

        private void majForm()
        {
            bool contenantValide = false;

            if (presBase > 0)
            {
                contenantValide = true;
            }

            if (TextBoxTypeObjet.Text.Length == 0 && contenantValide)
            {
                contenantValide = false;
            }

            if (contenantValide)
            {
                ButtonSave.Enabled = true;
            }
            else
            {
                ButtonSave.Enabled = false;
            }
        }
    }
}
