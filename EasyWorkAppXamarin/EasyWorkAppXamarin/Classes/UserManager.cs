using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class UserManager
    {
        public static Users CurrentUser { get; set; }

        public static void SetCurrentUser(Users user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsUserLoggedIn()
        {
            return CurrentUser != null;
        }

        public static bool UserIsAdmin()
        {
            return CurrentUser.IsAdmin;
        }
    }
}
