using System;
using System.Text.Json;

namespace KnowledgePath
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree.DeserializeTree(Tree.OpenTree());
        }
    }
}
