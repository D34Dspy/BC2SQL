﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    public class EnumMember
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
