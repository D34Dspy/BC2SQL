using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    public class Key
    {
        [XmlElement(ElementName = "PropertyRef")]
        public PropertyRef[] PropertyRefs;
    }
}
