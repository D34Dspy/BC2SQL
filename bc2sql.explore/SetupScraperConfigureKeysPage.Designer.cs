namespace bc2sql.explore
{
    partial class SetupScraperConfigureKeysPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupScraperConfigureKeysPage));
            this.keys = new System.Windows.Forms.DataGridView();
            this.keyOptions = new System.Windows.Forms.Panel();
            this.selKeys = new System.Windows.Forms.Label();
            this.useAutokey = new System.Windows.Forms.CheckBox();
            this.columnTools = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.bindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asGUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asInsertDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asModifyDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDefaultKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.keys)).BeginInit();
            this.keyOptions.SuspendLayout();
            this.columnTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // keys
            // 
            this.keys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keys.Location = new System.Drawing.Point(50, 75);
            this.keys.Name = "keys";
            this.keys.ReadOnly = true;
            this.keys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.keys.ShowEditingIcon = false;
            this.keys.Size = new System.Drawing.Size(500, 220);
            this.keys.TabIndex = 0;
            // 
            // keyOptions
            // 
            this.keyOptions.Controls.Add(this.selKeys);
            this.keyOptions.Controls.Add(this.useAutokey);
            this.keyOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.keyOptions.Location = new System.Drawing.Point(50, 295);
            this.keyOptions.Name = "keyOptions";
            this.keyOptions.Padding = new System.Windows.Forms.Padding(8);
            this.keyOptions.Size = new System.Drawing.Size(500, 55);
            this.keyOptions.TabIndex = 1;
            // 
            // selKeys
            // 
            this.selKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selKeys.Location = new System.Drawing.Point(8, 25);
            this.selKeys.Name = "selKeys";
            this.selKeys.Size = new System.Drawing.Size(484, 22);
            this.selKeys.TabIndex = 1;
            this.selKeys.Text = "Selected key(s):";
            this.selKeys.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // useAutokey
            // 
            this.useAutokey.AutoSize = true;
            this.useAutokey.Dock = System.Windows.Forms.DockStyle.Top;
            this.useAutokey.Location = new System.Drawing.Point(8, 8);
            this.useAutokey.Name = "useAutokey";
            this.useAutokey.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.useAutokey.Size = new System.Drawing.Size(484, 17);
            this.useAutokey.TabIndex = 0;
            this.useAutokey.Text = "Use System GUID and Insert/Modify Date";
            this.useAutokey.UseVisualStyleBackColor = true;
            // 
            // columnTools
            // 
            this.columnTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.columnTools.Location = new System.Drawing.Point(50, 50);
            this.columnTools.Name = "columnTools";
            this.columnTools.Size = new System.Drawing.Size(500, 25);
            this.columnTools.TabIndex = 2;
            this.columnTools.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindToolStripMenuItem,
            this.selectDefaultKeysToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton1.Text = "Key(s)";
            // 
            // bindToolStripMenuItem
            // 
            this.bindToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asGUIDToolStripMenuItem,
            this.asInsertDateToolStripMenuItem,
            this.asModifyDateToolStripMenuItem});
            this.bindToolStripMenuItem.Name = "bindToolStripMenuItem";
            this.bindToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bindToolStripMenuItem.Text = "Bind";
            // 
            // asGUIDToolStripMenuItem
            // 
            this.asGUIDToolStripMenuItem.Name = "asGUIDToolStripMenuItem";
            this.asGUIDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asGUIDToolStripMenuItem.Text = "As GUID";
            // 
            // asInsertDateToolStripMenuItem
            // 
            this.asInsertDateToolStripMenuItem.Name = "asInsertDateToolStripMenuItem";
            this.asInsertDateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asInsertDateToolStripMenuItem.Text = "As Insert Date";
            // 
            // asModifyDateToolStripMenuItem
            // 
            this.asModifyDateToolStripMenuItem.Name = "asModifyDateToolStripMenuItem";
            this.asModifyDateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asModifyDateToolStripMenuItem.Text = "As Modify Date";
            // 
            // selectDefaultKeysToolStripMenuItem
            // 
            this.selectDefaultKeysToolStripMenuItem.Name = "selectDefaultKeysToolStripMenuItem";
            this.selectDefaultKeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectDefaultKeysToolStripMenuItem.Text = "Select default keys";
            // 
            // SetupScraperConfigureKeysPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.keys);
            this.Controls.Add(this.keyOptions);
            this.Controls.Add(this.columnTools);
            this.Name = "SetupScraperConfigureKeysPage";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperConfigureKeysPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.keys)).EndInit();
            this.keyOptions.ResumeLayout(false);
            this.keyOptions.PerformLayout();
            this.columnTools.ResumeLayout(false);
            this.columnTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView keys;
        private System.Windows.Forms.Panel keyOptions;
        private System.Windows.Forms.Label selKeys;
        private System.Windows.Forms.CheckBox useAutokey;
        private System.Windows.Forms.ToolStrip columnTools;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem bindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asGUIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asInsertDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asModifyDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDefaultKeysToolStripMenuItem;
    }
}
