using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    public class Schema
    {
        [XmlAttribute]
        public string Namespace { get; set; }

        [XmlElement(ElementName = "EnumType")]
        public EnumType[] Enums { get; set; }

        [XmlElement(ElementName = "EntityType")]
        public EntityType[] Defs { get; set; }

        [XmlElement(ElementName = "EntitySet")]
        public EntitySet[] Sets { get; set; }

        [XmlElement(ElementName = "ComplexType")]
        public ComplexType[] ComplexTypes { get; set; }
    }
}
