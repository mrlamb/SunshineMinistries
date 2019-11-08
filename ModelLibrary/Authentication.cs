using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public static class Authentication
    {
        public static readonly string AUTHENTICATION_FAILED = "Invalid login credentials.";
        public static readonly string AUTHENTICATION_SUCCESS = "Login successful.";

        public static bool TryAuthenticateUser(string userName , string userPassword, out user user)
        {
            using (var context = new sunshinedataEntities())
            {
                user = context.users.FirstOrDefault(a => a.username == userName);
                if (user != null)
                {
                    return user.password == userPassword;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
