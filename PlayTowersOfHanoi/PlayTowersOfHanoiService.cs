using Newtonsoft.Json.Linq;
using PlayConsoleGames.Tools;
using System;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    public class PlayTowersOfHanoiService : IGame
    {
        private GameStatusTowersOfHanoi _gameState;
        public void InitGame()
        {
            Console .Clear();
            Console.WriteLine("You are now playing the Towers Of Hanoi!");

            InputValidationService validationService = new InputValidationService();

            Console.Write("Disk amount: ");
            int diskAmount;
            while (!validationService.ValdiateInt(Console.ReadLine(), 1, Int32.MaxValue, out diskAmount))
            {
                Console.Write("Enter a number: ");
            }
            _gameState = new GameStatusTowersOfHanoi(diskAmount);
            _gameState.DiskAmount = diskAmount;


            Console.Write("Print the towers normal(1) or upside down?(2)? ");
            int upsideDown;
            while (!validationService.ValdiateInt(Console.ReadLine(), 1, 2, out upsideDown))
            {
                Console.Write("Enter 1 or 2: ");
            }
            _gameState.UpsideDown = upsideDown;


            Console.Write("Print the towers with stars(1) or bangs?(2)? ");
            int starsBangs;
            while (!validationService.ValdiateInt(Console.ReadLine(), 1, 2, out starsBangs))
            {
                Console.Write("Enter 1 or 2: ");
            }
            _gameState.StarOrBang = starsBangs;

            InitPrinter();
        }        

        private void InitPrinter()
        {
            DiskDisplayType starOrBang = (DiskDisplayType)_gameState.StarOrBang;

            if (starOrBang == DiskDisplayType.Star)
            {
                _gameState.DiskPrinter = new PrintDiskStarService();
            }
            else if (starOrBang == DiskDisplayType.Bang)
            {
                _gameState.DiskPrinter = new PrintDiskBangService();
            }

            if (_gameState.UpsideDown == 1)
            {
                _gameState.Printer = new PrintBoardNormalService(_gameState.DiskPrinter);
            }
            else if (_gameState.UpsideDown == 2)
            {
                _gameState.Printer = new PrintBoardReverseService(_gameState.DiskPrinter);
            }
        }

        public void InitGame(object saveGame)
        {
            var test = (JObject)saveGame;
            var test2 = test.ToObject<GameStatusTowersOfHanoi>();
            _gameState = test2;            
            _gameState.StateHasChanged = true;
            InitPrinter();
        }

        public void PrintGame()
        {
            if (!_gameState.StateHasChanged)
            {
                return;
            }
            Console.Clear();
            _gameState.Printer.PrintBoard(_gameState.Board);
            Console.WriteLine("1      2      3");
            if (_gameState.InvalidInput)
            {
                Console.WriteLine("Invalid Input");
            }
            if (_gameState.WrongStack)
            {
                Console.WriteLine("You can't take from this stack or put a disk there");
            }
            _gameState.StateHasChanged = false;            
        }                

        //takes a disk and returns bool if it was successful
        private void TakeDisk(int towerIndex)
        {
            int counter;            
            
            if (_gameState.Board[towerIndex, counter = NextDisk(towerIndex)] == 0)
            {
                return;                
            }

            int removedDiskValue = _gameState.Board[towerIndex, NextDisk(towerIndex)];
            _gameState.Board[towerIndex, NextDisk(towerIndex)] = 0;
            _gameState.RemovedDisk = removedDiskValue;            
        }

        //Drops disk and returns bool whether its alowed or not
        private void DropDisk(int towerIndex)
        {
            if (NextFreeSlot(towerIndex) != _gameState.Board.GetLength(1) - 1)
            {
                if (_gameState.RemovedDisk > _gameState.Board[towerIndex, NextFreeSlot(towerIndex) + 1])
                {
                    return;
                }
            }
            _gameState.Board[towerIndex, NextFreeSlot(towerIndex)] = _gameState.RemovedDisk;
            _gameState.RemovedDisk = 0;
        }        

        private int NextFreeSlot(int towerIndex)
        {
            int i;
            for (i = _gameState.Board.GetLength(1) - 1; i >= 0; i--)
            {
                if (_gameState.Board[towerIndex, i] == 0)
                {
                    break;
                }
            }
            return i;
        }

        private int NextDisk(int towerIndex)
        {
            int i;
            for (i = 0; i < _gameState.Board.GetLength(1) - 1; i++)
            {
                if (_gameState.Board[towerIndex, i] != 0)
                {
                    break;
                }
            }
            return i;
        }     

        public bool HasEnded()
        {
            return _gameState.Board[2, 0] != 0;
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
                int dropOrTakeTower = Convert.ToInt32(char.ToString(consoleKeyInfo.KeyChar));
                if (dropOrTakeTower >= 1 && dropOrTakeTower <= 3)
                {
                    if (_gameState.RemovedDisk != 0)
                    {
                        DropDisk(dropOrTakeTower - 1);
                    }
                    else
                    {
                        TakeDisk(dropOrTakeTower - 1);
                    }
                    _gameState.InvalidInput = false;
                }
            }
            else _gameState.InvalidInput = true;            
        }        
    }
}
