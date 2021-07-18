using System;
using System.Collections.Generic;

namespace KnowledgePath
{
    class PathTracker
    {
        private readonly List<string> path = new List<string>();

        public PathTracker(Tree tree, int UID)
        {
            string _path = tree.GetCategoryForSubject(UID);
            path = new List<string>() { _path };
        }

        public void Add(Tree tree, int UID)
        {
            string _path = tree.GetCategoryForSubject(UID);
            path.Add(_path);
        }

        public void PrintPath()
        {
            int depth = 0;
            Console.WriteLine("You have reached the end of the tree for now, though it still grows.");
            Console.WriteLine("Your path:");
            foreach (string category in path)
            {
                for (int i = 0; i < depth; i++)
                {
                    Console.Write("=");
                }
                Console.Write("> ");
                Console.Write(category + "\n");
                depth += 1;
            }
            Console.Write("\n");
            Console.WriteLine("Press R to restart or any other key to close.");
        }
    }
}
