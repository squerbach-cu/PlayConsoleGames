using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PlayTowersOfHanoiService : IPlayGamesService
    {
        public void PlayGames()
        {
            Console.Write("Amount: ");
            int amountDisks = Convert.ToInt32(Console.ReadLine());
            int[,] currentDiskPlacement = GenerateBoard(amountDisks);


            Console.Write("Print upside down?(1) or normal(2)? ");
            int upsideDown = Convert.ToInt32(Console.ReadLine());

            Console.Write("Print Star(1) or Bang(2)");
            DiskDisplayType starOrBang = (DiskDisplayType)Convert.ToInt32(Console.ReadLine());

            IPrintDiskService print2 = new PrintDiskBangService();
            IPrintBoardService print;
            if (starOrBang == DiskDisplayType.Star)
            {
                print2 = new PrintDiskStarService();
            }

            if (upsideDown == 2)
            {
                print = new PrintBoardNormalService(print2);
            }
            else
            {
                print = new PrintBoardReverseService(print2);
            }
                       

            print.PrintBoard(currentDiskPlacement);



            while (notWon(currentDiskPlacement))
            {
                Console.Clear();
                print.PrintBoard(currentDiskPlacement);

                int towerIndex;
                do
                {
                    Console.Write("Take form stack 1/2/3: ");
                    towerIndex = InputValidation(Console.ReadLine());
                } while (takeDisk(currentDiskPlacement, towerIndex));

                Console.Clear();
                print.PrintBoard(currentDiskPlacement);

                int towerIndex2;
                do
                {
                    Console.Write("Put onto stack 1/2/3?: ");
                    towerIndex2 = InputValidation(Console.ReadLine());
                } while (dropDisk(currentDiskPlacement, removedDisk, towerIndex2));
            }

            Console.WriteLine("You win!");                
        }

        private static int removedDisk { get; set; }

        //takes a disk and returns bool if it was successful
        private static bool takeDisk(int[,] board, int towerIndex)
        {
            int counter;            

            if (board[towerIndex, counter = NextDisk(board, towerIndex)] == 0)
            {
                return true;                
            }

            int removedDiskValue = board[towerIndex, NextDisk(board, towerIndex)];
            board[towerIndex, NextDisk(board, towerIndex)] = 0;
            removedDisk = removedDiskValue;
            return false;
        }

        //Drops disk and returns bool whether its alowed or not
        private static bool dropDisk(int[,] board, int diskValue, int towerIndex)
        {
            if (NextFreeSlot(board, towerIndex) != board.GetLength(1) - 1)
            {
                while (diskValue > board[towerIndex, NextFreeSlot(board, towerIndex) + 1])
                {
                    return true;
                }
            }
            board[towerIndex, NextFreeSlot(board, towerIndex)] = diskValue;
            return false;
        }

        private static int[,] GenerateBoard(int diskAmount)
        {
            int[,] diskArray = new int[3, diskAmount];

            for (int i = 0; i < diskArray.GetLength(1); i++)
            {
                diskArray[0, i] = i + 1;

            }
            return diskArray;
        }



        private static int InputValidation(string input)
        {
            int returnnumber = 0;

            while (returnnumber <= 0)
            {
                
                bool erfolg = int.TryParse(input, out returnnumber);
                if (erfolg)
                {
                    if (returnnumber >= 1 && returnnumber <= 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Only 1,2 or 3 are valid inputs");
                        input = Console.ReadLine();
                        returnnumber = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Only 1,2 or 3 are valid inputs");
                    input = Console.ReadLine();
                }
            }



            return returnnumber - 1;
        }



        private static bool notWon(int[,] spielfeld)
        {
            return spielfeld[2, 0] == 0;
        }

        private static int NextFreeSlot(int[,] arrayToCheck, int towerIndex)
        {
            int i;
            for (i = arrayToCheck.GetLength(1) - 1; i >= 0; i--)
            {
                if (arrayToCheck[towerIndex, i] == 0)
                {
                    break;
                }
            }
            return i;
        }

        private static int NextDisk(int[,] arrayToCheck, int towerIndex)
        {
            int i;
            for (i = 0; i < arrayToCheck.GetLength(1) - 1; i++)
            {
                if (arrayToCheck[towerIndex, i] != 0)
                {
                    break;
                }
            }
            return i;
        }
    }
}
