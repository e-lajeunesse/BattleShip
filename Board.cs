using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Board
    {
            
        public string letters = "  A  B  C  D  E  F  G  H  I  J";
        public string[,] board = new string[10, 10];
       
        public void DisplayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = " . ";
                }
            }


            Console.WriteLine(letters);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i, j]}");
                }
                Console.WriteLine();
            }
        }






    }
}
