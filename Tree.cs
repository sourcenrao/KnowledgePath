using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace KnowledgePath
{
    public class Tree {


        public readonly struct tree
        {

        }

        public static string OpenTree()
        {
            try
            {
                string treeFileName = "Tree.json";
                string treeDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo treeDirectoryInfo = new DirectoryInfo(treeDirectory);
                string treeFilePath = Path.Combine(treeDirectoryInfo.FullName, treeFileName);
                return treeFilePath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeserializeTree(string treeFilePath)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader treeStream = new StreamReader(treeFilePath))
                using (JsonTextReader treeText = new JsonTextReader(treeStream))
                {

                }
            }
            catch
            {
                throw;
            }
        }
    }
}
