using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Player
    {
        public int totalShips { get; } = 3;
        public int Score { get; set; } = 0;
        public string Name { get; }

        public List<Ship> ShipList { get; } = new List<Ship> { new PatrolShip(),new Battleship(),new Carrier() };
        


        public Player(string name)
        {
            Name = name;
        }




        // Method for player to place ships on their own board
        public void PlaceShip(Ship playerShip, Board playerBoard)
        {
            bool shipPlacedSuccessfully = false;
            while (!shipPlacedSuccessfully)
            {
                Console.WriteLine($"\n{Name} Enter where you want to place your {playerShip.Name}: ");
                string playerChoice = Console.ReadLine();                

                if (!ShipChoiceOnBoard(playerChoice, playerShip.Length))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID ENTRY");
                    continue;
                }
                List<int> coordinates = ConvertChoiceToCoordinate(playerChoice);
                if (ShipChoiceHasShip(coordinates, playerShip.Length, playerBoard))
                {
                    Console.WriteLine("There's already a ship there!");
                }
                else
                {
                    for (int i = 0; i < playerShip.Length; i++)
                    {
                        playerBoard.board[coordinates[0], coordinates[1]+i].DisplayString = " S ";
                        playerBoard.board[coordinates[0], coordinates[1]+i].HasShip = true;
                        playerShip.Locations.Add(new List<int> { coordinates[0], coordinates[1] + i });
                        ValueTuple<int, int> shipLocation = (coordinates[0], coordinates[1] + i);
                        playerBoard.ShipTracker[shipLocation] = playerShip;
                    }
                    shipPlacedSuccessfully = true;                    
                }
            }
        }

        // Method for player to fire on opponents board
        public string Fire(Board playerBoard)
        {
            bool validFireGuess = false;
            string result = "";
            while (!validFireGuess)
            {
                Console.WriteLine($"\n {Name} Enter the location you want to fire at: ");
                string playerGuess = Console.ReadLine();

                if (!ChoiceOnBoard(playerGuess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID LOCATION");
                }
                else
                {
                    List<int> coordinates = ConvertChoiceToCoordinate(playerGuess);
                    ValueTuple<int, int> shipLocation = (coordinates[0], coordinates[1]);
                    if (playerBoard.board[coordinates[0], coordinates[1]].HasShip)
                    {
                        playerBoard.board[coordinates[0], coordinates[1]].DisplayString = " H ";
                        playerBoard.board[coordinates[0], coordinates[1]].HasShip = false;                        
                        Ship hitShip = playerBoard.ShipTracker[shipLocation];
                        if (hitShip.IsSunk(playerBoard))
                        {
                            
                            result =  $"You've sunk the enemies {hitShip.Name}!";                            
                            Score++;
                        }
                        else
                        {
                            result = $"You've hit the enemies {hitShip.Name}!";                             
                        }                        
                    }
                    else
                    {
                        result = "You Missed!";
                        if (!(playerBoard.board[coordinates[0], coordinates[1]].DisplayString == " H "))
                        {
                            playerBoard.board[coordinates[0], coordinates[1]].DisplayString = " M ";
                        }
                    }
                    validFireGuess = true;
                    
                }
            }
            return result;
            
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

        // Checks if a players entry for firing is on the game board
        public bool ChoiceOnBoard(string choice)
        {
            List<char> validLetters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            List<char> validNums = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (choice.Length != 2)
            {
                return false;
            }
            else if (!validLetters.Contains(choice[0]))
            {
                return false;
            }
            else if (!validNums.Contains(choice[1]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Checks if a players entry for placing ship is on the game board
        public bool ShipChoiceOnBoard(string choice, int shipLength)
        {
            List<char> allValidLetters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            List<char> allValidNums = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            List<char> validLettersForShip = allValidLetters.GetRange(0, allValidLetters.Count - shipLength + 1);
            if (choice.Length != 2)
            {
                return false;
            }
            else if (!validLettersForShip.Contains(choice[0]))
            {
                return false;
            }
            else if (!allValidNums.Contains(choice[1]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ShipChoiceHasShip(List<int> coordinates, int shipLength, Board playerBoard)
        {
            for (int i = 0; i < shipLength; i++)
            {
                if (playerBoard.board[coordinates[0], coordinates[1] + i].HasShip)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
