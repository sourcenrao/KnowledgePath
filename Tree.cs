using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace KnowledgePath
{
    public class Tree
    {
        private List<Subject> tree { get; set; }

        private record Subject
        {
            public string Category { get; set; }
            public int UID { get; set; }
            public List<int> Parents { get; set; }
            public List<int> Children { get; set; }
            public string Blurb { get; set; }
        }

        public Tree(string treeFileName)
        {
            string treeDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo treeDirectoryInfo = new DirectoryInfo(treeDirectory);
            string treeFilePath = Path.Combine(treeDirectoryInfo.FullName, treeFileName);
            using StreamReader treeFile = File.OpenText(treeFilePath);
            string treeString = treeFile.ReadToEnd();
            tree = JArray.Parse(treeString).ToObject<List<Subject>>();
        }

        private void CheckForRange(int UID)
        {
            if (UID >= tree.Count)
            {
                Console.WriteLine(UID + " out of range!");
                throw new IndexOutOfRangeException();
            }
        }
        public string GetCategoryForSubject(int UID)
        {
            CheckForRange(UID);
            return tree[UID].Category.ToString();
        }

        public List<int> GetChildrenForSubject(int UID)
        {
            CheckForRange(UID);
            return tree[UID].Children.ToList();
        }

        public List<int> GetUpTo3NextSubjects(int parentUID)
        {
            CheckForRange(parentUID);
            List<int> children = GetChildrenForSubject(parentUID);
            
            if(children.Count > 0)
            {
                List<int> nextSubjects = new(3);

                Random rnd = new();

                // Remove from list of possible subjects and add to list of next subjects
                while (children.Count > 0 && nextSubjects.Count < 3)
                {
                    int randomSubjectIndex = rnd.Next(children.Count);
                    nextSubjects.Add(children[randomSubjectIndex]);
                    children.RemoveAt(randomSubjectIndex);
                }

                return nextSubjects;
            }

            return new List<int>(0);

        }

        public HashSet<string> GetBlurbsForSubjects(List<int> subjectArray)
        {
            HashSet<string> blurbs = new();

            foreach(int UID in subjectArray)
            {
                CheckForRange(UID);
                blurbs.Add(tree[UID].Blurb);
            }

            return blurbs;
        }

        public void PrintBlurbs(HashSet<string> blurbs, int startingCount = 1)
        {
            foreach(string blurb in blurbs)
            {
                string orderedBlurb = startingCount + ": " + blurb;
                startingCount += 1;
                string[] lines = orderedBlurb
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    string process = lines[i];
                    List<string> wrapped = new();

                    while (process.Length > Console.WindowWidth)
                    {
                        int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
                        if (wrapAt <= 0) break;

                        wrapped.Add(process.Substring(0, wrapAt));
                        process = process.Remove(0, wrapAt + 1);
                    }

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
