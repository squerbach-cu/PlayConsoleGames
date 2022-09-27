using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class DynamicBoardPrinter : IBoardPrinter
    {
        public void PrintBoard(char[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
