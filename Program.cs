using System;
using System.Collections.Generic;

namespace KnowledgePath
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Load Tree from JSON */
            string treeFileName = "Tree.json";
            Tree tree = new Tree(treeFileName);
            Console.WriteLine("'To know what is possible is the most beautiful thing, for then you may dream of what may be.'");
            Console.WriteLine("Welcome to the Knowledge Path, press 1-3 to begin or to select an option.");
            Console.WriteLine("You can press 'q' at any time to quit.");
            Console.WriteLine("");

            int input = InputParser.ReturnUserChoice(Console.ReadKey().KeyChar);
            int currentNode = 0;

            List<string> treePath = new List<string>();

            while (input != 0)
            {
                List<int> nextSubjects = tree.GetUpTo3NextSubjects(currentNode);

                Console.Clear();

                if (nextSubjects is null)
                {
                    Console.WriteLine("You have reached the end of the tree for now, though it still grows.");
                    Console.WriteLine("Your path:");
                    foreach(string subject in treePath)
                    {
                        Console.WriteLine(subject);
                    }
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                tree.PrintBlurbs(tree.GetBlurbsForSubjects(nextSubjects));

                /* 
                > First node is 0
                > PrintFromList 3 of selected node's children's blurbs
                > Get user choice of nodes
                > Restart using user's choice of nodes
                */

                input = InputParser.ReturnUserChoice(Console.ReadKey().KeyChar);

                while (input == 4)
                {
                    Console.WriteLine("Please enter 1-3 or press 'q' to quit.");
                    input = InputParser.ReturnUserChoice(Console.ReadKey().KeyChar);
                }

                if (input != 0)
                {
                    currentNode = nextSubjects[input - 1];
                    treePath.Add(tree.tree[currentNode].category);
                }

            }

            Environment.Exit(0);
        }
    }
}
