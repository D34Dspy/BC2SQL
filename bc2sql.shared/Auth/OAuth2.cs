using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace bc2sql.shared.Auth
{
    internal class OAuth2
    {
        public static OAuth2Token GetToken(string tokenAddr, string clientId, string clientSecret, string grantType = "client_credentials", int timeout = 5000)
        {
            string addr = string.Format("{0}?grant_type={1}&client_id={2}&client_secret={3}", 
                tokenAddr, grantType, clientId, clientSecret);

            var req = WebRequest.Create(addr);
            req.UseDefaultCredentials = true;
            req.Timeout = timeout;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            var res = req.GetResponse();
            var body = res.GetResponseStream();
            var reader = new StreamReader(body);
            var tkn = JsonConvert.DeserializeObject<OAuth2Token>(reader.ReadToEnd());
            return tkn;
        }
    }
}
