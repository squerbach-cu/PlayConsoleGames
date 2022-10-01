using Newtonsoft.Json.Linq;
using PlayConsoleGames.Tools;
using System;

namespace PlayConsoleGames.Connect4
{
    ///<inheritdoc /> 
    public class PlayConnect4Service : IGame
    {
        private readonly WinValidation _winValidation;
        public PlayConnect4Service()
        {
            _winValidation = new WinValidation(WIN_COUNT);
        }
        private GameStatusC4 _gameState;
        private const int WIN_COUNT = 4;
        
        
        public void PrintGame()
        {
            if (!_gameState.StateHasChanged)
            {
                return;
            }
                
            _gameState.StateHasChanged = false;
            Console.Clear();

            for (int i = 0; i < _gameState.Board.GetLength(0); i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+");
                for (int j = 0; j < _gameState.Board.GetLength(1); j++)
                {
                    Console.Write("| {0} ", _gameState.Board[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+---+---+---+---+---+---+---+");
            Console.WriteLine("+ 1 + 2 + 3 + 4 + 5 + 6 + 7 +");
            Console.WriteLine("{0} please enter a Number, to drop a {1}", _gameState.GetActivePlayer().Name, _gameState.GetActivePlayer().Char);
            if (_gameState.IsInvalidInput)
            {
                Console.WriteLine("Your input was invalid");
            }
            if (_gameState.IsFullColumn)
            {
                Console.WriteLine("This collumn is full");
            }
            if (_gameState.IsBoardFull)
            {
                Console.WriteLine("The board is full, no one managed to win!");
            }
            if (_gameState.IsGameWon)
            {
                Console.WriteLine("{0} won the game by connecting four {1}", _gameState.GetActivePlayer().Name, _gameState.GetActivePlayer().Char);
            }                
                        
        }        

        public bool HasEnded()
        {
            
            if (_gameState.DroppedTokenCounter == 42)
            {
                _gameState.IsBoardFull = true;                
                return true;
            }
            else if (_winValidation.CheckWin(_gameState.Board, _gameState.GetInactivePlayer().Char, _gameState.LastDropColumn, _gameState.LastDropRow))
            {
                _gameState.IsGameWon = true;                
                return true;
            }
            else
            {
                return false;                 
            }
        }

        public void InitGame(object saveGame)
        {
            var test = (JObject)saveGame;
            var test2 = test.ToObject<GameStatusC4>();
            _gameState = test2;
            _gameState.StateHasChanged = true;
        }

        public void InitGame()
        {
            Console.Clear();
            Console.WriteLine("You are now playing the Connect Four!");

            _gameState = new GameStatusC4();            

            Console.Write("Enter name of player ONE: ");
            _gameState.PlayerOne.Name = Console.ReadLine();


            Console.Write("Enter name of player TWO: ");
            _gameState.PlayerTwo.Name = Console.ReadLine();
        }

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
                int dropColumn = Convert.ToInt32(char.ToString(consoleKeyInfo.KeyChar));
                if (dropColumn >= 1 && dropColumn <= 7)
                {
                    DropToken(dropColumn-1); 
                }
            }
            
        }

        //asks where to drop a token and then changes the _gameState array with the char of the active player
        //if the stack is full nothing changes and the game will return to the GameEngine and wait for another user input
        private void DropToken(int dropColumn)
        {
            if (IsFull(dropColumn))
            {
                _gameState.IsFullColumn = true;                
                return;
            }
            else
            {
                int dropRow = NextFreeSlot(_gameState.Board, dropColumn);
                _gameState.Board[dropRow, dropColumn] = _gameState.GetActivePlayer().Char;
                
                _gameState.LastDropColumn = dropColumn;
                _gameState.LastDropRow = dropRow;
                _gameState.DroppedTokenCounter++;                
                _gameState.SwitchActivePlayer();
                return;
            }
        }
        private bool IsFull(int stackIndex)
        {
            char[,] arrayToCheck = _gameState.Board;
            if (arrayToCheck[0, stackIndex] == ' ')
            {
                return false;
            }
            return true;
        }
        private static int NextFreeSlot(char[,] arrayToCheck, int stackIndex)
        {
            int i;
            for (i = (arrayToCheck.GetLength(0) - 1); i >= 0; i--)
            {
                if (arrayToCheck[i, stackIndex] == ' ')
                {
                    break;
                }
            }
            return i;
        }
    }    
}
