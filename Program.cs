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
            List<Subject> tree = Tree.OpenTree(treeFileName);
        }
    }
}
