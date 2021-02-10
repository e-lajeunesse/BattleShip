using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Player
    {
        public int totalShips { get; } = 2;
        public int Score { get; set; } = 0;

        public Ship shipOne { get; }
        public Ship shipTwo { get; }


        // Method for player to place ships on their own board
        public void PlaceShip(Ship playerShip, Board playerBoard)
        {

            bool shipPlacedSuccessfully = false;

            while (!shipPlacedSuccessfully)
            {
                Console.WriteLine("\nEnter where you want to place your ship: ");
                string playerChoice = Console.ReadLine();
                if (!ChoiceOnBoard(playerChoice))
                {
                    Console.WriteLine("Invalid Entry");
                }
                else
                {
                    List<int> coordinates = ConvertChoiceToCoordinate(playerChoice);
                    playerBoard.board[coordinates[0], coordinates[1]].DisplayString = " @ ";

                    playerBoard.board[coordinates[0], coordinates[1]].HasShip = true;
                    shipPlacedSuccessfully = true;
                    Console.WriteLine($"Ship {playerShip} placed at {playerChoice}");                    
                }
            }
        }

        // Method for player to fire on opponents board
        public void Fire(Board playerBoard)
        {
            bool validFireGuess = false;
            while (!validFireGuess)
            {
                Console.WriteLine("Enter the location you want to fire at: ");
                string playerGuess = Console.ReadLine();

                if (!ChoiceOnBoard(playerGuess))
                {
                    Console.WriteLine("Invalid Location");
                }
                else
                {
                    List<int> coordinates = ConvertChoiceToCoordinate(playerGuess);
                    if (playerBoard.board[coordinates[0], coordinates[1]].HasShip)
                    {
                        Console.WriteLine("You've hit the enemies ship!");
                        playerBoard.board[coordinates[0], coordinates[1]].DisplayString = " H ";
                        playerBoard.board[coordinates[0], coordinates[1]].HasShip = false;
                        Score++;
                    }
                    else
                    {
                        Console.WriteLine("You Missed!");
                        playerBoard.board[coordinates[0], coordinates[1]].DisplayString = " M ";

                    }
                    validFireGuess = true;
                }
            }
        }

        //Converts players choice to coordinates on board, i.e A1 converts to (1,0)
        public List<int> ConvertChoiceToCoordinate(string choice)
        {
            List<int> coordinates = new List<int>();
            int row = int.Parse(choice[1].ToString());
            int column = (int)(choice[0] - 65);
            coordinates.Add(row);
            coordinates.Add(column);
            return coordinates;
        }

        // Checks if a players entry on the game board
        public bool ChoiceOnBoard(string choice)
        {
            List<char> validLetters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            List<int> validNums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (choice.Length != 2)
            {
                return false;
            }
            else if (!validLetters.Contains(choice[0]))
            {
                return false;
            }
            else if (!validNums.Contains(int.Parse(choice[1].ToString())))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
