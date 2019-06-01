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
using Klasice;

namespace OOPWindowsFormsApp
{
    public partial class MainForm : Form
    {
        //obsolete
        //private const string TEAMS_PATH = @"data\team.json";
        private const string FAVOURITE_TEAM_PATH = "data\\favouriteTeam.txt";
        private const string FAVOURITE_PLAYERS_PATH = "data\\favouritePlayers.txt";
        //private const string FAVOURITE_TEAM_PLAYERS_PATH = "data\\favouriteTeamPlayers.txt";
        private Klasice.Data.Language language;
        private Klasice.Data.Team tim = null;
        private List<Klasice.Data.Player> players = null;
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

            if (Klasice.Utilities.IfFavouritePlayersExists(FAVOURITE_PLAYERS_PATH))
            {
                FillFavouritePlayers();
            }

            foreach (Control c in omiljeniIgraciPanel.Controls)
            {
                c.MouseDown += new MouseEventHandler(c_MouseDown);
            }
            omiljeniIgraciPanel.DragOver += new DragEventHandler(omiljeniIgraciPanel_DragOver);
            omiljeniIgraciPanel.DragDrop += new DragEventHandler(omiljeniIgraciPanel_DragDrop);

            //omiljeniIgraciPanel.DragEnter += OmiljeniIgraciPanel_DragEnter;
            
        }

        private void FillFavouritePlayers()
        {
            string[] lines = File.ReadAllLines(FAVOURITE_PLAYERS_PATH);
            for (int i = 1; i < lines.Length; i++)
            {
                Panel dynamicPanel = new Panel();
                dynamicPanel.Dock = DockStyle.Top;
                dynamicPanel.Location = new System.Drawing.Point();
                dynamicPanel.Size = new System.Drawing.Size(258, 50);
                dynamicPanel.BackColor = Color.LightBlue;
                dynamicPanel.BorderStyle = BorderStyle.FixedSingle;


                Panel _playerPanel = new Panel();
                _playerPanel.Location = new Point(5, 4);
                _playerPanel.Size = new Size(230, 40);
                _playerPanel.BackColor = Color.Violet;
                _playerPanel.Enabled = false;

                //nekada odreze dio teksta ako je predugacko ime ¯\_(ツ)_/¯
                Label _playerLabel = new Label();
                _playerLabel.Location = new Point(5, 5);
                _playerLabel.Text = $"{lines[i - 1]}\n{lines[i++]}";
                _playerLabel.Size = new Size(195, 30);
                _playerLabel.BackColor = Color.Transparent;
                _playerLabel.Enabled = true;
                _playerLabel.ForeColor = Color.Black;
                _playerLabel.Paint += _playerLabel_Paint;
                // _playerLabel.MouseClick += _playerLabel_MouseClick;

                PictureBox _playerIsFavourite = new PictureBox();
                _playerIsFavourite.Location = new Point(200, 10);
                _playerIsFavourite.Size = new Size(20, 20);
                _playerIsFavourite.Image = Properties.Resources.star;
                _playerIsFavourite.SizeMode = PictureBoxSizeMode.Zoom;
                _playerIsFavourite.Enabled = false;

                _playerPanel.Controls.Add(_playerLabel);
                _playerPanel.Controls.Add(_playerIsFavourite);
                dynamicPanel.Controls.Add(_playerPanel);


                omiljeniIgraciPanel.Controls.Add(dynamicPanel);
            }
        }

        private void igracPanel_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;

            var child = c.GetNextControl(c, true);
            child.Controls.RemoveAt(1);
            var grandchild = child.GetNextControl(child, true);
            omiljeniIgraciPanel.Controls.Remove(c);

            int i = 0;
            foreach (Control item in igracPanel.Controls)
            {
                var idk = item.GetNextControl(item.GetNextControl(item, true), true);
                if (grandchild.Text == idk.Text)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                c.Location = igracPanel.PointToClient(new Point(e.X, e.Y));
                igracPanel.Controls.Add(c);
            }


