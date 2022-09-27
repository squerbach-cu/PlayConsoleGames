using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class GameStatusTicTacToe
    {
        private bool isFull;
        private bool spaceIsFull;
        private char[,] board;
        private bool isWon;

        public GameStatusTicTacToe()
        {
            PlayerOne = new Player
            {
                Char = 'X'
            };
            PlayerTwo = new Player
            {
                Char = 'O'
            };
            Board = new char[3, 3];
            int k = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = Convert.ToChar(Convert.ToString(k++));
                }
            }
        }

        public bool StateHasChanged { get; set; }         
        public char[,] Board
        {
            get => board;
            set
            {
                StateHasChanged = true;
                board = value;
            }
        }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public bool IsWon
        {
            get => isWon;
            set
            {
                StateHasChanged = true;
                isWon = value;
            }
        }
        public int PrinterIndex { get; set; }
        public IBoardPrinter Printer { get; set; }
        public bool SpaceIsFull
        {
            get => spaceIsFull;
            set
            {
                StateHasChanged = true;
                spaceIsFull = value;
            }
        }
        public bool IsFull
        {
            get => isFull;
            set
            {
                StateHasChanged = true;
                isFull = value;
            }
        }

        public Player GetActivePlayer() => PlayerOne.IsActive ? PlayerOne : PlayerTwo;
        public Player GetInactivePlayer() => PlayerOne.IsActive ? PlayerTwo : PlayerOne;       
        public void SwitchActivePlayer()
        {
            PlayerOne.IsActive = !PlayerOne.IsActive;
            PlayerTwo.IsActive = !PlayerTwo.IsActive;
        }

    }
}