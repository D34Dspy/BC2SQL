using bc2sql.explore.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    partial class SetupScraperBindDataSourcePage : UserControl, ISetupPage
    {
        SetupView _view;
        SetupController _controller;

        public SetupScraperBindDataSourcePage(SetupView view, SetupController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
        }

        public SetupButton[] GetButtons()
        {
            return Util.GetFirstSetupButtons();
        }

        public string GetCaption()
        {
            return "Datasource";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }

        public void OnButtonClicked(SetupButton button)
        {

        }
        private void InitDataSets()
        {
            Util.Bind(dataSources, "Name", "Name", "Name of the data source");
            Util.Bind(dataSources, "Description", "Description", "Description of the data source");

            Util.Bind(dataSourceEntities, "", "Name", "Name of the data source");
            Util.Bind(dataSourceEntities, "", ".NET Type", "");
        }

        private void BindDataSets()
        {
            // databases.DataSource = _view.Databases;
        }

        private void SetupScraperBindDatasourcePage_Load(object sender, EventArgs e)
        {

        }
    }
}
