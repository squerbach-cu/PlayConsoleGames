using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.Connect4
{
    internal class GameStatusC4
    {
        public GameStatusC4()
        {
            Array = new char[6, 7];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] = ' ';
                }
            }
        }
        public char[,] Array { get; set; }

    }

}
