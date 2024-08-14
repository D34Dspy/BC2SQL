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
    public class EntityContainer
    {
        [XmlAttribute]
        public string Name;

        [XmlElement(ElementName = "EntitySet")]
        public EntitySet[] Sets;
    }
}
