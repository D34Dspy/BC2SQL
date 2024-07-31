using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class SCHConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(SCHConfig));
        public Guid Identifier { get; set; }
        public Origin Library { get; set; }
        public BoundOrigin[] Scrapers { get; set; }
    }
}
