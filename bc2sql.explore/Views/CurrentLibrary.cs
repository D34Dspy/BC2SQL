using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentLibrary
    {
        public delegate void LibraryChangeHandler(object sender, string Filename, string ScrapeExe);
        public event LibraryChangeHandler OnChangeLibrary;

        ExploreModel _model;

        [DescriptionAttribute("Filename of current library"),
            CategoryAttribute("Workspace")]
        public string Filename
        {
            get
            {
                return _model.LibraryConfig.GetOrigin();
            }
            set
            {
                OnChangeLibrary(this, value, ScraperExe);
            }
        }

        [Browsable(false)]
        public string Source
        {
            get
            {
                return _model.LibraryConfig.GetSource();
            }
        }

        [DescriptionAttribute("Filename of scraper executable"),
            CategoryAttribute("Executable(s)")]
        public string ScraperExe
        {
            get
            {
                return _model.LibraryConfig.ScrapeExe;
            }
            set
            {
                OnChangeLibrary(this, Filename, value);
            }
        }

        public CurrentLibrary(ExploreModel model)
        {
            _model = model;
        }
    }
}
