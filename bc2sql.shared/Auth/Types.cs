using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bc2sql.shared.Auth
{
    [DefaultValue(None)]
    public enum Types
    {
        None,
        WindowsUser,
        OAuth2
    }
}
