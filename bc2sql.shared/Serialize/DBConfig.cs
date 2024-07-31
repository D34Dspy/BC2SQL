using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class DBConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(DSConfig));
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConnectString { get; set; }
    }
}
