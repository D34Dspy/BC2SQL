using bc2sql.explore.Controllers;
using bc2sql.explore.Views;
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
        SetupScraperView _view;
        SetupScraperController _controller;

        public SetupScraperBindDataSourcePage(SetupScraperView view, SetupScraperController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
            _controller.SetDatasource(0);
            _controller.SetDataset(0);
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
            if(button == SetupButton.Next)
            {
                
            }
        }
        private void InitDataSets()
        {
            Util.Bind(dataSources, "Name", "Name", "Name of the data source");
            Util.Bind(dataSources, "Description", "Description", "Description of the data source");

            Util.Bind(dataSourceEntities, "SetName", "Entity Set", "Name of the data collection");
            Util.Bind(dataSourceEntities, "TypeName", "Entity Type", "Name of the data type");
        }

        private void BindDataSets()
        {
            dataSources.DataSource = _view.DataSources;
            dataSourceEntities.DataSource = _view.EntityTypes;
        }

        private void SetupScraperBindDatasourcePage_Load(object sender, EventArgs e)
        {
            InitDataSets();
            BindDataSets();
        }

        private void dataSources_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetDatasource(e.RowIndex);
            dataSourceEntities.ClearSelection();
            if(dataSourceEntities.Rows.Count > 0)
                dataSourceEntities.Rows[0].Selected = true;
        }

        private void dataSources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // see dataSources_RowEnter
            _controller.SetDataset(dataSourceEntities.SelectedRows[0].Index);
        }

        private void odataEndpoint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void odataMetadata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void odataEntity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dataSourceEntities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
