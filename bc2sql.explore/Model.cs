using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.explore
{
    internal class Model
    {
        public LibraryConfig LibraryConfig;
        public DataSourceConfig SelectedDataSource;
        public DatabaseConfig SelectedDatabase;
        public ScraperConfig SelectedScraper;
        public SchedulerConfig SelectedScheduler;

        public Model()
        {
            LibraryConfig = new LibraryConfig();

            if(0 != LibraryConfig.DataSources.Count)
                SelectedDataSource = LibraryConfig.DataSources[0];
        }
    }
}
