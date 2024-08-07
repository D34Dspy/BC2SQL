using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal partial class SetupScraperConfigureStrategy : UserControl, ISetupPage
    {
        SetupView _view;
        SetupController _controller;

        public SetupScraperConfigureStrategy(SetupView view, SetupController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
            useFixed.Checked = true;
        }

        public SetupButton[] GetButtons()
        {
            return Util.GetDefaultSetupButtons();
        }

        public string GetCaption()
        {
            return "Strategy";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }

        void ISetupPage.OnButtonClicked(SetupButton button)
        {
            
        }

        private void SetupScraperConfigureStrategy_Load(object sender, EventArgs e)
        {
        }

        private void useWindowing_CheckedChanged(object sender, EventArgs e)
        {
            windowOptions.Enabled = useWindowing.Checked;
        }

        private void useFixed_CheckedChanged(object sender, EventArgs e)
        {
            if(useFixed.Checked)
            {
                useRelative.Checked = false;
                numDatasets.Enabled = true;
                numPercentage.Enabled = false;
            }
        }

        private void Relative_CheckedChanged(object sender, EventArgs e)
        {
            if (useRelative.Checked)
            {
                useFixed.Checked = false;
                numDatasets.Enabled = false;
                numPercentage.Enabled = true;
            }
        }
    }
}
