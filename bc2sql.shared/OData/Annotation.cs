using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    public class Annotation
    {
        [XmlAttribute]
        public string Term { get; set; }

        [XmlAttribute("String")]
        public string Tag { get; set; }

        [XmlElement]
        public Annotation[] Annotations { get; set; }

        [XmlElement]
        public Record[] Records { get; set; }
    }
}
