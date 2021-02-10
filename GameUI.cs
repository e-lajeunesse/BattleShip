using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class GameUI
    {
        private int turnCounter = 2;
        // Game is played by two players. Each player has their own 5x5 board.
        // At the start of the game each player chooses where to place their ships
        // The players take turns guessing where the other player's ships are on their board.
        private Player playerOne = new Player();
        private Player playerTwo = new Player();
        public void NewGame()
        {
            //Player One places ships
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
            foreach (Point point in playerOneBoard.board)
            {
                point.DisplayString = " . ";
            }

            // Player Two Places Ships
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

            for(int i=0; i<1; i++)
            {
                //Player One fires on Player Two's Board
                for (int j=0; j<5; j++)
                {
                    DisplayTitle();
                    playerTwoBoard.DisplayBoard();
                    playerOne.Fire(playerTwoBoard);
                    if(playerOne.Score >= playerTwo.totalShips)
                    {
                        break;
                    }
                }
                DisplayTitle();
                playerTwoBoard.DisplayBoard();
                Console.WriteLine("Your out of shots");                
                Console.ReadKey();

                //Player Two fires on Player One's Board
                for (int j = 0; j < 5; j++)
                {
                    DisplayTitle();
                    playerOneBoard.DisplayBoard();
                    playerTwo.Fire(playerOneBoard);
                    if (playerTwo.Score >= playerOne.totalShips)
                    {
                        break;
                    }
                }
                DisplayTitle();
                playerOneBoard.DisplayBoard();
                Console.WriteLine("You're out of shots");                
                Console.ReadKey();

                if (IsGameOver())
                {
                    EndGame();
                    break;
                }
            }
            EndGame();

        }

        // Displays Title and Scores
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

        public bool IsGameOver()
        {
            if ( playerOne.Score >= playerTwo.totalShips || playerTwo.Score >= playerOne.totalShips)
            {
                return true;
            }
            return false;
        }

        public void EndGame()
        {
            DisplayTitle();
            Console.WriteLine("Thank you for playing Battleship!");
            Console.WriteLine("The Winner is: ");
            if (playerOne.Score > playerTwo.Score)
            {
                Console.WriteLine("Player 1!");
            }
            else if (playerTwo.Score > playerOne.Score)
            {
                Console.WriteLine("Player 2!");
            }
            else
            {
                Console.WriteLine("The game ends in a tie!");
            }
        }

    }

}

    
