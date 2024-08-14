namespace bc2sql.explore
{
    partial class SetupExplorerNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupExplorerNew));
            this.filenameOptions = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.recommendation = new System.Windows.Forms.Label();
            this.filenameOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // filenameOptions
            // 
            this.filenameOptions.Controls.Add(this.textBox1);
            this.filenameOptions.Controls.Add(this.button1);
            this.filenameOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.filenameOptions.Location = new System.Drawing.Point(50, 50);
            this.filenameOptions.Name = "filenameOptions";
            this.filenameOptions.Size = new System.Drawing.Size(500, 39);
            this.filenameOptions.TabIndex = 1;
            this.filenameOptions.TabStop = false;
            this.filenameOptions.Text = "Filename";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(468, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(471, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // recommendation
            // 
            this.recommendation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recommendation.Location = new System.Drawing.Point(50, 89);
            this.recommendation.Name = "recommendation";
            this.recommendation.Size = new System.Drawing.Size(500, 261);
            this.recommendation.TabIndex = 2;
            this.recommendation.Text = resources.GetString("recommendation.Text");
            this.recommendation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupExplorerNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recommendation);
            this.Controls.Add(this.filenameOptions);
            this.Name = "SetupExplorerNew";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(600, 400);
            this.filenameOptions.ResumeLayout(false);
            this.filenameOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filenameOptions;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label recommendation;
    }
}
