using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    public class InputParser
    {
        public enum Selection
        {
            Invalid = -1,
            Quit = 0,
            Subject1 = 1,
            Subject2 = 2,
            Subject3 = 3,
            Restart = 9
        }

        public bool restart;

        public bool quit;

        public Selection selection;

        public InputParser()
        {
            selection = Selection.Invalid;
            restart = false;
            quit = false;
        }

        /* Choices are 1-3, 'q' returns 0, other entries return -1*/
        public void GetUserChoice()
        {
            char input = Console.ReadKey().KeyChar;
            if (char.IsNumber(input))
            {
                int value = (int)char.GetNumericValue(input);
                if (value >= 1 && value <= 3)
                {
                    selection = (Selection) value;
                }
                else
                {
                    selection = Selection.Invalid;
                }
            }
            else if (input == 'q' || input == 'Q')
            {
                selection = Selection.Quit;
                quit = true;
            }
            else if (input == 'r' || input == 'R')
            {
                selection = Selection.Restart;
                restart = true;
            }
        }
    }
}
