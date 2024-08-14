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
        SetupScraperView _view;
        SetupScraperController _controller;

        public SetupScraperConfigureStrategy(SetupScraperView view, SetupScraperController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
            useFixed.Checked = true;
            mergeSrcAlias.Text = _view.MergeSourceAlias;
            mergeDstAlias.Text = _view.MergeDestinationAlias;
            destinationTableName.Text = _view.TableName;
            useWindowing.Checked = _view.UseWindowing;
            useRelative.Checked = _view.UseWindowingPercentage;
            numDatasets.Value = _view.WindowingDatasets;
            numPercentage.Value = (decimal)_view.WindowingPercentage;
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

        private void tableNameOption_Enter(object sender, EventArgs e)
        {

        }

        private void mergeSrcAlias_TextChanged(object sender, EventArgs e)
        {
            _controller.SetSourceAlias(mergeSrcAlias.Text);
        }

        private void mergeDstAlias_TextChanged(object sender, EventArgs e)
        {
            _controller.SetDestinationAlias(mergeDstAlias.Text);
        }

        private void destinationTableName_TextChanged(object sender, EventArgs e)
        {
            _controller.SetTableName(destinationTableName.Text);
        }

        private void numDatasets_ValueChanged(object sender, EventArgs e)
        {
            _controller.SetDatasets(numDatasets.Value);
        }

        private void numPercentage_ValueChanged(object sender, EventArgs e)
        {
            _controller.SetPercentage(numPercentage.Value);

        }
    }
}
