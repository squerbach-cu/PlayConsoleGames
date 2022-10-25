namespace PlayConsoleGames.PlayTowersOfHanoi
{
    internal class GameStatusTowersOfHanoi
    {
        private int removedDisk;
        /// <summary>
        /// Object that saves all relevant information about the game 
        /// gets initialiesed with the amount of disks the player enters
        /// </summary>
        /// <param name="diskAmount"></param>
        public GameStatusTowersOfHanoi(int diskAmount)
        {
            Board = new int[3, diskAmount];
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                Board[0, i] = i + 1;
            }
            StateHasChanged = true;
        }
        public int[,] Board { get; set; }
        public int RemovedDisk
        { 
            get => removedDisk;
            set
            {
                StateHasChanged = true;
                removedDisk = value;
            } 
        }
        public bool StateHasChanged { get; set; } 
        public int DiskAmount { get; set; }
        public int UpsideDown { get; set; }
        public int StarOrBang { get; set; }
        public bool InvalidInput { get; set; }
        public IPrintBoardService Printer { get; set; }
        public IPrintDiskService DiskPrinter { get; set; }
        public bool WrongStack { get; set; }
    }
}
