using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using bc2sql.shared;

namespace bc2sql.explore.Controllers
{
    internal class LibraryConfiguration
    {
        public delegate void LibraryChangedHandler(object sender, string source);

        public event LibraryChangedHandler OnLibraryChanged;

        private string _filename;
        public string Filename { 
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnLibraryChanged(this, value);
            }
        }

        public LibraryConfiguration()
        {
            _filename = string.Empty;
        }
    }
}
