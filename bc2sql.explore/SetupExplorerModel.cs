using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class SetupExplorerModel
    {
        public ExplorerConfig ExplorerConfig;

        public SetupExplorerModel()
        {
            ExplorerConfig = new ExplorerConfig();
            
        }
    }
}
