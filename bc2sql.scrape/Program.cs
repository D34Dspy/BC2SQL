using bc2sql.shared.OData;
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

            // /$metadata#Company('CRONUS%20UK%20Ltd.')
            var req = ODataQueryRequest.Create("http://desktop-4rot5j5:7048/BC140/ODataV4", "SalesOrder", new FormField[]
            {
                new FormField {
                    Key = "$company",
                    Value = "CRONUS%20UK%20Ltd."
                }
            });

            var resp = req.GetResponse();

            Console.WriteLine("-- OData context: " + resp.Context);
            Console.WriteLine("-- OData query good: " + resp.Validate());

            var firstRow = resp.Columns.Zip(resp.Rows[0], (column, cell) => string.Format(
                "-- OData Field {0} \"{1}\" = {2};",
                column.Type.ToString(),
                column.Identifier,
                cell
                ));

            Console.WriteLine(string.Join("\n", firstRow));

            var entityType = resp.Lookup(data);

            Console.WriteLine(SqlForge.CreateMergeScript(resp, entityType, "HelloWorld"));

            Console.ReadLine();
        }
    }
}
