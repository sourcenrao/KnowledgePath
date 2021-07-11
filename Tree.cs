using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace KnowledgePath
{
    public class Tree {

        public class Subject
        {
            public string category { get; set; }
            public int UID { get; set; }
            public List<int> parents { get; set; }
            public List<int> children { get; set; }
            public List<string> blurbs { get; set; }
        }

        /* From selected subject's children and return the categories */
        public static string[] Next3(int[])
        {
            
        }

        public static JArray OpenTree(string treeFileName)
        {
            try
            {
                string treeDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo treeDirectoryInfo = new DirectoryInfo(treeDirectory);
                string treeFilePath = Path.Combine(treeDirectoryInfo.FullName, treeFileName);
                using (StreamReader treeFile = File.OpenText(treeFilePath))
                {
                    string treeString = treeFile.ReadToEnd();
                    return JArray.Parse(treeString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
