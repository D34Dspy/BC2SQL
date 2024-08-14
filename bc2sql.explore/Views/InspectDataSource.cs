using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class InspectDataSource
    {
        private ExploreModel _model;

        public string Name
        {
            get
            {
                return _model.InspectDataSource.Name;
            }
        }

        public string Description
        {
            get
            {
                return _model.InspectDataSource.Description;
            }
        }

        public string Endpoint
        {
            get
            {
                return _model.InspectDataSource.Endpoint;
            }
        }

        public string Metadata
        {
            get
            {
                return _model.InspectDataSource.MetadataUrl;
            }
        }

        public string Guid
        {
            get
            {
                return _model.InspectDataSource.Identifier.ToString();
            }
        }

        public InspectDataSource(ExploreModel model)
        {
            _model = model;
        }
    }
}
