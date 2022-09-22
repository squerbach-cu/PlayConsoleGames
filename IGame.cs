using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
