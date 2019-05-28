using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using System.Resources;
using System.Collections;
using System.Net.Http;

namespace OOPWindowsFormsApp
{
    public partial class MainForm : Form
    {
        //obsolete
        //private const string TEAMS_PATH = @"data\team.json";
        private const string FAVOURITE_TEAMS_PATH = "data\\favouriteTeam.txt";
        private Klasice.Data.Language language;
        private Klasice.Data.Team tim = null;
        private HttpClient client;

        public MainForm(Klasice.Data.Language language, Klasice.Data.Team tim, HttpClient client)
        {
            this.client = client;
            this.tim = tim;
            this.language = language;
            LoadTeamBackground();
            InitializeComponent();
        }

        public MainForm(Klasice.Data.Language language, HttpClient client)
        {
            this.client = client;
            BackgroundImage = Properties.Resources.DefaultBackgroundImage;
            this.language = language;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeLanguage(SetLanguage(language));

            Icon = Properties.Resources.IkonaOdSrednje;

            //obsolete
            //Task<List<Klasice.Data.Team>> teams = Klasice.Utilities.GetTeamsAsync(client);
            //List<Klasice.Data.Team> timovi = Klasice.Utilities.GetTeams(TEAMS_PATH);

            teamsComboBox.DataSource = Klasice.Utilities.GetTeamsAsync(client).Result;
            teamsComboBox.DisplayMember = "FormattedName";
        }

        private void ConfirmFavouriteTeamButton_Click(object sender, EventArgs e)
        {
            tim = (Klasice.Data.Team)teamsComboBox.SelectedItem;
            Klasice.Utilities.SaveFavouriteTeam(FAVOURITE_TEAMS_PATH, tim);

            LoadTeamBackground();

            switch (language)
            {
                case Klasice.Data.Language.English:
                    MessageBox.Show("Favourite team saved.");
                    break;

                case Klasice.Data.Language.Hrvatski:
                    MessageBox.Show("Spremljen omiljeni tim.");
                    break;
            }
        }

        private string SetLanguage(Klasice.Data.Language language)
        {
            switch (language)
            {
                case Klasice.Data.Language.English:
                    return"en";

                case Klasice.Data.Language.Hrvatski:
                    //iz nekog razloga uporno stavlja tekst na engleski samo za ovaj gumb
                    confirmFavouriteTeamButton.Text = "Potvrdi omiljenu reprezentaciju."; 
                    return "hr";

                default:
                    return "en";
            }
        }

        private void LoadTeamBackground()
        {
            foreach (DictionaryEntry entry in Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
            {
                if (tim.Fifa_Code == entry.Key.ToString())
                {
                    BackgroundImage = (Bitmap)entry.Value;
                }
            }
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm(language, BackgroundImage).ShowDialog();
        }
    }
}
