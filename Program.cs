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

            InputParser input = new();

            int currentNode = 0;

            PathTracker pathTracker = new(tree, currentNode);

            input.GetUserChoice();

            while (!input.quit)
            {
                Console.Clear();

                List<int> nextSubjects = tree.GetUpTo3NextSubjects(currentNode);

                if (nextSubjects.Count is 0) // Runs if selected subject has no child nodes
                {
                    pathTracker.PrintPath();
                    input.GetUserChoice();

                    if (input.restart)
                    {
                        currentNode = 0;
                        pathTracker = new(tree, currentNode);
                    }
                }

                else // Runs if child nodes exist
                {
                    tree.PrintBlurbs(tree.GetBlurbsForSubjects(nextSubjects));
                    input.GetUserChoice();

                    while (input.selection == InputParser.Selection.Invalid)
                    {
                        Console.WriteLine("Please enter 1-3 or press 'q' to quit.\n");
                        input.GetUserChoice();
                    }
                }

                if (!input.restart && !input.quit)
                {
                    currentNode = nextSubjects[(int)input.selection - 1];
                    pathTracker.Add(tree, currentNode);
                }
                else
                {
                    input.restart = false;
                }
            }

            Environment.Exit(0);
        }
    }
}
