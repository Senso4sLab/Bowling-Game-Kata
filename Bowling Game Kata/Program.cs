using System;
using System.Collections.Generic;

namespace Bowling_Game_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pins = new List<int> { 1, 2, 3, 4, 5, 5, 7, 1, 4, 6, 10, 4, 4, 8, 2, 4, 3, 10, 8, 1, 2, 4, 5 };

            List<int> pins1 = new List<int> { 1, 2, 3, 4, 5, 5, 7, 1, 4, 6, 10, 10, 10, 8, 2, 4, 3, 10, 8, 1, 2, 4, 5 };
            Game game = new Game();           

            foreach(var pin in pins1)
                game.Roll(pin);

            int TotalScore = game.TotalScore;
            game.PrintResult();   
        
        }
    }
}
