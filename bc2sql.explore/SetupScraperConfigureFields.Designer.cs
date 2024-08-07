namespace bc2sql.explore
{
    partial class SetupScraperConfigureFields
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
            this.formFieldsAndWhereClauses = new System.Windows.Forms.SplitContainer();
            this.formFieldOptions = new System.Windows.Forms.GroupBox();
            this.sqlFieldOptions = new System.Windows.Forms.GroupBox();
            this.requestFormFields = new System.Windows.Forms.DataGridView();
            this.mergeConditions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.formFieldsAndWhereClauses)).BeginInit();
            this.formFieldsAndWhereClauses.Panel1.SuspendLayout();
            this.formFieldsAndWhereClauses.Panel2.SuspendLayout();
            this.formFieldsAndWhereClauses.SuspendLayout();
            this.formFieldOptions.SuspendLayout();
            this.sqlFieldOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestFormFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mergeConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // formFieldsAndWhereClauses
            // 
            this.formFieldsAndWhereClauses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formFieldsAndWhereClauses.Location = new System.Drawing.Point(50, 50);
            this.formFieldsAndWhereClauses.Name = "formFieldsAndWhereClauses";
            this.formFieldsAndWhereClauses.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // formFieldsAndWhereClauses.Panel1
            // 
            this.formFieldsAndWhereClauses.Panel1.Controls.Add(this.formFieldOptions);
            // 
            // formFieldsAndWhereClauses.Panel2
            // 
            this.formFieldsAndWhereClauses.Panel2.Controls.Add(this.sqlFieldOptions);
            this.formFieldsAndWhereClauses.Size = new System.Drawing.Size(500, 300);
            this.formFieldsAndWhereClauses.SplitterDistance = 166;
            this.formFieldsAndWhereClauses.TabIndex = 0;
            // 
            // formFieldOptions
            // 
            this.formFieldOptions.Controls.Add(this.requestFormFields);
            this.formFieldOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formFieldOptions.Location = new System.Drawing.Point(0, 0);
            this.formFieldOptions.Name = "formFieldOptions";
            this.formFieldOptions.Size = new System.Drawing.Size(500, 166);
            this.formFieldOptions.TabIndex = 0;
            this.formFieldOptions.TabStop = false;
            this.formFieldOptions.Text = "OData Request Form Fields";
            // 
            // sqlFieldOptions
            // 
            this.sqlFieldOptions.Controls.Add(this.mergeConditions);
            this.sqlFieldOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlFieldOptions.Location = new System.Drawing.Point(0, 0);
            this.sqlFieldOptions.Name = "sqlFieldOptions";
            this.sqlFieldOptions.Size = new System.Drawing.Size(500, 130);
            this.sqlFieldOptions.TabIndex = 1;
            this.sqlFieldOptions.TabStop = false;
            this.sqlFieldOptions.Text = "SQL Merge Conditions";
            // 
            // requestFormFields
            // 
            this.requestFormFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestFormFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestFormFields.Location = new System.Drawing.Point(3, 16);
            this.requestFormFields.Name = "requestFormFields";
            this.requestFormFields.Size = new System.Drawing.Size(494, 147);
            this.requestFormFields.TabIndex = 0;
            // 
            // mergeConditions
            // 
            this.mergeConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mergeConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeConditions.Location = new System.Drawing.Point(3, 16);
            this.mergeConditions.Name = "mergeConditions";
            this.mergeConditions.Size = new System.Drawing.Size(494, 111);
            this.mergeConditions.TabIndex = 1;
            // 
            // SetupScraperConfigureFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formFieldsAndWhereClauses);
            this.Name = "SetupScraperConfigureFields";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperSettingsPage_Load);
            this.formFieldsAndWhereClauses.Panel1.ResumeLayout(false);
            this.formFieldsAndWhereClauses.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formFieldsAndWhereClauses)).EndInit();
            this.formFieldsAndWhereClauses.ResumeLayout(false);
            this.formFieldOptions.ResumeLayout(false);
            this.sqlFieldOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestFormFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mergeConditions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formFieldsAndWhereClauses;
        private System.Windows.Forms.GroupBox formFieldOptions;
        private System.Windows.Forms.DataGridView requestFormFields;
        private System.Windows.Forms.GroupBox sqlFieldOptions;
        private System.Windows.Forms.DataGridView mergeConditions;
    }
}
