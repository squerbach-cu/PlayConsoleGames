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
            Console.Write("Play Connect Four(1), Towers Of Hanoi(2) or Tic Tac Toe(3)?: ");
            int gameIndex = Convert.ToInt32(Console.ReadLine());

            IPlayGamesService gameService;

            switch (gameIndex)
            {
                case 1:
                    gameService = new PlayConnect4Service();                    
                    break;

                case 2:
                    gameService = new PlayTowersOfHanoiService();                    
                    break;

                case 3:
                    gameService = new PlayTicTacToeService();                    
                    break;

                default:
                    Console.WriteLine("Invalid input!");
                    Main(args);
                    return;
            }
            gameService.PlayGames();
        } 
    }
}
