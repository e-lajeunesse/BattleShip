using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
   public class Ship
    {
        public int Length { get; } = 3;
        public List<List<int>> Locations { get; set; } = new List<List<int>>();

        public bool IsSunk(Board playerBoard)
        {
            foreach(List<int> coordinate in Locations)
            {
                if (playerBoard.board[coordinate[0] ,coordinate[1]].HasShip)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
