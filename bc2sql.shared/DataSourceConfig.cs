using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace bc2sql.shared
{
    public class DataSourceConfig : IWorkspace
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public Schema Metadata { get; set; }
        public List<FormField> Fields { get; set; }
        public Auth.Types AuthType { get; set; }
        public string OAuth2AccessTokenUrl { get; set; }
        public string OAuth2ClientID { get; set; }
        public string OAuth2ClientSecret { get; set; }
        public string OAuth2AccessToken { get; set; }
        public string OAuth2RefreshToken { get; set; }
        public string OAuth2IdentityToken { get; set; }
        public DateTime OAuth2ExpiresIn { get; set; }
        public string OAuth2Username { get; set; }
        public string OAuth2Password { get; set; }

        public string MetadataUrl {  
            get
            {
                var url = Endpoint.ToString();
                if (!url.EndsWith("/"))
                    url += "/";
                url += "$metadata";
                return url;
            } 
        }

        public string GetEntityUrl(EntityType type)
        {
            return MetadataUrl.Replace("$metadata", type.Name); // TODO create url from entity set rather than entity type...
        }

        public void FetchMetaData()
        {
            var req = WebRequest.Create(MetadataUrl);
            req.Method = "GET";
            req.ContentType = "application/xml";
            req.UseDefaultCredentials = true;
            req.Timeout = 10000;

            var resp = req.GetResponse();

            var s = new StreamReader(resp.GetResponseStream());
            Metadata = ODataForge.GetSchema(s.ReadToEnd()).Services.Schemas[0];
        }

        public bool FetchOAuth2()
        {
            if (AuthType != Auth.Types.OAuth2)
                return false;
            try
            {
                var tkn = Auth.OAuth2.GetToken(OAuth2AccessTokenUrl, OAuth2ClientID, OAuth2ClientSecret);

                OAuth2AccessToken = tkn.AccessToken;
                OAuth2RefreshToken = tkn.RefreshToken;
                OAuth2ExpiresIn = DateTime.Now.AddSeconds(tkn.ExpiresIn);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DSConfig Io(DSConfig config = null)
        {
            if (config == null)
            {
                config = new DSConfig()
                {
                    Identifier = Identifier,
                    Name = Name,
                    Description = Description,
                    Endpoint = Endpoint,
                    Metadata = Metadata,
                    AuthType = AuthType,
                    OAuth2AccessTokenUrl = OAuth2AccessTokenUrl,
                    OAuth2ClientID = OAuth2ClientID,
                    OAuth2ClientSecret = OAuth2ClientSecret,
                    OAuth2AccessToken= OAuth2AccessToken,
                    OAuth2RefreshToken = OAuth2RefreshToken,
                    OAuth2ExpiresIn = OAuth2ExpiresIn,
                    OAuth2Username = OAuth2Username,
                    OAuth2Password = OAuth2Password,
                    OAuth2IdentityToken = OAuth2IdentityToken,
                };
            }
            else
            {
                Identifier = config.Identifier;
                Name = config.Name; 
                Description = config.Description;
                Endpoint = config.Endpoint;
                Metadata = config.Metadata;
                AuthType = config.AuthType;
                OAuth2AccessTokenUrl = config.OAuth2AccessTokenUrl;
                OAuth2ClientID = config.OAuth2ClientID;
                OAuth2ClientSecret = config.OAuth2ClientSecret;
                OAuth2AccessToken = config.OAuth2AccessToken;
                OAuth2RefreshToken = config.OAuth2RefreshToken;
                OAuth2ExpiresIn = config.OAuth2ExpiresIn;
                OAuth2Username = config.OAuth2Username;
                OAuth2Password = config.OAuth2Password;
                OAuth2IdentityToken = config.OAuth2IdentityToken;
            }

            return config;
        }

        private string _origin;
        public string GetSource() { return Util.Serialize(DSConfig.gSerializer, Io(null)); }
        public void SetSource(string source) { Io((DSConfig)Util.Deserialize(DSConfig.gSerializer, source)); }
        public string GetStandardName() { return "bc2sql.datasource.xml"; }
        public string GetOrigin() { return _origin; }
        public void SetOrigin(string origin) { _origin = origin; }
        public object Clone() { return MemberwiseClone(); }
    }
}
