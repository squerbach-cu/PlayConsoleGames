using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.TicTacToe
{
    public class GameStatusTicTacToe
    {
        public GameStatusTicTacToe()
        {
            Array = new char[3, 3];
            int k = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Array[i, j] = Convert.ToChar(Convert.ToString(k++));
                }
            }
        }
        public char[,] Array { get; set; }
    }
}