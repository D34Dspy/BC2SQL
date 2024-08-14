using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class BoundOrigin
    {
        public Binding[] Bindings;
        public string Filename;

        public Guid GetBinding(string key)
        {
            foreach(Binding binding in Bindings)
            {
                if(key.Equals(binding.Key)) 
                    return binding.Value;
            }
            throw new KeyNotFoundException(string.Format("key \"{0}\" not found", key));
        }
    }
}
