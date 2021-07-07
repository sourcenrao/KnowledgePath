using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace KnowledgePath
{
    public class Tree {

        public class Subject
        {
            [JsonPropertyName("category")]
            public string Category { get; set; }

            [JsonPropertyName("UID")]
            public int UID { get; set; }

            [JsonPropertyName("parents")]
            public List<int> Parents { get; } = new List<int>();

            [JsonPropertyName("children")]
            public List<int> Children { get; } = new List<int>();

            [JsonPropertyName("blurbs")]
            public List<string> Blurbs { get; } = new List<string>();
        }

        public class Root
        {
            [JsonPropertyName("categories")]
            public List<Subject> Categories { get; } = new List<Subject>();
        }

        public static Root OpenTree(string treeFileName)
        {
            try
            {
                string treeDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo treeDirectoryInfo = new DirectoryInfo(treeDirectory);
                string treeFilePath = Path.Combine(treeDirectoryInfo.FullName, treeFileName);
                return JsonConvert.DeserializeObject<Root>(treeFilePath);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
