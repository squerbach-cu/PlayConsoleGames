using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class ColorfulStaticBoardPrinter : IBoardPrinter
    {

        public void PrintBoard(char[,] arr)
        {
            Console.Clear();
            WriteThings(arr, 0);
            Console.WriteLine("---|---|---");
            WriteThings(arr, 1);
            Console.WriteLine("---|---|---");
            WriteThings(arr, 2);

        }

        private void WriteThings(char[,] arr, int indexRow)
        {
            Console.Write(" ");
            WriteField(arr[indexRow, 0]);
            Console.Write(" | ");
            WriteField(arr[indexRow, 1]);
            Console.Write(" | ");
            WriteField(arr[indexRow, 2]);
            Console.WriteLine(" ");
            
        }
        private void WriteField(char XO)
        {
            switch (XO)
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 'O':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write(XO);
            Console.ResetColor();
        }            
    }
}