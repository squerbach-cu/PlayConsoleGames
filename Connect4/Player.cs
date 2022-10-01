namespace PlayConsoleGames.Connect4
{
    /// <summary>
    /// A Class that stores the Name Char and weather or not its Active
    /// The Active player is the one that will drop the next token.
    /// </summary>
    internal class Player
    {
        public string Name { get; set; }
        public char Char { get; set; }
        public bool IsActive { get; set; }
    }
}
