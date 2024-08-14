using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class ScraperSettings
    {
        public delegate void ScraperChangeHandler(object sender, ScraperSettingsChangeEventArgs e);

        private SetupScraperModel _model;
        public ScraperSettings(SetupScraperModel model) { _model = model; }

        public event ScraperChangeHandler OnChangeScraper;

        [DescriptionAttribute("Source alias of table that is the input data for the merge"),
            DisplayName("Source Alias"),
            CategoryAttribute("Workspace")]
        public string SourceAlias
        {
            get
            {
                return _model.SourceAlias;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Destination alias of table that is the output data for the merge"),
            DisplayName("Destination Alias"),
            CategoryAttribute("Workspace")]
        public string DestinationAlias
        {
            get
            {
                return _model.DestinationAlias;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Table name of the output for the merge"),
            DisplayName("Table Name"),
            CategoryAttribute("Workspace")]
        public string TableName
        {
            get
            {
                return _model.TableName;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Whether or not to merge with windows"),
            DisplayName("Use Windowing"),
            CategoryAttribute("Workspace")]
        public bool UseWindowing
        {
            get
            {
                return _model.UseWindowing;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Amount of data sets to use in a window"),
            DisplayName("Data set amount"),
            CategoryAttribute("Workspace")]
        public int WindowDatasets
        {
            get
            {
                return _model.WindowingDatasets;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Percentage of data sets to use in a window"),
            DisplayName("Data set %"),
            CategoryAttribute("Workspace")]
        public float WindowPercentage
        {
            get
            {
                return _model.WindowingPercentage;
            }
            set
            {
                if (OnChangeScraper != null)
                    OnChangeScraper(this, new ScraperSettingsChangeEventArgs
                    {

                    });
            }
        }

        [DescriptionAttribute("Identifier of attached database"),
            DisplayName("GUID"),
            CategoryAttribute("Attached Database")]
        public Guid DatabaseIdentifier
        {
            get
            {
                return _model.Database.Identifier;
            }
        }
        [DescriptionAttribute("Name of attached database"),
            DisplayName("Database"),
            CategoryAttribute("Attached Database")]
        public string DatabaseName
        {
            get
            {
                return _model.Database.Name;
            }
        }
        [DescriptionAttribute("Connect string of attached database"),
            DisplayName("Connect string"),
            CategoryAttribute("Attached Database")]
        public string DatabaseConnectString
        {
            get
            {
                return _model.Database.ConnectString;
            }
        }
        [DescriptionAttribute("Filename of attached database (config)"),
            DisplayName("Filename"),
            CategoryAttribute("Attached Database")]
        public string DatabaseFilename
        {
            get
            {
                return _model.Database.GetOrigin();
            }
        }

        [DescriptionAttribute("Identifier of attached data source"),
            DisplayName("GUID"),
            CategoryAttribute("Attached Data Source")]
        public Guid DataSourceIdentifier
        {
            get
            {
                return _model.DataSource.Identifier;
            }
        }
        [DescriptionAttribute("Name of attached data source"),
            DisplayName("Name"),
            CategoryAttribute("Attached Data Source")]
        public string DataSourceName
        {
            get
            {
                return _model.DataSource.Name;
            }
        }
        [DescriptionAttribute("Filename of attached source (config)"),
            DisplayName("Filename"),
            CategoryAttribute("Attached Data Source")]
        public string DataSourceFilename
        {
            get
            {
                return _model.DataSource.GetOrigin();
            }
        }
    }
}
