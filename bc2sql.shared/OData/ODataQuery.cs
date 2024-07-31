using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace bc2sql.shared.OData
{
    public class ODataQuery
    {
        public string InferedEntity;
        public string Context;
        public ODataQueryColumn[] Columns;
        public object[][] Rows;

        void ExtractValueArray(JsonTextReader stream, bool annotateColumns = true, bool ignoreOdataFields = false)
        {
            int arrayDepth = 0;
            int objectDepth = 0;
            var columns = new List<ODataQueryColumn>();
            var row = new List<object>();
            var rows = new List<object[]>();
            var removeIndices = new int[0];

            bool recordColumns = annotateColumns;
            
            while (stream.Read())
            {
                if (arrayDepth < 0)
                    break;
                switch (stream.TokenType)
                {
                    case JsonToken.StartArray:
                        arrayDepth++;
                        break;
                    case JsonToken.EndArray:
                        arrayDepth--;
                        break;
                    case JsonToken.StartObject:
                        objectDepth++;
                        break;
                    case JsonToken.EndObject:
                        objectDepth--;
                        if(recordColumns)
                        {
                            if (ignoreOdataFields)
                                removeIndices = columns.FindAll(column => column.Identifier.Contains("@odata")).Select(col => columns.IndexOf(col)).ToArray();
                            recordColumns = false;
                        }
                        recordColumns = false;

                        foreach(var rem in removeIndices)
                        {
                            // TODO
                        }

                        rows.Add(row.ToArray());
                        row.Clear();
                        break;
                    default:
                        if(arrayDepth == 0 && objectDepth == 1)
                        {
                            switch (stream.TokenType)
                            {
                                case JsonToken.PropertyName:
                                    if (!recordColumns)
                                        break;
                                    var last = columns.Count > 0 ? columns.Last() : null;
                                    if (last != null && last.Type == null)
                                        last.Identifier = stream.Value.ToString();
                                    else
                                    {
                                        columns.Add(new ODataQueryColumn
                                        {
                                            Identifier = stream.Value.ToString(),
                                            Type = null
                                        });
                                    }
                                    break;
                                case JsonToken.String:
                                    if(recordColumns)
                                        columns.Last().Type = typeof(string);
                                    row.Add(stream.Value);
                                    break;
                                case JsonToken.Integer:
                                    if (recordColumns)
                                        columns.Last().Type = typeof(int);
                                    row.Add(stream.Value);
                                    break;
                                case JsonToken.Float:
                                    if (recordColumns)
                                        columns.Last().Type = typeof(float);
                                    row.Add(stream.Value);
                                    break;
                                case JsonToken.Date:
                                    if (recordColumns)
                                        columns.Last().Type = typeof(DateTime);
                                    row.Add(stream.Value);
                                    break;
                                case JsonToken.Boolean:
                                    if (recordColumns)
                                        columns.Last().Type = typeof(bool);
                                    row.Add(stream.Value);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                }
            }
            Columns = columns.ToArray();
            Rows = rows.ToArray();
        }

        public bool Validate()
        {
            return Context != null && Context.Contains(InferedEntity);
        }

        public EntityType Lookup(Edmx metadata)
        {
            foreach(var schema in metadata.Services.Schemas)
            {
                foreach(var type in schema.Defs)
                {
                    if (type.Name == InferedEntity) return type;
                }
            }
            throw new KeyNotFoundException(InferedEntity);
        }

        public ODataQuery(StreamReader reader, string inferedEntity, bool annotateColumns = true, bool ignoreOdataFields = false) 
        {

            InferedEntity = inferedEntity;

            var jsonStream = new JsonTextReader(reader);
            jsonStream.DateParseHandling = DateParseHandling.DateTime;
            jsonStream.DateTimeZoneHandling = DateTimeZoneHandling.Local;

            bool isArrayNext = false;
            bool isContextNext = false;

            while(jsonStream.Read())
            {
                switch (jsonStream.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch(jsonStream.Value.ToString())
                        {
                            case "@odata.context":
                                isContextNext = true;
                                break;
                            case "value":
                                isArrayNext = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    case JsonToken.String:
                        if(isContextNext)
                        {
                            Context = jsonStream.Value.ToString();
                            isContextNext = false;
                        }
                        break;
                    case JsonToken.StartArray:
                        if(isArrayNext)
                        {
                            ExtractValueArray(jsonStream, annotateColumns, ignoreOdataFields);
                            isArrayNext = false;
                        }
                        break;
                    default:
                        isContextNext = isArrayNext = false;
                        break;
                }
            }

        }
    }
}
