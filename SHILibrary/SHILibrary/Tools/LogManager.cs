using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHILibrary.Tools
{
    class LogManager
    {
        private string _path;

        #region Constructs
        public LogManager(string path)
        {
            _path = path;
            _SetLogPath();
        }
        public LogManager()
            : this(System.IO.Path.Combine(Application.Root, "Log"))
        {
        }
        #endregion

        #region Methods
        private void _SetLogPath()
        {
            if (!System.IO.Directory.Exists(_path))
                System.IO.Directory.CreateDirectory(_path);
            string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            _path = System.IO.Path.Combine(_path, logFile);
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
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t" + data));
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
