using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPWindowsFormsApp
{
    static class Program
    {
        private const string LANGUAGE_PATH = @"data\language.txt";
        private const string FAVOURITE_TEAMS_PATH = @"data\favouriteTeam.txt";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HttpClient client = new HttpClient();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Klasice.Utilities.IfLanguageSettingExists(LANGUAGE_PATH))
            {
                try
                {
                    if (Klasice.Utilities.IfFavouriteTeamExists(FAVOURITE_TEAMS_PATH))
                    {
                        Application.Run(new MainForm(Klasice.Utilities.GetLanguage(LANGUAGE_PATH), Klasice.Utilities.GetFavouriteTeam(FAVOURITE_TEAMS_PATH), client));
                    }
                    else
                    {
                        Application.Run(new MainForm(Klasice.Utilities.GetLanguage(LANGUAGE_PATH), client));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}\nStarting language form.");
                    Application.Run(new LanguageForm(client));
                }
            }
            else
            {
                Application.Run(new LanguageForm(client));
            }
        }
    }
}
