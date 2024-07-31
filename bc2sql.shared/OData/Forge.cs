﻿using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace bc2sql.shared.OData
{
    public class ODataForge
    {
        public static Edmx GetSchema(string body)
        {
            // XmlNode node = xmlDoc.SelectSingleNode("//*[local-name()='YourNodeName']");
            return (Edmx)Util.Deserialize(new System.Xml.Serialization.XmlSerializer(typeof(Edmx)), body);
        }
    }
}
