using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameUI ui = new GameUI();
            ui.NewGame();

/*            string s = "0123456";
            foreach (char c in s)
            {
                Console.WriteLine((int)c);
            }*/

            Player testplayer = new Player();
            List<int> testOne = testplayer.ConvertChoiceToCoordinate("A2");
            List<int> testTwo = testplayer.ConvertChoiceToCoordinate("E3");
            List<int> testThree = testplayer.ConvertChoiceToCoordinate("J9");

            /*            Console.WriteLine($"A2 : {testOne[0]}{testOne[1]}");
                        Console.WriteLine($"E3 : {testTwo[0]}{testTwo[1]}");
                        Console.WriteLine($"J9 : {testThree[0]}{testThree[1]}");*/

/*            Console.WriteLine(testplayer.ChoiceOnBoard("G9"));
            Console.WriteLine(testplayer.ChoiceOnBoard("C4"));
            Console.WriteLine(testplayer.ChoiceOnBoard("A9"));*/


        }
    }
}
