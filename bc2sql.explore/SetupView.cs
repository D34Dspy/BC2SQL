using bc2sql.shared;
using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class SetupView
    {
        private SetupModel _model;

        public bool IsEditing { get { return !_model.IsNew; } }

        public IEnumerable<DataSourceConfig> DataSources
        {
            get
            {
                return _model.DataSourceConfigs;
            }
        }

        public IEnumerable<DatabaseConfig> Databases
        {
            get
            {
                return _model.DatabaseConfigs;
            }
        }

        public bool UseWindowing
        {
            get { return _model.UseWindowing; }
            set { _model.UseWindowing = value; }
        }
        public bool UseWindowingPercentage
        {
            get { return _model.UsePercentage; }
            set { _model.UsePercentage = value; }
        }
        public float WindowingPercentage
        {
            get { return _model.WindowingPercentage; }
            set { _model.WindowingPercentage = value; }
        }
        public int WindowingDatasets
        {
            get { return _model.WindowingDatasets; }
            set { _model.WindowingDatasets = value; }
        }
        public List<int> SelectedKeys
        {
            get { return _model.SelectedKeys; }
        }
        public bool UseSystemGUIDInsertUpdate
        {
            get { return _model.UseSystemGUIDInsertUpdate; }
            set { _model.UseSystemGUIDInsertUpdate = value; }
        }
        public int IndexOfSystemGUID
        {
            get { return _model.IndexOfSystemGUID; }
            set { _model.IndexOfSystemGUID = value; }
        }
        public int IndexOfInsertDate
        {
            get { return _model.IndexOfInsertDate; }
            set { _model.IndexOfInsertDate = value; }
        }
        public int IndexOfUpdateDate
        {
            get { return _model.IndexOfUpdateDate; }
            set { _model.IndexOfUpdateDate = value; }
        }

        public SetupView(SetupModel mdl)
        {
            _model = mdl;
        }
    }
}
