using PlayConsoleGames.Connect4;
using PlayConsoleGames.PlayTowersOfHanoi;
using PlayConsoleGames.TicTacToe;
using PlayConsoleGames.Tools;
using System;
using System.IO;
using System.Threading;

namespace PlayConsoleGames
{
    internal class GameEngine
    {
        public void run()
        {
            //The input validator will be used to verify that a existing game is selected 
            InputValidationService inputValidation = new InputValidationService();
            //The SaveGame instance will be used to check for a safegame and get the index of the game, if it exists.
            //the loadedGame variable is used the later init the game the correct way.
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
                //Guten Tag
                Console.WriteLine("Welcome! to THE game browser\n");
                Console.WriteLine("You navigate the games by pressing 1 to 3, 7 or 9 on your keyboard");
                Console.WriteLine("When pressing 's' on your keyboard you can safe at any time.");
                Console.WriteLine("When you open the game again the saved state will load.\n");

                //gets a game index from the user
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Towers of Hanoi(1),");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Connect Four(2),");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TicTacToe(3)");
                Console.ResetColor();

                Console.Write("What game do you want to play? Press 1, 2 or 3: ");                
                while (!inputValidation.ValdiateInt(Console.ReadLine(), 1, 3, out gameIndex))
                {
                    Console.Write("Only 1,2 or 3 are valid inputs: ");
                } 
            }            

            //uses the gameIndex to create a instance of the selected game 
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
                    Console.WriteLine("Something went wroooong!");
                    return;
            }

            //if there is a savegame the game will be initialized  with the _gameState from a Json
            //otherwise it will be initialize without a savegame and ask for userinput
            if (loadedGame)
            {
                game.InitGame(load.LoadFromMedium());
            }
            else
            {
                game.InitGame();
            }        

            //main gameplay loop that will run will till HasEnded is true 
            //and will "listen" for a key input
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
