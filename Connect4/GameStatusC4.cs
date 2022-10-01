using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.Connect4
{
    /// <summary>
    /// Game State of Connect 4 it stores everything and will be used to save the game as well.
    /// The Constructor creates two players and creats an Array that serves as the Board
    /// Some properties have a setter, that also puts changes the StateHasChanged Bool on True so that the Printer only prints the 
    /// board when something changes, so that there is no flickering on the console.
    /// </summary>
    internal class GameStatusC4
    {
        private int droppedTokenCounter;
        private bool isInvalidInput;
        private bool isGameWon;
        private bool isFullColumn;
        private bool isBoardFull;

        public GameStatusC4()
        {
            PlayerOne = new Player
            {
                Char = 'X'
            };
            PlayerTwo = new Player
            {
                Char = 'O'
            };
            PlayerOne.IsActive = true;
            StateHasChanged = true;
            Board = new char[6, 7];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = ' ';
                }
            }
        }

        public char[,] Board { get; set; }
        public int DroppedTokenCounter
        {
            get => droppedTokenCounter;
            set
            {
                StateHasChanged = true;
                droppedTokenCounter = value;
            }
        }
        public bool IsInvalidInput
        {
            get => isInvalidInput;
            set
            {
                StateHasChanged = true;
                isInvalidInput = value;
            }
        }
        public bool IsGameWon
        {
            get => isGameWon;
            set
            {
                StateHasChanged = true;
                isGameWon = value;
            }
        }
        public bool IsFullColumn
        {
            get => isFullColumn;
            set
            {
                StateHasChanged = true;
                isFullColumn = value;
            }
        }

        public int LastDropColumn { get; set; }
        public int LastDropRow { get; set; }
        public bool IsBoardFull
        {
            get => isBoardFull;
            set
            {
                StateHasChanged = true;
                isBoardFull = value;
            }
        }
        public bool StateHasChanged { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public Player GetActivePlayer() => PlayerOne.IsActive ? PlayerOne : PlayerTwo;

        public Player GetInactivePlayer() => PlayerOne.IsActive ? PlayerTwo : PlayerOne;

        //the same as above => expression body
        //    if (PlayerOne.IsActive)
        //    {
        //        return PlayerOne;
        //    }
        //    else
        //    {
        //        return PlayerTwo;
        //    }

        /// <summary>
        /// Swaps the bool and therefore changes the activeplayer
        /// </summary>
        public void SwitchActivePlayer()
        {
            PlayerOne.IsActive = !PlayerOne.IsActive;
            PlayerTwo.IsActive = !PlayerTwo.IsActive;
        }

    }

}
