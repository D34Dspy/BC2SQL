using bc2sql.explore.Views;
using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal class ExploreView
    {
        private ExploreModel _model;
        public CurrentLibrary CurrentLibrary { get; private set; }
        public CurrentDataSource CurrentDataSource { get; private set; }
        public CurrentDataBase CurrentDataBase { get; private set; }
        public CurrentScraper CurrentScraper { get; private set; }
        public BindingSource DataSources { get; private set; }
        public BindingSource Databases { get; private set; }
        public BindingSource Scrapers { get; private set; }
        public BindingSource Schedulers { get; private set; }

        public ExploreView(ExploreModel model)
        {
            _model = model;
            CurrentLibrary = new CurrentLibrary(model);
            CurrentDataSource = new CurrentDataSource(model);
            CurrentDataBase = new CurrentDataBase(model);
            CurrentScraper = new CurrentScraper(model);

            RefreshDataSources();
            RefreshDatabases();
            RefreshSchedulers();
            RefreshScrapers();
        }

        public void RefreshDataSources()
        {
            DataSources = new BindingSource();
            DataSources.DataSource = _model.LibraryConfig.DataSources;
            DataSources.AllowNew = false;
        }

        public void RefreshDatabases()
        {
            Databases = new BindingSource();
            Databases.DataSource = _model.LibraryConfig.Databases;
            Databases.AllowNew = false;
        }

        public void RefreshScrapers()
        {
            Scrapers = new BindingSource();
            Scrapers.DataSource = _model.LibraryConfig.Scrapers;
            Scrapers.AllowNew = false;
        }

        public void RefreshSchedulers()
        {
            Schedulers = new BindingSource();
            Schedulers.DataSource = _model.LibraryConfig.Schedulers;
            Schedulers.AllowNew = false;
        }

        public bool HasSelectedDataSource()
        {
            return _model.SelectedDataSource != null;
        }
        public bool HasSelectedDatabase()
        {
            return _model.SelectedDatabase != null;
        }
        public bool HasSelectedMetadata()
        {
            return HasSelectedDataSource() && _model.SelectedDataSource.Metadata != null;
        }
    
        public InspectView CreateInspectView()
        {
            return new InspectView(_model);
        }
    }
}
