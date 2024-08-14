namespace bc2sql.explore
{
    partial class SetupScraperBindDatabasePage
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
            this.databases = new System.Windows.Forms.DataGridView();
            this.databaseButtons = new System.Windows.Forms.Panel();
            this.connString = new System.Windows.Forms.Label();
            this.connState = new System.Windows.Forms.Label();
            this.testConn = new System.Windows.Forms.Button();
            this.databaseOptions = new System.Windows.Forms.Panel();
            this.databaseTools = new System.Windows.Forms.ToolStrip();
            this.databaseSearch = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.databases)).BeginInit();
            this.databaseButtons.SuspendLayout();
            this.databaseTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // databases
            // 
            this.databases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databases.Location = new System.Drawing.Point(50, 75);
            this.databases.MultiSelect = false;
            this.databases.Name = "databases";
            this.databases.ReadOnly = true;
            this.databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.databases.Size = new System.Drawing.Size(500, 230);
            this.databases.TabIndex = 1;
            this.databases.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.databases_CellContentClick);
            // 
            // databaseButtons
            // 
            this.databaseButtons.Controls.Add(this.connString);
            this.databaseButtons.Controls.Add(this.connState);
            this.databaseButtons.Controls.Add(this.testConn);
            this.databaseButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.databaseButtons.Location = new System.Drawing.Point(50, 305);
            this.databaseButtons.Name = "databaseButtons";
            this.databaseButtons.Padding = new System.Windows.Forms.Padding(8);
            this.databaseButtons.Size = new System.Drawing.Size(500, 45);
            this.databaseButtons.TabIndex = 2;
            // 
            // connString
            // 
            this.connString.AutoSize = true;
            this.connString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connString.Location = new System.Drawing.Point(83, 21);
            this.connString.Name = "connString";
            this.connString.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.connString.Size = new System.Drawing.Size(94, 13);
            this.connString.TabIndex = 2;
            this.connString.Text = "Connect String: -";
            // 
            // connState
            // 
            this.connState.AutoSize = true;
            this.connState.Dock = System.Windows.Forms.DockStyle.Top;
            this.connState.Location = new System.Drawing.Point(83, 8);
            this.connState.Name = "connState";
            this.connState.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.connState.Size = new System.Drawing.Size(149, 13);
            this.connState.TabIndex = 1;
            this.connState.Text = "Connection State: Unknown";
            // 
            // testConn
            // 
            this.testConn.Dock = System.Windows.Forms.DockStyle.Left;
            this.testConn.Location = new System.Drawing.Point(8, 8);
            this.testConn.Name = "testConn";
            this.testConn.Size = new System.Drawing.Size(75, 29);
            this.testConn.TabIndex = 0;
            this.testConn.Text = "Test";
            this.testConn.UseVisualStyleBackColor = true;
            // 
            // databaseOptions
            // 
            this.databaseOptions.AutoSize = true;
            this.databaseOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.databaseOptions.Location = new System.Drawing.Point(50, 75);
            this.databaseOptions.Name = "databaseOptions";
            this.databaseOptions.Size = new System.Drawing.Size(500, 0);
            this.databaseOptions.TabIndex = 3;
            // 
            // databaseTools
            // 
            this.databaseTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseSearch});
            this.databaseTools.Location = new System.Drawing.Point(50, 50);
            this.databaseTools.Name = "databaseTools";
            this.databaseTools.Size = new System.Drawing.Size(500, 25);
            this.databaseTools.TabIndex = 4;
            this.databaseTools.Text = "toolStrip1";
            // 
            // databaseSearch
            // 
            this.databaseSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.databaseSearch.AutoSize = false;
            this.databaseSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.databaseSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.databaseSearch.Name = "databaseSearch";
            this.databaseSearch.Size = new System.Drawing.Size(150, 23);
            this.databaseSearch.ToolTipText = "Search...";
            this.databaseSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyUp);
            // 
            // SetupScraperBindDatabasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.databases);
            this.Controls.Add(this.databaseOptions);
            this.Controls.Add(this.databaseButtons);
            this.Controls.Add(this.databaseTools);
            this.Name = "SetupScraperBindDatabasePage";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperBindDatabasePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databases)).EndInit();
            this.databaseButtons.ResumeLayout(false);
            this.databaseButtons.PerformLayout();
            this.databaseTools.ResumeLayout(false);
            this.databaseTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView databases;
        private System.Windows.Forms.Panel databaseButtons;
        private System.Windows.Forms.Label connString;
        private System.Windows.Forms.Label connState;
        private System.Windows.Forms.Button testConn;
        private System.Windows.Forms.Panel databaseOptions;
        private System.Windows.Forms.ToolStrip databaseTools;
        private System.Windows.Forms.ToolStripTextBox databaseSearch;
    }
}
