using bc2sql.shared;
using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using bc2sql.shared.SQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace bc2sql.scrape
{
    internal class Program
    {
        static void Scrape(DataSourceConfig ds, DatabaseConfig db, ScraperConfig scr)
        {
            if (ds.AuthType == shared.Auth.Types.OAuth2 && !ds.FetchOAuth2())
            {
                Console.WriteLine("-- unable to acquire oauth2 access token");
                return;
            }

            var req = ODataQueryRequest.Create(ds.Endpoint, scr.Set.Name, scr.FormFields);
            var query = req.GetResponse();

            var datasets = query.MapDatasets(scr.Type);

            var sourceScheme = SqlForge.CreateSchemeFromMetadata(null, scr.Type, "#TMP");
            var srcAlias = scr.SourceAlias;

            var destinationScheme = SqlForge.CreateSchemeFromMetadata(scr.TableName, scr.Type);
            var dstAlias = scr.DestinationAlias;

            var merge =
                new DataSetMerge()
                .WithSource(sourceScheme)
                .WithDestination(destinationScheme)
                .WithDatasets(sourceScheme.FormatDatasets(datasets))
                .WithAliases(srcAlias, dstAlias)
                .WithWhere(SqlForge.AllEqualkeys(srcAlias, dstAlias, sourceScheme.FieldDefinitions.Where(fld => fld.Key)))
                .Finalize();

            Console.WriteLine(merge);

            using (var conn = new SqlConnection(db.ConnectString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(merge, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(String.Format("-- records affected: {0}", reader.RecordsAffected));
                    }
                }
            }
        }

        static void PromptEnd(CommandLine commandLine)
        {
            if(commandLine.PromptFinish)
            {
                Console.WriteLine("Press ENTER to exit!");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            string[] debug = new string[]
            {
                "",
                "scrape",
                "--keep-open",
                "--filename",
                "C:\\Users\\god\\Desktop\\bc2sql\\scraper\\bc2sql\\bc2sql.explore\\bin\\Debug\\Scrapers\\5105e50e-c912-4f4d-b787-ddd3d8fd4826\\bc2sql.scraper.xml",
            };
            CommandLine commandLine = new CommandLine(debug);
            //CommandLine commandLine = new CommandLine(args);
            if (commandLine.DryRun)
            {
                Console.WriteLine(string.Format("-- Args: {0}", string.Join(" ", args).ToString()));
                Console.WriteLine(string.Format("-- KeepOpen: {0}", commandLine.PromptFinish));
                Console.WriteLine(string.Format("-- RC: {0}", commandLine.RC));
                Console.WriteLine(string.Format("-- Filename: {0}", commandLine.Filename));
                Console.WriteLine(string.Format("-- DryRun: {0}", commandLine.DryRun));
            }
            if (commandLine.RC == RunConfig.None)
            {
                Console.WriteLine("-- No run config!");
                PromptEnd(commandLine);
                return;
            }
            try
            {
                if (commandLine.Filename == null || !File.Exists(commandLine.Filename))
                    throw new FileNotFoundException(commandLine.Filename);

                if (commandLine.RC == RunConfig.Scraper)
                {
                    if (commandLine.DryRun)
                        Console.WriteLine("-- Running Scraper");
                    ScraperConfig scraperConfig = new ScraperConfig();
                    WorkspaceUtil.Load(scraperConfig, commandLine.Filename);
                    DataSourceConfig dataSourceConfig = new DataSourceConfig();
                    WorkspaceUtil.Load(dataSourceConfig, scraperConfig.DataSourceOrigin);
                    DatabaseConfig databaseConfig = new DatabaseConfig();
                    WorkspaceUtil.Load(databaseConfig, scraperConfig.DatabaseOrigin);
                    Scrape(dataSourceConfig, databaseConfig, scraperConfig);
                }

                PromptEnd(commandLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                PromptEnd(commandLine);
                throw ex;
            }

            return;

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

            Console.WriteLine("-- the script has not been executed yet, just generated and printed");

            Console.ReadLine();

        }
    }
}
