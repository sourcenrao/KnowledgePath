using Newtonsoft.Json.Linq;
using System;

namespace KnowledgePath
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Load Tree from JSON */
            string treeFileName = "Tree.json";
            Tree tree = new Tree(treeFileName);
            
            Console.WriteLine("Welcome to the Knowledge Path, press 1-3 to start or select an option.");
            Console.WriteLine("You can press 'q' at any time to quit.");
            Console.WriteLine("");

            char input = Console.ReadKey().KeyChar;
            int currentNode = 0;

            while(InputParser.ReturnUserChoice(input) != 0)
            {
                tree.PrintFromList(tree.GetBlurbsForSubjects(tree.GetNextSubjects(0)));
                input = Console.ReadKey().KeyChar;
                /* 
                > First node is 0
                > GetNextSubjects to select 3 child nodes (at random to be implemented) from array of children
                > PrintFromList the 3 selected node's blurbs
                > Get user choice of nodes
                > Restart using user's choice of nodes

                > Track the path of subjects for display at end.
                */
            }
            Console.ReadKey();
        }
    }
}
