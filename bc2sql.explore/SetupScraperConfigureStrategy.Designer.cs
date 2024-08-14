namespace bc2sql.explore
{
    partial class SetupScraperConfigureStrategy
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
            this.useWindowing = new System.Windows.Forms.CheckBox();
            this.windowOptions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.relativeOptions = new System.Windows.Forms.Panel();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.percentage = new System.Windows.Forms.Label();
            this.useRelative = new System.Windows.Forms.RadioButton();
            this.fixedOptions = new System.Windows.Forms.Panel();
            this.numDatasets = new System.Windows.Forms.NumericUpDown();
            this.datasets = new System.Windows.Forms.Label();
            this.useFixed = new System.Windows.Forms.RadioButton();
            this.mergeAliasOptions = new System.Windows.Forms.Panel();
            this.mergeDstAliasOptions = new System.Windows.Forms.GroupBox();
            this.mergeDstAlias = new System.Windows.Forms.TextBox();
            this.mergeSorceAliasOptions = new System.Windows.Forms.GroupBox();
            this.mergeSrcAlias = new System.Windows.Forms.TextBox();
            this.tableNameOption = new System.Windows.Forms.GroupBox();
            this.destinationTableName = new System.Windows.Forms.TextBox();
            this.windowOptions.SuspendLayout();
            this.relativeOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            this.fixedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDatasets)).BeginInit();
            this.mergeAliasOptions.SuspendLayout();
            this.mergeDstAliasOptions.SuspendLayout();
            this.mergeSorceAliasOptions.SuspendLayout();
            this.tableNameOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // useWindowing
            // 
            this.useWindowing.AutoSize = true;
            this.useWindowing.Dock = System.Windows.Forms.DockStyle.Top;
            this.useWindowing.Location = new System.Drawing.Point(50, 50);
            this.useWindowing.Name = "useWindowing";
            this.useWindowing.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.useWindowing.Size = new System.Drawing.Size(500, 27);
            this.useWindowing.TabIndex = 2;
            this.useWindowing.Text = "Use Windowing";
            this.useWindowing.UseVisualStyleBackColor = true;
            this.useWindowing.CheckedChanged += new System.EventHandler(this.useWindowing_CheckedChanged);
            // 
            // windowOptions
            // 
            this.windowOptions.Controls.Add(this.label1);
            this.windowOptions.Controls.Add(this.relativeOptions);
            this.windowOptions.Controls.Add(this.fixedOptions);
            this.windowOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowOptions.Enabled = false;
            this.windowOptions.Location = new System.Drawing.Point(50, 77);
            this.windowOptions.Name = "windowOptions";
            this.windowOptions.Size = new System.Drawing.Size(500, 193);
            this.windowOptions.TabIndex = 3;
            this.windowOptions.TabStop = false;
            this.windowOptions.Text = "Window Options";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Windowing means to replicate certain spans of the table - specifying a percentage" +
    " (Relative Option) will result into an EXTRA OData Count request!\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // relativeOptions
            // 
            this.relativeOptions.Controls.Add(this.numPercentage);
            this.relativeOptions.Controls.Add(this.percentage);
            this.relativeOptions.Controls.Add(this.useRelative);
            this.relativeOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.relativeOptions.Location = new System.Drawing.Point(3, 76);
            this.relativeOptions.Name = "relativeOptions";
            this.relativeOptions.Padding = new System.Windows.Forms.Padding(10);
            this.relativeOptions.Size = new System.Drawing.Size(494, 60);
            this.relativeOptions.TabIndex = 1;
            // 
            // numPercentage
            // 
            this.numPercentage.DecimalPlaces = 2;
            this.numPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPercentage.Location = new System.Drawing.Point(90, 32);
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(394, 20);
            this.numPercentage.TabIndex = 2;
            this.numPercentage.Value = new decimal(new int[] {
            125,
            0,
            0,
            65536});
            this.numPercentage.ValueChanged += new System.EventHandler(this.numPercentage_ValueChanged);
            // 
            // percentage
            // 
            this.percentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.percentage.Location = new System.Drawing.Point(10, 32);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(80, 18);
            this.percentage.TabIndex = 1;
            this.percentage.Text = "Percentage:";
            // 
            // useRelative
            // 
            this.useRelative.AutoSize = true;
            this.useRelative.Dock = System.Windows.Forms.DockStyle.Top;
            this.useRelative.Location = new System.Drawing.Point(10, 10);
            this.useRelative.Name = "useRelative";
            this.useRelative.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.useRelative.Size = new System.Drawing.Size(474, 22);
            this.useRelative.TabIndex = 3;
            this.useRelative.TabStop = true;
            this.useRelative.Text = "Relative";
            this.useRelative.UseVisualStyleBackColor = true;
            this.useRelative.CheckedChanged += new System.EventHandler(this.Relative_CheckedChanged);
            // 
            // fixedOptions
            // 
            this.fixedOptions.Controls.Add(this.numDatasets);
            this.fixedOptions.Controls.Add(this.datasets);
            this.fixedOptions.Controls.Add(this.useFixed);
            this.fixedOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.fixedOptions.Location = new System.Drawing.Point(3, 16);
            this.fixedOptions.Name = "fixedOptions";
            this.fixedOptions.Padding = new System.Windows.Forms.Padding(10);
            this.fixedOptions.Size = new System.Drawing.Size(494, 60);
            this.fixedOptions.TabIndex = 0;
            // 
            // numDatasets
            // 
            this.numDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDatasets.Location = new System.Drawing.Point(90, 32);
            this.numDatasets.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDatasets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDatasets.Name = "numDatasets";
            this.numDatasets.Size = new System.Drawing.Size(394, 20);
            this.numDatasets.TabIndex = 1;
            this.numDatasets.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDatasets.ValueChanged += new System.EventHandler(this.numDatasets_ValueChanged);
            // 
            // datasets
            // 
            this.datasets.Dock = System.Windows.Forms.DockStyle.Left;
            this.datasets.Location = new System.Drawing.Point(10, 32);
            this.datasets.Name = "datasets";
            this.datasets.Size = new System.Drawing.Size(80, 18);
            this.datasets.TabIndex = 0;
            this.datasets.Text = "Datasets:";
            // 
            // useFixed
            // 
            this.useFixed.AutoSize = true;
            this.useFixed.Dock = System.Windows.Forms.DockStyle.Top;
            this.useFixed.Location = new System.Drawing.Point(10, 10);
            this.useFixed.Name = "useFixed";
            this.useFixed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.useFixed.Size = new System.Drawing.Size(474, 22);
            this.useFixed.TabIndex = 2;
            this.useFixed.TabStop = true;
            this.useFixed.Text = "Fixed";
            this.useFixed.UseVisualStyleBackColor = true;
            this.useFixed.CheckedChanged += new System.EventHandler(this.useFixed_CheckedChanged);
            // 
            // mergeAliasOptions
            // 
            this.mergeAliasOptions.Controls.Add(this.mergeDstAliasOptions);
            this.mergeAliasOptions.Controls.Add(this.mergeSorceAliasOptions);
            this.mergeAliasOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mergeAliasOptions.Location = new System.Drawing.Point(50, 270);
            this.mergeAliasOptions.Name = "mergeAliasOptions";
            this.mergeAliasOptions.Size = new System.Drawing.Size(500, 40);
            this.mergeAliasOptions.TabIndex = 4;
            // 
            // mergeDstAliasOptions
            // 
            this.mergeDstAliasOptions.Controls.Add(this.mergeDstAlias);
            this.mergeDstAliasOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeDstAliasOptions.Location = new System.Drawing.Point(255, 0);
            this.mergeDstAliasOptions.Name = "mergeDstAliasOptions";
            this.mergeDstAliasOptions.Size = new System.Drawing.Size(245, 40);
            this.mergeDstAliasOptions.TabIndex = 1;
            this.mergeDstAliasOptions.TabStop = false;
            this.mergeDstAliasOptions.Text = "Merge Destination Alias";
            // 
            // mergeDstAlias
            // 
            this.mergeDstAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeDstAlias.Location = new System.Drawing.Point(3, 16);
            this.mergeDstAlias.Name = "mergeDstAlias";
            this.mergeDstAlias.Size = new System.Drawing.Size(239, 20);
            this.mergeDstAlias.TabIndex = 0;
            this.mergeDstAlias.Text = "BC2SQL_DST";
            this.mergeDstAlias.TextChanged += new System.EventHandler(this.mergeDstAlias_TextChanged);
            // 
            // mergeSorceAliasOptions
            // 
            this.mergeSorceAliasOptions.Controls.Add(this.mergeSrcAlias);
            this.mergeSorceAliasOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.mergeSorceAliasOptions.Location = new System.Drawing.Point(0, 0);
            this.mergeSorceAliasOptions.Name = "mergeSorceAliasOptions";
            this.mergeSorceAliasOptions.Size = new System.Drawing.Size(255, 40);
            this.mergeSorceAliasOptions.TabIndex = 0;
            this.mergeSorceAliasOptions.TabStop = false;
            this.mergeSorceAliasOptions.Text = "Merge Source Alias";
            // 
            // mergeSrcAlias
            // 
            this.mergeSrcAlias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeSrcAlias.Location = new System.Drawing.Point(3, 16);
            this.mergeSrcAlias.Name = "mergeSrcAlias";
            this.mergeSrcAlias.Size = new System.Drawing.Size(249, 20);
            this.mergeSrcAlias.TabIndex = 1;
            this.mergeSrcAlias.Text = "BC2SQL_SRC";
            this.mergeSrcAlias.TextChanged += new System.EventHandler(this.mergeSrcAlias_TextChanged);
            // 
            // tableNameOption
            // 
            this.tableNameOption.Controls.Add(this.destinationTableName);
            this.tableNameOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableNameOption.Location = new System.Drawing.Point(50, 310);
            this.tableNameOption.Name = "tableNameOption";
            this.tableNameOption.Size = new System.Drawing.Size(500, 40);
            this.tableNameOption.TabIndex = 5;
            this.tableNameOption.TabStop = false;
            this.tableNameOption.Text = "(Destination) Table Name";
            this.tableNameOption.Enter += new System.EventHandler(this.tableNameOption_Enter);
            // 
            // destinationTableName
            // 
            this.destinationTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destinationTableName.Location = new System.Drawing.Point(3, 16);
            this.destinationTableName.Name = "destinationTableName";
            this.destinationTableName.Size = new System.Drawing.Size(494, 20);
            this.destinationTableName.TabIndex = 0;
            this.destinationTableName.TextChanged += new System.EventHandler(this.destinationTableName_TextChanged);
            // 
            // SetupScraperConfigureStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windowOptions);
            this.Controls.Add(this.useWindowing);
            this.Controls.Add(this.mergeAliasOptions);
            this.Controls.Add(this.tableNameOption);
            this.Name = "SetupScraperConfigureStrategy";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.SetupScraperConfigureStrategy_Load);
            this.windowOptions.ResumeLayout(false);
            this.relativeOptions.ResumeLayout(false);
            this.relativeOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).EndInit();
            this.fixedOptions.ResumeLayout(false);
            this.fixedOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDatasets)).EndInit();
            this.mergeAliasOptions.ResumeLayout(false);
            this.mergeDstAliasOptions.ResumeLayout(false);
            this.mergeDstAliasOptions.PerformLayout();
            this.mergeSorceAliasOptions.ResumeLayout(false);
            this.mergeSorceAliasOptions.PerformLayout();
            this.tableNameOption.ResumeLayout(false);
            this.tableNameOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox useWindowing;
        private System.Windows.Forms.GroupBox windowOptions;
        private System.Windows.Forms.Panel relativeOptions;
        private System.Windows.Forms.NumericUpDown numPercentage;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.RadioButton useRelative;
        private System.Windows.Forms.Panel fixedOptions;
        private System.Windows.Forms.NumericUpDown numDatasets;
        private System.Windows.Forms.Label datasets;
        private System.Windows.Forms.RadioButton useFixed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mergeAliasOptions;
        private System.Windows.Forms.GroupBox mergeDstAliasOptions;
        private System.Windows.Forms.TextBox mergeDstAlias;
        private System.Windows.Forms.GroupBox mergeSorceAliasOptions;
        private System.Windows.Forms.TextBox mergeSrcAlias;
        private System.Windows.Forms.GroupBox tableNameOption;
        private System.Windows.Forms.TextBox destinationTableName;
    }
}
