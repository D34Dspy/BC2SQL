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
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(SCHConfig));
        public string Identifier { get; set; }
        public string DataSourceIdentifier { get; set; }
        public string DataBaseIdentifier { get; set; }
        public string Endpoint { get; set; }
        public string ConnectString { get; set; }
        public ScraperStrategy Strategy { get; set; }
        public string TableName { get; set; }

    }
}
