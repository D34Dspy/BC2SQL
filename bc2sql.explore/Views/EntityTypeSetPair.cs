using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    [DefaultValue(null)]
    internal class EntityTypeSetPair
    {
        public EntitySet Set;
        public EntityType Type;

        public string SetName
        {
            get
            {
                return Set.Name;
            }
        }

        public string TypeName
        {
            get
            {
                return Set.Name;
            }
        }

        IEnumerable<EntityTypeSetPair> Query(Edmx metadata)
        {
            foreach (var schema in metadata.Services.Schemas)
                foreach (var container in schema.Containers)
                    foreach (var set in container.Sets)
                        foreach (var def in schema.Defs)
                            if (set.Type.StartsWith(schema.Namespace))
                                if (set.Type.Substring(schema.Namespace.Length).Equals(def.Name))
                                    yield return new EntityTypeSetPair
                                    {
                                        Set = set,
                                        Type = def
                                    };
        }

        public static EntityTypeSetPair ElementAt(EntityTypeSetPair[] pairs, EntityType type)
        {
            return pairs.FirstOrDefault(pair => pair.Type.Equals(type));
        }

        public static EntityTypeSetPair ElementAt(EntityTypeSetPair[] pairs, EntitySet set)
        {
            return pairs.SingleOrDefault(pair => pair.Set.Equals(set));
        }

        public EntityTypeSetPair[] Extract(Edmx metadata)
        {
            return Query(metadata).ToArray();
        }
    }
}
