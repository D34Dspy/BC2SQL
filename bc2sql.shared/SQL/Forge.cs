using bc2sql.shared.OData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

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
        public static Scheme CreateSchemeFromMetadata(string name, EntityType typeDef, string prefix = null)
        {
            if (typeDef == null)
                return null;
            if (prefix == null)
                prefix = string.Empty;
            if (name == null || name == string.Empty)
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

            var scheme = new Scheme(prefix + name);

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

        public static string CreateTable(string tableName, IEnumerable<FieldDef> fields)
        {
            return string.Format(
                "CREATE TABLE [{0}] (\n{1},\nPRIMARY KEY ( {2} )\n)",
                tableName,
                string.Join(",\n", fields.Select(fld => fld.ToString()).ToArray()),
                StringUtil.Join(", ", fields.Where(fld => fld.Key).Select(fld => "\"" + fld.Identifier + "\""))
            );
        }

        public static string CreateOrAlterTable(string tableName, IEnumerable<FieldDef> fields)
        {
            // TODO
            return CreateTable(tableName, fields);
        }

        public static string CreateTableIfNotExist(string tableName, IEnumerable<FieldDef> fields, bool tmp = false)
        {
            return string.Format("IF OBJECT_ID(N'{2}{0}', N'U') IS NULL BEGIN {1} END",
                tableName,
                CreateTable(tableName, fields),
                tmp ? "tempdb.." : string.Empty
                );
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

        public static string FormatColumns(IEnumerable<FieldDef> fields)
        {
            throw new NotImplementedException();
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

        public static string EnsureCollations(string tableName, IEnumerable<FieldDef> fieldDefs)
        {
            return StringUtil.Join("\n", fieldDefs.Where(fld => !fld.Key && fld.Collation().Length > 1).Select(fld => string.Format("ALTER TABLE [{0}] ALTER COLUMN {1} COLLATE {2};", tableName, fld.ToString(), fld.Collation())));
        }

        public static string FormatRow(IEnumerable<FieldDef> fieldDef, IEnumerable<object> dataset)
        {
            StringBuilder stringBuilder= new StringBuilder();
            var fld = fieldDef.GetEnumerator();
            var set = dataset.GetEnumerator();
            stringBuilder.Append("(");
            bool first = true;
            while(fld.MoveNext() && set.MoveNext())
            {
                if (first)
                    first = false;
                else if (fld.Current != null && set.Current != null)
                {
                    stringBuilder.Append(",");
                }
                else break;
                stringBuilder.Append(fld.Current.FormatValue(set.Current));
            }
            stringBuilder.AppendLine(")");
            return stringBuilder.ToString();
        }

        public static string InsertIntoValues(string tableName, IEnumerable<string> keys, IEnumerable<string> values)
        {
            return string.Format(
            "INSERT INTO [{0}] ( \"{1}\" ) VALUES {2}",
                tableName,
                StringUtil.Join("\", \"", keys),
                StringUtil.Join(",\n", values)
            );
        }

        public static string InsertFromValues(string tableName, IEnumerable<string> keys)
        {
            return string.Format(
            "INSERT ( \"{0}\" ) VALUES ({1})",
                StringUtil.Join("\", \"", keys),
                StringUtil.Join(",\n", keys.Select(key => string.Format("{0}.\"{1}\"", tableName, key)))
            );
        }

        public static string InsertValues(IEnumerable<string> keys, IEnumerable<string> values)
        {
            return string.Format(
            "INSERT ( {1} ) VALUES {2}",
                StringUtil.Join(", ", keys),
                StringUtil.Join(",\n", values)
            );
        }

        public static IEnumerable<string> FieldAssignments(
            string destinationName, IEnumerable<FieldDef> destinationFields,
            string sourceName, IEnumerable<FieldDef> sourceFields
            )
        {
            var dfld = destinationFields.GetEnumerator();
            var sfld = sourceFields.GetEnumerator();
            
            while(dfld.MoveNext() && sfld.MoveNext())
            {
                if(destinationName == null)
                {
                    yield return string.Format("\"{0}\" = {1}.\"{2}\"", dfld.Current.Identifier, sourceName, sfld.Current.Identifier);
                }
                else
                {
                    yield return string.Format("{0}.\"{1}\" = {2}.\"{3}\"", destinationName, dfld.Current.Identifier, sourceName, sfld.Current.Identifier);
                }
            }
        }

        public static string UpdateSetTransferFields(IEnumerable<FieldDef> destinationFields, string sourceAlias, IEnumerable<FieldDef> sourceFields)
        {
            return string.Format(
                "UPDATE SET\n\t{0}",
                StringUtil.Join(",\n\t", FieldAssignments(null, destinationFields, sourceAlias, sourceFields))
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

        public static string AssignRows(string sourceTableName, IEnumerable<FieldDef> sourceFields, 
            string destinationTableName, IEnumerable<FieldDef> destinationFields)
        {
            throw new NotImplementedException();
        }


        // public static string FormatMerge(string fromTableName, IEnumerable<FieldDef> fromFields, string toTableName, IEnumerable<FieldDef> toFields, string whereClause = null)
        // {
        //     var pkWhereClause = MatchWhereClause(
        //         fromFields.Where(field => field.Key), 
        //         toFields.Where(field => field.Key)
        //     );
        // 
        //     if(whereClause == null) 
        //         whereClause = string.Format("( {0} )", pkWhereClause);
        //     else whereClause = string.Format("( {0} ) AND ( {1} )", whereClause, pkWhereClause);
        // 
        //     return string.Format(
        //         "INSERT INTO [{0}] ( SELECT * FROM [{1}] WHERE ( {2} ) )",
        //         toTableName,
        //         fromTableName
        //     );
        // }

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

        public static string MigrateTable(EntityType previousType, EntityType newType, string destinationTable)
        {
            throw new NotImplementedException();
        }
        public static string RecursiveAllEqualkeys(string sourceAlias, string destAlias, string expr, IEnumerator<FieldDef> keys)
        {
            if(keys.MoveNext())
            {
                return Disjunction(
                    expr,
                    RecursiveAllEqualkeys(sourceAlias, destAlias, EqualFields(sourceAlias, keys.Current, destAlias), keys)
                    );
            }
            return expr;
        }

        public static string AllEqualkeys(string sourceAlias, string destAlias, IEnumerable<FieldDef> keys)
        {
            return RecursiveAllEqualkeys(sourceAlias, destAlias, null, keys.GetEnumerator());
        }

        public static string Between(string tableName, FieldDef fieldDef, object begin, object end) {
            return string.Format("{0}.\"{1}\" between {2}.\"{3}\"", tableName, fieldDef.Identifier, 
                fieldDef.FormatValue(begin), fieldDef.FormatValue(end));
        }

        public static string Equals(string tableName, FieldDef fieldDef, object val)
        {
            return string.Format("{0}.\"{1}\" = {2}", tableName, fieldDef.Identifier,
                fieldDef.FormatValue(val));
        }

        public static string EqualFields(string lhsTableName, FieldDef lhsField, string rhsTableName, FieldDef rhsField = null)
        {
            if (rhsField == null)
                rhsField = lhsField;
            return string.Format("{0}.\"{1}\" = {2}.\"{3}\"",
                lhsTableName, lhsField.Identifier,
                rhsTableName, rhsField.Identifier);
        }

        public static string GreaterFields(string lhsTableName, FieldDef lhsField, string rhsTableName, FieldDef rhsField = null)
        {
            if (rhsField == null)
                rhsField = lhsField;
            return string.Format("{0}.\"{1}\" > {2}.\"{3}\"",
                lhsTableName, lhsField.Identifier,
                rhsTableName, rhsField.Identifier);
        }

        public static string SmallerFields(string lhsTableName, FieldDef lhsField, string rhsTableName, FieldDef rhsField = null)
        {
            if (rhsField == null)
                rhsField = lhsField;
            return string.Format("{0}.\"{1}\" < {2}.\"{3}\"",
                lhsTableName, lhsField.Identifier,
                rhsTableName, rhsField.Identifier);
        }

        public static string Conjunction(string lhsSqlExpr, string rhsSqlExpr)
        {
            if (lhsSqlExpr == null && rhsSqlExpr != null)
                return rhsSqlExpr;
            if (rhsSqlExpr == null && lhsSqlExpr != null)
                return lhsSqlExpr;
            return string.Format("( {0} OR {1} )", lhsSqlExpr, rhsSqlExpr);
        }

        public static string Disjunction(string lhsSqlExpr, string rhsSqlExpr)
        {
            if (lhsSqlExpr == null && rhsSqlExpr != null)
                return rhsSqlExpr;
            if (rhsSqlExpr == null && lhsSqlExpr != null)
                return lhsSqlExpr;
            return string.Format("( {0} AND {1} )", lhsSqlExpr, rhsSqlExpr);
        }

        public static string Merge(
            string destinationTable,
            string sourceTable,
            string whereClause,
            string whenMatched = null,
            string whenNotMatchedBySource = null,
            string whenNotMatchedByDestination = null,
            string sourceAlias = null,
            string destinationAlias = null
            )
        {
            if (sourceAlias == null)
                sourceAlias = "BC2SQL_SRC";
            if (destinationAlias == null)
                destinationAlias = "BC2SQL_DST";

            /*
            MERGE 

                INTO <DestinationTable> AS BC2SQL_DST
                USING <SourceTable> AS BC2SQL_SRC
                ON <Matching Keys>

                    WHEN MATCHED THEN
                        UPDATE SET 

                    WHEN NOT MATCHED BY SOURCE THEN 
                        DELETE

                    WHEN NOT MATCHED BY TARGET THEN 
                        INSERT <DestinationFields> VALUES ( <SourceFields> )
            */
            var match = whenMatched != null ? "WHEN MATCHED THEN " + whenMatched : string.Empty;
            var noMatchBySrc = whenNotMatchedBySource != null ? "WHEN NOT MATCHED BY SOURCE THEN " + whenNotMatchedBySource : string.Empty;
            var noMatchByDst = whenNotMatchedByDestination != null ? "WHEN NOT MATCHED BY TARGET THEN " + whenNotMatchedByDestination : string.Empty;
            var lines = new string[]
            {
                "MERGE",
                "INTO [{0}] AS {1}",
                "USING [{2}] AS {3}",
                "ON {4}",
                "{5}",
                "{6}",
                "{7}",
                ";"
            };
            return string.Format(
                string.Join("\n    ", lines),
                destinationTable, destinationAlias,
                sourceTable, sourceAlias,
                whereClause,
                match,
                noMatchBySrc,
                noMatchByDst
            );
        }

        // public static string CreateManualMergeScript(
        //     ODataQuery query,
        //     EntityType type,
        //     string destinationTable,
        //     string prefix = "OData"
        //     )
        // {
        //     Scheme generatedScheme = CreateSchemeFromMetadata(null, type);
        // 
        //     string odataSourceTableName = "";
        //     string databaseTableName = "";
        // 
        //     var fieldDefs = AlterFieldDefsForMerge(generatedScheme.FieldDefinitions.GetEnumerator()).ToArray();
        // 
        //     string[] parts = new string[]
        //     {
        //         FormatSqlScriptPrefix(),
        //         CreateOrAlterTable(prefix + "_" + generatedScheme.Identifier, fieldDefs, true, out odataSourceTableName),
        //         InsertODataValues(query, odataSourceTableName, fieldDefs, AlterDatasetsForMerge),
        //         CreateOrAlterTable(generatedScheme.Identifier, fieldDefs, false, out databaseTableName),
        //         // FormatMerge(odataSourceTableName, databaseTableName, fieldDefs),
        //         string.Format("SELECT * INTO [{0}] FROM [{1}]",
        //             databaseTableName,
        //             odataSourceTableName
        //         ),
        //         DropTable(odataSourceTableName)
        //     };
        // 
        //     return string.Join("\n", parts);
        // }
    }
}
