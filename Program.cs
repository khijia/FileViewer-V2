
using FileViewer.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace FileViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dataFolder = CONS.dataFolder;
            if (!Directory.Exists(dataFolder)) Directory.CreateDirectory(dataFolder);
            if(!File.Exists(CONS.documentFile))
            {
                Copy(dataFolder);
            }

            Application.Run(new FileViewer());
        }
        static void Copy(string targetPath)
        {
            string sourcePath = "Lib";
            Directory.CreateDirectory(targetPath);
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                // Copy the files and overwrite destination files if they already existed.
                foreach (string s in files)
                {
                    var destFile = Path.Combine(targetPath, Path.GetFileName(s));
                    File.Copy(s, destFile, true);
                }
            }            
        }
    }
}
