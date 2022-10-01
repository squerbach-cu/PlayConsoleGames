using System;
using System.ComponentModel.DataAnnotations;

namespace PlayConsoleGames.Tools
{
    internal class InputValidationService
    {
        /// <summary>
        /// Gets a string and return a int and a bool if the string contains a numeric value between minVal and maxVal
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <param name="validInt"></param>
        /// <returns></returns>
        public bool ValdiateInt(string userInput, int minVal, int maxVal, out int validInt)
        {
            if (!int.TryParse(userInput, out validInt))
            {
                return false;
            }
            if (int.TryParse(userInput, out validInt))
            {
                if (validInt <= maxVal && validInt >= minVal)
                {
                    return true;
                }
                return false;
            }
            return false;
        }        
    }
}
