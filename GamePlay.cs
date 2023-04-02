using Snake2.Enum;
using Snake2.Factory;
using Snake2.Helper;
using Snake2.Installer;
using Snake2.UserServices;
using System;
using System.Threading;

namespace Snake2
{
    internal class GamePlay
    {
        private UserService _userService = new UserService();
        public void StartGame(User user)
        {
            if (user == null)
            { 
                user = new User();
            }

            Console.CursorVisible = false;

            int score = 0; // user score

            LineInstaller line = new LineInstaller();
            line.DrawShapes();

            Point food = FoodFactory.RandomFood(119, 20, '*');
            Console.ForegroundColor = ColorHelper.RandomColor(new Random().Next(0, 5));
            food.DrawPoint();
            Console.ResetColor();

            Snake snake = Snake.CreateSnake(5, new Point(10, 10, '@'), DirectionEnum.Right);
            snake.DrawLine();

            Thread.Sleep(200);

            int time = 100; // Snake speed
            bool exit = true;

            while (exit)
            {
                ScoreHelper.GetScore(score);

                Thread.Sleep(time);

                snake.Move();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.PressKey(key.Key);
                }

                if (snake.EatFood(food))
                {
                    food = FoodFactory.RandomFood(119, 20, '*');
                    Console.ForegroundColor = ColorHelper.RandomColor(new Random().Next(0, 5));
                    food.DrawPoint();
                    Console.ResetColor();

                    time -= 5; // Snake speed -5
                    score++; // user score +1
                }

                if (line.Collision(snake) || snake.CollisionWithTail())
                {
                    exit = false;
                }
            }

            Snake._snake = null;
            user.Score = score;
            _userService.SaveScore(user);
        }
    }
}
