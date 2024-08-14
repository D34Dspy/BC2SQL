using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace bc2sql.shared.Auth
{
    [DefaultValue(Key)]
    public enum OAuth2Type
    {
        Key,
        Implicit,
        ResourceOwnerPasswordCredentials,
        ClientCredentials,
    }
}
