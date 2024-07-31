using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bc2sql.shared
{
    public class WorkspaceUtil
    {
        public static void Save(IWorkspace ws)
        {
            File.WriteAllText(ws.GetOrigin(), ws.GetSource());
        }
        public static void Load(IWorkspace ws, string filename = null)
        {
            if (filename == null)
                filename = ws.GetOrigin();
            ws.SetSource(File.ReadAllText(filename));
            ws.SetOrigin(filename);
        }
        public static void Delete<T>(T data, IList<T> collection)
        {
            var ws = (IWorkspace)data;
            collection.Remove(data);
            File.Delete(ws.GetOrigin());
        }
    }
}
