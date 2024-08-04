using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class InspectController
    {
        private Model _model;
        public InspectController(Model model)
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
