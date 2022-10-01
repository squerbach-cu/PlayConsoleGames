namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PrintDiskStarService : IPrintDiskService
    {
        // </inheritdoc>        
        public string GenerateVisualDisk(int diskMaxAmount, int diskToPrint)
        {
            string outputString = diskToPrint.ToString();
            const string diskBroadnessVisual = "*";
            const string diskBroadnessVisual2 = " ";
            int difference = diskMaxAmount - diskToPrint;
            // If the diskToPrint value is 0 the method just adds spaces till the lenght of the string is diskMaxAmount
            if (diskToPrint == 0)
            {
                outputString = " ";
                for (int i = 0; i < diskMaxAmount; i++)
                {
                    outputString = diskBroadnessVisual2 + outputString + diskBroadnessVisual2;
                }
            }
            //These Loops will add diskVisuals(*) till the diskToPrint value is matched
            //then it will add spaces till the diskMaxAmount value is met, so all disk strings have the same lenght.
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