            File.WriteAllText(FAVOURITE_PLAYERS_PATH, "");
            foreach (Control item in omiljeniIgraciPanel.Controls)
            {
                var panela = item.GetNextControl(item, true);
                var labela = panela.GetNextControl(panela, true);
                File.AppendAllText(FAVOURITE_PLAYERS_PATH, labela.Text + "\n");
            }
        }

        //private void OmiljeniIgraciPanel_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //}

        private void omiljeniIgraciPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void omiljeniIgraciPanel_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;

            PictureBox _playerIsFavourite = new PictureBox();
            _playerIsFavourite.Location = new Point(200, 10);
            _playerIsFavourite.Size = new Size(20, 20);
            _playerIsFavourite.Image = Properties.Resources.star;
            _playerIsFavourite.SizeMode = PictureBoxSizeMode.Zoom;
            _playerIsFavourite.Enabled = false;

            var child = c.GetNextControl(c, true);
            var grandchild = child.GetNextControl(child, true);
            igracPanel.Controls.Remove(c);

            int i = 0;
            foreach (Control item in omiljeniIgraciPanel.Controls)
            {
                var idk = item.GetNextControl(item.GetNextControl(item, true), true);
                if (grandchild.Text == idk.Text)
                {
                    i++;
                }
            }

            if (omiljeniIgraciPanel.Controls.Count < 3 && i == 0)
            {
                c.Location = omiljeniIgraciPanel.PointToClient(new Point(e.X, e.Y));
                omiljeniIgraciPanel.Controls.Add(c);
                child.Controls.Add(_playerIsFavourite);

                File.WriteAllText(FAVOURITE_PLAYERS_PATH,"");
                foreach (Control item in omiljeniIgraciPanel.Controls)
                {
                    var panela = item.GetNextControl(item, true);
                    var labela = panela.GetNextControl(panela, true);
                    File.AppendAllText(FAVOURITE_PLAYERS_PATH, labela.Text + "\n");
                }
            }
            else if(omiljeniIgraciPanel.Controls.Count >= 3)
            {
                switch (language)
                {
                    case Klasice.Data.Language.English:
                        MessageBox.Show("Maximum 3 favourite players.");
                        break;

                    case Klasice.Data.Language.Hrvatski:
                        MessageBox.Show("Maksimalno 3 omiljena igrača.");
                        break;
                }
            }
        }

        private void igracPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private static void c_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void FillPlayerList(Klasice.Data.Team tim)
        {
            players = Klasice.Utilities.GetPlayers(Klasice.Utilities.GetMatchesByFifaCode(client, tim).Result[0], tim);
            foreach (Klasice.Data.Player player in players)
            {
                igracPanel.Controls.Add(NewPlayerControl(player));
            }
        }

        private static Control NewPlayerControl(Data.Player player)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Dock = DockStyle.Top;
            dynamicPanel.Location = new System.Drawing.Point();
            dynamicPanel.Size = new System.Drawing.Size(258, 50);
            dynamicPanel.BackColor = Color.LightBlue;
            dynamicPanel.BorderStyle = BorderStyle.FixedSingle;


            Panel _playerPanel = new Panel();
            _playerPanel.Location = new Point(5, 4);
            _playerPanel.Size = new Size(230, 40);
            _playerPanel.BackColor = Color.Violet;
            _playerPanel.Enabled = false;

            //nekada odreze dio teksta ako je predugacko ime ¯\_(ツ)_/¯
            Label _playerLabel = new Label();
            _playerLabel.Location = new Point(5, 5);
            _playerLabel.Text = player.ToString();
            _playerLabel.Size = new Size(195, 30);
            _playerLabel.BackColor = Color.Transparent;
            _playerLabel.Enabled = true;
            _playerLabel.Paint += _playerLabel_Paint;
            _playerLabel.ForeColor = Color.Black;
           // _playerLabel.MouseClick += _playerLabel_MouseClick;

            _playerPanel.Controls.Add(_playerLabel);
            dynamicPanel.Controls.Add(_playerPanel);
            //foreach (Control c in dynamicPanel.Controls)
            //{
            //    c.MouseDown += c_MouseDown;
            //}

            return dynamicPanel;
        }

        private static void _playerLabel_Paint(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            SolidBrush drawBrush = new SolidBrush(c.ForeColor);
            e.Graphics.DrawString(c.Text, c.Font, drawBrush, 0f, 0f);
        }

        private static void _playerLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.Parent.Parent.DoDragDrop(c.Parent.Parent, DragDropEffects.Move);
        }

        private void ConfirmFavouriteTeamButton_Click(object sender, EventArgs e)
        {
            tim = (Klasice.Data.Team)teamsComboBox.SelectedItem;
            Klasice.Utilities.SaveFavouriteTeam(FAVOURITE_TEAM_PATH, tim);
            //Klasice.Utilities.SavePlayersOfSelectedTeam(FAVOURITE_TEAM_PLAYERS_PATH, Klasice.Utilities.GetPlayers(Klasice.Utilities.GetMatchesByFifaCode(client, tim).Result[0], tim));

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

        //pojma nemam kaj radim
        private void TeamsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            igracPanel.Controls.Clear();
            tim = (Klasice.Data.Team)teamsComboBox.SelectedItem;
            FillPlayerList(tim);

            foreach (Control c in igracPanel.Controls)
            {
                c.MouseDown += new MouseEventHandler(c_MouseDown);
            }
            igracPanel.DragOver += new DragEventHandler(igracPanel_DragOver);
            igracPanel.DragDrop += new DragEventHandler(igracPanel_DragDrop);
        }
    }
}
