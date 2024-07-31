using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace bc2sql.shared.SQL
{
    public class Scheme : ICloneable
    {
        public IEnumerable<Type> ColumnTypes
        {
            get
            {
                return FieldDefinitions.Select((fld) => fld.LanguageType);
            }
        }
        public IEnumerable<DataTypes> ColumnSQLTypes
        {
            get
            {
                return FieldDefinitions.Select((fld) => fld.DataType);
            }
        }
        public IEnumerable<int> ColumnSizes
        {
            get
            {
                return FieldDefinitions.Select((fld) => fld.Length);
            }
        }
        public IEnumerable<string> ColumnNames
        {
            get
            {
                return FieldDefinitions.Select((fld) => fld.Identifier);
            }
        }

        public string Identifier;
        public List<FieldDef> FieldDefinitions;

        private static int SchemeCounter = 0;
        public Scheme(string id = null)
        {
            if (id == null)
                id = string.Format("BC2SQL_AutoGenTbl{0}", ++SchemeCounter);
            Identifier = id;
            FieldDefinitions = new List<FieldDef>();
        }

        public Scheme With(string name, Type type, int length = 0, bool PK = false)
        {
            FieldDefinitions.Add(new FieldDef(name, type, length, PK));
            return this;
        }

        public Scheme WithPK(string name, Type type, int length = 0)
        {
            return With(name, type, length, true);
        }

        public Scheme WithEx(string name, DataTypes type, int length = 0, bool PK = false)
        {
            FieldDefinitions.Add(new FieldDef(name, type, length, PK));
            return this;
        }

        public Scheme WithPKEx(string name, DataTypes type, int length = 0)
        {
            return WithEx(name, type, length, true);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
