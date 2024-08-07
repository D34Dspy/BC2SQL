using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using bc2sql.explore.Controllers;
using System.Windows.Forms;
using System.Security.Cryptography;
using bc2sql.shared;
using System.Net;
using System.Xml;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace bc2sql.explore
{
    internal class ExploreController
    {
        private Model _model;

        public LibraryConfiguration LibraryConfiguration;
        public Scrapers Scrapers;
        public Databases Databases;

        public string SuppliedLibraryFilename { get; private set; }

        void DetermineSuppliedLibraryFilename(string[] args)
        {

            SuppliedLibraryFilename = string.Empty;

            bool nextOneIsFilename = false;
            foreach (var arg in args)
            {
                if (nextOneIsFilename)
                {
                    SuppliedLibraryFilename = arg;
                    nextOneIsFilename = false;
                }
                var toLower = arg.ToLower();
                if (toLower.Equals("--library") || toLower.Equals("-l"))
                {
                    nextOneIsFilename = true;
                }
            }

            if (SuppliedLibraryFilename.Equals(string.Empty))
            {
                SuppliedLibraryFilename = string.Format("{0}\\{1}",
                    System.IO.Directory.GetCurrentDirectory(),
                    _model.LibraryConfig.GetStandardName()
                    );
            }
        }

        void CreateSubWorkspace(string filename)
        {
            if(!Directory.Exists(filename))
                Directory.CreateDirectory(filename);
        }

        void CreateSubWorkspaces() {
            var lib = _model.LibraryConfig;
            CreateSubWorkspace(lib.GetDatabases());
            CreateSubWorkspace(lib.GetScrapers());
            CreateSubWorkspace(lib.GetSchedulers());
            CreateSubWorkspace(lib.GetDataSources());
        }

        void OnLibraryChanged(object sender, string filename)
        {
            filename = ValidateLibraryFilename(filename);

            bool write = false;

            if(!File.Exists(filename))
            {
                var msg = string.Format("Library workspace does not exist @ \"{0}\"\nDo you want to create one there?", filename);
                if (MessageBox.Show(msg, "Library not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                }
                else if (MessageBox.Show("Do you wish to open one instead?", "Library not found - action", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var ofd = new OpenFileDialog();
                    ofd.Title = "Open configuration file...";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        filename = ofd.FileName;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    var sfd = new SaveFileDialog();
                    sfd.Title = "Save new configuration file...";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        filename = sfd.FileName;
                        write = true;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }

            _model.LibraryConfig.SetOrigin(filename);

            try
            {
                _model.LibraryConfig.SetSource(File.ReadAllText(filename));
            }
            catch (FileNotFoundException)
            {
                write = true;
            }

            if (!File.Exists(_model.LibraryConfig.ConfigureExe))
            {
                var ofd = new OpenFileDialog();
                ofd.Title = "Specify configuration executable...";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _model.LibraryConfig.ConfigureExe = ofd.FileName;
                }
            }

            if (!File.Exists(_model.LibraryConfig.ScrapeExe))
            {
                var ofd = new OpenFileDialog();
                ofd.Title = "Specify scraper executable...";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _model.LibraryConfig.ScrapeExe = ofd.FileName;
                }
            }

            if(write)
            {
                File.WriteAllText(_model.LibraryConfig.GetOrigin(), _model.LibraryConfig.GetSource());
            }

            CreateSubWorkspaces();
        }

        void SetupControllers()
        {
            LibraryConfiguration = new LibraryConfiguration();
            LibraryConfiguration.OnLibraryChanged += OnLibraryChanged;

            Scrapers = new Scrapers();
            Databases = new Databases();
        }

        string ValidateLibraryFilename(string filename)
        {
            try
            {
                if ((File.GetAttributes(filename) & FileAttributes.Directory)
                    == FileAttributes.Directory)
                {
                    return string.Format("{0}\\{1}", filename, _model.LibraryConfig.GetStandardName());
                }
                return filename;
            }
            catch (FileNotFoundException)
            {
                return filename;
            }
        }

        public ExploreController(Model model, string[] args)
        {
            _model = model;

            DetermineSuppliedLibraryFilename(args);
            SetupControllers();

            LibraryConfiguration.Filename = ValidateLibraryFilename(SuppliedLibraryFilename);
        }

        public void ReloadLibrary()
        {
            LibraryConfiguration.Filename = LibraryConfiguration.Filename;
        }

        private void Create<T>(string home_subdir, T cfg, IList<T> collection, out T storage) where T: IWorkspace
        {
            // Guid guid = Guid.NewGuid();
            // var dataSource = new DataSourceConfig();
            // 
            // var home = Path.Combine(_model.LibraryConfig.GetDataSources(), guid.ToString());
            // Directory.CreateDirectory(home);
            // var cfg = Path.Combine(home, dataSource.GetStandardName());
            // 
            // dataSource.Identifier = guid;
            // dataSource.Name = "Unnamed";
            // dataSource.SetOrigin(cfg);
            // 
            // _model.LibraryConfig.DataSources.Add(dataSource);
            // _model.SelectedDataSource = dataSource;
            // 
            // SaveDataSource();ww
            // SaveLibrary();

            Guid guid = Guid.NewGuid();
            var home = Path.Combine(home_subdir, guid.ToString());
            Directory.CreateDirectory(home);
            var filename = Path.Combine(home, cfg.GetStandardName());

            cfg.Identifier = guid;
            cfg.SetOrigin(filename);

            collection.Add(cfg);
            storage = cfg;

            SaveDataSource();
            SaveLibrary();
        }

        private void Clone<T>(string home_subdir, T data, IList<T> collection, out T storage) where T : IWorkspace
        {
            Create(
                home_subdir,
                (T)data.Clone(),
                collection,
                out storage);
        }

        public void CreateDataSource()
        {
            Create(
                _model.LibraryConfig.GetDataSources(),
                new DataSourceConfig(),
                _model.LibraryConfig.DataSources,
                out _model.SelectedDataSource);
        }

        public void CreateDatabase()
        {
            Create(
                _model.LibraryConfig.GetDatabases(),
                new DatabaseConfig(),
                _model.LibraryConfig.Databases,
                out _model.SelectedDatabase);
        }

        public void CloneDataSource()
        {
            Clone(
                _model.LibraryConfig.GetDataSources(),
                _model.SelectedDataSource,
                _model.LibraryConfig.DataSources,
                out _model.SelectedDataSource);
        }

        public void CloneDatabase()
        {
            Clone(
                _model.LibraryConfig.GetDatabases(),
                _model.SelectedDatabase,
                _model.LibraryConfig.Databases,
                out _model.SelectedDatabase);
        }

        public void DeleteDataSource()
        {
            WorkspaceUtil.Delete(_model.SelectedDataSource, _model.LibraryConfig.DataSources);
        }
        public void DeleteDatabase()
        {
            WorkspaceUtil.Delete(_model.SelectedDatabase, _model.LibraryConfig.Databases);
        }

        public void SaveDataSource()
        {
            WorkspaceUtil.Save(_model.SelectedDataSource);
        }
        public void SaveDatabase()
        {
            WorkspaceUtil.Save(_model.SelectedDatabase);
        }

        public void SaveLibrary()
        {
            WorkspaceUtil.Save(_model.LibraryConfig);
        }

        public void SetLibrarySource(string src)
        {
            _model.LibraryConfig.SetSource(src);
        }

        public void SetDatabaseSource(string src)
        {
            _model.SelectedDatabase.SetSource(src);
        }

        public void SetDataSourceSource(string src)
        {
            _model.SelectedDataSource.SetSource(src);
        }

        public void MakeDataSourceCurrent(int index)
        {
            _model.SelectedDataSource = _model.LibraryConfig.DataSources[index];
        }

        public void MakeDatabaseCurrent(int index)
        {
            _model.SelectedDatabase = _model.LibraryConfig.Databases[index];
        }

        public delegate void OnMetadataFetched(bool succeeded);
        class MetadataPayload
        {
            public OnMetadataFetched OnFetch;
            public DataSourceConfig DataSource;
            public void Execute()
            {
                try
                {
                    DataSource.FetchMetaData();
                    OnFetch(true);
                }
                catch (Exception ex)
                {
                    OnFetch(false);
                }
            }
        }

        public void FetchMetadata(OnMetadataFetched onFetch = null)
        {
            // Thread t = new Thread((object o) => ((MetadataPayload)o).Execute());
            // t.Start(new MetadataPayload
            // {
            //     OnFetch = onFetch,
            //     DataSource = _model.SelectedDataSource
            // });
            try
            {
                _model.SelectedDataSource.FetchMetaData();
                onFetch(true);
            }
            catch (Exception ex)
            {
                onFetch(false);
            }
        }

        public void CreateScraper(Guid guid)
        {

        }

        internal void CreateInspection(int index)
        {
            _model.InspectIndex = index;
            _model.InspectDataSource = _model.SelectedDataSource;
            _model.InspectDataType = _model.SelectedDataSource.Metadata.Defs[index];
            _model.InspectEntityName = _model.InspectDataType.Name;
            _model.InspectPropertyIndex = 0;
            _model.InspectProperty = _model.InspectDataType.Properties[0];
        }

        internal InspectController CreateInspectController()
        {
            return new InspectController(_model);
        }

        internal SetupModel CreateSetupModel()
        {
            return new SetupModel(_model);
        }
    }
}
