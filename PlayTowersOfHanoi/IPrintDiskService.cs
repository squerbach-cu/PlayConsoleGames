namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public interface IPrintDiskService
    {
        /// <summary>
        /// Generates a string that represents a disk in the towers of hanoi
        /// </summary>
        /// <param name="diskMaxAmount"></param>
        /// <param name="diskToPrint"></param>
        /// <returns></returns>
        string GenerateVisualDisk(int diskMaxAmount, int diskToPrint);
    }
}
