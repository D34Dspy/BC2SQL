using bc2sql.shared.Serialize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace bc2sql.shared
{
    public class LibraryConfig : IWorkspace
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }

        public List<SchedulerConfig> Schedulers { get { return _schedulers; } }
        private List<SchedulerConfig> _schedulers;

        public List<ScraperConfig> Scrapers { get { return _scrapers; } }
        private List<ScraperConfig> _scrapers;

        public List<DataSourceConfig> DataSources { get { return _dataSources; } }
        private List<DataSourceConfig> _dataSources;

        public List<DatabaseConfig> Databases { get { return _databases; } }
        private List<DatabaseConfig> _databases;

        public string ScrapeExe { get; set; }

        public LibraryConfig()
        {
            _schedulers = new List<SchedulerConfig>();
            _scrapers = new List<ScraperConfig>();
            _dataSources = new List<DataSourceConfig>();
            _databases = new List<DatabaseConfig>();
        }

        public DataSourceConfig GetDataSourceById(Guid guid)
        {
            foreach (var datasource in DataSources)
            {
                if (datasource.Identifier == guid)
                {
                    return datasource;
                }
            }
            throw new KeyNotFoundException(string.Format("data source \"{0}\" not found", guid.ToString()));
        }

        public DatabaseConfig GetDatabaseById(Guid guid)
        {
            foreach (var database in Databases)
            {
                if (database.Identifier == guid)
                {
                    return database;
                }
            }
            throw new KeyNotFoundException(string.Format("database \"{0}\" not found", guid.ToString()));
        }

        public LIBConfig Io(LIBConfig config = null)
        {
            if (config == null)
            {
                config = new LIBConfig();

                // Properties
                config.Identifier = Identifier;
                config.ScrapeExe = ScrapeExe;
                config.Name = Name;

                // Collections
                config.DataSources = DataSources.Select(dataSource =>
                    new Origin { Filename = dataSource.GetOrigin() }).ToArray();
                config.Schedulers = Schedulers.Select(scheduler =>
                    new Origin { Filename = scheduler.GetOrigin() }).ToArray();
                config.Databases = Databases.Select(database =>
                    new Origin { Filename = database.GetOrigin() }).ToArray();
                config.Scrapers = Scrapers.Select(scraper =>
                {
                    return new BoundOrigin()
                    {
                        Filename = scraper.GetOrigin(),
                        Bindings = new Binding[] {
                            new Binding { Key = "DataSource", Value = scraper.DataSourceIdentifier },
                            new Binding { Key = "Database", Value = scraper.DataBaseIdentifier }
                        }
                    };
                }).ToArray();
            }
            else
            {
                // Properties
                Identifier = config.Identifier;
                ScrapeExe = config.ScrapeExe;
                Name = config.Name;

                // Collections
                _schedulers = new List<SchedulerConfig>();
                _schedulers.AddRange(config.Schedulers.Select(scheduler =>
                {
                    var deserialized = new SchedulerConfig();
                    deserialized.SetOrigin(scheduler.Filename);
                    deserialized.SetSource(File.ReadAllText(scheduler.Filename));
                    return deserialized;
                }));

                _dataSources = new List<DataSourceConfig>();
                _dataSources.AddRange(config.DataSources.Select(dataSource =>
                {
                    var deserialized = new DataSourceConfig();
                    deserialized.SetOrigin(dataSource.Filename);
                    deserialized.SetSource(File.ReadAllText(dataSource.Filename));
                    return deserialized;
                }));

                _databases = new List<DatabaseConfig>();
                _databases.AddRange(config.Databases.Select(dataSource =>
                {
                    var deserialized = new DatabaseConfig();
                    deserialized.SetOrigin(dataSource.Filename);
                    deserialized.SetSource(File.ReadAllText(dataSource.Filename));
                    return deserialized;
                }));

                _scrapers = new List<ScraperConfig>();
                _scrapers.AddRange(config.Scrapers.Select(scraper =>
                {
                    var deserialized = new ScraperConfig();
                    deserialized.SetOrigin(scraper.Filename);
                    deserialized.SetSource(File.ReadAllText(scraper.Filename));
                    deserialized.Bind(
                        GetDataSourceById(scraper.GetBinding("DataSource")),
                        GetDatabaseById(scraper.GetBinding("Database"))
                        );
                    return deserialized;
                }));

            }

            return config;
        }

        private string _origin;
        public string GetSource() { return Util.Serialize(LIBConfig.gSerializer, Io(null)); }
        public void SetSource(string source) { Io((LIBConfig)Util.Deserialize(LIBConfig.gSerializer, source)); }
        public string GetStandardName() { return "bc2sql.library.xml"; }
        public string GetOrigin() { return _origin; }
        public void SetOrigin(string origin) { _origin = origin; }

        public string GetWorkspace()
        {
            return Path.GetDirectoryName(GetOrigin());
        }
        public string GetDatabases()
        {
            return Path.Combine(GetWorkspace(), "Databases");
        }
        public string GetDataSources()
        {
            return Path.Combine(GetWorkspace(), "DataSources");
        }
        public string GetSchedulers()
        {
            return Path.Combine(GetWorkspace(), "Schedulers");
        }
        public string GetScrapers()
        {
            return Path.Combine(GetWorkspace(), "Scrapers");
        }
    
        public Process Join(string filename, string[] args, bool dry = false)
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo(filename, string.Join(" ", args));
            return dry || proc.Start() ? proc : throw new Exception("Unable to start process");
        }
        public Process RunScraper(ScraperConfig config, bool keepOpen = false, bool dry = false)
        {
            return keepOpen 
                ? Join(
                    ScrapeExe,
                    new string[]
                    {
                        ScrapeExe,
                        "scrape",
                        "--keep-open",
                        "--filename",
                        string.Format("\"{0}\"", config.GetOrigin())
                    },
                    dry) 
                : Join(
                    ScrapeExe,
                    new string[]
                    {
                        ScrapeExe,
                        "scrape",
                        "--filename",
                        string.Format("\"{0}\"", config.GetOrigin())
                    },
                    dry
            );
        }
        public Process RunScheduler(SchedulerConfig config)
        {
            return Join(
                ScrapeExe,
                new string[]
                {
                    "schedule",
                    "--filename",
                    string.Format("\"{0}\"", config.GetSource())
                }
            );
        }
        public object Clone() { return MemberwiseClone(); }
    }
}
