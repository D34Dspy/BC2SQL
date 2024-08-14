using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bc2sql.shared
{
    public class WorkspaceLogger
    {
        public bool RedirectToConsole = true;
        public bool KeepOpen = false;
        public List<ConsoleColor> Colors = new List<ConsoleColor>
            {
                Console.ForegroundColor
            };
        public IWorkspace Workspace;
        public string Filename;
        public string Directory;
        public string LoggerPrefix;
        private StreamWriter _stream;

        public WorkspaceLogger(IWorkspace ws, bool spewConsole = true, bool keepOpen = false) {
            Workspace = ws;

            Filename = ws.GetOrigin() + ".log";
            Directory = Path.GetDirectoryName(Filename);

            RedirectToConsole = spewConsole;

            KeepOpen = keepOpen;

            if(KeepOpen)
                _stream = new StreamWriter(File.OpenWrite(Filename));

        }

        public void SubUnitFile(string sender, string key, string value)
        {
            File.AppendAllText(string.Format("{0}.{1}.log", key), value);
        }

        public void Push(ConsoleColor col)
        {
            if (!RedirectToConsole)
                return;
            Colors.Add(Console.ForegroundColor);
            Console.ForegroundColor = col;
        }

        public void Pop(ConsoleColor col)
        {
            if (!RedirectToConsole)
                return;
            Colors.Add(Console.ForegroundColor);
            Console.ForegroundColor = col;
        }

        public void Clear()
        {
            if(RedirectToConsole)
                Console.Clear();
        }

        private void Put(string s)
        {
            Console.Out.Write(s);
            if(KeepOpen)
                _stream.Write(s);
            else
                File.AppendAllText(Filename, s);
        }

        private void BeforeTransaction()
        {
            
        }

        private void AfterTransaction()
        {
            if(KeepOpen)
                _stream.Flush();
            Console.Out.Flush();
        }

        public void Append(string content)
        {
            BeforeTransaction();
            Put(content);
            AfterTransaction();
        }

        public void AppendLine(string content)
        {
            BeforeTransaction();
            Put(content + "\r\n");
            AfterTransaction();
        }
    }
}
