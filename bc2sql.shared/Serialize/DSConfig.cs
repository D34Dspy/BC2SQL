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
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public FormField[] FormFields { get; set; }
        public string SourceCode { get; set; }
        public OData.Edmx Metadata { get; set; }
    }
}
