namespace bc2sql.explore
{
    partial class SetupScraperBindDataSourcePage
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
            this.views = new System.Windows.Forms.SplitContainer();
            this.dataSources = new System.Windows.Forms.DataGridView();
            this.dataSourceEntities = new System.Windows.Forms.DataGridView();
            this.dataSourceOptions = new System.Windows.Forms.Panel();
            this.connState = new System.Windows.Forms.Label();
            this.testConn = new System.Windows.Forms.Button();
            this.dataSourceTools = new System.Windows.Forms.ToolStrip();
            this.dataSourceEntityTools = new System.Windows.Forms.ToolStrip();
            this.dataSourceSearch = new System.Windows.Forms.ToolStripTextBox();
            this.dataSourceEntitySearch = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.views)).BeginInit();
            this.views.Panel1.SuspendLayout();
            this.views.Panel2.SuspendLayout();
            this.views.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceEntities)).BeginInit();
            this.dataSourceOptions.SuspendLayout();
            this.dataSourceTools.SuspendLayout();
            this.dataSourceEntityTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // views
            // 
            this.views.Dock = System.Windows.Forms.DockStyle.Fill;
            this.views.Location = new System.Drawing.Point(50, 50);
            this.views.Name = "views";
            // 
            // views.Panel1
            // 
            this.views.Panel1.Controls.Add(this.dataSources);
            this.views.Panel1.Controls.Add(this.dataSourceTools);
            // 
            // views.Panel2
            // 
            this.views.Panel2.Controls.Add(this.dataSourceEntities);
            this.views.Panel2.Controls.Add(this.dataSourceEntityTools);
            this.views.Size = new System.Drawing.Size(500, 249);
            this.views.SplitterDistance = 249;
            this.views.TabIndex = 0;
            // 
            // dataSources
            // 
            this.dataSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSources.Location = new System.Drawing.Point(0, 25);
            this.dataSources.Name = "dataSources";
            this.dataSources.Size = new System.Drawing.Size(249, 224);
            this.dataSources.TabIndex = 2;
            // 
            // dataSourceEntities
            // 
            this.dataSourceEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSourceEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceEntities.Location = new System.Drawing.Point(0, 25);
            this.dataSourceEntities.Name = "dataSourceEntities";
            this.dataSourceEntities.Size = new System.Drawing.Size(247, 224);
            this.dataSourceEntities.TabIndex = 1;
            // 
            // dataSourceOptions
            // 
            this.dataSourceOptions.Controls.Add(this.connState);
            this.dataSourceOptions.Controls.Add(this.testConn);
            this.dataSourceOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataSourceOptions.Location = new System.Drawing.Point(50, 299);
            this.dataSourceOptions.Name = "dataSourceOptions";
            this.dataSourceOptions.Padding = new System.Windows.Forms.Padding(10);
            this.dataSourceOptions.Size = new System.Drawing.Size(500, 51);
            this.dataSourceOptions.TabIndex = 1;
            // 
            // connState
            // 
            this.connState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connState.Location = new System.Drawing.Point(85, 10);
            this.connState.Name = "connState";
            this.connState.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.connState.Size = new System.Drawing.Size(405, 31);
            this.connState.TabIndex = 2;
            this.connState.Text = "Connection State: Unknown";
            this.connState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // testConn
            // 
            this.testConn.Dock = System.Windows.Forms.DockStyle.Left;
            this.testConn.Location = new System.Drawing.Point(10, 10);
            this.testConn.Name = "testConn";
            this.testConn.Size = new System.Drawing.Size(75, 31);
            this.testConn.TabIndex = 0;
            this.testConn.Text = "Test";
            this.testConn.UseVisualStyleBackColor = true;
            // 
            // dataSourceTools
            // 
            this.dataSourceTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSourceSearch});
            this.dataSourceTools.Location = new System.Drawing.Point(0, 0);
            this.dataSourceTools.Name = "dataSourceTools";
            this.dataSourceTools.Size = new System.Drawing.Size(249, 25);
            this.dataSourceTools.TabIndex = 3;
            this.dataSourceTools.Text = "toolStrip1";
            // 
            // dataSourceEntityTools
            // 
            this.dataSourceEntityTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSourceEntitySearch});
            this.dataSourceEntityTools.Location = new System.Drawing.Point(0, 0);
            this.dataSourceEntityTools.Name = "dataSourceEntityTools";
            this.dataSourceEntityTools.Size = new System.Drawing.Size(247, 25);
            this.dataSourceEntityTools.TabIndex = 2;
            this.dataSourceEntityTools.Text = "toolStrip2";
            // 
            // dataSourceSearch
            // 
            this.dataSourceSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dataSourceSearch.AutoSize = false;
            this.dataSourceSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataSourceSearch.Name = "dataSourceSearch";
            this.dataSourceSearch.Size = new System.Drawing.Size(150, 25);
            // 
            // dataSourceEntitySearch
            // 
            this.dataSourceEntitySearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dataSourceEntitySearch.AutoSize = false;
            this.dataSourceEntitySearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataSourceEntitySearch.Name = "dataSourceEntitySearch";
            this.dataSourceEntitySearch.Size = new System.Drawing.Size(150, 25);
            // 
            // SetupScraperBindDataSourcePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.views);
            this.Controls.Add(this.dataSourceOptions);
            this.Name = "SetupScraperBindDataSourcePage";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperBindDatasourcePage_Load);
            this.views.Panel1.ResumeLayout(false);
            this.views.Panel1.PerformLayout();
            this.views.Panel2.ResumeLayout(false);
            this.views.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.views)).EndInit();
            this.views.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceEntities)).EndInit();
            this.dataSourceOptions.ResumeLayout(false);
            this.dataSourceTools.ResumeLayout(false);
            this.dataSourceTools.PerformLayout();
            this.dataSourceEntityTools.ResumeLayout(false);
            this.dataSourceEntityTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer views;
        private System.Windows.Forms.Panel dataSourceOptions;
        private System.Windows.Forms.DataGridView dataSources;
        private System.Windows.Forms.DataGridView dataSourceEntities;
        private System.Windows.Forms.Button testConn;
        private System.Windows.Forms.Label connState;
        private System.Windows.Forms.ToolStrip dataSourceTools;
        private System.Windows.Forms.ToolStripTextBox dataSourceSearch;
        private System.Windows.Forms.ToolStrip dataSourceEntityTools;
        private System.Windows.Forms.ToolStripTextBox dataSourceEntitySearch;
    }
}
