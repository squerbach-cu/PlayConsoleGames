using System;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PrintBoardReverseService : IPrintBoardService
    {
        private readonly IPrintDiskService _printDiskService;

        public PrintBoardReverseService(IPrintDiskService printDiskService)
        {
            _printDiskService = printDiskService;
        }

        public void PrintBoard(int[,] currentDiskPlacementArray)
        {
            for (int slot = currentDiskPlacementArray.GetLength(1) - 1; slot >= 0; slot--)
            {
                for (int stack = 0; stack < currentDiskPlacementArray.GetLength(0); stack++)
                {
                    Console.Write(_printDiskService.GenerateVisualDisk(currentDiskPlacementArray.GetLength(1), currentDiskPlacementArray[stack, slot]));
                }
                Console.WriteLine();
            }
        }
    }
}
