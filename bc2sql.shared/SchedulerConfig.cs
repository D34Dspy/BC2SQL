using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace bc2sql.shared
{
    public class SchedulerConfig : IWorkspace
    {
        public Guid Identifier { get; set; }

        public SCHConfig Io(SCHConfig config = null)
        {
            if (config == null)
            {
                config = new SCHConfig()
                {
                    Identifier = Identifier,
                };
            }
            else
            {
                Identifier = config.Identifier;
            }

            return config;
        }

        private string _origin;
        public string GetSource() { return Util.Serialize(SCHConfig.gSerializer, Io(null)); }
        public void SetSource(string source) { Io((SCHConfig)Util.Deserialize(SCHConfig.gSerializer, source)); }
        public string GetStandardName() { return "bc2sql.scheduler.xml"; }
        public string GetOrigin() { return _origin; }
        public void SetOrigin(string origin) { _origin = origin; }
        public object Clone() { return MemberwiseClone(); }
    }
}
