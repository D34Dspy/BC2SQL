using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace bc2sql.shared.OData
{
    public class ODataQueryRequest
    {
        private WebRequest _webRequest;
        public string Entity;
        public string BaseUrl;
        public string TargetUrl;
        public bool IgnoreOdataFields;

        public delegate void CreateHook(WebRequest req);
        public static ODataQueryRequest Create(string url, string entity, FormField[] fields, bool ignoreOdataFields = false, int timeout = 10000, CreateHook hk = null)
        {
            var target = url;
            if(!target.EndsWith("/"))
                target += "/";
            target += entity;

            if(fields != null)
            {
                bool first = true;
                foreach(var field in fields)
                {
                    if(first)
                    {
                        target += string.Format("?{0}={1}", field.Key, field.Value);
                        first = false;
                    }
                    else
                        target += string.Format("&{0}={1}", field.Key, field.Value);
                }
            }

            var req = WebRequest.Create(target);
            // req.UseDefaultCredentials = true;
            req.Timeout = timeout;
            req.Method = "GET";

            if (hk != null)
                hk(req);

            return new ODataQueryRequest
            {
                _webRequest = req,
                Entity = entity,
                BaseUrl = url,
                TargetUrl = target,
                IgnoreOdataFields = ignoreOdataFields
            };
        }

        public ODataQuery GetResponse()
        {
            var response = _webRequest.GetResponse();
            return new ODataQuery(new StreamReader(response.GetResponseStream()), Entity, true, IgnoreOdataFields);
        }
    }
}
