using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2.UserServices
{
    internal static class UserInitializer
    {
        public static List<User> GetSampleUserData()
        {
            List<User> users = new List<User>();

            users.Add(new User { Name = "Some Name", Score = 123});
            users.Add(new User { Name = "Some Name2", Score = 124});
            users.Add(new User { Name = "Simple user", Score = 3});
            users.Add(new User { Name = "Professional User", Score = 500});

            return users;
        }
    }
}
