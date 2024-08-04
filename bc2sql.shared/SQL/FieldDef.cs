using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared.SQL
{
    public class FieldDef : ICloneable
    {
        public Type LanguageType;
        public string Identifier;
        public DataTypes DataType;
        public int Length;
        public bool Key;

        bool Fits(FieldDef other)
        {
            return DataType == other.DataType && Length < other.Length;
        }

        string FormatLen()
        {
            if (Length > 0)
                return string.Format("({0})", Length);
            return string.Empty;
        }

        string FormatDType()
        {
            switch (DataType)
            {
                case DataTypes.Int:
                    return "INT";
                case DataTypes.Float:
                    return "FLOAT";
                case DataTypes.Bool:
                    return "BIT";
                case DataTypes.VarChar:
                    return "VARCHAR";
                case DataTypes.Date:
                    return "DATE";
                case DataTypes.DateTime:
                    return "DATETIME";
                case DataTypes.DateTimeOffset:
                    return "DATETIME";
                default:
                    throw new NotImplementedException();
            }
        } 

        public override string ToString()
        {
            return string.Format(
                "\"{0}\" {1}{2}",
                Identifier,
                FormatDType(),
                FormatLen()
            );
        }

        public string FormatValue(object value)
        {
            switch(DataType)
            {
                // TODO:
                case DataTypes.Bool:
                    return (bool)value ? "1" : "0";
                case DataTypes.VarChar:
                    return "'" + value.ToString().Replace("'", "''") + "'";
                case DataTypes.DateTime:
                    return string.Format("'{0:yyyy-MM-dd hh:mm:ss}'", value);
                case DataTypes.Date:
                    return string.Format("'{0:yyyy-MM-dd}'", value);
                default:
                    return value.ToString();
            }
        }

        static Dictionary<string, DataTypes> dict = null;
        void InferSqlType(Type dtype, int len)
        {
            if(dict == null)
            {
                dict = new Dictionary<string, DataTypes>
                {
                    { "System.String", DataTypes.VarChar },
                    { "System.Boolean", DataTypes.Bool },
                    { "System.Single", DataTypes.Float },
                    { "System.Decimal", DataTypes.Float },
                    { "System.Int32", DataTypes.Int },
                    { "System.Date", DataTypes.DateTime },
                    { "System.DateTime", DataTypes.DateTime },
                    { "System.DateTimeOffset", DataTypes.DateTimeOffset }
                };
            }

            Length = len;
            LanguageType = dtype;
            DataType = dict[dtype.FullName];
        }

        public FieldDef(string name, Type type, int length = 0, bool PK = false)
        {
            Identifier = name;
            Length = length;
            Key = PK;
            InferSqlType(type, length);

            // Hack for option strings/enums
            if (DataType == DataTypes.VarChar && Length == 0)
                Length = 64;
        }

        public FieldDef(string name, DataTypes type, int length = 0, bool PK = false)
        {
            Identifier = name;
            Length = length;
            Key = PK;
            DataType = type;

            switch (type)
            {
                case DataTypes.Int:
                    LanguageType = typeof(int);
                    break;
                case DataTypes.Float:
                    LanguageType = typeof(float);
                    break;
                case DataTypes.VarChar:
                    LanguageType = typeof(string);
                    break;
                case DataTypes.Date:
                    LanguageType = typeof(DateTime);
                    break;
                case DataTypes.DateTime:
                    LanguageType = typeof(DateTime);
                    break;
                case DataTypes.DateTimeOffset:
                    LanguageType = typeof(DateTimeOffset);
                    break;
                case DataTypes.Bool:
                    LanguageType = typeof(bool);
                    break;
            }

            // Hack for option strings/enums
            if (DataType == DataTypes.VarChar && Length == 0)
                Length = 64;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
