using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class Point
    {
        public int row { get; set; }
        public int column { get; set; }
        public bool HasShip { get; set; }
        public string DisplayString { get; set; }
    }
}
