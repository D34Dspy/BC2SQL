using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace bc2sql.shared.Serialize
{
    internal class Util
    {
        public static Stream InStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        public static Stream OutStream()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string Serialize(XmlSerializer xml, object s)
        {
            var o = OutStream();
            xml.Serialize(o, s);
            o.Position = 0;
            return new StreamReader(o).ReadToEnd();
        }

        public static object Deserialize(XmlSerializer xml, string s)
        {
            return xml.Deserialize(InStream(s));
        }
    }
}
