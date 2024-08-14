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
    public class SCRConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(SCRConfig));
        public Guid Identifier { get; set; }
        public Guid DataSourceIdentifier { get; set; }
        public Guid DataBaseIdentifier { get; set; }
        public string DataSourceOrigin { get; set; }
        public string DatabaseOrigin { get; set; }
        public EntityType Type { get; set; }
        public EntitySet Set { get; set; }
        public ScraperStrategy Strategy { get; set; }
        public string TableName { get; set; }
        public string MergeSourceAlias { get; set; }
        public string MergeDestinationAlias { get; set; }
    }
}
