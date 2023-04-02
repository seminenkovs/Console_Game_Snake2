using Snake2.UI;
using System;

namespace Snake2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIService uiservice = new UIService();
            uiservice.GetMenu();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                uiservice.GetCommand(key.Key);
            }
        }
    }
}
