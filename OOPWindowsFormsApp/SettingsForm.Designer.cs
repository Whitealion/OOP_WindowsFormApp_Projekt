using System;
using System.Windows.Forms;

namespace OOPWindowsFormsApp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.resetFavouritePlayersButton = new System.Windows.Forms.Button();
            this.resetFavouriteTeamButton = new System.Windows.Forms.Button();
            this.changeLanguageButton = new System.Windows.Forms.Button();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resetFavouritePlayersButton
            // 
            resources.ApplyResources(this.resetFavouritePlayersButton, "resetFavouritePlayersButton");
            this.resetFavouritePlayersButton.Name = "resetFavouritePlayersButton";
            this.resetFavouritePlayersButton.UseVisualStyleBackColor = true;
            this.resetFavouritePlayersButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ResetFavouritePlayersButton_KeyPress);
            // 
            // resetFavouriteTeamButton
            // 
            resources.ApplyResources(this.resetFavouriteTeamButton, "resetFavouriteTeamButton");
            this.resetFavouriteTeamButton.Name = "resetFavouriteTeamButton";
            this.resetFavouriteTeamButton.UseVisualStyleBackColor = true;
            this.resetFavouriteTeamButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ResetFavouriteTeamButton_KeyPress);
            // 
            // changeLanguageButton
            // 
            resources.ApplyResources(this.changeLanguageButton, "changeLanguageButton");
            this.changeLanguageButton.Name = "changeLanguageButton";
            this.changeLanguageButton.UseVisualStyleBackColor = true;
            this.changeLanguageButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChangeLanguageButton_KeyPress);
            // 
            // languageComboBox
            // 
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LanguageComboBox_KeyPress);
            // 
            // confirmButton
            // 
            resources.ApplyResources(this.confirmButton, "confirmButton");
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfirmButton_KeyPress);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CancelButton_KeyPress);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.resetFavouritePlayersButton);
            this.Controls.Add(this.resetFavouriteTeamButton);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.changeLanguageButton);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button resetFavouritePlayersButton;
        private System.Windows.Forms.Button resetFavouriteTeamButton;
        private System.Windows.Forms.Button changeLanguageButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}