using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class LIBConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(LIBConfig));
        public Guid Identifier;
        public string Name;
        public BoundOrigin[] Scrapers;
        public Origin[] DataSources;
        public Origin[] Databases;
        public Origin[] Schedulers;
        public string ScrapeExe;
    }
}
