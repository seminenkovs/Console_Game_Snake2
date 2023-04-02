using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2.Helper
{
    internal static class ScoreHelper
    {
        public static void GetScore(int score)
        {
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"Score : {score}");
        }
    }
}
