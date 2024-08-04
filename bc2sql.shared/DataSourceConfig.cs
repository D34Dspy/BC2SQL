﻿using bc2sql.shared.OData;
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

        public DSConfig Io(DSConfig config = null)
        {
            if (config == null)
            {
                config = new DSConfig()
                {
                    Identifier = Identifier,
                    Name = Name,
                    Description= Description,
                    Endpoint = Endpoint,
                    Metadata = Metadata
                };
            }
            else
            {
                Identifier = config.Identifier;
                Name = config.Name; 
                Description = config.Description;
                Endpoint = config.Endpoint;
                Metadata = config.Metadata;
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
