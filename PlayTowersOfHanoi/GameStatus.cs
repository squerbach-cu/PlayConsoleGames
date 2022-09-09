using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    internal class GameStatus
    {
        public int[,] TowersOfHanoiBoard { get; set; }
        public int removedDisk { get; set; }

        //star or bang 
        //upsidedown or normal

    }
}
