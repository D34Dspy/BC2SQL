namespace bc2sql.explore
{
    partial class Setup
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
            this.setupActionContainer = new System.Windows.Forms.Panel();
            this.wizardButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.setupPageContainer = new System.Windows.Forms.Panel();
            this.setupAgenda = new System.Windows.Forms.FlowLayoutPanel();
            this.setupActionContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // setupActionContainer
            // 
            this.setupActionContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.setupActionContainer.Controls.Add(this.wizardButtonLayout);
            this.setupActionContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setupActionContainer.Location = new System.Drawing.Point(0, 384);
            this.setupActionContainer.Name = "setupActionContainer";
            this.setupActionContainer.Padding = new System.Windows.Forms.Padding(10);
            this.setupActionContainer.Size = new System.Drawing.Size(800, 66);
            this.setupActionContainer.TabIndex = 0;
            // 
            // wizardButtonLayout
            // 
            this.wizardButtonLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardButtonLayout.ColumnCount = 4;
            this.wizardButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.wizardButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.wizardButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.wizardButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 552F));
            this.wizardButtonLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.wizardButtonLayout.Location = new System.Drawing.Point(13, 10);
            this.wizardButtonLayout.Name = "wizardButtonLayout";
            this.wizardButtonLayout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.wizardButtonLayout.RowCount = 1;
            this.wizardButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.wizardButtonLayout.Size = new System.Drawing.Size(777, 46);
            this.wizardButtonLayout.TabIndex = 1;
            // 
            // setupPageContainer
            // 
            this.setupPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupPageContainer.Location = new System.Drawing.Point(200, 0);
            this.setupPageContainer.Name = "setupPageContainer";
            this.setupPageContainer.Size = new System.Drawing.Size(600, 384);
            this.setupPageContainer.TabIndex = 1;
            // 
            // setupAgenda
            // 
            this.setupAgenda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.setupAgenda.Dock = System.Windows.Forms.DockStyle.Left;
            this.setupAgenda.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.setupAgenda.Location = new System.Drawing.Point(0, 0);
            this.setupAgenda.Name = "setupAgenda";
            this.setupAgenda.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.setupAgenda.Size = new System.Drawing.Size(200, 384);
            this.setupAgenda.TabIndex = 0;
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.setupPageContainer);
            this.Controls.Add(this.setupAgenda);
            this.Controls.Add(this.setupActionContainer);
            this.DoubleBuffered = true;
            this.Name = "Setup";
            this.ShowIcon = false;
            this.Text = "Wizard - BC2SQL";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.setupActionContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel setupActionContainer;
        private System.Windows.Forms.TableLayoutPanel wizardButtonLayout;
        private System.Windows.Forms.Panel setupPageContainer;
        private System.Windows.Forms.FlowLayoutPanel setupAgenda;
    }
}