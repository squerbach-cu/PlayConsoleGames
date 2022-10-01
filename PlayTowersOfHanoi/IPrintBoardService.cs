namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public interface IPrintBoardService
    {
        /// <summary>
        /// Interface that implements multiple variations of output, that can be chosen by the user.
        /// </summary>
        /// <param name="board"></param>
        void PrintBoard(int[,] board);
    }
}
