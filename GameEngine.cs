using PlayConsoleGames.Connect4;
using PlayConsoleGames.PlayTowersOfHanoi;
using PlayConsoleGames.TicTacToe;
using System;
using System.IO;
using System.Threading;

namespace PlayConsoleGames
{
    internal class GameEngine
    {
        public void run()
        {
            ISave load = new SaveGame();
            IGame game;
            bool loadedGame = false;
            int gameIndex = 0;

            var dir = Environment.CurrentDirectory;
            if (File.Exists(dir + "\\Savegame.json"))
            {
                gameIndex = load.GetGameIndex();
                loadedGame = true;
            }



            #region advanced stuff
            //var gametypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => typeof(IGame).IsAssignableFrom(p) && p != typeof(IGame)).ToArray();

            //Console.WriteLine("What game do you want to play?: ");

            //for (var i = 0; i < gametypes.Length; i++)
            //{
            //    Console.WriteLine($"{gametypes[i].Name} ({i + 1})");
            //}

            //int gameIndex = Convert.ToInt32(Console.ReadLine());
            //IGame game = (IGame)Activator.CreateInstance(gametypes[gameIndex - 1]);
            #endregion

            if (!loadedGame)
            {
                //welches spiel soll gespielt werden
                Console.WriteLine("Towers of Hanoi(1), Connect Four(2), TicTacToe(3)");
                Console.Write("What game do you want to play?: ");
                gameIndex = Convert.ToInt32(Console.ReadLine());                 
            }            

            switch (gameIndex)
            {
                case 1:
                    game = new PlayTowersOfHanoiService();
                    break;

                case 2:
                    game = new PlayConnect4Service();
                    break;

                case 3:
                    game = new PlayTicTacToeService();
                    break;

                default:
                    Console.WriteLine("Invalid input!");
                    return;
            }

            if (loadedGame)
            {
                game.InitGame(load.LoadFromMedium());
            }
            else
            {
                game.InitGame();
            }        

            while (true)
            {
                game.PrintGame();

                Thread.Sleep(1000/60);                

                if (Console.KeyAvailable)
                {
                    game.HandleInput(Console.ReadKey());
                } 

                if (game.HasEnded())
                {
                    game.PrintGame();
                    break;
                } 
            }

        }
    }
}
