using System;

namespace TowersOfHanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Amount: ");
            int amountDisks = Convert.ToInt32(Console.ReadLine());
            int[,] currentDiskPlacement = GenerateBoard(amountDisks);
            PrintCurrentBoard(currentDiskPlacement);
            
            while (notWon(currentDiskPlacement))
            {
                Console.Write("Take form stack 1/2/3: ");
                int diskToRemoveIndex = InputValidation(Console.ReadLine());
                int removedDisk = takeDisk(currentDiskPlacement, diskToRemoveIndex);

                Console.Clear();
                PrintCurrentBoard(currentDiskPlacement);

                Console.Write("Put onto stack 1/2/3?: ");
                int stackToPutOnIndex = InputValidation(Console.ReadLine());
                dropDisk(currentDiskPlacement, stackToPutOnIndex, removedDisk);

                Console.Clear();
                PrintCurrentBoard(currentDiskPlacement);
            }
            Console.WriteLine("Against all odds your did indeed win!");
        }

        public static int takeDisk(int[,]board,int towerIndex)
        {
            int counter;
            while (board[towerIndex, counter = NextDisk(board, towerIndex)] == 0)
            {
                Console.Write("Try again: ");
                towerIndex = InputValidation(Console.ReadLine());               
            }            
            int removedDiskValue = board[towerIndex, NextDisk(board, towerIndex)];
            board[towerIndex, NextDisk(board, towerIndex)] = 0;
            return removedDiskValue;
        }

        public static void dropDisk(int[,]board,int towerIndex, int diskValue)
        {
            if (NextFreeSlot(board, towerIndex) != board.GetLength(1)-1)
            {
                while (diskValue > board[towerIndex, NextFreeSlot(board, towerIndex) + 1])
                {
                    Console.Write("Try again: ");
                    towerIndex = InputValidation(Console.ReadLine());

                    dropDisk(board, towerIndex, diskValue);
                    return;
                }
            }

            board[towerIndex, NextFreeSlot(board, towerIndex)] = diskValue;
        }

        public static int[,] GenerateBoard(int diskAmount)
        {
            int[,] diskArray = new int[3, diskAmount];

            for (int i = 0; i < diskArray.GetLength(1); i++)
            {
                diskArray[0, i] = i + 1;

            }
            return diskArray;
        }

        public static string GenerateVisualDisk(int diskMaxAmount, int diskToPrint)
        {
            
            string outputString = diskToPrint.ToString();
            const string diskBroadnessVisual = "*";
            const string diskBroadnessVisual2 = " ";            
            int difference = diskMaxAmount - diskToPrint;
            if (diskToPrint == 0)
            {
                outputString = " ";
                for (int i = 0; i < diskMaxAmount; i++)
                {
                    outputString = diskBroadnessVisual2 + outputString + diskBroadnessVisual2;
                }
            }
            else
            {
                for (int i = 0; i < diskToPrint; i++)
                {
                    outputString = diskBroadnessVisual + outputString + diskBroadnessVisual;
                }
                for (int i = 0; i < difference; i++)
                {
                    outputString = diskBroadnessVisual2 + outputString + diskBroadnessVisual2;
                }
            }
            return outputString;
        }

        public static int InputValidation(string input)
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

        public static void PrintCurrentBoard(int[,] currentDiskPlacementArray)
        {
            for (int slot = 0; slot < currentDiskPlacementArray.GetLength(1); slot++)
            {
                for (int stack = 0; stack < currentDiskPlacementArray.GetLength(0); stack++)
                {
                    Console.Write(GenerateVisualDisk(currentDiskPlacementArray.GetLength(1), currentDiskPlacementArray[stack, slot]));
                }
                Console.WriteLine();
            }
        }

        public static bool notWon(int[,] spielfeld)
        {
            return spielfeld[2, 0] == 0;            
        }

        public static int NextFreeSlot(int[,] arrayToCheck, int towerIndex)
        {
            int i;
            for (i = (arrayToCheck.GetLength(1)-1); i >= 0; i--)
            {
                if (arrayToCheck[towerIndex, i] == 0)
                {
                    break;
                }
            }
            return i ;
        }

        public static int NextDisk(int[,] arrayToCheck, int towerIndex)
        {
            int i;
            for (i = 0; i < (arrayToCheck.GetLength(1) - 1); i++)
            {
                if (arrayToCheck[towerIndex, i] != 0)
                {
                    break;
                }
            }
            return i ;
        } 
    }
}
