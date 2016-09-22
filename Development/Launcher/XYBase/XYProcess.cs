using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace XYBase
{
    public static class XYProcess
    {
        public static class Application
        {
            public static void StartXYWE()
            {
                Process.Start(@"..\ydwe\YDWE.exe");
            }

            public static void StartXYCodeLibraryManager()
            {
                Process.Start(@"XYCodeLibraryManager.exe");
            }

            public static void StartXYMpqLibraryManager()
            {
                Process.Start(@"XYMpqLibraryManager.exe");
            }
        }
        public static class Website
        {
            public static void StartOfficial()
            {
                Process.Start("https://wow9.org/xywe");
            }
        }
    }
}
