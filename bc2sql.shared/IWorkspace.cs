using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared
{
    public interface IWorkspace : ICloneable
    {
        Guid Identifier { get; set; }
        string GetSource();
        string GetStandardName();
        void SetSource(string source);
        string GetOrigin();
        void SetOrigin(string origin);
    }
}
