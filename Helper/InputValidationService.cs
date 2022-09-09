using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.Tools
{
    internal class InputValidationService
    {
        public static int InputValidation(string input)
        {
            int returnnumber = 0;

            while (returnnumber <= 0)
            {
                bool erfolg = int.TryParse(input, out returnnumber);
                if (erfolg)
                {
                    if (returnnumber >= 1 && returnnumber <= 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Only 1 to 9 are valid inputs");
                        input = Console.ReadLine();
                        returnnumber = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Only 1 to 9 are valid inputs");
                    input = Console.ReadLine();
                }
            }
            return returnnumber;
        }
    }
}
