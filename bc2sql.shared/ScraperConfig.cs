using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace bc2sql.shared
{
    public class ScraperConfig : IWorkspace
    {
        // Connection
        public Guid DataSourceIdentifier { get; set; }
        public Guid DataBaseIdentifier { get; set; }
        public string DataSourceOrigin { get; set; }
        public string DatabaseOrigin { get; set; }

        // Data Source
        public EntityType Type { get; set; }
        public EntitySet Set { get; set; }

        // Scraper
        public Guid Identifier { get; set; }
        public ScraperStrategy Strategy { get; set; }
        public bool UseWindowing { get; set; }
        public int WindowSize { get; set; }
        public int DataSourceCount { get; set; } // To Assign WindowSize via a percentage
        public string SourceAlias { get; set; }
        public string DestinationAlias { get; set; }
        public Property[] Keys { get; set; }
        public bool UseSystemGuidInsertModifyDate { get; set; }
        public string TableName { get; set; }
        public string[] MergeConditions { get; set; }
        public FormField[] FormFields { get; set; }

        // Bindings
        private DataSourceConfig _dataSource;
        private DatabaseConfig _database;

        public void Bind(DataSourceConfig ds, DatabaseConfig db)
        {
            _dataSource = ds;
            DataSourceIdentifier = ds.Identifier;
            DataSourceOrigin = ds.GetOrigin();
            _database = db;
            DataBaseIdentifier = db.Identifier;
            DatabaseOrigin = db.GetOrigin();
        }

        public DataSourceConfig GetDataSource()
        {
            return _dataSource;
        }
        public DatabaseConfig GetDatabase()
        {
            return _database;
        }

        public SCRConfig Io(SCRConfig config = null)
        {
            if (config == null)
            {
                config = new SCRConfig()
                {
                    DataSourceIdentifier = DataSourceIdentifier,
                    DataBaseIdentifier = DataBaseIdentifier,
                    DataSourceOrigin = DataSourceOrigin,
                    DatabaseOrigin = DatabaseOrigin,
                    Identifier = Identifier,
                    Strategy = Strategy,
                    TableName = TableName,
                    Set = Set,
                    Type = Type,
                    MergeSourceAlias = SourceAlias,
                    MergeDestinationAlias = DestinationAlias,
                };
            }
            else
            {
                DataSourceIdentifier = config.DataSourceIdentifier;
                DataBaseIdentifier = config.DataBaseIdentifier;
                DataSourceOrigin = config.DataSourceOrigin;
                DatabaseOrigin = config.DatabaseOrigin;
                Identifier = config.Identifier;
                Strategy = config.Strategy;
                TableName = config.TableName;
                Set = config.Set;
                Type = config.Type;
                SourceAlias = config.MergeSourceAlias;
                DestinationAlias = config.MergeDestinationAlias;
            }
            return config;
        }

        private string _origin;
        public string GetSource() { return Util.Serialize(SCRConfig.gSerializer, Io(null)); }
        public void SetSource(string source) { Io((SCRConfig)Util.Deserialize(SCRConfig.gSerializer, source)); }
        public string GetStandardName() { return "bc2sql.scraper.xml"; }
        public string GetOrigin() { return _origin; }
        public void SetOrigin(string origin) { _origin = origin; }
        public object Clone() { return MemberwiseClone(); }
    }
}
