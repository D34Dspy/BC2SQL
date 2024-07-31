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

        // Data Source
        public Url Endpoint { get; set; }

        // Database
        public string ConnectString { get; set; }

        // Scraper
        public Guid Identifier { get; set; }
        public ScraperStrategy Strategy { get; set; }
        public string TableName { get; set; }

        // Bindings
        private DataSourceConfig _dataSource;
        private DatabaseConfig _database;

        public void Bind(DataSourceConfig ds, DatabaseConfig db)
        {
            _dataSource = ds;
            _database = db;
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
                    DataSourceIdentifier = DataBaseIdentifier.ToString(),
                    DataBaseIdentifier = DataBaseIdentifier.ToString(),
                    Endpoint = Endpoint.ToString(),
                    ConnectString = ConnectString,
                    Identifier = Identifier.ToString(),
                    Strategy = Strategy,
                    TableName = TableName
                };
            }
            else
            {
                DataSourceIdentifier = new Guid(config.DataSourceIdentifier);
                DataBaseIdentifier = new Guid(config.DataBaseIdentifier);
                Endpoint = new Url(config.Endpoint);
                ConnectString = config.ConnectString;  
                Identifier = new Guid(config.Identifier);
                Strategy = config.Strategy;
                TableName = config.TableName;
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
