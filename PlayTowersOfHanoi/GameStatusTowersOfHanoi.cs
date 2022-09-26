﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.PlayTowersOfHanoi
{
    internal class GameStatusTowersOfHanoi
    {
        private int removedDisk;
        public GameStatusTowersOfHanoi(int diskAmount)
        {
            Board = new int[3, diskAmount];
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                Board[0, i] = i + 1;
            }
            StateHasChanged = true;
        }
        public int[,] Board { get; set; }
        public int RemovedDisk
        { 
            get => removedDisk;
            set
            {
                StateHasChanged = true;
                removedDisk = value;
            } 
        }
        public bool StateHasChanged { get; set; } 
        public int DiskAmount { get; set; }
        public int UpsideDown { get; set; }
        public int StarOrBang { get; set; }
        public bool InvalidInput { get; set; }
        public IPrintBoardService Printer { get; set; }
        public IPrintDiskService DiskPrinter { get; set; }
        public bool WrongStack { get; set; }
    }
}