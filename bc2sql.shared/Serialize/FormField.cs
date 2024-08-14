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
        public static FormField Create(string Key, string Value)
        {
            var ff = new FormField();
            ff.Key = Key;
            ff.Value = Value;
            return ff;
        }
        public override string ToString()
        {
            return string.Format("{0}={1}", Key, Value);
        }
    }
}
