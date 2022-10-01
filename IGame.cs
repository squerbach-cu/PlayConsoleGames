using System;

namespace PlayConsoleGames
{
    internal interface IGame
    {
        //Interface that implements all three games and offers the ability to save
        /// <summary>
        /// Print the board and game massages
        /// </summary>
        void PrintGame();
        /// <summary>
        /// Handels the input by either placing "tokens, disks, etc" or saving the game.
        /// </summary>
        /// <param name="consoleKeyInfo"></param>
        void HandleInput(ConsoleKeyInfo consoleKeyInfo);
        /// <summary>
        /// Initialises the game by asking for user input and storing it in the Game State.
        /// </summary>
        void InitGame();
        /// <summary>
        /// Checks if a game has ended, by either someone winning, or the board being full.
        /// </summary>
        /// <returns></returns>
        bool HasEnded();
        /// <summary>
        /// Initialises the game by loading a Json file into the Game State.
        /// </summary>
        /// <param name="saveGame"></param>
        void InitGame(object saveGame);
    }
}
