using Newtonsoft.Json.Linq;
using System;

namespace KnowledgePath
{
    class Program
    {
        static void Main(string[] args)
        {
            string treeFileName = "Tree.json";
            Tree tree = new Tree(treeFileName);
            
            Console.WriteLine(tree.tree[0].blurb);
            Console.WriteLine(tree.GetNextSubjects(1));
            tree.PrintFromList(tree.GetBlurbsForSubjects(tree.GetNextSubjects(1)));
            Console.ReadKey();
        }
    }
}
