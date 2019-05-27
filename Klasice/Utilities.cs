using System;
using System.Collections.Generic;
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

            if (!char.IsLetter(s[5][0]))
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
        
        public static List<Team> GetTeams(string path)
        {
            return new JavaScriptSerializer().Deserialize<List<Team>>(File.ReadAllText(path));
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

        public async static Task<List<Team>> GetTeamsAsync(HttpClient client)
        {
            var request = await client.GetAsync(TEAMS_URL);
            return new JavaScriptSerializer().Deserialize<List<Team>>(await request.Content.ReadAsStringAsync());
        }

        public static void SaveFavouriteTeam(string path, Team tim)
        {
            File.WriteAllText(path, tim.ToString());
        }
    }
}
