using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SHIClassLibrary.Tools
{
    public enum LogType { Daily, Monthly }

    public class LogManager
    {
        private string _path;

        #region Constructs
        public LogManager(string path,LogType logType, string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
        }
        public LogManager(string prefix, string postfix)
            : this(Path.Combine(Application.Root,"Log"), LogType.Daily, prefix, postfix)
        {
        }
        public LogManager()
            : this(System.IO.Path.Combine(Application.Root, "Log"), LogType.Daily, null, null)
        {
        }
        #endregion

        #region Methods
        private void _SetLogPath(LogType logType, string prefix, string postfix)
        {
            string path = string.Empty;
            string name = string.Empty;
            switch (logType)
            {
                case LogType.Daily:
                    path =string.Format(@"{0}\{1}\",DateTime.Now.Year,DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    //Console.WriteLine(path);
                    //Console.ReadLine();
                    break;
                case LogType.Monthly:
                    path =string.Format(@"{0}\",DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }
            _path = Path.Combine(_path, path);
            if (!System.IO.Directory.Exists(_path))
                System.IO.Directory.CreateDirectory(_path);

            if (!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name;
            }
            if (!String.IsNullOrEmpty(postfix))
            {
                name=name + postfix;
            }
            name=name + ".txt";


            //string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            _path = Path.Combine(_path, name);


            //Console.WriteLine(prefix);
            //Console.WriteLine(postfix);
            //Console.WriteLine(name);
            //Console.WriteLine(_path);
            //Console.ReadLine();
        }
        public void Write(string data)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex)
            { }
        }
        public void WriteLine(string data)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_path, true))
                {
                    //20161226 21:25:30     + data
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t") + data);
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
