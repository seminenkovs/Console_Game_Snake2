using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2.Helper
{
    internal static class ColorHelper
    {
        public static ConsoleColor RandomColor(int value)
        {
            switch (value)
            {
                case 1: 
                    return ConsoleColor.Green;
                case 2:
                    return ConsoleColor.Red;
                case 3:
                    return ConsoleColor.Yellow;
                case 4:
                    return ConsoleColor.Blue;
                case 5:
                    return ConsoleColor.Magenta;
                default: 
                    return ConsoleColor.White;
            }
        }
    }
}
