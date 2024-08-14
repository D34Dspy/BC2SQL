using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class CurrentScraper
    {
        public delegate void LibraryChangeHandler(object sender, string Filename, string ScrapeExe);
        public event LibraryChangeHandler OnChangeLibrary;

        ExploreModel _model;
        public CurrentScraper(ExploreModel model)
        {
            _model = model;
        }

        [DescriptionAttribute("Filename of current scraper"),
            CategoryAttribute("Workspace")]
        public string Filename
        {
            get
            {
                return _model.SelectedScraper.GetOrigin();
            }
        }
    }
}
