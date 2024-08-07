using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore.Views
{
    internal class EntityTypeSetPair
    {
        public EntitySet Set;
        public EntityType Type;

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
        
        public EntityTypeSetPair[] Extract(Edmx metadata)
        {
            return Query(metadata).ToArray();
        }
    }
}
