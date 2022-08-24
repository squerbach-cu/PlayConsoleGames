using System;

namespace TowersOfHanoi
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IPlayGamesService gameService = new PlayTowersOfHanoiService();
            gameService.PlayGames();

        } 
    }
}
