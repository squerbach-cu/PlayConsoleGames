using System;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PrintBoardNormalService : IPrintBoardService
    {
        private IPrintDiskService _printDiskService;

        public PrintBoardNormalService(IPrintDiskService printDiskService)
        {
            _printDiskService = printDiskService;
        }

        public void PrintBoard(int[,] currentDiskPlacementArray)
        {
            for (int slot = 0; slot < currentDiskPlacementArray.GetLength(1); slot++)
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
