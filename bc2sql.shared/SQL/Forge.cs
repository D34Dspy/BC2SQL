using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bc2sql.shared.SQL
{
    public class SqlForge
    {
        // public static Scheme CreateSchemeFromQuery(string name, ODataQuery query, ODataQueryColumn[] keys)
        // {
        //     if (query == null || query.Columns.Length == 0)
        //         return null;
        // 
        //     throw new NotImplementedException();
        // }
        // public static Scheme CreateSchemeFromQueryAndMetadata(string name, ODataQuery query, EntityType typeDef)
        // {
        //     if (query == null || query.Columns.Length == 0)
        //         return null;
        // 
        //     throw new NotImplementedException();
        // }
        public static Scheme CreateSchemeFromMetadata(string name, EntityType typeDef)
        {
            if (typeDef == null)
                return null;
            if (name == null)
                name = typeDef.Name;

            // var dict = new Dictionary<string, Type>();
            // dict.Add("Edm.String", typeof(string));
            // dict.Add("Edm.Boolean", typeof(bool));
            // dict.Add("Edm.Decimal", typeof(float));
            // dict.Add("Edm.Int32", typeof(int));
            // dict.Add("Edm.Date", typeof(DateTime));
            // dict.Add("Edm.DateTime", typeof(DateTime));
            // dict.Add("Edm.DateTimeOffset", typeof(DateTimeOffset));

            var dict = new Dictionary<string, DataTypes>();
            dict.Add("Edm.String", DataTypes.VarChar);
            dict.Add("Edm.Boolean", DataTypes.Bool);
            dict.Add("Edm.Decimal", DataTypes.Float);
            dict.Add("Edm.Int32", DataTypes.Int);
            dict.Add("Edm.Date", DataTypes.Date);
            dict.Add("Edm.DateTime", DataTypes.DateTime);
            dict.Add("Edm.DateTimeOffset", DataTypes.DateTimeOffset);

            var scheme = new Scheme(name);

            foreach (var prop in typeDef.Properties) {

                bool isKey = typeDef.Keys[0].PropertyRefs.Select(key => key.Name).Contains(prop.Name);

                scheme.WithEx(
                    prop.Name,
                    dict[prop.Type],
                    prop.MaxLength,
                    isKey
                );
            }

            return scheme;
        }

        public static string CreateTable(string tableName, IEnumerable<FieldDef> fields, bool temporary, out string targetTableName)
        {
            string identifier = tableName;
            if (temporary)
                identifier = "#TMP_" + identifier;
            targetTableName = identifier;
            return string.Format(
                "CREATE TABLE [{0}] (\n{1}\n)",
                identifier,
                string.Join(",\n", fields.Select(fld => fld.ToString()).ToArray())
            );
        }

        public static string CreateOrAlterTable(string tableName, IEnumerable<FieldDef> fields, bool temporary, out string targetTableName)
        {
            // TODO
            return CreateTable(tableName, fields, temporary, out targetTableName);
        }

        public delegate string DataSetInjector(object[] dataset, IEnumerable<FieldDef> metadata, out int skipDataset, out int fieldsToSkipDataset);

        public static string FormatODataSet(IEnumerable<ODataQueryColumn> columns, IEnumerable<FieldDef> fields, object[] dataset, DataSetInjector injector = null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Capacity = 2048;
            int end = dataset.Length - 1;

            builder.Append("( ");
            int fieldsToSkip = 0;
            int fieldsToSkipDataset = 0;
            if (injector != null)
                builder.Append(injector(dataset, fields, out fieldsToSkip, out fieldsToSkipDataset));

            var sep = dataset.Take(end);
            var last = dataset.Last();

            var fldEnum = fields.GetEnumerator();
            var ofldEnum = columns.GetEnumerator();


            if (!ofldEnum.MoveNext() || !fldEnum.MoveNext())
                throw new Exception("bug");

            while (fieldsToSkip > 0)
            {
                if (!ofldEnum.MoveNext())
                    throw new Exception("bug");
                while (ofldEnum.Current.Identifier.Contains("@odata"))
                    if (!ofldEnum.MoveNext())
                        throw new Exception("bug");
                if (!fldEnum.MoveNext())
                    throw new Exception("bug");
                fieldsToSkip--;
            }
            
            foreach (var elem in sep)
            {
                if(fieldsToSkipDataset > 0)
                {
                    fieldsToSkipDataset--;
                    continue;
                }
                if (ofldEnum.Current.Identifier.Contains("@odata"))
                    if (!ofldEnum.MoveNext())
                        continue;
                builder.Append(fldEnum.Current.FormatValue(elem)); 
                builder.Append(", ");
                if (!fldEnum.MoveNext() || !ofldEnum.MoveNext())
                    throw new Exception("bug");
            }
            builder.Append(fldEnum.Current.FormatValue(last));
            builder.Append(" )");

            return builder.ToString();
        }

        public static string InsertODataValues(ODataQuery query, string tableName, IEnumerable<FieldDef> fields, DataSetInjector injector = null)
        {

            var columns = fields.Select(fld => string.Format("[{0}]", fld.Identifier)).ToArray();
            var datasets = query.Rows.Select(dataset => FormatODataSet(query.Columns, fields, dataset, injector)).ToArray();

            return string.Format(
                "INSERT INTO [{0}] ( {1} ) VALUES {2}",
                tableName,
                string.Join(", ", columns),
                string.Join(",\n", datasets)
            );
        }

        public static string DropTable(string tableName)
        {
            return string.Format("DROP TABLE [{0}]", tableName);
        }

        public static string FormatSqlScriptPrefix()
        {
            return "-- AUTO GENERATED SQL SCRIPT FROM BC2SQL";
        }

        public static string TransferRows(string fromTableName, string toTableName, IEnumerable<FieldDef> fields)
        {
            throw new NotImplementedException();
        }

        public static string FormatMerge(string fromTableName, string toTableName, IEnumerable<FieldDef> fields)
        {
            return string.Format(
                "SELECT {0} FROM [{1}] "
            );
        }

        static IEnumerable<T> Combine<T>(System.Collections.IEnumerator first, IEnumerator<T> second)
        {
            while (first.MoveNext())
            {
                yield return (T)first.Current;
            }
            while (second.MoveNext())
            {
                yield return second.Current;
            }
        }

        public static IEnumerable<FieldDef> AlterFieldDefsForMerge(IEnumerator<FieldDef> fields)
        {
            FieldDef[] prefix = new FieldDef[] {
                new FieldDef("BC2SQL_QueryDate", typeof(DateTime), 0, true)
            };
            var prefix_iter = prefix.GetEnumerator();
            return Combine(prefix_iter, fields);
        }

        public static string AlterDatasetsForMerge(object[] dataset, IEnumerable<FieldDef> fields, out int skip, out int fieldsToSkipDataset)
        {
            skip = 1; // BC2SQL_Query
            fieldsToSkipDataset = 1; // HACK @odata.etag
            return string.Format(
                "{0}, ",
                fields.Take(1).Single().FormatValue(DateTime.Now)
            );
        }

        public static string CreateWindowedMergeScript(
            ODataQuery query,
            EntityType type,
            string destinationTable
            )
        {
            throw new NotImplementedException();
        }

        public static string CreateMergeScript(
            ODataQuery query,
            EntityType type,
            string destinationTable
            )
        {
            Scheme generatedScheme = CreateSchemeFromMetadata(null, type);

            string odataSourceTableName = "";
            string databaseTableName = "";

            var fieldDefs = AlterFieldDefsForMerge(generatedScheme.FieldDefinitions.GetEnumerator()).ToArray();

            string[] parts = new string[]
            {
                FormatSqlScriptPrefix(),
                CreateOrAlterTable(generatedScheme.Identifier, fieldDefs, true, out odataSourceTableName),
                InsertODataValues(query, odataSourceTableName, fieldDefs, AlterDatasetsForMerge),
                //CreateOrAlterTable(generatedScheme, false, out databaseTableName),
                //FormatMerge(odataSourceTableName, databaseTableName, fieldDefs)
                DropTable(odataSourceTableName)
            };

            return string.Join("\n", parts);
        }
    }
}
