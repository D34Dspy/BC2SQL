using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class InspectProperty
    {
        private Model _model;

        [DescriptionAttribute("Name of current property / field / column..."),
            CategoryAttribute("Property")]
        public string Name
        {
            get
            {
                return _model.InspectProperty.Name;
            }
        }

        [DescriptionAttribute("Type of current property"),
            CategoryAttribute("Property")]
        public string Type
        {
            get
            {
                return _model.InspectProperty.Type; ;
            }
        }

        [DescriptionAttribute("Whether or not current property can be NULL"),
            CategoryAttribute("Property")]
        public bool Nullable
        {
            get
            {
                return _model.InspectProperty.Nullable; ;
            }
        }

        [DescriptionAttribute("Length of current property"),
            CategoryAttribute("Property")]
        public int MaxLength
        {
            get
            {
                return _model.InspectProperty.MaxLength;
            }
        }

        public InspectProperty(Model model)
        {
            _model = model;
        }
    }
}
