using System.Collections.Generic;
using LoginAndroid.Models;

namespace LoginAndroid.Repositories
{
    public static class UserRepository
    {
        public static IList<User> Users;

        static UserRepository()
        {
            if (Users ==  null)
            {
                Users = new List<User>();
            }
        }
    }
}