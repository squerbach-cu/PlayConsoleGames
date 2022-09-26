using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.TicTacToe
{
    internal class GameStatusTicTacToe
    {
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
        public char[,] Board { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public bool IsFull { get; set; }
        public bool IsWon { get; set; }
        public int PrinterIndex { get; set; }
        public IBoardPrinter Printer { get; set; }
        public bool SpaceFull { get; internal set; }

        public Player GetActivePlayer() => PlayerOne.IsActive ? PlayerOne : PlayerTwo;
        public Player GetInactivePlayer() => PlayerOne.IsActive ? PlayerTwo : PlayerOne;       
        public void SwitchActivePlayer()
        {
            PlayerOne.IsActive = !PlayerOne.IsActive;
            PlayerTwo.IsActive = !PlayerTwo.IsActive;
        }

    }
}