using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    [DebuggerDisplay("{Name,nq}")]
    public class EntityType
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Key")]
        public Key[] Keys { get; set; }

        [XmlElement(ElementName = "Property")]
        public Property[] Properties { get; set; }

        [XmlElement(ElementName = "NavigationProperty")]
        public NavigationProperty[] NavProperties { get; set; }
        public delegate T OnSelectKey<T>(Key k, PropertyRef r, Property p);
        public IEnumerable<T> SelectKeys<T>(OnSelectKey<T> selector)
        {
            foreach (var key in Keys)
                foreach (var propRef in key.PropertyRefs)
                    foreach (var property in Properties)
                        if (propRef.Name == property.Name)
                            yield return selector(key, propRef, property);
        }
        public IEnumerable<T> SelectKey<T>(Key k, OnSelectKey<T> selector)
        {
            foreach (var propRef in k.PropertyRefs)
                foreach (var property in Properties)
                    if (propRef.Name == property.Name)
                        yield return selector(k, propRef, property);
        }
    }
}
