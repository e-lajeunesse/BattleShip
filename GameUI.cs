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
        private Player playerOne = new Player("Player 1");
        private Player playerTwo = new Player("Player 2");
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

            playerOne.PlaceShip(playerOne.shipThree, playerOneBoard);
            DisplayTitle();
            playerOneBoard.DisplayBoard();

            playerOne.PlaceShip(playerOne.shipFour, playerOneBoard);
            DisplayTitle();
            playerOneBoard.DisplayBoard();

            playerOne.PlaceShip(playerOne.shipFive, playerOneBoard);
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

            playerTwo.PlaceShip(playerTwo.shipThree, playerTwoBoard);
            DisplayTitle();
            playerTwoBoard.DisplayBoard();

            playerTwo.PlaceShip(playerTwo.shipFour, playerTwoBoard);
            DisplayTitle();
            playerTwoBoard.DisplayBoard();

            playerTwo.PlaceShip(playerTwo.shipFive, playerTwoBoard);
            DisplayTitle();
            playerTwoBoard.DisplayBoard();

            Console.ReadKey();
            foreach (Point point in playerTwoBoard.board)
            {
                point.DisplayString = " . ";
            }

            // Players take turns firing on opponents board until someone hits all ships or 5 total turns are up
            for(int i=0; i<5; i++)
            {
                //Player One fires on Player Two's Board
                for (int j=0; j<6; j++)
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
                if(playerOne.Score >= playerTwo.totalShips)
                {
                    Console.WriteLine("\n You've hit all the enemies ships!");
                }
                else
                {
                    Console.WriteLine("\n You're out of shots");                
                }
                Console.ReadKey();

                //Player Two fires on Player One's Board
                for (int j = 0; j < 6; j++)
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
                if (playerTwo.Score >= playerOne.totalShips)
                {
                    Console.WriteLine("\n You've hit all the enemy ships!");
                }
                else
                {
                    Console.WriteLine("\n You're out of shots");                
                }
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

        // Checks if either player has won
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
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.ReadKey();
        }

    }

}

    
