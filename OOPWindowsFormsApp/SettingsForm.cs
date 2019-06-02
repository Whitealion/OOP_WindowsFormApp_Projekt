using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOPWindowsFormsApp
{
    public partial class SettingsForm : Form
    {
        private Klasice.Data.Language language;
        private MainForm mainForm;
        private bool resetTeam = false, resetPlayers = false, changeLanguage = false;
        private const string LANGUAGE_PATH = @"data\language.txt";

        public SettingsForm(Klasice.Data.Language language, Image backgroundImage, MainForm form)
        {
            mainForm = form;
            this.language = language;
            BackgroundImage = backgroundImage;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ChangeLanguage(SetLanguage(language));
            Icon = Properties.Resources.IkonaOdSrednje;
            languageComboBox.DataSource = Enum.GetValues(typeof(Klasice.Data.Language));

            resetFavouriteTeamButton.Click += ResetFavouriteTeamButton_Click;
            resetFavouritePlayersButton.Click += ResetFavouritePlayersButton_Click;
            confirmButton.Click += ConfirmButton_Click;
            cancelButton.Click += CancelButton_Click;
            changeLanguageButton.Click += ChangeLanguageButton_Click;
            languageComboBox.KeyPress += LanguageComboBox_KeyPress1;
        }

        public void ChangeLanguage(string lang)
        {
            foreach (Control c in Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(SettingsForm));
                resources.ApplyResources(c, c.Name, new System.Globalization.CultureInfo(lang));
            }
        }

        public string SetLanguage(Klasice.Data.Language language)
        {
            switch (language)
            {
                case Klasice.Data.Language.English:
                    return "en";

                case Klasice.Data.Language.Hrvatski:
                    return "hr";

                default:
                    return "en";
            }
        }

        private void LanguageComboBox_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                ConfirmAndExit();
            }
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            changeLanguage = true;
            switch (mainForm.language)
            {
                case Klasice.Data.Language.English:
                    MessageBox.Show("Language will be changed when applying changes.", "Warning");
                    break;

                case Klasice.Data.Language.Hrvatski:
                    MessageBox.Show("Nakon potvrde će odabrani jezik biti promjenjen,", "Warning");
                    break;
            }
            language = (Klasice.Data.Language)languageComboBox.SelectedValue;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelAndExit();
        }

        private void CancelAndExit()
        {
            resetTeam = false;
            resetPlayers = false;
            changeLanguage = false;
            Hide();
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ConfirmAndExit();
        }

        private void ConfirmAndExit()
        {
            if (resetTeam)
            {
                mainForm.ResetBackground();
                File.WriteAllText(MainForm.FAVOURITE_TEAM_PATH, "");
            }
            if (resetPlayers)
            {
                mainForm.omiljeniIgraciPanel.Controls.Clear();
                File.WriteAllText(MainForm.FAVOURITE_PLAYERS_PATH, "");
            }
            if (changeLanguage)
            {
                mainForm.ChangeLanguage(mainForm.SetLanguage(language));
                File.WriteAllText(LANGUAGE_PATH, language.ToString());
            }

            Hide();
            Close();
        }

        private void ResetFavouritePlayersButton_Click(object sender, EventArgs e)
        {
            resetPlayers = true;
            switch (mainForm.language)
            {
                case Klasice.Data.Language.English:
                    MessageBox.Show("Favourite team will be reset when apllying changes.", "Warning");
                    break;

                case Klasice.Data.Language.Hrvatski:
                    MessageBox.Show("Nakon potvrde će omiljena reprezentacija biti resetirana.", "Warning");
                    break;
            }
        }

        private void ResetFavouriteTeamButton_Click(object sender, EventArgs e)
        {
            resetTeam = true;
            switch (mainForm.language)
            {
                case Klasice.Data.Language.English:
                    MessageBox.Show("Favourite players will be reset when apllying changes.", "Warning");
                    break;

                case Klasice.Data.Language.Hrvatski:
                    MessageBox.Show("Nakon potvrde će omiljeni igrači biti resetirani.", "Warning");
                    break;
            }
        }

        #region eventovi za ESC key

        private void ChangeLanguageButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CancelAndExit();
            }
        }

        private void ResetFavouriteTeamButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CancelAndExit();
            }
        }

        private void ResetFavouritePlayersButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CancelAndExit();
            }
        }

        private void ConfirmButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CancelAndExit();
            }
        }

        private void CancelButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ConfirmAndExit();
            }
        }

        private void LanguageComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CancelAndExit();
            }
        }

        #endregion
    }
}
