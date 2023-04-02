using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2.Factory
{
    internal static class FoodFactory
    {
        private static Random _rnd = new Random();
        public static Point RandomFood( int playgroundWidth, int playgroundHeight, char symbol)
        {
            playgroundWidth = _rnd.Next(2, playgroundWidth - 2);
            playgroundHeight = _rnd.Next(2, playgroundHeight - 2);

            return new Point(playgroundWidth, playgroundHeight, symbol);
        }
    }
}
