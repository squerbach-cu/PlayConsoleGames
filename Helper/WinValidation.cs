using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.Tools
{
    internal class WinValidation
    {
        private static bool InsideArray(char[,] c4array, int dropRow, int dropColum)
        {

            if (dropColum <= c4array.GetLength(1) - 1 && dropColum >= 0
                 && dropRow <= c4array.GetLength(0) - 1 && dropRow >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool CheckWin(char[,] c4array, char activePlayerChar, int dropColumn, int dropRow, int winningNumber )
        {
            int currentColumn = dropColumn;
            int currentRow = dropRow;
            int counter = 1;

            //horizontal
            while (counter < winningNumber)
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

            currentColumn = dropColumn;

            while (counter < winningNumber)
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

            if (counter == winningNumber)
            {
                return true;
            }
            currentColumn = dropColumn;
            counter = 1;

            //vertikal 
            while (counter < winningNumber)
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

            if (counter == winningNumber)
            {
                return true;
            }
            currentRow = dropRow;
            counter = 1;

            while (counter < winningNumber)
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

            if (counter == winningNumber)
            {
                return true;
            }
            currentRow = dropRow;
            counter = 1;

            //diagonal
            while (counter < winningNumber)
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

            while (counter < winningNumber)
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

            if (counter == winningNumber)
            {
                return true;
            }

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
