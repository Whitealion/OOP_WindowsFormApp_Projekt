using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPWindowsFormsApp
{
    public partial class SettingsForm : Form
    {
        private Klasice.Data.Language language;

        public SettingsForm(Klasice.Data.Language language, Image backgroundImage)
        {
            this.language = language;
            BackgroundImage = backgroundImage;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.IkonaOdSrednje;
        }
    }
}
