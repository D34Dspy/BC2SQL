using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace bc2sql.shared
{
    public class CommandLine
    {
        public delegate void OptionHandler(string key);
        public CommandLine(string[] args) {

            int pos = 0;

            Dictionary<string, RunConfig> pos0 = new Dictionary<string, RunConfig>
            {
                { "scrape", RunConfig.Scraper }
            };
            OptionHandler captureNext = null;

            foreach (string arg in args.Skip(1))
            {
                Console.WriteLine("-- param " + arg);
                var larg = arg.ToLower();

                if(captureNext != null)
                {
                    captureNext(arg);
                    captureNext = null;
                    continue;
                }


                if (arg.StartsWith("-"))
                {
                    if (larg.Equals("--filename"))
                        captureNext = (string key) => Filename = key;
                    else if (larg.Equals("--prompt-finish") || larg.Equals("--keep-open"))
                        PromptFinish = true;
                    else if (larg.Equals("--dry-run"))
                        DryRun = true;
                }
                else
                {
                    switch(pos++)
                    {
                        case 0:
                            RC = pos0[larg];
                            break;
                        default:
                            throw new KeyNotFoundException(string.Format("Positional argument #{0} \"{1}\" is not supported!", pos, arg));
                    }
                }
            }
        }

        public RunConfig RC { get; private set; }
        public string Filename { get; private set; }
        public bool DryRun { get; private set; }
        public bool PromptFinish { get; private set; }
    }
}
