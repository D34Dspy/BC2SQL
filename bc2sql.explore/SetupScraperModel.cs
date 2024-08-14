using bc2sql.explore.Views;
using bc2sql.shared;
using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class SetupScraperModel
    {
        private ExploreModel _model;

        public bool IsNew;
        public string Name;
        public string SourceAlias;
        public string DestinationAlias;
        public string TableName;

        public bool UseWindowing;
        public bool UsePercentage;
        public float WindowingPercentage; // for usePercentage=true
        public int WindowingDatasets;

        public List<Property> SelectedKeys;
        public Property SelectedKey;
        public List<Property> Keys;

        public bool UseSystemGUIDInsertUpdate;
        public int IndexOfSystemGUID;
        public int IndexOfInsertDate;
        public int IndexOfUpdateDate;

        public DataSourceConfig DataSource;
        public DatabaseConfig Database;
        public EntityTypeSetPair EntityTypeSet;
        public EntityTypeSetPair[] EntityTypeSets;

        public List<FormField> FormFields; // Web Request
        public List<string> MergeConditions; // SQL

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

        public SetupScraperModel(ExploreModel model)
        { 
            _model = model;
            IndexOfSystemGUID = -1;
            IndexOfInsertDate = -1;
            IndexOfUpdateDate = -1;
            WindowingDatasets = 1;
            WindowingPercentage = 20;
            EntityTypeSets = new EntityTypeSetPair[0];
            FormFields = new List<FormField>();
            MergeConditions = new List<string>();
            SelectedKeys = new List<Property>();
            Keys = new List<Property>();
        }

        public void SetDataSource(int index)
        {
            DataSource = _model.LibraryConfig.DataSources[index];
        }

        public void SetDatabase(int index)
        {
            Database = _model.LibraryConfig.Databases[index];
        }
    }
}
