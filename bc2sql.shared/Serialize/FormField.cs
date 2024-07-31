using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class FormField
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
