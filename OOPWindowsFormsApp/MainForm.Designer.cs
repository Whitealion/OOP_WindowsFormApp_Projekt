namespace OOPWindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.teamsComboBox = new System.Windows.Forms.ComboBox();
            this.confirmFavouriteTeamButton = new System.Windows.Forms.Button();
            this.teamsGroupBox = new System.Windows.Forms.GroupBox();
            this.showMatchesButton = new System.Windows.Forms.Button();
            this.igracPictureBox = new System.Windows.Forms.PictureBox();
            this.omiljeniIgraciPanel = new System.Windows.Forms.Panel();
            this.omiljeniIgraciLabel = new System.Windows.Forms.Label();
            this.igracPanel = new System.Windows.Forms.Panel();
            this.igraciLabel = new System.Windows.Forms.Label();
            this.prikazIgracaButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.teamsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.igracPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // teamsComboBox
            // 
            resources.ApplyResources(this.teamsComboBox, "teamsComboBox");
            this.teamsComboBox.FormattingEnabled = true;
            this.teamsComboBox.Name = "teamsComboBox";
            this.teamsComboBox.SelectedIndexChanged += new System.EventHandler(this.TeamsComboBox_SelectedIndexChanged);
            // 
            // confirmFavouriteTeamButton
            // 
            resources.ApplyResources(this.confirmFavouriteTeamButton, "confirmFavouriteTeamButton");
            this.confirmFavouriteTeamButton.Name = "confirmFavouriteTeamButton";
            this.confirmFavouriteTeamButton.UseVisualStyleBackColor = true;
            this.confirmFavouriteTeamButton.Click += new System.EventHandler(this.ConfirmFavouriteTeamButton_Click);
            // 
            // teamsGroupBox
            // 
            resources.ApplyResources(this.teamsGroupBox, "teamsGroupBox");
            this.teamsGroupBox.Controls.Add(this.showMatchesButton);
            this.teamsGroupBox.Controls.Add(this.confirmFavouriteTeamButton);
            this.teamsGroupBox.Controls.Add(this.teamsComboBox);
            this.teamsGroupBox.Name = "teamsGroupBox";
            this.teamsGroupBox.TabStop = false;
            // 
            // showMatchesButton
            // 
            resources.ApplyResources(this.showMatchesButton, "showMatchesButton");
            this.showMatchesButton.Name = "showMatchesButton";
            this.showMatchesButton.UseVisualStyleBackColor = true;
            // 
            // igracPictureBox
            // 
            resources.ApplyResources(this.igracPictureBox, "igracPictureBox");
            this.igracPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.igracPictureBox.Name = "igracPictureBox";
            this.igracPictureBox.TabStop = false;
            // 
            // omiljeniIgraciPanel
            // 
            resources.ApplyResources(this.omiljeniIgraciPanel, "omiljeniIgraciPanel");
            this.omiljeniIgraciPanel.AllowDrop = true;
            this.omiljeniIgraciPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.omiljeniIgraciPanel.Name = "omiljeniIgraciPanel";
            // 
            // omiljeniIgraciLabel
            // 
            resources.ApplyResources(this.omiljeniIgraciLabel, "omiljeniIgraciLabel");
            this.omiljeniIgraciLabel.Name = "omiljeniIgraciLabel";
            // 
            // igracPanel
            // 
            resources.ApplyResources(this.igracPanel, "igracPanel");
            this.igracPanel.AllowDrop = true;
            this.igracPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.igracPanel.Name = "igracPanel";
            // 
            // igraciLabel
            // 
            resources.ApplyResources(this.igraciLabel, "igraciLabel");
            this.igraciLabel.Name = "igraciLabel";
            // 
            // prikazIgracaButton
            // 
            resources.ApplyResources(this.prikazIgracaButton, "prikazIgracaButton");
            this.prikazIgracaButton.Name = "prikazIgracaButton";
            this.prikazIgracaButton.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            resources.ApplyResources(this.settingsButton, "settingsButton");
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.prikazIgracaButton);
            this.Controls.Add(this.igraciLabel);
            this.Controls.Add(this.igracPanel);
            this.Controls.Add(this.omiljeniIgraciLabel);
            this.Controls.Add(this.omiljeniIgraciPanel);
            this.Controls.Add(this.teamsGroupBox);
            this.Controls.Add(this.igracPictureBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.teamsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.igracPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox igracPictureBox;
        private System.Windows.Forms.ComboBox teamsComboBox;
        private System.Windows.Forms.Button confirmFavouriteTeamButton;
        private System.Windows.Forms.GroupBox teamsGroupBox;
        private System.Windows.Forms.Panel omiljeniIgraciPanel;
        private System.Windows.Forms.Label omiljeniIgraciLabel;
        private System.Windows.Forms.Panel igracPanel;
        private System.Windows.Forms.Label igraciLabel;
        private System.Windows.Forms.Button prikazIgracaButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button showMatchesButton;
    }
}

