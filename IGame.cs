using System;

namespace PlayConsoleGames
{
    internal interface IGame
    {
        void PrintGame();
        void HandleInput(ConsoleKeyInfo consoleKeyInfo);
        void InitGame();
        bool HasEnded();
        void InitGame(object saveGame);
    }
}
