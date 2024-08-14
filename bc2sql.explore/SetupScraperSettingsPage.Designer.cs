namespace bc2sql.explore
{
    partial class SetupScraperSettingsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settings = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // settings
            // 
            this.settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings.Location = new System.Drawing.Point(50, 50);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(500, 300);
            this.settings.TabIndex = 0;
            // 
            // SetupScraperSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settings);
            this.Name = "SetupScraperSettingsPage";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperSettingsPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid settings;
    }
}
