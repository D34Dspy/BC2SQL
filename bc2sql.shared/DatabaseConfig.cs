using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace bc2sql.shared
{
    public class DatabaseConfig : IWorkspace
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConnectString { get; set; }

        public DBConfig Io(DBConfig config = null)
        {
            if (config == null)
            {
                config = new DBConfig()
                {
                    Identifier = Identifier,
                    Name = Name,
                    Description = Description,
                    ConnectString = ConnectString
                };
            }
            else
            {
                Identifier = config.Identifier;
                Name = config.Name;
                Description = config.Description;
                ConnectString = config.ConnectString;
            }

            return config;
        }

        private string _origin;
        public string GetSource() { return Util.Serialize(DBConfig.gSerializer, Io(null)); }
        public void SetSource(string source) { Io((DBConfig)Util.Deserialize(DBConfig.gSerializer, source)); }
        public string GetStandardName() { return "bc2sql.database.xml"; }
        public string GetOrigin() { return _origin; }
        public void SetOrigin(string origin) { _origin = origin; }
        public object Clone() { return MemberwiseClone(); }
    }
}
