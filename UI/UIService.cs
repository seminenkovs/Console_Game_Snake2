using Snake2.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake2;

namespace Snake2.UI
{
    internal class UIService
    {
        private GamePlay _gamePlay = new GamePlay();
        private UserService _userService = new UserService();
        private User _user = new User();

        public void GetMenu()
        {
            string text = @"
                -----------------------------------------

                         Welcome to Snake Game

                ------------------------------------------


                    - Press Enter to Start the Game

                    - Use arrows to Move the Snake
                    - Press C to Create new User
                    - Press S to Get all Scores
                    - Press ESC to Quite the Game
             ";
            Console.Clear();
            Console.SetCursorPosition(40, 5);
            Console.WriteLine(text);
        }

        public void GetCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    StartGame();
                    break;
                case ConsoleKey.C:
                    CreateUserForm();
                    break;
                case ConsoleKey.S:
                    ScoreBoard();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    GetMenu();
                    break;
            }
        }

        private void StartGame()
        {   
            Console.Clear();
            _gamePlay.StartGame(_user);
            Concede();
            
        }

        private void CreateUserForm()
        {
            Console.Clear();

            Console.WriteLine("Enter your name: ");
            string userName = Console.ReadLine();

            try
            {
                _user = _userService.CreateUser(userName);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("User Name Saved");

            Console.WriteLine("\nBack to menu BackSpace");
        }

        private void ScoreBoard()
        {
            Console.Clear();
            IEnumerable<User> users = _userService.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} with score: {user.Score}");
            }

            Console.WriteLine("\nBack to Menu press BackSpace");
        }

        private void Concede()
        {
            Console.Clear();
            Console.WriteLine("Game Over\n");
            Console.WriteLine("\nBack to menu BackSpace");
        }
    }
}
