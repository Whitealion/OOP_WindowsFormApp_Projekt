namespace OOPWindowsFormsApp
{
    partial class LanguageForm
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
            this.languageLabel1 = new System.Windows.Forms.Label();
            this.languageLabel2 = new System.Windows.Forms.Label();
            this.languageButton1 = new System.Windows.Forms.Button();
            this.languageButton2 = new System.Windows.Forms.Button();
            this.menuGroupBox = new System.Windows.Forms.GroupBox();
            this.menuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // languageLabel1
            // 
            this.languageLabel1.AutoSize = true;
            this.languageLabel1.Location = new System.Drawing.Point(15, 28);
            this.languageLabel1.Name = "languageLabel1";
            this.languageLabel1.Size = new System.Drawing.Size(94, 13);
            this.languageLabel1.TabIndex = 0;
            this.languageLabel1.Text = "Choose Language";
            // 
            // languageLabel2
            // 
            this.languageLabel2.AutoSize = true;
            this.languageLabel2.Location = new System.Drawing.Point(141, 28);
            this.languageLabel2.Name = "languageLabel2";
            this.languageLabel2.Size = new System.Drawing.Size(71, 13);
            this.languageLabel2.TabIndex = 1;
            this.languageLabel2.Text = "Odaberi Jezik";
            // 
            // languageButton1
            // 
            this.languageButton1.AutoSize = true;
            this.languageButton1.Location = new System.Drawing.Point(18, 87);
            this.languageButton1.Name = "languageButton1";
            this.languageButton1.Size = new System.Drawing.Size(75, 23);
            this.languageButton1.TabIndex = 2;
            this.languageButton1.Text = "English";
            this.languageButton1.UseVisualStyleBackColor = true;
            this.languageButton1.Click += new System.EventHandler(this.LanguageButton1_Click);
            // 
            // languageButton2
            // 
            this.languageButton2.Location = new System.Drawing.Point(137, 87);
            this.languageButton2.Name = "languageButton2";
            this.languageButton2.Size = new System.Drawing.Size(75, 23);
            this.languageButton2.TabIndex = 3;
            this.languageButton2.Text = "Hrvatski";
            this.languageButton2.UseVisualStyleBackColor = true;
            this.languageButton2.Click += new System.EventHandler(this.LanguageButton2_Click);
            // 
            // menuGroupBox
            // 
            this.menuGroupBox.Controls.Add(this.languageLabel1);
            this.menuGroupBox.Controls.Add(this.languageLabel2);
            this.menuGroupBox.Controls.Add(this.languageButton2);
            this.menuGroupBox.Controls.Add(this.languageButton1);
            this.menuGroupBox.Location = new System.Drawing.Point(263, 159);
            this.menuGroupBox.Name = "menuGroupBox";
            this.menuGroupBox.Size = new System.Drawing.Size(232, 135);
            this.menuGroupBox.TabIndex = 4;
            this.menuGroupBox.TabStop = false;
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuGroupBox);
            this.MaximizeBox = false;
            this.Name = "LanguageForm";
            this.Text = "絶望 Nogomet";
            this.Load += new System.EventHandler(this.LanguageForm_Load);
            this.menuGroupBox.ResumeLayout(false);
            this.menuGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label languageLabel1;
        private System.Windows.Forms.Label languageLabel2;
        private System.Windows.Forms.Button languageButton1;
        private System.Windows.Forms.Button languageButton2;
        private System.Windows.Forms.GroupBox menuGroupBox;
    }
}