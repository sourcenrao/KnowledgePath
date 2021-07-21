using System;
using System.Collections.Generic;

namespace KnowledgePath
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            /* Load Tree from JSON */
            string treeFileName = "Tree.json";
            Tree tree = new(treeFileName);
            Console.WriteLine("'To know what is possible is the most beautiful thing, for then you may dream of what may be.'");
            Console.WriteLine("Welcome to the Knowledge Path, press 1-3 to begin or to select an option.");
            Console.WriteLine("You can press 'q' at any time to quit.");
            Console.WriteLine("");
            
            int input = InputParser.GetUserChoice();
            int currentNode = 0;

            // Use separate bool to track restart
            bool restart = false;

            PathTracker pathTracker = new(tree, currentNode);

            while (input != 0)
            {
                List<int> nextSubjects = tree.GetUpTo3NextSubjects(currentNode);

                Console.Clear();

                if (nextSubjects.Count is 0) // Runs if selected subject has no child nodes
                {
                    pathTracker.PrintPath();
                    input = InputParser.CheckForRestart(); // Returns 5 for restart, 0 for quit

                    if (input == 5)
                    {
                        currentNode = 0;
                        pathTracker = new(tree, currentNode);
                    }
                }

                else // Runs if child nodes exist
                {
                    tree.PrintBlurbs(tree.GetBlurbsForSubjects(nextSubjects));

                    input = InputParser.GetUserChoice();

                    while (input == 4)
                    {
                        Console.WriteLine("Please enter 1-3 or press 'q' to quit.");
                        input = InputParser.GetUserChoice();
                    }
                }

                if (input != 0)
                {
                    if (input != 5)
                    {
                        currentNode = nextSubjects[input - 1];
                        pathTracker.Add(tree, currentNode);
                    }
                }

            }

            Environment.Exit(0);
        }
    }
}
