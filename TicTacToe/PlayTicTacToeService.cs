using PlayConsoleGames.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.TicTacToe
{
    internal class PlayTicTacToeService : IGame
    {
        public void HandleInput(ConsoleKeyInfo consoleKeyInfo)
        {
            throw new NotImplementedException();
        }

        public bool HasEnded()
        {
            throw new NotImplementedException();
        }

        public void InitGame()
        {
            throw new NotImplementedException();
        }

        public void InitGame(object saveGame)
        {
            throw new NotImplementedException();
        }

        //Gameplay Loop
        public void PlayGames()
        {
            GameStatusTicTacToe board = new GameStatusTicTacToe();
            IBoardPrinter printer = new CollorfullStaticBoardPrinter();
            GameLogic gameLogic = new GameLogic();
            printer.PrintBoard(board.Array);            
            
            //public static bool CheckWin(char[,] c4array, char activePlayerChar, int dropColumn, int dropRow, int winningNumber)
            char X = 'X';
            char O = 'O';
            char win = '0';
            int movesCount = 0;
            int playerTurn = 0;
            

            while (movesCount < 9 && win == '0')
            {
                if (playerTurn % 2 == 0)
                {
                    win = gameLogic.PutXO(board.Array, X);
                    Console.Clear();
                    printer.PrintBoard(board.Array);
                    movesCount++;
                }
                else if (playerTurn % 2 != 0)
                {
                    win = gameLogic.PutXO(board.Array, O);
                    Console.Clear();
                    printer.PrintBoard(board.Array);
                    movesCount++;
                }
                playerTurn++; 
            }

            if (win == 'X')
            {
                Console.WriteLine("The X player won the game");
            }
            else if (win == 'O')
            {
                Console.WriteLine("The O player won the game");
            }
            else if (movesCount == 9)
            {
                Console.WriteLine("No one managed to Win this Round!");
            }

            
        }

        public void PrintGame()
        {
            throw new NotImplementedException();
        }
    }   
}
