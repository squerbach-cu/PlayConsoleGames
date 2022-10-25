using Newtonsoft.Json.Linq;
using PlayConsoleGames.Tools;
using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class PlayTicTacToeService : IGame
    {
        private GameStatusTicTacToe _gameState;
        private InputValidationService _validationService;
        private const int WIN_COUNT = 3;        

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
            if (_gameState.IsFull || _gameState.IsWon)
            {
                return true;
            } 
            return false;
        }

        public void InitGame()
        {
            
            Console.Clear();
            Console.WriteLine("You are now playing the TicTacToe!");
            _validationService = new InputValidationService();
            _gameState = new GameStatusTicTacToe();

            int printerIndex;
            Console.Write("How do you want your game printed, colorful(1), dynamic(2) or static(3)? ");
            while (!_validationService.ValdiateInt(Console.ReadLine(), 1, 3, out printerIndex))
            {
                Console.Write("Enter 1,2 or 3: ");
            }
            _gameState.PrinterIndex = printerIndex;
            _gameState.StateHasChanged = true;
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


        private void PutXO(int space1To9)
        {
            int countToNine = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (countToNine == space1To9)
                    {
                        if (_gameState.Board[i, j] != 'X' && _gameState.Board[i, j] != 'O')
                        {
                            _gameState.Board[i, j] = _gameState.GetActivePlayer().Char;
                            _gameState.SpaceIsFull = false;
                            _gameState.SwitchActivePlayer();
                            
                            WinValidation winValidation = new WinValidation(WIN_COUNT);
                             
                            _gameState.IsWon = winValidation.CheckWin(_gameState.Board, _gameState.GetInactivePlayer().Char, j, i);
                        }
                        else
                        {
                            _gameState.SpaceIsFull = true;
                            return;
                        } 
                    }
                    countToNine++;
                }
            }            
        }

        public void PrintGame()
        {
            if (!_gameState.StateHasChanged)
            {
                return;
            }
            _gameState.StateHasChanged = false;
            Console.Clear();
            _gameState.Printer.PrintBoard(_gameState.Board);

            if (_gameState.SpaceIsFull)
            {
                Console.WriteLine("You can't put your {0} there. Please try again",_gameState.GetActivePlayer().Char);
            }
            if (_gameState.IsFull)
            {
                Console.WriteLine("The board is full, no one managed to win");
            }
            if (_gameState.IsWon)
            {
                Console.WriteLine("The player who put {0}s won the game",_gameState.GetInactivePlayer().Char);
            }
        }

        private void InitPrinter()
        {
            switch (_gameState.PrinterIndex)
            {
                case 1:
                    _gameState.Printer = new ColorfulStaticBoardPrinter();
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
