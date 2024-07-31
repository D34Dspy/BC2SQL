using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bc2sql.shared
{
    internal class CommandLine
    {
        public delegate void OptionHandler(string key);
        public CommandLine(string[] args) {

            int pos = 0;

            Dictionary<string, RunConfig> pos0 = new Dictionary<string, RunConfig>();
            OptionHandler captureNext = null;

            foreach (string arg in args)
            {
                var larg = arg.ToLower();

                if(captureNext != null)
                {
                    captureNext = null;
                    continue;
                }

                if (arg.StartsWith("-"))
                {
                    if (larg.Equals("--configure"))
                        Configure = true;
                    else if (larg.Equals("--filename"))
                        captureNext = (string key) => Filename = key;
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
        public bool Configure { get; private set; }
        public string Filename { get; private set; }
    }
}
