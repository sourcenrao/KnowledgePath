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
            Root tree = Tree.OpenTree(treeFileName);
            Console.WriteLine(tree);
            Console.ReadKey();
        }
    }
}
