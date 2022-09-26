using Newtonsoft.Json.Linq;
using PlayConsoleGames.Tools;
using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class PlayTicTacToeService : IGame
    {
        private GameStatusTicTacToe _gameState;
        public void HandleInput(ConsoleKeyInfo consoleKeyInfo)
        {
            if (char.IsLetter(consoleKeyInfo.KeyChar))
            {
                if (consoleKeyInfo.KeyChar == 's')
                {
                    SaveGame saveGame = new SaveGame();
                    saveGame.SaveToMedium(_gameState);
                    Console.WriteLine("Game has been saved!");
                    Environment.Exit(0);
                }
            }
            if (char.IsDigit(consoleKeyInfo.KeyChar))
            {
                int dropSpace = Convert.ToInt32(char.ToString(consoleKeyInfo.KeyChar));
                if (dropSpace >= 1 && dropSpace <= 9)
                {
                    PutXO(dropSpace - 1);
                }
            }
        }

        public bool HasEnded()
        {
            if (_gameState.IsFull)
            {
                return true;
            }

            WinValidation winValidation = new WinValidation();

            int winCount = 3;
            if (winValidation.CheckWin(_gameState.Board, XOSpace, j, i, winCount))
            {

            }
            

            return _gameState.IsWon;
        }

        public void InitGame()
        {
            _gameState = new GameStatusTicTacToe();
            _gameState.PrinterIndex = Convert.ToInt32(Console.ReadLine());
            InitPrinter();
        }

        public void InitGame(object saveGame)
        {
            var test = (JObject)saveGame;
            var test2 = test.ToObject<GameStatusTicTacToe>();
            _gameState = test2;
            _gameState.StateHasChanged = true;
            InitPrinter();
        }

        //Gameplay Loop
        public void PlayGames()
        {
             
            //public static bool CheckWin(char[,] c4array, char activePlayerChar, int dropColumn, int dropRow, int winningNumber)
            char X = 'X';
            char O = 'O';
            char win = '0';
            
            

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
        }

        private void PutXO(int space1To9)
        {
            char XOSpace = Convert.ToChar(space1To9);
            int countToNine = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (countToNine == XOSpace)
                    {
                        if (_gameState.Board[i, j] != 'X' && _gameState.Board[i, j] != 'O')
                        {
                            _gameState.Board[i, j] = _gameState.GetActivePlayer().Char;
                            _gameState.SpaceFull = false;                            
                        }
                        else
                        {
                            _gameState.SpaceFull = true;
                            return;
                        } 
                    }
                    countToNine++;
                }
            }            
        }

        public void PrintGame()
        {
            _gameState.Printer.PrintBoard(_gameState.Board);
        }

        private void InitPrinter()
        {
            switch (_gameState.PrinterIndex)
            {
                case 1:
                    _gameState.Printer = new CollorfullStaticBoardPrinter();
                    break;
                
                case 2:
                    _gameState.Printer = new DynamicBoardPrinter();
                    break;

                case 3:
                    _gameState.Printer = new StaticBoardPrinter();
                    break;        
            } 
        }
    }   
}
