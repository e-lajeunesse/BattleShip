using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Board
    {

        public string letters = "  A  B  C  D  E  F  G  H  I  J";
        public Point[,] board = new Point[10, 10];

        
        // needed separate method since everytime you use DisplayBoard it would change all points back to '.'
        public void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Point();
                    board[i, j].DisplayString = " . ";
                }
            }

        }
        public void DisplayBoard()
        {

            
            Console.WriteLine(letters);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i, j].DisplayString}");
                }
                Console.WriteLine();
            }
        }






    }
}
