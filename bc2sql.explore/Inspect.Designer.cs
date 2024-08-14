namespace bc2sql.explore
{
    partial class Inspect
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
            this.components = new System.ComponentModel.Container();
            this.inspectPages = new System.Windows.Forms.TabControl();
            this.metaDataPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fields = new System.Windows.Forms.DataGridView();
            this.fieldProperties = new System.Windows.Forms.PropertyGrid();
            this.dataSourceInfo = new System.Windows.Forms.GroupBox();
            this.dataSourceEntity = new System.Windows.Forms.LinkLabel();
            this.dataSourceDescription = new System.Windows.Forms.Label();
            this.dataSourceMetadata = new System.Windows.Forms.LinkLabel();
            this.dataSourceLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSourceGuid = new System.Windows.Forms.Label();
            this.dataSourceName = new System.Windows.Forms.Label();
            this.dataPage = new System.Windows.Forms.TabPage();
            this.dataSets = new System.Windows.Forms.DataGridView();
            this.inspectActions = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.closeNewScraper = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.ToolTip(this.components);
            this.entityType = new System.Windows.Forms.Label();
            this.entitySet = new System.Windows.Forms.Label();
            this.inspectPages.SuspendLayout();
            this.metaDataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fields)).BeginInit();
            this.dataSourceInfo.SuspendLayout();
            this.dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSets)).BeginInit();
            this.inspectActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // inspectPages
            // 
            this.inspectPages.Controls.Add(this.metaDataPage);
            this.inspectPages.Controls.Add(this.dataPage);
            this.inspectPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectPages.Location = new System.Drawing.Point(0, 0);
            this.inspectPages.Name = "inspectPages";
            this.inspectPages.SelectedIndex = 0;
            this.inspectPages.Size = new System.Drawing.Size(845, 537);
            this.inspectPages.TabIndex = 0;
            // 
            // metaDataPage
            // 
            this.metaDataPage.Controls.Add(this.splitContainer1);
            this.metaDataPage.Controls.Add(this.dataSourceInfo);
            this.metaDataPage.Location = new System.Drawing.Point(4, 22);
            this.metaDataPage.Name = "metaDataPage";
            this.metaDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.metaDataPage.Size = new System.Drawing.Size(837, 511);
            this.metaDataPage.TabIndex = 0;
            this.metaDataPage.Text = "Metadata";
            this.metaDataPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 84);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fields);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fieldProperties);
            this.splitContainer1.Size = new System.Drawing.Size(831, 424);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 1;
            // 
            // fields
            // 
            this.fields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fields.Location = new System.Drawing.Point(0, 0);
            this.fields.MultiSelect = false;
            this.fields.Name = "fields";
            this.fields.ReadOnly = true;
            this.fields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fields.Size = new System.Drawing.Size(296, 424);
            this.fields.TabIndex = 0;
            this.fields.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.fields_RowEnter);
            // 
            // fieldProperties
            // 
            this.fieldProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldProperties.Location = new System.Drawing.Point(0, 0);
            this.fieldProperties.Name = "fieldProperties";
            this.fieldProperties.Size = new System.Drawing.Size(531, 424);
            this.fieldProperties.TabIndex = 0;
            // 
            // dataSourceInfo
            // 
            this.dataSourceInfo.Controls.Add(this.entityType);
            this.dataSourceInfo.Controls.Add(this.entitySet);
            this.dataSourceInfo.Controls.Add(this.dataSourceEntity);
            this.dataSourceInfo.Controls.Add(this.dataSourceDescription);
            this.dataSourceInfo.Controls.Add(this.dataSourceMetadata);
            this.dataSourceInfo.Controls.Add(this.dataSourceLink);
            this.dataSourceInfo.Controls.Add(this.label3);
            this.dataSourceInfo.Controls.Add(this.dataSourceGuid);
            this.dataSourceInfo.Controls.Add(this.dataSourceName);
            this.dataSourceInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataSourceInfo.Location = new System.Drawing.Point(3, 3);
            this.dataSourceInfo.Name = "dataSourceInfo";
            this.dataSourceInfo.Size = new System.Drawing.Size(831, 81);
            this.dataSourceInfo.TabIndex = 0;
            this.dataSourceInfo.TabStop = false;
            this.dataSourceInfo.Text = "Data Source";
            // 
            // dataSourceEntity
            // 
            this.dataSourceEntity.AutoSize = true;
            this.dataSourceEntity.Location = new System.Drawing.Point(616, 56);
            this.dataSourceEntity.Name = "dataSourceEntity";
            this.dataSourceEntity.Size = new System.Drawing.Size(67, 13);
            this.dataSourceEntity.TabIndex = 6;
            this.dataSourceEntity.TabStop = true;
            this.dataSourceEntity.Text = "OData Entity";
            this.dataSourceEntity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dataSourceEntity_LinkClicked);
            this.dataSourceEntity.MouseEnter += new System.EventHandler(this.dataSourceEntity_MouseEnter);
            // 
            // dataSourceDescription
            // 
            this.dataSourceDescription.AutoSize = true;
            this.dataSourceDescription.Location = new System.Drawing.Point(6, 56);
            this.dataSourceDescription.Name = "dataSourceDescription";
            this.dataSourceDescription.Size = new System.Drawing.Size(60, 13);
            this.dataSourceDescription.TabIndex = 5;
            this.dataSourceDescription.Text = "Description";
            // 
            // dataSourceMetadata
            // 
            this.dataSourceMetadata.AutoSize = true;
            this.dataSourceMetadata.Location = new System.Drawing.Point(616, 36);
            this.dataSourceMetadata.Name = "dataSourceMetadata";
            this.dataSourceMetadata.Size = new System.Drawing.Size(86, 13);
            this.dataSourceMetadata.TabIndex = 4;
            this.dataSourceMetadata.TabStop = true;
            this.dataSourceMetadata.Text = "OData Metadata";
            this.dataSourceMetadata.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dataSourceMetadata_LinkClicked);
            this.dataSourceMetadata.MouseEnter += new System.EventHandler(this.dataSourceMetadata_MouseEnter);
            // 
            // dataSourceLink
            // 
            this.dataSourceLink.AutoSize = true;
            this.dataSourceLink.Location = new System.Drawing.Point(616, 16);
            this.dataSourceLink.Name = "dataSourceLink";
            this.dataSourceLink.Size = new System.Drawing.Size(83, 13);
            this.dataSourceLink.TabIndex = 3;
            this.dataSourceLink.TabStop = true;
            this.dataSourceLink.Text = "OData Endpoint";
            this.dataSourceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dataSourceLink_LinkClicked);
            this.dataSourceLink.DragLeave += new System.EventHandler(this.dataSourceLink_DragLeave);
            this.dataSourceLink.MouseEnter += new System.EventHandler(this.dataSourceLink_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // dataSourceGuid
            // 
            this.dataSourceGuid.AutoSize = true;
            this.dataSourceGuid.Location = new System.Drawing.Point(6, 36);
            this.dataSourceGuid.Name = "dataSourceGuid";
            this.dataSourceGuid.Size = new System.Drawing.Size(34, 13);
            this.dataSourceGuid.TabIndex = 1;
            this.dataSourceGuid.Text = "GUID";
            // 
            // dataSourceName
            // 
            this.dataSourceName.AutoSize = true;
            this.dataSourceName.Location = new System.Drawing.Point(6, 16);
            this.dataSourceName.Name = "dataSourceName";
            this.dataSourceName.Size = new System.Drawing.Size(35, 13);
            this.dataSourceName.TabIndex = 0;
            this.dataSourceName.Text = "Name";
            // 
            // dataPage
            // 
            this.dataPage.Controls.Add(this.dataSets);
            this.dataPage.Location = new System.Drawing.Point(4, 22);
            this.dataPage.Name = "dataPage";
            this.dataPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataPage.Size = new System.Drawing.Size(837, 511);
            this.dataPage.TabIndex = 1;
            this.dataPage.Text = "Data";
            this.dataPage.UseVisualStyleBackColor = true;
            this.dataPage.Click += new System.EventHandler(this.dataPage_Click);
            // 
            // dataSets
            // 
            this.dataSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSets.Location = new System.Drawing.Point(3, 3);
            this.dataSets.Name = "dataSets";
            this.dataSets.Size = new System.Drawing.Size(831, 505);
            this.dataSets.TabIndex = 0;
            // 
            // inspectActions
            // 
            this.inspectActions.Controls.Add(this.close);
            this.inspectActions.Controls.Add(this.closeNewScraper);
            this.inspectActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inspectActions.Location = new System.Drawing.Point(0, 537);
            this.inspectActions.Name = "inspectActions";
            this.inspectActions.Size = new System.Drawing.Size(845, 45);
            this.inspectActions.TabIndex = 1;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.No;
            this.close.Location = new System.Drawing.Point(545, 10);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // closeNewScraper
            // 
            this.closeNewScraper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeNewScraper.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.closeNewScraper.Location = new System.Drawing.Point(626, 10);
            this.closeNewScraper.Name = "closeNewScraper";
            this.closeNewScraper.Size = new System.Drawing.Size(207, 23);
            this.closeNewScraper.TabIndex = 0;
            this.closeNewScraper.Text = "Create new scraper and close";
            this.closeNewScraper.UseVisualStyleBackColor = true;
            this.closeNewScraper.Click += new System.EventHandler(this.closeNewScraper_Click);
            // 
            // entityType
            // 
            this.entityType.AutoSize = true;
            this.entityType.Location = new System.Drawing.Point(297, 36);
            this.entityType.Name = "entityType";
            this.entityType.Size = new System.Drawing.Size(60, 13);
            this.entityType.TabIndex = 8;
            this.entityType.Text = "Entity Type";
            // 
            // entitySet
            // 
            this.entitySet.AutoSize = true;
            this.entitySet.Location = new System.Drawing.Point(297, 16);
            this.entitySet.Name = "entitySet";
            this.entitySet.Size = new System.Drawing.Size(52, 13);
            this.entitySet.TabIndex = 7;
            this.entitySet.Text = "Entity Set";
            // 
            // Inspect
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(845, 582);
            this.Controls.Add(this.inspectPages);
            this.Controls.Add(this.inspectActions);
            this.Name = "Inspect";
            this.ShowIcon = false;
            this.Text = "Inspect - BC2SQL";
            this.Load += new System.EventHandler(this.Inspect_Load);
            this.inspectPages.ResumeLayout(false);
            this.metaDataPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fields)).EndInit();
            this.dataSourceInfo.ResumeLayout(false);
            this.dataSourceInfo.PerformLayout();
            this.dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSets)).EndInit();
            this.inspectActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl inspectPages;
        private System.Windows.Forms.TabPage metaDataPage;
        private System.Windows.Forms.TabPage dataPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView fields;
        private System.Windows.Forms.PropertyGrid fieldProperties;
        private System.Windows.Forms.GroupBox dataSourceInfo;
        private System.Windows.Forms.LinkLabel dataSourceMetadata;
        private System.Windows.Forms.LinkLabel dataSourceLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dataSourceGuid;
        private System.Windows.Forms.Label dataSourceName;
        private System.Windows.Forms.DataGridView dataSets;
        private System.Windows.Forms.Label dataSourceDescription;
        private System.Windows.Forms.LinkLabel dataSourceEntity;
        private System.Windows.Forms.Panel inspectActions;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button closeNewScraper;
        private System.Windows.Forms.ToolTip help;
        private System.Windows.Forms.Label entityType;
        private System.Windows.Forms.Label entitySet;
    }
}