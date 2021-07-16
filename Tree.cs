using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace KnowledgePath
{
    public class Tree
    {
        public List<Subject> tree { get; set; }

        public record Subject
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
        public List<int> GetUpTo3NextSubjects(int parentUID)
        {
            List<int> children = tree[parentUID].children;
            HashSet<int> nextSubjects = new HashSet<int>(3);
            int length = children.Count;
            Random rnd = new Random();

            if (length > 0)
            {
                while (nextSubjects.Count < 3 && nextSubjects.Count < length)
                {
                    int randomSubjectUID = children[rnd.Next(length)];
                    nextSubjects.Add(randomSubjectUID);
                }
                return nextSubjects.ToList();
            }
            else return null;
        }

        public HashSet<string> GetBlurbsForSubjects(List<int> subjectArray)
        {
            HashSet<string> blurbs = new HashSet<string>();

            foreach(int UID in subjectArray)
            {
                blurbs.Add(tree[UID].blurb);
            }

            return blurbs;
        }

        public void PrintBlurbs(HashSet<string> blurbs, int startingCount = 1)
        {
            foreach(string blurb in blurbs)
            {
                string[] lines = blurb
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    string process = lines[i];
                    List<string> wrapped = new List<string>();

                    while (process.Length > Console.WindowWidth)
                    {
                        int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
                        if (wrapAt <= 0) break;

                        wrapped.Add(process.Substring(0, wrapAt));
                        process = process.Remove(0, wrapAt + 1);
                    }

                    Console.Write(startingCount + ": ");
                    startingCount += 1;

                    foreach (string wrap in wrapped)
                    {
                        Console.WriteLine(wrap);
                    }

                    Console.WriteLine(process + "\n");
                }
            }
        }
    }
}
