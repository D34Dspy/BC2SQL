using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bc2sql.explore
{
    public partial class Explore : Form
    {
        private ExploreView _view;
        private ExploreController _controller;

        public Explore()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void InitDataSets()
        {
            Util.Bind(dataSources, "Name", "Name", "Name of the data source");
            Util.Bind(dataSources, "Identifier", "ID", "(Unique) identifier of the data source");

            Util.Bind(databases, "Name", "Name", "Name of the database");
            Util.Bind(databases, "Identifier", "ID", "(Unique) identifier of the database");

            Util.Bind(dataSourceMetaData, "Name", "Name", "Name of the (OData) entity type");
            Util.Bind(dataSourceEntitySets, "Name", "Name", "Name of the (OData) entity set");

            Util.Bind(scrapers, "Name", "Name", "Name of the scraper");
            Util.Bind(scrapers, "DataSourceIdentifier", "DSID", "(Unique) identifier of the data source");
            Util.Bind(scrapers, "DatabaseIdentifier", "DBID", "(Unique) identifier of the database");
        }

        private void BindDataSets()
        {
            dataSources.DataSource = _view.DataSources;
            if (_view.HasSelectedDataSource())
            {
                dataSourceConfig.SelectedObject = _view.CurrentDataSource;
                if(_view.HasSelectedMetadata())
                {
                    dataSourceMetaData.DataSource = _view.CurrentDataSource.Metadata.Defs;
                    dataSourceEntitySets.DataSource = _view.CurrentDataSource.Sets;
                }
            }

            databases.DataSource = _view.Databases;
            if(_view.HasSelectedDatabase())
                databaseConfig.SelectedObject = _view.CurrentDataBase;

            schedulers.DataSource = _view.Schedulers;
            scrapers.DataSource = _view.Scrapers;
        }

        private void Explore_Load(object sender, EventArgs e)
        {
            libraryConfigProperties.SelectedObject = _view.CurrentLibrary;

            InitDataSets();
            BindDataSets();
            Activate();
        }

        internal void SetVC(ExploreView view, ExploreController controller)
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
            if (dataSources.SelectedRows.Count == 0) return;
            if(MessageBox.Show("Are you sure you want to delete this data source?\nHint: it cannot be undone!!!", "Confirm Deletion", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                _controller.DeleteDataSource();
                BindDataSets();
                dataSources.Refresh();
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
            _view.RefreshDatabases();
            BindDataSets();
        }

        private void dataSourceMetaDataInspect_Click(object sender, EventArgs e)
        {
            var entityIdx = dataSourceMetaData.SelectedRows[0].Index;
            _controller.CreateInspectionByType(entityIdx);

            Inspect inspector = new Inspect();
            inspector.SetVC(_view.CreateInspectView(), _controller.CreateInspectController());
            inspector.ShowDialog();
        }

        private void obtainDatasourceMetadata_Click(object sender, EventArgs e)
        {
            if (!_view.HasSelectedDataSource() || _view.CurrentDataSource.Endpoint == null ||
                _view.CurrentDataSource.Endpoint == string.Empty)
            {
                MessageBox.Show("No endpoint specified in data source.", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            webFetcher.RunWorkerAsync();
        }

        private void RunScraperSetup(DataSourceConfig dataSource = null, string entity = null)
        {
            var setupModel = _controller.CreateSetupModel();
            var setupView = new SetupScraperView(setupModel, _view);
            var setupController = new SetupScraperController(setupModel, _controller);
            var setup = Setup.CreateScraper(setupView, setupController);

            setupModel.IsNew = dataSource == null;

            var result = setup.ShowDialog();

            if(result == DialogResult.OK)
            {
                var cfg = setupController.CreateConfig();
            }
            else MessageBox.Show("The operation was aborted or has been canceled");

        }

        private void createScraperFromEntity_Click(object sender, EventArgs e)
        {
            RunScraperSetup();
        }

        private void removeDatabase_Click(object sender, EventArgs e)
        {
            if (databases.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Are you sure you want to delete this database?\nHint: it cannot be undone!!!", "Confirm Deletion", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                databases.Rows.Remove(databases.SelectedRows[0]);
                _controller.DeleteDatabase();
                BindDataSets();
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

        private void webFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            _controller.FetchMetadata((bool ok) => {
                dataSourceConnectionState.Text =
                    string.Format("Connection Status: {0}", ok ? "success" : "failure");
            });
        }

        private void webFetcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindDataSets();
        }

        private void addScraper_Click(object sender, EventArgs e)
        {
            RunScraperSetup();
        }

        private void databaseConfig_Click(object sender, EventArgs e)
        {

        }

        private void obtainDatasourceMetadata_Click_1(object sender, EventArgs e)
        {
            if (!_view.HasSelectedDataSource() || _view.CurrentDataSource.Endpoint == null ||
                _view.CurrentDataSource.Endpoint == string.Empty)
            {
                MessageBox.Show("No endpoint specified in data source.", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            webFetcher.RunWorkerAsync();
        }

        private void inspectMetadata_Click(object sender, EventArgs e)
        {
            var entityIdx = dataSourceEntitySets.SelectedRows[0].Index;
            _controller.CreateInspectionBySet(entityIdx);

            Inspect inspector = new Inspect();
            inspector.SetVC(_view.CreateInspectView(), _controller.CreateInspectController());
            inspector.ShowDialog();
        }

        private void createScraper_Click(object sender, EventArgs e)
        {
            RunScraperSetup();
        }

        private void runScraper_Click(object sender, EventArgs e)
        {

        }

        private void databases_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _controller.MakeDatabaseCurrent(e.RowIndex);
            BindDataSets();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;

            // _controller.RunScraper();
            var launcher = new Launch(_controller.RunScraper(),
            (proc_) => {
                var proc = (Process)proc_;
                proc.WaitForExit();
                return proc.HasExited 
                ? (proc.ExitCode == 0 
                    ? DialogResult.OK 
                    : DialogResult.Abort) 
                : DialogResult.Retry;
            });

            if(launcher.ShowDialog() != DialogResult.OK)
                MessageBox.Show("The operation has been aborted or cancelled!");

            Enabled = true;
        }

        private void scrapers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.MakeScraperCurrent(e.RowIndex);
        }

        private void scrapers_SelectionChanged(object sender, EventArgs e)
        {
            if(scrapers.SelectedRows.Count > 0)
                _controller.MakeScraperCurrent(scrapers.SelectedRows[0].Index);
        }

        private void runKeepOpen_Click(object sender, EventArgs e)
        {
            Enabled = false;

            // _controller.RunScraper();
            var launcher = new Launch(_controller.RunScraper(true),
            (proc_) => {
                var proc = (Process)proc_;
                proc.WaitForExit();
                return proc.HasExited
                ? (proc.ExitCode == 0
                    ? DialogResult.OK
                    : DialogResult.Abort)
                : DialogResult.Retry;
            });

            if (launcher.ShowDialog() != DialogResult.OK)
                MessageBox.Show("The operation has been aborted or cancelled!");

            Enabled = true;
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var proc = _controller.RunScraper(false, true))
            {
                MessageBox.Show(
                    string.Format("{0} {1}", proc.StartInfo.FileName, proc.StartInfo.Arguments),
                    "Scraper Run Command - BC2SQL"
                );
            }
        }

        private void runAndKeepOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeScraper_Click(object sender, EventArgs e)
        {
            _controller.DeleteScraper();
        }
    }
}
