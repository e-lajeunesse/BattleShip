using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class GameUI
    {
        // Game is played by two players. Each player has their own 5x5 board.
        // At the start of the game each player chooses where to place their ships
        // The players take turns guessing where the other player's ships are on their board.

        public void NewGame()
        {
            Player playerOne = new Player();
            Player playerTwo = new Player();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n*************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     BATTLESHIP GAME!!!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Player 1: {playerOne.Score}      Player 2: {playerTwo.Score}\n\n");
            Board board = new Board();
            board.DisplayBoard();
            PlaceShip();
        }

        public void PlaceShip()
        {
            Console.WriteLine("\nEnter where you want to place your ship: ");
            string playerChoice = Console.ReadLine();
        }
    }

}

    
