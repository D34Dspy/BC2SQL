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
            this.label1 = new System.Windows.Forms.Label();
            this.useWindowing = new System.Windows.Forms.CheckBox();
            this.windowOptions = new System.Windows.Forms.GroupBox();
            this.relativeOptions = new System.Windows.Forms.Panel();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.percentage = new System.Windows.Forms.Label();
            this.useRelative = new System.Windows.Forms.RadioButton();
            this.fixedOptions = new System.Windows.Forms.Panel();
            this.numDatasets = new System.Windows.Forms.NumericUpDown();
            this.datasets = new System.Windows.Forms.Label();
            this.useFixed = new System.Windows.Forms.RadioButton();
            this.windowOptions.SuspendLayout();
            this.relativeOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            this.fixedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDatasets)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(50, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Windowing means to replicate certain spans of the table - specifying a percentage" +
    " (Relative Option) will result into an EXTRA OData Count request!\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.windowOptions.Controls.Add(this.relativeOptions);
            this.windowOptions.Controls.Add(this.fixedOptions);
            this.windowOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowOptions.Enabled = false;
            this.windowOptions.Location = new System.Drawing.Point(50, 77);
            this.windowOptions.Name = "windowOptions";
            this.windowOptions.Size = new System.Drawing.Size(500, 218);
            this.windowOptions.TabIndex = 3;
            this.windowOptions.TabStop = false;
            this.windowOptions.Text = "Window Options";
            // 
            // relativeOptions
            // 
            this.relativeOptions.Controls.Add(this.numPercentage);
            this.relativeOptions.Controls.Add(this.percentage);
            this.relativeOptions.Controls.Add(this.useRelative);
            this.relativeOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.relativeOptions.Location = new System.Drawing.Point(3, 98);
            this.relativeOptions.Name = "relativeOptions";
            this.relativeOptions.Padding = new System.Windows.Forms.Padding(20);
            this.relativeOptions.Size = new System.Drawing.Size(494, 81);
            this.relativeOptions.TabIndex = 1;
            // 
            // numPercentage
            // 
            this.numPercentage.DecimalPlaces = 2;
            this.numPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPercentage.Location = new System.Drawing.Point(100, 42);
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(374, 20);
            this.numPercentage.TabIndex = 2;
            this.numPercentage.Value = new decimal(new int[] {
            125,
            0,
            0,
            65536});
            // 
            // percentage
            // 
            this.percentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.percentage.Location = new System.Drawing.Point(20, 42);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(80, 19);
            this.percentage.TabIndex = 1;
            this.percentage.Text = "Percentage:";
            // 
            // useRelative
            // 
            this.useRelative.AutoSize = true;
            this.useRelative.Dock = System.Windows.Forms.DockStyle.Top;
            this.useRelative.Location = new System.Drawing.Point(20, 20);
            this.useRelative.Name = "useRelative";
            this.useRelative.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.useRelative.Size = new System.Drawing.Size(454, 22);
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
            this.fixedOptions.Padding = new System.Windows.Forms.Padding(20);
            this.fixedOptions.Size = new System.Drawing.Size(494, 82);
            this.fixedOptions.TabIndex = 0;
            // 
            // numDatasets
            // 
            this.numDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDatasets.Location = new System.Drawing.Point(100, 42);
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
            this.numDatasets.Size = new System.Drawing.Size(374, 20);
            this.numDatasets.TabIndex = 1;
            this.numDatasets.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // datasets
            // 
            this.datasets.Dock = System.Windows.Forms.DockStyle.Left;
            this.datasets.Location = new System.Drawing.Point(20, 42);
            this.datasets.Name = "datasets";
            this.datasets.Size = new System.Drawing.Size(80, 20);
            this.datasets.TabIndex = 0;
            this.datasets.Text = "Datasets:";
            // 
            // useFixed
            // 
            this.useFixed.AutoSize = true;
            this.useFixed.Dock = System.Windows.Forms.DockStyle.Top;
            this.useFixed.Location = new System.Drawing.Point(20, 20);
            this.useFixed.Name = "useFixed";
            this.useFixed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.useFixed.Size = new System.Drawing.Size(454, 22);
            this.useFixed.TabIndex = 2;
            this.useFixed.TabStop = true;
            this.useFixed.Text = "Fixed";
            this.useFixed.UseVisualStyleBackColor = true;
            this.useFixed.CheckedChanged += new System.EventHandler(this.useFixed_CheckedChanged);
            // 
            // SetupScraperConfigureStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windowOptions);
            this.Controls.Add(this.useWindowing);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
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
    }
}
