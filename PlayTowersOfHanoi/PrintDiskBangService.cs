namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PrintDiskBangService : IPrintDiskService
    {
        public string GenerateVisualDisk(int diskMaxAmount, int diskToPrint)
        {

            string outputString = diskToPrint.ToString();
            const string diskBroadnessVisual = "!";
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
    }
}
