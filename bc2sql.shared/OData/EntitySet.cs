using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    [DebuggerDisplay("{Name,nq}")]
    public class EntitySet
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "EntityType")]
        public string Type { get; set; }

        [XmlElement]
        public Annotation[] Annotations { get; set; }
    }
}
