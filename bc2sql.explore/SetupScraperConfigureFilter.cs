using bc2sql.explore.Controllers;
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
    internal partial class SetupScraperConfigureFilter : UserControl, ISetupPage
    {
        SetupScraperView _view;
        SetupScraperController _controller;

        public SetupScraperConfigureFilter(SetupScraperView view, SetupScraperController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
        }
        public SetupScraperConfigureFilter()
        {
            InitializeComponent();
        }

        private void InitDataSets()
        {
            Util.Bind(mergeConditions, null, "Expression", "SQL expression of the conditions");

            Util.Bind(requestFormFields, "Key", "Key", "Name of the form field");
            Util.Bind(requestFormFields, "Value", "Value", "Name of the form field");
        }

        private void BindDataSets()
        {
            mergeConditions.DataSource = _view.MergeConditions;
            requestFormFields.DataSource = _view.FormFields;
        }


        private void SetupScraperSettingsPage_Load(object sender, EventArgs e)
        {
            InitDataSets();
            BindDataSets();
        }

        public SetupButton[] GetButtons()
        {
            return Util.GetDefaultSetupButtons();
        }

        public void OnButtonClicked(SetupButton button)
        {
        }

        public string GetCaption()
        {
            return "Filter";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }

        private void mergeConditions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
