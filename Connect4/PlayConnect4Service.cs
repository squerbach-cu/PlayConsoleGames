using PlayConsoleGames.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.Connect4
{
    public class PlayConnect4Service : IPlayGamesService
    {
        public void PlayGames()
        {
            Console.WriteLine("Enter name of player ONE: ");
            Player PlayerOne = new Player();
            PlayerOne.Name = Console.ReadLine();
            PlayerOne.Char = 'o';

            Console.WriteLine("Enter name of player TWO: ");
            Player PlayerTwo = new Player();
            PlayerTwo.Name = Console.ReadLine();
            PlayerTwo.Char = 'x';

            //char[,] board = new char[6, 7];
            //FillBoard(board);            
            GameStatusC4 board = new GameStatusC4();


            int droppedTokenCounter = 0;
            int someoneWon = 0;


            while (42 > droppedTokenCounter && someoneWon == 0)
            {
                Console.Clear();
                PrintBoard(board.Array);

                if (droppedTokenCounter % 2 == 0)
                {
                    if (DropToken(board.Array, PlayerOne.Char, PlayerOne.Name))
                    {
                        someoneWon = 1;
                        break;
                    }
                }
                else
                {
                    if (DropToken(board.Array, PlayerTwo.Char, PlayerTwo.Name))
                    {
                        someoneWon = 2;
                        break;
                    }
                }
                droppedTokenCounter++;
            }
            Console.Clear();
            PrintBoard(board.Array);
            if (someoneWon == 1)
            {
                Console.WriteLine($"{PlayerOne.Name} won the game!");
            }
            else if (someoneWon == 2)
            {
                Console.WriteLine($"{PlayerTwo.Name} won the game!");
            }
            if (droppedTokenCounter == 42 && someoneWon == 0)
            {

                Console.WriteLine("The board is full!");
            }
        }

        //asks where to drop a token and then changes THE array with the char of the active player
        //if the stack is full the drop methode is called recursive
        private static bool DropToken(char[,] c4array, char activePlayerChar, string activePlayerName)
        {
            int connectFour = 4;
            Console.Write($"{activePlayerName}s turn. Where do you want to drop a token?: ");
            int dropColum = InputValidation(Console.ReadLine());

            if (IsFull(c4array, dropColum))
            {
                Console.WriteLine("Colum is full!");
                DropToken(c4array, activePlayerChar, activePlayerName);
            }
            else
            {
                int dropRow = NextFreeSlot(c4array, dropColum);
                c4array[dropRow, dropColum] = activePlayerChar;
                if (WinValidation.CheckWin(c4array, activePlayerChar, dropColum, dropRow, connectFour))
                {
                    return true;
                }
            }
            return false;
        }        

        private static bool IsFull(char[,] arrayToCheck, int stackIndex)
        {
            if (arrayToCheck[0, stackIndex] == ' ')
            {
                return false;
            }
            return true;
        }

        private static int NextFreeSlot(char[,] arrayToCheck, int stackIndex)
        {
            int i;
            for (i = (arrayToCheck.GetLength(0) - 1); i >= 0; i--)
            {
                if (arrayToCheck[i, stackIndex] == ' ')
                {
                    break;
                }
            }
            return i;
        }

        private static int InputValidation(string input)
        {
            int returnnumber = 0;

            while (returnnumber <= 0)
            {
                bool erfolg = int.TryParse(input, out returnnumber);
                if (erfolg)
                {
                    if (returnnumber >= 1 && returnnumber <= 7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Only 1-7 are valid inputs");
                        input = Console.ReadLine();
                        returnnumber = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Only 1-7 are valid inputs");
                    input = Console.ReadLine();
                }
            }
            return returnnumber - 1;
        }

        //prints out a static ascii art board
        //with the array, that safes the standing, as input
        private static void PrintBoard(char[,] c4array)
        {
            for (int i = 0; i < c4array.GetLength(0); i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+");
                for (int j = 0; j < c4array.GetLength(1); j++)
                {
                    Console.Write("| {0} ", c4array[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+---+---+---+---+---+---+---+");
            Console.WriteLine("+ 1 + 2 + 3 + 4 + 5 + 6 + 7 +");
        }

        //private static void FillBoard(char[,] c4array)
        //{
        //    for (int i = 0; i < c4array.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < c4array.GetLength(1); j++)
        //        {
        //            c4array[i, j] = ' ';
        //        }
        //    }
        //}

    }    
}
