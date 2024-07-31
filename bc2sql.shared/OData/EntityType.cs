using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    public class EntityType
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Key")]
        public Key[] Keys { get; set; }

        [XmlElement(ElementName = "Property")]
        public Property[] Properties { get; set; }

        [XmlElement(ElementName = "NavigationProperty")]
        public NavigationProperty[] NavProperties { get; set; }
    }
}
