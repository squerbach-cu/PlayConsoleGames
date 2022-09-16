using System;
using PlayConsoleGames.Connect4;
using PlayConsoleGames.PlayTowersOfHanoi;
using PlayConsoleGames.TicTacToe;

namespace PlayConsoleGames
{

    internal class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            engine.run();
        } 
    }
}
