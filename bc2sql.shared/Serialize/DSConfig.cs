using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    [Serializable]
    public class DSConfig
    {
        public static XmlSerializer gSerializer = new XmlSerializer(typeof(DSConfig));
        [XmlAttribute]
        public Guid Identifier { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        [XmlAttribute]
        public string Endpoint { get; set; }
        [XmlElement]
        public FormField[] FormFields { get; set; }
        [XmlElement]
        public Schema Metadata { get; set; }
        [XmlElement]
        public Auth.Types AuthType { get; set; }
        [XmlElement]
        public string OAuth2AccessTokenUrl { get; set; }
        [XmlElement]
        public string OAuth2ClientID { get; set; }
        [XmlElement]
        public string OAuth2ClientSecret { get; set; }
        [XmlElement]
        public string OAuth2AccessToken { get; set; }
        [XmlElement]
        public string OAuth2RefreshToken { get; set; }
        [XmlElement]
        public string OAuth2IdentityToken { get; set; }
        [XmlElement]
        public DateTime OAuth2ExpiresIn { get; set; }
        [XmlElement]
        public string OAuth2Username { get; set; }
        [XmlElement]
        public string OAuth2Password { get; set; }
    }
}
