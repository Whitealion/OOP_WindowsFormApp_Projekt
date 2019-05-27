﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPWindowsFormsApp
{
    public partial class LanguageForm : Form
    {
        private const string LANGUAGE_PATH = @"data\language.txt";
        private Klasice.Data.Team team;
        private HttpClient client;

        public LanguageForm(HttpClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        public LanguageForm(Klasice.Data.Team team, HttpClient client)
        {
            this.client = client;
            this.team = team;
            InitializeComponent();
        }

        private void LanguageButton1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(LANGUAGE_PATH, Klasice.Data.Language.English.ToString());

            Hide();
            StartMainForm();
            Close();
        }

        private void LanguageButton2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(LANGUAGE_PATH, Klasice.Data.Language.Hrvatski.ToString());

            Hide();
            StartMainForm();
            Close();
        }

        private void StartMainForm()
        {
            if (team != null)
            {
                new MainForm(Klasice.Data.Language.English, team, client).ShowDialog();
            }
            else
            {
                new MainForm(Klasice.Data.Language.Hrvatski, client).ShowDialog();
            }
        }

        private void LanguageForm_Load(object sender, EventArgs e)
        {
            Klasice.Utilities.CenterControl(menuGroupBox);
            Icon = Properties.Resources.IkonaOdSrednje;
            BackgroundImage = Properties.Resources.DefaultBackgroundImage;
        }
    }
}
