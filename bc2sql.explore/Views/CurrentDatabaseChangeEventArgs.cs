using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentDatabaseChangeEventArgs
    {
        public string Name;
        public string Description;
        public string ConnectString;
    }
}
