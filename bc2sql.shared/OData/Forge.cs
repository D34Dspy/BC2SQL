using bc2sql.shared.Serialize;
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

        public delegate void OnCreateFormField(FormField ff);
        public static void CreateOrAlterODataDistinction(string odataExpression, IEnumerable<FormField> ffs, OnCreateFormField cff)
        {
            foreach (var ff in ffs)
            {
                if(ff.Key == "filter")
                {
                    ff.Value = string.Format("{0} and {1}", odataExpression);
                }
            }
        }
    }
}
