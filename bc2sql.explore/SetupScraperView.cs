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
    internal class SetupScraperView
    {
        private SetupScraperModel _model;
        public ExploreView Explorer;
        public ScraperSettings Settings;

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

        public DatabaseConfig Database
        {
            get
            {
                return _model.Database;
            }
        }

        public DataSourceConfig DataSource
        {
            get
            {
                return _model.DataSource;
            }
        }

        public EntityType EntityType
        {
            get
            {
                return _model.EntityTypeSet.Type;
            }
        }

        public EntitySet EntitySet
        {
            get
            {
                return _model.EntityTypeSet.Set;
            }
        }

        public IEnumerable<EntityTypeSetPair> EntityTypes
        {
            get
            {
                return _model.EntityTypeSets;
            }
        }

        public IEnumerable<Property> Keys
        {
            get
            {
                return _model.Keys;
            }
        }

        public List<string> MergeConditions
        {
            get
            {
                return _model.MergeConditions;
            }
        }

        public List<FormField> FormFields
        {
            get
            {
                return _model.FormFields;
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

        public IEnumerable<Property> SelectedKeys
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

        public string MergeSourceAlias
        {
            get { return _model.SourceAlias; }
            set { _model.SourceAlias = value; }
        }

        public string MergeDestinationAlias
        {
            get { return _model.DestinationAlias; }
            set { _model.DestinationAlias = value; }
        }

        public string TableName
        {
            get { return _model.TableName; }
            set { _model.TableName = value; }
        }

        public IEnumerable<Property> SelectKeys(IEnumerable<int> indices)
        {
            foreach(var index in indices)
            {
                yield return _model.Keys[index];
            }
        }
        public SetupScraperView(SetupScraperModel mdl, ExploreView view)
        {
            _model = mdl;
            Explorer = view;
            Settings = new ScraperSettings(mdl);
        }
    }
}
