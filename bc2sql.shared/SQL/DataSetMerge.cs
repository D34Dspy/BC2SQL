using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared.SQL
{
    public class DataSetMerge
    {
        private StringBuilder _builder;
        private Scheme _sourceScheme;
        private string _sourceAlias;

        private bool SourceTemporary { get { return _sourceScheme.Identifier.StartsWith("#"); } }
        private Scheme _destinationScheme;
        private string _destinationAlias;

        private bool _useGuidInsertModifyDate;
        private FieldDef _guid;
        private FieldDef _insertDate;
        private FieldDef _modifyDate;
        // for _useInsertModifyDate = false: use keys alternatively
        private string _matchCondition;

        private List<DataSetHook> _hooks;

        private IEnumerable<string> _datasets;

        private DateTime _date;

        public DataSetMerge(bool useInsertModifyDate = false)
        {
            _builder = new StringBuilder();
            _hooks = new List<DataSetHook>();
            _useGuidInsertModifyDate = useInsertModifyDate;
        }

        public delegate string DataSetHook(object[] dataset, 
            IEnumerable<FieldDef> metadata, out int skipDataset, out int fieldsToSkipDataset);

        public delegate string DataSetFormatter(object[] dataset);

        public DataSetMerge WithHook(DataSetHook hk)
        {
            _hooks.Add(hk);
            return this;
        }

        public DataSetMerge WithDate(DateTime date)
        {
            _date = date;
            return this;
        }

        public DataSetMerge WithOData(ODataQuery query, EntityType type, bool supressDestinationAssignment = true)
        {

            if(!supressDestinationAssignment)
            {

            }


            return this;
        }

        public DataSetMerge WithDatasets(IEnumerable<string> datasets)
        {
            _datasets = datasets;
            return this;
        }

        public DataSetMerge WithInsertModifyDates(FieldDef guid = null, FieldDef insertDate = null, FieldDef modifyDate = null)
        {
            _useGuidInsertModifyDate = true;
            _guid = guid;
            _insertDate = insertDate;
            _modifyDate = modifyDate;
            
            return WithWhere(
                SqlForge.Disjunction(
                    SqlForge.Conjunction(
                        SqlForge.GreaterFields(_sourceAlias, _modifyDate, _destinationAlias),
                        SqlForge.GreaterFields(_sourceAlias, _insertDate, _destinationAlias)
                        ),
                    SqlForge.EqualFields(_sourceAlias, _guid, _destinationAlias)
                    )
                );
        }

        public DataSetMerge WithDestination(Scheme scheme, string tableName = null)
        {
            _destinationScheme = scheme;
            if (tableName != null)
            {
                _destinationScheme = (Scheme)_destinationScheme.Clone();
                _destinationScheme.Identifier = tableName;
            }

            return this;
        }

        public DataSetMerge WithSource(Scheme scheme, string tableName = null)
        {
            _sourceScheme = scheme;
            if (tableName != null)
            {
                _sourceScheme = (Scheme)scheme.Clone();
                _sourceScheme.Identifier = scheme.Identifier.StartsWith("#") && !tableName.StartsWith("#") ? "#TMP_" : string.Empty + tableName;
            }
            return this;
        }

        public DataSetMerge WithWhere(string sqlExpression)
        {
            _matchCondition = sqlExpression;
            return this;
        }

        public DataSetMerge WithAliases(string source, string destination)
        {
            _sourceAlias = source;
            _destinationAlias = destination;
            return this;
        }

        private string CreateWhereClause()
        {
            if(_useGuidInsertModifyDate)
            {
                // var date = _date.ToShortDateString();
                return string.Format("{0}.{2} = {1}.{2} AND ({0}.{3} >= {1}.{3} OR {0}.{4} >= {1}.{4})",
                    _sourceAlias,
                    _destinationAlias,
                    _guid.Identifier,
                    _modifyDate.Identifier,
                    _insertDate.Identifier
                    );
            }
            else return _matchCondition;
        }
    
        public string Finalize()
        {
            // Create or alter source table
            _builder.AppendLine(
                SqlForge.CreateOrAlterTable(
                    _sourceScheme.Identifier,
                    _sourceScheme.FieldDefinitions
                    )
                );

            // Insert datasets into source table
            _builder.AppendLine(
                SqlForge.InsertIntoValues(
                    _sourceScheme.Identifier,
                    _sourceScheme.ColumnNames,
                    _datasets
                    )
                );

            // Merge datasets from source table into destination table
            _builder.AppendLine(SqlForge.Merge(
                    _destinationScheme.Identifier,
                    _sourceScheme.Identifier,
                    CreateWhereClause(),
                    SqlForge.UpdateSetTransferFields(_destinationScheme.FieldDefinitions, _sourceAlias, _sourceScheme.FieldDefinitions),
                    "DELETE",
                    SqlForge.InsertFromValues(_sourceAlias, _sourceScheme.ColumnNames),
                    _sourceAlias,
                    _destinationAlias
                    )
                );

            // Drop source table
            if(SourceTemporary)
            {
                _builder.AppendLine(
                    SqlForge.DropTable(
                        _sourceScheme.Identifier
                        )
                    );
            }

            return _builder.ToString();
        }
    }
}
