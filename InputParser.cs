using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    public class InputParser
    {
        /* Choices are 1-3, 'q' returns 0, other entries return 4*/
        public static int GetUserChoice()
        {
            char input = Console.ReadKey().KeyChar;
            if (char.IsNumber(input))
            {
                int value = (int)char.GetNumericValue(input);
                if (value >= 1 && value <= 3)
                {
                    return value;
                }
                else
                {
                    return 4;
                }
            }
            else if (input == 'q' || input == 'Q')
            {
                return 0;
            }
            else
            {
                return 4;
            }
        }

        public static int CheckForRestart()
        {
            char input = Console.ReadKey().KeyChar;

            if (input == 'r' || input == 'R')
            {
                return 5;
            }

            return 0;
        }
    }
}
