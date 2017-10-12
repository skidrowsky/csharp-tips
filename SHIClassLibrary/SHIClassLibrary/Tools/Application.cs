using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHIClassLibrary.Tools
{
    public static class Application
    {
        public static string Root
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
