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
    public partial class FormAjoutSortMagieInnee : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public bool CloseSaveCancel;
        /// <summary>
        /// 
        /// </summary>
        public ClassSort Sort;
        int voiePrecedente;

        public FormAjoutSortMagieInnee()
        {
            InitializeComponent();

            CloseSaveCancel = false;
            Sort = null;

            voiePrecedente = 0;

            ComboBoxVoieMagie.DataSource = Properties.Settings.Default.VoieDeMagie;
        }

        private void TextBoxNomSort_TextChanged(object sender, EventArgs e)
        {
            majForme();
        }

        private void ComboBoxVoieMagie_SelectedIndexChanged(object sender, EventArgs e)
        {
            majForme();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            CreerSort();

            CloseSaveCancel = true;

            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseSaveCancel = false;

            this.Close();
        }

        private void CreerSort()
        {
            Sort = new ClassSort((int)NumericUpDownNiveau.Value, (int)NumericUpDownZeon.Value, TextBoxNomSort.Text, ComboBoxVoieMagie.SelectedIndex);
        }

        private void majForme()
        {
            if (TextBoxNomSort.Text.Length != 0 && ComboBoxVoieMagie.SelectedIndex != 0)
            {
                ButtonSave.Enabled = true;
            }
            else
            {
                ButtonSave.Enabled = false;
            }
        }

        public void ShowDialog(int ajout)
        {
            if (ajout > 0)
            {
                voiePrecedente = ajout;
            }
            ShowDialog();
        }

        private void FormAjoutSortMagieInnee_Load(object sender, EventArgs e)
        {
            if (voiePrecedente > 0)
            {
                ComboBoxVoieMagie.Enabled = false;
                ComboBoxVoieMagie.SelectedIndex = voiePrecedente;
            }
        }
    }
}
