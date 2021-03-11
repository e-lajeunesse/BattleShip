using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Board
    {

        public string letters = "  A  B  C  D  E  F  G  H  I  J";
        public Point[,] board = new Point[10, 10];

        public Dictionary<ValueTuple<int,int>, Ship> ShipTracker { get; set; } = 
            new Dictionary<ValueTuple<int,int>, Ship>();



        // Method to initialize board with points        
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

        //Method to display board to console
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

                    if( board[i,j].DisplayString == " M ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (board[i, j].DisplayString == " H ")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (board[i, j].DisplayString == " S ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.Write($"{board[i, j].DisplayString}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine();
            }
        }

        






    }
}
