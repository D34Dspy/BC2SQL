using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace bc2sql.shared.OData
{
    public class Filter
    {
        public Filter(string expression)
        {

        }

        public bool IsConstant
        {
            get
            {
                return Operation == FilterOperation.Constant;
            }
        }


        public string ConstantValue;

        public FilterOperation Operation;

        public Filter[] Operands;

        public static string OpToString(FilterOperation op)
        {
            switch (op)
            {
                case FilterOperation.Equals:
                    return "eq";
                case FilterOperation.NotEquals:
                    return "ne";
                case FilterOperation.Not:
                    return "not";
                case FilterOperation.In:
                    return "in";
                case FilterOperation.Has:
                    return "has";
                case FilterOperation.LessThan:
                    return "lt";
                case FilterOperation.GreaterThan:
                    return "gt";
                case FilterOperation.GreaterThanOrEqual:
                    return "ge";
                case FilterOperation.LessThanOrEqual:
                    return "le";
                case FilterOperation.And:
                    return "and";
                case FilterOperation.Or:
                    return "or";
                case FilterOperation.StartsWith:
                    return "startswith";
                case FilterOperation.EndsWith:
                    return "endswith";
                case FilterOperation.Contains:
                    return "startswith";
                case FilterOperation.Constant:
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
