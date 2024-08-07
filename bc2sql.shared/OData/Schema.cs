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

        [XmlElement(ElementName = "EntityContainer")]
        public EntityContainer[] Containers { get; set; }

        [XmlElement(ElementName = "ComplexType")]
        public ComplexType[] ComplexTypes { get; set; }

        public delegate T OnSelectSet<T>(EntitySet set, string nameSpace);
        public void SelectAllSets<T>(OnSelectSet<T> selector)
        {

        }
    }
}
