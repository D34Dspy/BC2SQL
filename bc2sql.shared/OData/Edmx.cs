﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable, XmlRoot(Namespace = "http://docs.oasis-open.org/odata/ns/edmx")]
    public class Edmx
    {
        [XmlElement(ElementName = "DataServices")]
        public DataServices Services { get; set; }
    }
}
