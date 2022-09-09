using PlayConsoleGames.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayConsoleGames.TicTacToe
{
    internal class GameLogic
    {
        
        public char PutXO(char[,] board, char activePlayerChar)
        {
            Console.Write($"Where do you want to put an {activePlayerChar}?: ");
            int XO = InputValidationService.InputValidation(Console.ReadLine());
            int winCount = 3;
            int countToNine = 1;           
            


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (countToNine == XO)
                    {
                        if (board[i, j] != 'X' && board[i, j] != 'O')
                        {
                            board[i, j] = activePlayerChar;
                        }
                        else
                        {
                            Console.WriteLine("You can't put another X or O there!");
                            PutXO(board, activePlayerChar);
                        } 

                        if (WinValidation.CheckWin(board, activePlayerChar, j, i, winCount))
                        {
                            return activePlayerChar; 
                        }
                        return '0';
                    }
                    countToNine++;
                }                
            }
            return '0';
        }        
    }
}
