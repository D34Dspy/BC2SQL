namespace bc2sql.explore
{
    partial class SetupExplorerOpen
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
            this.recentWorkspaceOptions = new System.Windows.Forms.GroupBox();
            this.recentWorkspaces = new System.Windows.Forms.ListView();
            this.workspaceOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.addLib = new System.Windows.Forms.Button();
            this.rmLib = new System.Windows.Forms.Button();
            this.rmAllLib = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.Label();
            this.recentWorkspaceOptions.SuspendLayout();
            this.workspaceOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // recentWorkspaceOptions
            // 
            this.recentWorkspaceOptions.Controls.Add(this.recentWorkspaces);
            this.recentWorkspaceOptions.Controls.Add(this.workspaceOptions);
            this.recentWorkspaceOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentWorkspaceOptions.Location = new System.Drawing.Point(50, 50);
            this.recentWorkspaceOptions.Name = "recentWorkspaceOptions";
            this.recentWorkspaceOptions.Padding = new System.Windows.Forms.Padding(20);
            this.recentWorkspaceOptions.Size = new System.Drawing.Size(500, 262);
            this.recentWorkspaceOptions.TabIndex = 0;
            this.recentWorkspaceOptions.TabStop = false;
            this.recentWorkspaceOptions.Text = "Recent Libraries";
            // 
            // recentWorkspaces
            // 
            this.recentWorkspaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentWorkspaces.HideSelection = false;
            this.recentWorkspaces.Location = new System.Drawing.Point(20, 33);
            this.recentWorkspaces.Name = "recentWorkspaces";
            this.recentWorkspaces.Size = new System.Drawing.Size(345, 209);
            this.recentWorkspaces.TabIndex = 1;
            this.recentWorkspaces.UseCompatibleStateImageBehavior = false;
            // 
            // workspaceOptions
            // 
            this.workspaceOptions.AutoSize = true;
            this.workspaceOptions.Controls.Add(this.addLib);
            this.workspaceOptions.Controls.Add(this.rmAllLib);
            this.workspaceOptions.Controls.Add(this.rmLib);
            this.workspaceOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.workspaceOptions.Location = new System.Drawing.Point(365, 33);
            this.workspaceOptions.Name = "workspaceOptions";
            this.workspaceOptions.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.workspaceOptions.Size = new System.Drawing.Size(115, 209);
            this.workspaceOptions.TabIndex = 2;
            // 
            // addLib
            // 
            this.addLib.Location = new System.Drawing.Point(20, 0);
            this.addLib.Margin = new System.Windows.Forms.Padding(0);
            this.addLib.Name = "addLib";
            this.addLib.Size = new System.Drawing.Size(75, 23);
            this.addLib.TabIndex = 0;
            this.addLib.Text = "Add";
            this.addLib.UseVisualStyleBackColor = true;
            // 
            // rmLib
            // 
            this.rmLib.Location = new System.Drawing.Point(20, 86);
            this.rmLib.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.rmLib.Name = "rmLib";
            this.rmLib.Size = new System.Drawing.Size(75, 23);
            this.rmLib.TabIndex = 1;
            this.rmLib.Text = "Remove";
            this.rmLib.UseVisualStyleBackColor = true;
            // 
            // rmAllLib
            // 
            this.rmAllLib.Location = new System.Drawing.Point(20, 43);
            this.rmAllLib.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.rmAllLib.Name = "rmAllLib";
            this.rmAllLib.Size = new System.Drawing.Size(75, 23);
            this.rmAllLib.TabIndex = 2;
            this.rmAllLib.Text = "Remove all";
            this.rmAllLib.UseVisualStyleBackColor = true;
            // 
            // tip
            // 
            this.tip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tip.Location = new System.Drawing.Point(50, 312);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(500, 38);
            this.tip.TabIndex = 1;
            this.tip.Text = "Press Finish to open selected library.\r\nPress Next to proceed creating a new libr" +
    "ary.";
            this.tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupExplorerOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recentWorkspaceOptions);
            this.Controls.Add(this.tip);
            this.Name = "SetupExplorerOpen";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.recentWorkspaceOptions.ResumeLayout(false);
            this.recentWorkspaceOptions.PerformLayout();
            this.workspaceOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox recentWorkspaceOptions;
        private System.Windows.Forms.ListView recentWorkspaces;
        private System.Windows.Forms.FlowLayoutPanel workspaceOptions;
        private System.Windows.Forms.Button addLib;
        private System.Windows.Forms.Button rmLib;
        private System.Windows.Forms.Button rmAllLib;
        private System.Windows.Forms.Label tip;
    }
}
