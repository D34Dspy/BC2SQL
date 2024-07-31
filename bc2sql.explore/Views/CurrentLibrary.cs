using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentLibrary
    {
        public delegate void LibraryChangeHandler(object sender, string Filename, string ConfigExe, string ScrapeExe);
        public event LibraryChangeHandler OnChangeLibrary;

        Model _model;

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
                OnChangeLibrary(this, value, ConfiguratorExe, ScraperExe);
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

        [DescriptionAttribute("Filename of configurator executable"),
            CategoryAttribute("Executables")]
        public string ConfiguratorExe
        {
            get
            {
                return _model.LibraryConfig.ConfigureExe;
            }
            set
            {
                OnChangeLibrary(this, Filename, value, ScraperExe);
            }
        }

        [DescriptionAttribute("Filename of scraper executable"),
            CategoryAttribute("Executables")]
        public string ScraperExe
        {
            get
            {
                return _model.LibraryConfig.ScrapeExe;
            }
            set
            {
                OnChangeLibrary(this, Filename, ConfiguratorExe, value);
            }
        }

        public CurrentLibrary(Model model)
        {
            _model = model;
        }
    }
}
