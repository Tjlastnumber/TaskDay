using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskDay.Core.Common;

namespace TaskDay.GeneralLibrary
{
    public static class FileHelper
    {
        private readonly static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TaskDay");
        public static string FileName = "TaskDay.js";
        public static string FilePath = Path.Combine(FolderPath, FileName);

        public static void SaveJosn(string jsonString)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            File.WriteAllText(FilePath, jsonString, Encoding.UTF8);
        }

        public static T ReadJosn<T>(string path = "")
        {
            var jsonPath = !path.IsNullOrWhiteSpace() ? path : FilePath;
            if (File.Exists(jsonPath))
            {
                string jsonString = File.ReadAllText(jsonPath);

                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return default(T);
        }
    }

}
