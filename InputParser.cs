using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    class InputParser
    {
        /* Choices are 1-3, quit returns 0, invalid entry returns 4*/
        public static int ReturnUserChoice(char input)
        {
            if(Char.IsNumber(input))
            {
                int value = (int)Char.GetNumericValue(input);
                if(value >= 1 && value <= 3)
                {
                    return value;
                }
                else
                {
                    return 4;
                }
            }
            else if(input == 'q')
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
