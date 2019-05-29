using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static Klasice.Data;

namespace Klasice
{
    public static class Utilities
    {
        private const string TEAMS_URL = "https://worldcup.sfg.io/teams/";
        private const string MATCHES_URL = "https://worldcup.sfg.io/matches";
        private const string BY_COUNTRY = "/country?fifa_code=";

        public static void CenterControl(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
            control.Top = (control.Parent.Height - control.Height) / 2;
        }

        public static bool IfLanguageSettingExists(string path)
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (File.Exists(path) && string.IsNullOrWhiteSpace(File.ReadAllText(path)))
            {
                return false;
            }

            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }

        public static bool IfFavouriteTeamExists(string path)
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (File.Exists(path) && string.IsNullOrWhiteSpace(File.ReadAllText(path)))
            {
                return false;
            }

            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }

        public static Team GetFavouriteTeam(string path)
        {
            string[] s = File.ReadAllText(path).Split('|');
            if (!int.TryParse(s[0], out _))
            {
                throw new CorruptedFileException("Favourite team file is corrupted.");
            }

            if (s[3].Length != 3)
            {
                throw new CorruptedFileException("Favourite team file is corrupted.");
            }

            if (!int.TryParse(s[4], out _))
            {
                throw new CorruptedFileException("Favourite team file is corrupted.");
            }

            if (!char.IsLetter(s[5][0]) && s[5].Length != 1)
            {
                throw new CorruptedFileException("Favourite team file is corrupted.");
            }

            //nemam pojma kako provjeriti country i alternate name bez da idem po cijeloj listi

            return new Team
            {
                Id = s[0],
                Country = s[1],
                Alternate_Name = s[2],
                Fifa_Code = s[3],
                Group_Id = s[4],
                Group_Letter = s[5]
            };
        }

        public static Control NewPlayerControl(Player player, int max)
        {
            int i = 0;
            Panel _playerPanel = new Panel();
            _playerPanel.Location = new Point(_playerPanel.Parent.Parent.Width/2, _playerPanel.Parent.Parent.Height / 2);
            _playerPanel.Name = "-";
            _playerPanel.Size = new Size(_playerPanel.Parent.Width - 2, 30);
            _playerPanel.TabIndex = i;
            _playerPanel.BackColor = Color.LightBlue;
            _playerPanel.Show();

            return _playerPanel;
        }

        public static Language GetLanguage(string path)
        {
            switch (File.ReadAllText(path).ToLower())
            {
                case "english":
                    return Language.English;

                case "hrvatski":
                    return Language.Hrvatski;

                default:
                    throw new CorruptedFileException("Language file is corrupted.");
            }
        }

        //obsolete
        //public static List<Team> GetTeams(string path)
        //{
        //    return new JavaScriptSerializer().Deserialize<List<Team>>(File.ReadAllText(path));
        //}

        public async static Task<List<Team>> GetTeamsAsync(HttpClient client)
        {
            //popravljeno
            var request = await client.GetAsync(TEAMS_URL).ConfigureAwait(false);
            return new JavaScriptSerializer().Deserialize<List<Team>>(await request.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async static Task<List<Match>> GetMatchesByFifaCode(HttpClient client, Team team)
        {
            var request = await client.GetAsync($"{MATCHES_URL}{BY_COUNTRY}{team.Fifa_Code}").ConfigureAwait(false);
            return new JavaScriptSerializer().Deserialize<List<Match>>(await request.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public static List<Player> GetPlayers(Match match, Team team)
        {
            List<Player> players = new List<Player>();

            if (match.Home_Team.Code == team.Fifa_Code)
            {
                players.AddRange(match.Home_Team_Statistics.Starting_Eleven);
                players.AddRange(match.Home_Team_Statistics.Substitutes);
            }
            else
            {
                players.AddRange(match.Away_Team_Statistics.Starting_Eleven);
                players.AddRange(match.Away_Team_Statistics.Substitutes);
            }

            return players;
        }

        public static void SavePlayersOfSelectedTeam(string path, List<Player> players)
        {
            File.WriteAllText(path, "");
            foreach (var player in players)
            {
                File.AppendAllText(path, player.FormatForFile() + "\n");
            }
        }

        public static void SaveFavouriteTeam(string path, Team tim)
        {
            File.WriteAllText(path, tim.FormatForFile());
        }
    }
}
