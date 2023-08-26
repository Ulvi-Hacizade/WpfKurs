using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DOC_21Core.Utils
{
    public static class Constants
    {
        private static string applicationFilesDirectory = "C:/Edtrac";
        public static string ApplicationFilesDirectory
        {
            get
            {
                if (!Directory.Exists(applicationFilesDirectory))
                {
                    Directory.CreateDirectory(applicationFilesDirectory);
                }

                return applicationFilesDirectory;
            }
        }

        public static string ConfigurationFilePath => $"{ApplicationFilesDirectory}/Configs.json";
        public static string ErrorMessage = "Bilinməyən bir xəta baş verdi";

        public static string LOGFILEFOLDER = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Edtrac\";

        public static string LOGFILEPATH = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Edtrac\log.txt";
    }
}
