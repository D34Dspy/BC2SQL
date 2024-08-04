using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class DSConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(DSConfig));
        [XmlAttribute]
        public Guid Identifier { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        [XmlAttribute]
        public string Endpoint { get; set; }
        [XmlElement]
        public FormField[] FormFields { get; set; }
        [XmlElement]
        public Schema Metadata { get; set; }
    }
}
