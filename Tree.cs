using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace KnowledgePath
{
    public class Tree
    {
        public List<Subject> tree { get; set; }

        public class Subject
        {
            public string category { get; set; }
            public int UID { get; set; }
            public List<int> parents { get; set; }
            public List<int> children { get; set; }
            public string blurb { get; set; }
        }

        public Tree(string treeFileName)
        {
            try
            {
                string treeDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo treeDirectoryInfo = new DirectoryInfo(treeDirectory);
                string treeFilePath = Path.Combine(treeDirectoryInfo.FullName, treeFileName);
                using (StreamReader treeFile = File.OpenText(treeFilePath))
                {
                    string treeString = treeFile.ReadToEnd();
                    tree = JArray.Parse(treeString).ToObject<List<Subject>>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<int> GetNextSubjects(int parentUID)
        {
            return tree[parentUID - 1].children;
        }

        public List<string> GetBlurbsForSubjects(List<int> subjectArray)
        {
            List<string> blurbs = new List<string>();
            foreach(int subjectID in subjectArray)
            {
                blurbs.Add(tree[subjectID - 1].blurb);
            }
            return blurbs;
        }

        public void PrintFromList(List<string> blurbs)
        {
            foreach(string blurb in blurbs)
            {
                Console.WriteLine(blurb);
                Thread.Sleep(200);
            }
        }

        public JArray OpenTree(string treeFileName)
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
