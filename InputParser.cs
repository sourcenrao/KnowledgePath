using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    class InputParser
    {
        /* Choices are 1-3, 'q' returns 0, other entries return 4*/
        public static int ReturnUserChoice(char input)
        {
            if(char.IsNumber(input))
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
            else if (input == 'q')
            {
                return 0;
            }
            else
            {
                return 4;
            }
        }
    }
}
