using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class SetupModel
    {
        private Model _model;

        public bool IsNew;

        public bool UseWindowing;
        public bool UsePercentage;
        public float WindowingPercentage; // for usePercentage=true
        public int WindowingDatasets;

        public List<int> SelectedKeys;

        public bool UseSystemGUIDInsertUpdate;
        public int IndexOfSystemGUID;
        public int IndexOfInsertDate;
        public int IndexOfUpdateDate;

        public DataSourceConfig DataSource;
        public DatabaseConfig Database;

        public List<DataSourceConfig> DataSourceConfigs
        {
            get
            {
                return _model.LibraryConfig.DataSources;
            }
        }

        public List<DatabaseConfig> DatabaseConfigs
        {
            get
            {
                return _model.LibraryConfig.Databases;
            }
        }

        public SetupModel(Model model)
        { 
            _model = model; 
        }
    }
}
