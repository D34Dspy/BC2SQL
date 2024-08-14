using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared.OData
{
    public enum FilterOperation
    {
        Equals,
        NotEquals,
        Not,
        In,
        Has,
        LessThan,
        GreaterThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        And,
        Or,
        StartsWith,
        EndsWith,
        Contains,
        // not an operation
        Constant,
        Collection
    }
}
