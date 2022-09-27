using System;

namespace PlayConsoleGames.TicTacToe
{
    internal class StaticBoardPrinter : IBoardPrinter
    {
        
        public void PrintBoard(char[,] arr)
        {
            Console.Clear();
            Console.WriteLine($" {arr[0,0]} | {arr[0,1]} | {arr[0,2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {arr[1,0]} | {arr[1,1]} | {arr[1,2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {arr[2,0]} | {arr[2,1]} | {arr[2,2]} ");
            
        } 
    }
}
