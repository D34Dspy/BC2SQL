using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class InspectController
    {
        private ExploreModel _model;
        public InspectController(ExploreModel model)
        {
            _model = model;
        }

        public void MakePropertyCurrent(int index)
        {
            _model.InspectPropertyIndex = index;
            _model.InspectProperty = _model.InspectDataType.Properties[index];
        }
    }
}
