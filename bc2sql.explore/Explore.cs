using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bc2sql.explore
{
    public partial class Explore : Form
    {
        private View _view;
        private Controller _controller;

        public Explore()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Bind(DataGridView dgv, string sourceField, string caption, string description) { 
            var col = new DataGridViewColumn();
            col.DataPropertyName = sourceField;
            col.HeaderText = caption;
            col.ToolTipText = description;
            if(dgv.AutoGenerateColumns)
                dgv.AutoGenerateColumns = false;
            col.CellTemplate = new DataGridViewTextBoxCell();
            dgv.Columns.Add(col);
        }

        private void InitDataSets()
        {
            Bind(dataSources, "Name", "Name", "Name of the data source");
            Bind(dataSources, "Identifier", "ID", "(Unique) identifier of the data source");

            Bind(databases, "Name", "Name", "Name of the database");
            Bind(databases, "Identifier", "ID", "(Unique) identifier of the database");

            Bind(dataSourceMetaData, "Name", "Name", "Name of the (OData) entity");
        }

        private int WarnDataSetChangesLoss(int dataset, int xDataset)
        {
            if (MessageBox.Show("You're about to select another data set!\nPotential changes might not persist.\nAre you sure you want to continue?", "Data Loss", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return dataset;
            return xDataset;
        }

        private void BindDataSets()
        {
            dataSources.DataSource = _view.DataSources;
            if (_view.HasSelectedDataSource())
            {
                dataSourceConfig.SelectedObject = _view.CurrentDataSource;
                if(_view.HasSelectedMetadata())
                    dataSourceMetaData.DataSource = _view.CurrentDataSource.Metadata.Services.Schemas[0].Defs;
            }

            databases.DataSource = _view.Databases;
            schedulers.DataSource = _view.Schedulers;
            scrapers.DataSource = _view.Scrapers;
        }

        private void Explore_Load(object sender, EventArgs e)
        {
            libraryConfigProperties.SelectedObject = _view.CurrentLibrary;

            InitDataSets();
            BindDataSets();
        }

        internal void SetVC(View view, Controller controller)
        {
            _view = view;
            _controller = controller;
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void addDataSource_Click(object sender, EventArgs e)
        {
            _controller.CreateDataSource();
            _view.RefreshDataSources();
            BindDataSets();
        }

        private void removeDataSource_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this data source?\nHint: it cannot be undone!!!", "Confirm Deletion", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                _controller.DeleteDataSource();
            }
        }

        private void saveDataSource_Click(object sender, EventArgs e)
        {
            _controller.SaveDataSource();
        }

        private void downloadDataSourceMetaData_Click(object sender, EventArgs e)
        {

        }

        private void allDataSources_Click(object sender, EventArgs e)
        {

        }

        void SearchScrapers()
        {

        }

        private void scraperRefresh_Click(object sender, EventArgs e)
        {
            SearchScrapers();
        }

        private void scraperFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchScrapers();
            }
        }

        private void addScheduler_Click(object sender, EventArgs e)
        {

        }

        private void removeScheduler_Click(object sender, EventArgs e)
        {

        }

        private void editScheduler_Click(object sender, EventArgs e)
        {

        }

        private void runScheduler_Click(object sender, EventArgs e)
        {

        }

        void SearchSchedulers()
        {

        }

        private void schedulerFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchSchedulers();
            }
        }

        private void searchSchedulers_Click(object sender, EventArgs e)
        {
            SearchSchedulers();
        }

        private void librarySourcePage_Enter(object sender, EventArgs e)
        {
            librarySource.Text = _view.CurrentLibrary.Source;
        }

        private void librarySourcePage_Leave(object sender, EventArgs e)
        {
            _controller.SetLibrarySource(librarySource.Text);
        }

        private void scraperList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO update GUID
        }

        private void setScraperDataSource_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void setScraperDatabase_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void dataSources_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _controller.MakeDataSourceCurrent(e.RowIndex);
            BindDataSets();
        }

        private void refreshConfiguration_Click(object sender, EventArgs e)
        {
            _controller.ReloadLibrary();
        }

        private void saveConfiguration_Click(object sender, EventArgs e)
        {
            _controller.SaveLibrary();
        }

        private void saveDatabase_Click(object sender, EventArgs e)
        {
            _controller.SaveDatabase();
        }

        private void addDatabase_Click(object sender, EventArgs e)
        {
            _controller.CreateDatabase();
            _view.RefreshDataSources();
            BindDataSets();
        }

        private void dataSourceMetaDataInspect_Click(object sender, EventArgs e)
        {

        }

        private void obtainDatasourceMetadata_Click(object sender, EventArgs e)
        {
            _controller.FetchMetadata((bool ok) => {

                dataSourceConnectionState.Text =
                    string.Format("Connection Status: {0}", ok ? "success" : "failure");

                BindDataSets();

            });
        }

        private void createScraperFromEntity_Click(object sender, EventArgs e)
        {

        }

        private void removeDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this database?\nHint: it cannot be undone!!!", "Confirm Deletion", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                _controller.DeleteDatabase();
            }
        }

        private void databaseCodePage_Enter(object sender, EventArgs e)
        {
            databaseCode.Text = _view.CurrentDataBase.Source;
        }

        private void databaseCodePage_Leave(object sender, EventArgs e)
        {
            _controller.SetDatabaseSource(databaseCode.Text);
        }

        private void dataSourceCodeCodePage_Enter(object sender, EventArgs e)
        {
            dataSourceCode.Text = _view.CurrentDataSource.Source;
        }

        private void dataSourceCodeCodePage_Leave(object sender, EventArgs e)
        {
            _controller.SetDataSourceSource(dataSourceCode.Text);
        }

        private void cloneDataSource_Click(object sender, EventArgs e)
        {
            _controller.CloneDataSource();
        }

        private void cloneDatabase_Click(object sender, EventArgs e)
        {
            _controller.CloneDatabase();
        }

        private void removeAllDatabases_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
