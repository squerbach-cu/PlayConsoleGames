namespace PlayConsoleGames.Tools
{
    internal class WinValidation
    {
        private readonly int _winningNumber;

        public WinValidation(int winningNumber)
        {
            /// <summary>
            /// In connect4 the winning number is four and in tic tac toe its 3 
            /// </summary>
            _winningNumber = winningNumber;
        }

        /// <summary>
        /// Checks whether or not the next slot that is about to be cheked is in the bounds of the array.
        /// </summary>
        /// <param name="c4array"></param>
        /// <param name="dropRow"></param>
        /// <param name="dropColum"></param>
        /// <returns></returns>
        /// 
        private static bool InsideArray(char[,] c4array, int dropRow, int dropColum)
        {

            if (dropColum <= c4array.GetLength(1) - 1 && dropColum >= 0
                 && dropRow <= c4array.GetLength(0) - 1 && dropRow >= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if someone connected the amount of chars set in the winningNumber int
        /// the tokens hae to align in a horizontal, diagonal or vertical way
        /// </summary>
        /// <param name="c4array"></param>
        /// <param name="activePlayerChar"></param>
        /// <param name="dropColumn"></param>
        /// <param name="dropRow"></param>        
        /// <returns></returns>
        
        public bool CheckWin(char[,] c4array, char activePlayerChar, int dropColumn, int dropRow)
        {
            int currentColumn = dropColumn;
            int currentRow = dropRow;
            int counter = 1;

            //horizontal
            while (counter < _winningNumber)
            {
                currentColumn++;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;   
                }
                else
                {
                    break;
                }
            }

            //return the dropColumn back to the currentColumn so that the other horizontal direction can be checked 
            currentColumn = dropColumn;

            while (counter < _winningNumber)
            {
                currentColumn--;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter == _winningNumber)
            {
                return true;
            }
            currentColumn = dropColumn;
            counter = 1;

            //vertikal 
            while (counter < _winningNumber)
            {
                currentRow--;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            currentRow = dropRow;

            if (counter == _winningNumber)
            {
                return true;
            }
            currentRow = dropRow;
            counter = 1;

            while (counter < _winningNumber)
            {
                currentRow++;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter == _winningNumber)
            {
                return true;
            }
            currentRow = dropRow;
            counter = 1;

            //diagonal
            while (counter < _winningNumber)
            {
                currentRow++;
                currentColumn++;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            currentColumn = dropColumn;
            currentRow = dropRow;

            while (counter < _winningNumber)
            {
                currentRow--;
                currentColumn--;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter == _winningNumber)
            {
                return true;
            }

            //diagonal but the other direction
            currentColumn = dropColumn;
            currentRow = dropRow;
            counter = 1;

            while (counter < 4)
            {
                currentRow--;
                currentColumn++;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            currentColumn = dropColumn;
            currentRow = dropRow;

            while (counter < 4)
            {
                currentRow++;
                currentColumn--;
                if (InsideArray(c4array, currentRow, currentColumn) && c4array[currentRow, currentColumn] == activePlayerChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter == 4)
            {
                return true;
            }

            return false;
        }
    }
}
