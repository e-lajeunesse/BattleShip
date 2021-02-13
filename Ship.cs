using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
   public abstract class Ship
    {
         
        public List<List<int>> Locations { get; set; } = new List<List<int>>();

        public virtual int Length { get; }
        public virtual string Name { get; }

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

    public class PatrolShip : Ship
    {
        public override int Length => 2;
        public override string Name => "Patrol Ship";
    }

    public class Battleship : Ship
    {
        public override int Length => 3;
        public override string Name => "Battleship";
    }

    public class Carrier : Ship
    {
        public override int Length => 5;
        public override string Name => "Carrier";
    }
}
