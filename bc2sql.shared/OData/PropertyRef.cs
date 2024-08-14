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
    public class PropertyRef
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
