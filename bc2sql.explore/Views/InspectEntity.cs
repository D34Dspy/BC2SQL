using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class InspectEntity
    {
        private Model _model;

        public string ODataUrl
        {
            get
            {
                return _model.InspectDataSource.GetEntityUrl(_model.InspectDataType); 
            }
        }

        public InspectEntity(Model model)
        {
            _model = model;
        }
    }
}
