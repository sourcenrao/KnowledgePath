using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static KnowledgePath.Tree;

namespace KnowledgePath
{
    class Program
    {
        static void Main(string[] args)
        {
            string treeFileName = "Tree.json";
            JArray tree = OpenTree(treeFileName);
            
            Console.WriteLine(tree[0]["blurbs"][0]);
            Console.WriteLine(GetNextSubjects(tree, 0));
            PrintFromList(GetBlurbsForSubjects(tree, GetNextSubjects(tree, 0)));
            Console.ReadKey();
        }
    }
}
