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
        private Player playerOne = new Player();
        private Player playerTwo = new Player();
        public void NewGame()
        {
            Board playerOneBoard = new Board();
            DisplayTitle();             
            playerOneBoard.FillBoard();
            playerOneBoard.DisplayBoard();
            playerOne.PlaceShip(playerOne.shipOne, playerOneBoard);     
            DisplayTitle();
            playerOneBoard.DisplayBoard();
            playerOne.PlaceShip(playerOne.shipTwo, playerOneBoard);
            DisplayTitle();
            playerOneBoard.DisplayBoard();
            Console.ReadKey();


            Board playerTwoBoard = new Board();
            DisplayTitle();
            playerTwoBoard.FillBoard();
            playerTwoBoard.DisplayBoard();
            playerTwo.PlaceShip(playerTwo.shipOne, playerTwoBoard);
            DisplayTitle();
            playerTwoBoard.DisplayBoard();
            playerTwo.PlaceShip(playerTwo.shipTwo, playerTwoBoard);
            DisplayTitle();
            playerTwoBoard.DisplayBoard();
            Console.ReadKey();
            foreach (Point point in playerTwoBoard.board)
            {
                point.DisplayString = " . ";
            }


            for (int i=0; i<5; i++)
            {
                DisplayTitle();
                playerTwoBoard.DisplayBoard();
                playerOne.Fire(playerTwoBoard);
            }
            Console.WriteLine("Your out of shots");

            for (int i = 0; i < 5; i++)
            {
                playerTwo.Fire(playerOneBoard);
                playerOneBoard.DisplayBoard();
                DisplayTitle();
            }
            Console.WriteLine("Your out of shots");

        }

        public void DisplayTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n*************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     BATTLESHIP GAME!!!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Player 1: {playerOne.Score}      Player 2: {playerTwo.Score}\n\n");
        }



    }

}

    
