﻿using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using bc2sql.shared.SQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bc2sql.scrape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edmx data = ODataForge.GetSchema(File.ReadAllText("C:\\Users\\god\\Desktop\\$metadata.xml"));

            // validate simple sets and types
            // foreach(var schema in data.Services.Schemas)
            // {
            //     if (schema.Containers == null)
            //         continue;
            //     if (schema.Defs == null)
            //         continue;
            //     foreach (var coll in schema.Containers)
            //     {
            //         if (coll.Sets == null)
            //             continue;
            //         foreach(var set in coll.Sets)
            //         {
            //             EntityType type = null;
            //             foreach(var def in schema.Defs)
            //             {
            //                 if(set.Type.Equals("NAV." + def.Name))
            //                 {
            //                     type = def;
            //                     break;
            //                 }
            //             }
            // 
            //             if(type == null)
            //             {
            //                 Console.WriteLine(string.Format("-- entity set \"{0}\" has no corresponding entity type", set.Name));
            //                 return;
            //             }
            //             else
            //             {
            //                 Console.WriteLine(string.Format("-- entity set \"{0}\" has entity type \"{1}\"", set.Name, type.Name));
            //             }
            //         }
            //     }
            // }
            // Console.ReadLine();
            // return;

            // /$metadata#Company('CRONUS%20UK%20Ltd.')
            var req = ODataQueryRequest.Create("http://desktop-4rot5j5:7048/BC140/ODataV4", "SalesOrder", new FormField[]
            {
                new FormField {
                    Key = "$company",
                    Value = "CRONUS%20UK%20Ltd."
                }
            });

            var query = req.GetResponse();

            var entityType = query.LookupMetadata(data);
            var datasets = query.MapDatasets(entityType);

            var sourceScheme = SqlForge.CreateSchemeFromMetadata(null, entityType, "#TMP");
            var srcAlias = "BC2SQL_SOURCE";

            var destinationScheme = SqlForge.CreateSchemeFromMetadata(null, entityType);
            var dstAlias = "BC2SQL_DESTINATION";

            var merge =
                new DataSetMerge()
                .WithSource(sourceScheme)
                .WithDestination(destinationScheme)
                .WithDatasets(sourceScheme.FormatDatasets(datasets))
                .WithAliases(srcAlias, dstAlias)
                .WithWhere(SqlForge.AllEqualkeys(srcAlias, dstAlias, sourceScheme.FieldDefinitions.Where(fld => fld.Key)))
                .Finalize();

            Console.WriteLine(merge);

            Console.ReadLine();

        }
    }
}
