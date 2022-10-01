namespace PlayConsoleGames
{

    internal class Program
    {
        /// <summary>
        /// The Main method is the entry point of a C# application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            engine.run();
        } 
    }
}
