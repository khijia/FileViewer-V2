using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileViewer.Model
{
    public static class log
    {
        public static void info(Exception ex)
        {
            var path = Path.GetTempPath()+ "ALCFileViewer";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var logFilePath = $@"{path}\log.log";
            File.AppendAllText(logFilePath, DateTime.Now.ToString()+"=> "+ ex.Message + "\r\n");
            File.AppendAllText(logFilePath, DateTime.Now.ToString() + "=> " + ex.StackTrace + "\r\n");

        }

        public static void info(string str)
        {
            var path = Path.GetTempPath();
            var logFilePath = $@"{path}\log.log";
            File.AppendAllText(logFilePath, str + "\r\n");
        }
    }
}
