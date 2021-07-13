﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace KnowledgePath
{
    public static class Tree
    {

        public static JToken GetNextSubjects(JArray tree, int parentUID)
        {
            return tree[parentUID]["children"];
        }

        public static List<JToken> GetBlurbsForSubjects(JArray tree, JToken subjectArray)
        {
            List<JToken> blurbs = new List<JToken>();
            foreach(int subjectID in subjectArray)
            {
                blurbs.Add(tree[subjectID - 1]["blurbs"]);
            }
            return blurbs;
        }

        public static void PrintFromList(List<JToken> blurbs)
        {
            foreach(JToken blurb in blurbs)
            {
                Console.WriteLine(blurb);
                Thread.Sleep(200);
            }
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
