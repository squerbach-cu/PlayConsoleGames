using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.TicTacToe
{
    internal interface IBoardPrinter
    {
        void PrintBoard(char[,] board);        
    }
}
