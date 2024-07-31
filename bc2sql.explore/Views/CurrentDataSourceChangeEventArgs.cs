using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentDataSourceChangeEventArgs
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
    }
}
