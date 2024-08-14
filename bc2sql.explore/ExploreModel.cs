using bc2sql.shared;
using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.explore
{
    internal class ExploreModel
    {
        public LibraryConfig LibraryConfig;
        public DataSourceConfig SelectedDataSource;
        public DatabaseConfig SelectedDatabase;
        public ScraperConfig SelectedScraper;
        public SchedulerConfig SelectedScheduler;

        public int InspectIndex;
        public int InspectPropertyIndex;
        public string InspectEntityName;
        public string InspectSetName
        {
            get
            {
                if (InspectDataSet != null)
                    return InspectDataSet.Name;
                else return InspectDataType.Name;
            }
        }
        public DataSourceConfig InspectDataSource;
        public EntitySet InspectDataSet;
        public EntityType InspectDataType;
        public Property InspectProperty;

        public ExploreModel()
        {
            LibraryConfig = new LibraryConfig();

            if(0 != LibraryConfig.DataSources.Count)
                SelectedDataSource = LibraryConfig.DataSources[0];
        }
    }
}
