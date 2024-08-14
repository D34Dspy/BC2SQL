using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.OData
{
    [Serializable]
    [DebuggerDisplay("{Namespace,nq}")]
    public class Schema
    {
        [XmlAttribute]
        public string Namespace { get; set; }

        [XmlElement(ElementName = "EnumType")]
        public EnumType[] Enums { get; set; }

        [XmlElement(ElementName = "EntityType")]
        public EntityType[] Defs { get; set; }

        [XmlElement(ElementName = "EntityContainer")]
        public EntityContainer[] Containers { get; set; }

        [XmlElement(ElementName = "ComplexType")]
        public ComplexType[] ComplexTypes { get; set; }
        public EntityType Find(EntitySet set)
        {
            if (Containers == null)
                throw new KeyNotFoundException();
            foreach(var def in Defs)
            {
                var namespaceMember = string.Format("{0}.{1}", Namespace, def.Name);
                if (namespaceMember.Equals(set.Type))
                    return def;
            }
            throw new KeyNotFoundException();
        }
        public EntitySet Find(EntityType type)
        {
            if (Containers == null)
                throw new KeyNotFoundException();
            var namespaceMember = string.Format("{0}.{1}", Namespace, type.Name);
            foreach (var container in Containers)
            {
                var nameSpace = container.Name;
                if (nameSpace != Namespace)
                    continue;
                foreach (var set in container.Sets)
                    if (namespaceMember.Equals(set.Type))
                        return set;
            }
            throw new KeyNotFoundException();
        }
        public delegate T OnSelectSet<T>(EntitySet set);
        public delegate T OnSelectTypeSet<T>(EntityType type, EntitySet set, string nameSpace);
        public IEnumerable<T> SelectSets<T>(OnSelectSet<T> selector)
        {
            if (Containers != null)
            {
                foreach (var container in Containers)
                {
                    var nameSpace = container.Name;
                    if (nameSpace != Namespace)
                        continue;
                    foreach (var set in container.Sets)
                        yield return selector(set);
                }
            }
        }
        public IEnumerable<T> SelectSetsAndTypes<T>(OnSelectTypeSet<T> selector)
        {
            if (Containers != null)
            {
                foreach (var container in Containers)
                {
                    var nameSpace = container.Name;
                    if (nameSpace != Namespace)
                        continue;
                    foreach (var set in container.Sets)
                    {
                        foreach (var def in Defs)
                        {
                            var namespaceMember = string.Format("{0}.{1}", Namespace, def.Name);
                            if (namespaceMember.Equals(set.Type))
                                yield return selector(def, set, nameSpace);
                        }
                    }
                }
            }
        }
    }
}
