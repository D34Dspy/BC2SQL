using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    [DebuggerDisplay("{Debugger,nq}")]
    public class Property
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public bool Nullable { get; set; }
        [XmlAttribute]
        public int MaxLength { get; set; }
        [XmlElement]
        public Property[] Properties { get;set; }

        private string Debugger
        {
            get
            {
                return string.Format("({0}) {1} {2} [{3}]", Nullable ? "maybenull" : "notnull", Type, Name, MaxLength);
            }
        }
    }
}
