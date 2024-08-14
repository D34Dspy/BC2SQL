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
            this.dataSourceTools = new System.Windows.Forms.ToolStrip();
            this.dataSourceSearch = new System.Windows.Forms.ToolStripTextBox();
            this.dataSourceEntities = new System.Windows.Forms.DataGridView();
            this.dataSourceEntityTools = new System.Windows.Forms.ToolStrip();
            this.dataSourceEntitySearch = new System.Windows.Forms.ToolStripTextBox();
            this.dataSourceOptions = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.odataEntity = new System.Windows.Forms.LinkLabel();
            this.odataMetadata = new System.Windows.Forms.LinkLabel();
            this.odataEndpoint = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.views)).BeginInit();
            this.views.Panel1.SuspendLayout();
            this.views.Panel2.SuspendLayout();
            this.views.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSources)).BeginInit();
            this.dataSourceTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceEntities)).BeginInit();
            this.dataSourceEntityTools.SuspendLayout();
            this.dataSourceOptions.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.views.Size = new System.Drawing.Size(500, 241);
            this.views.SplitterDistance = 249;
            this.views.TabIndex = 0;
            // 
            // dataSources
            // 
            this.dataSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSources.Location = new System.Drawing.Point(0, 25);
            this.dataSources.MultiSelect = false;
            this.dataSources.Name = "dataSources";
            this.dataSources.ReadOnly = true;
            this.dataSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataSources.Size = new System.Drawing.Size(249, 216);
            this.dataSources.TabIndex = 2;
            this.dataSources.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSources_CellContentClick);
            this.dataSources.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSources_RowEnter);
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
            // dataSourceSearch
            // 
            this.dataSourceSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dataSourceSearch.AutoSize = false;
            this.dataSourceSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataSourceSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataSourceSearch.Name = "dataSourceSearch";
            this.dataSourceSearch.Size = new System.Drawing.Size(150, 23);
            // 
            // dataSourceEntities
            // 
            this.dataSourceEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSourceEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceEntities.Location = new System.Drawing.Point(0, 25);
            this.dataSourceEntities.MultiSelect = false;
            this.dataSourceEntities.Name = "dataSourceEntities";
            this.dataSourceEntities.ReadOnly = true;
            this.dataSourceEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataSourceEntities.Size = new System.Drawing.Size(247, 216);
            this.dataSourceEntities.TabIndex = 1;
            this.dataSourceEntities.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSourceEntities_CellContentClick);
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
            // dataSourceEntitySearch
            // 
            this.dataSourceEntitySearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dataSourceEntitySearch.AutoSize = false;
            this.dataSourceEntitySearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataSourceEntitySearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataSourceEntitySearch.Name = "dataSourceEntitySearch";
            this.dataSourceEntitySearch.Size = new System.Drawing.Size(150, 23);
            // 
            // dataSourceOptions
            // 
            this.dataSourceOptions.Controls.Add(this.panel1);
            this.dataSourceOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataSourceOptions.Location = new System.Drawing.Point(50, 291);
            this.dataSourceOptions.Name = "dataSourceOptions";
            this.dataSourceOptions.Padding = new System.Windows.Forms.Padding(10);
            this.dataSourceOptions.Size = new System.Drawing.Size(500, 59);
            this.dataSourceOptions.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.odataEntity);
            this.panel1.Controls.Add(this.odataMetadata);
            this.panel1.Controls.Add(this.odataEndpoint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 39);
            this.panel1.TabIndex = 3;
            // 
            // odataEntity
            // 
            this.odataEntity.AutoSize = true;
            this.odataEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.odataEntity.Location = new System.Drawing.Point(0, 26);
            this.odataEntity.Name = "odataEntity";
            this.odataEntity.Size = new System.Drawing.Size(67, 13);
            this.odataEntity.TabIndex = 2;
            this.odataEntity.TabStop = true;
            this.odataEntity.Text = "OData Entity";
            this.odataEntity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.odataEntity_LinkClicked);
            // 
            // odataMetadata
            // 
            this.odataMetadata.AutoSize = true;
            this.odataMetadata.Dock = System.Windows.Forms.DockStyle.Top;
            this.odataMetadata.Location = new System.Drawing.Point(0, 13);
            this.odataMetadata.Name = "odataMetadata";
            this.odataMetadata.Size = new System.Drawing.Size(86, 13);
            this.odataMetadata.TabIndex = 0;
            this.odataMetadata.TabStop = true;
            this.odataMetadata.Text = "OData Metadata";
            this.odataMetadata.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.odataMetadata_LinkClicked);
            // 
            // odataEndpoint
            // 
            this.odataEndpoint.AutoSize = true;
            this.odataEndpoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.odataEndpoint.Location = new System.Drawing.Point(0, 0);
            this.odataEndpoint.Name = "odataEndpoint";
            this.odataEndpoint.Size = new System.Drawing.Size(83, 13);
            this.odataEndpoint.TabIndex = 1;
            this.odataEndpoint.TabStop = true;
            this.odataEndpoint.Text = "OData Endpoint";
            this.odataEndpoint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.odataEndpoint_LinkClicked);
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
            this.dataSourceTools.ResumeLayout(false);
            this.dataSourceTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceEntities)).EndInit();
            this.dataSourceEntityTools.ResumeLayout(false);
            this.dataSourceEntityTools.PerformLayout();
            this.dataSourceOptions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer views;
        private System.Windows.Forms.Panel dataSourceOptions;
        private System.Windows.Forms.DataGridView dataSources;
        private System.Windows.Forms.DataGridView dataSourceEntities;
        private System.Windows.Forms.ToolStrip dataSourceTools;
        private System.Windows.Forms.ToolStripTextBox dataSourceSearch;
        private System.Windows.Forms.ToolStrip dataSourceEntityTools;
        private System.Windows.Forms.ToolStripTextBox dataSourceEntitySearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel odataEntity;
        private System.Windows.Forms.LinkLabel odataMetadata;
        private System.Windows.Forms.LinkLabel odataEndpoint;
    }
}
