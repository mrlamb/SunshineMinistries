/* Class: Authentication
 * Passing userName and userPassword to Authenticate will query the
 * underlying data store for a user object to compare the password 
 * to and return a UserCredentials object which includes the userName and
 * UserAccessOptions for the user
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;
using System.Data.Entity;
using ModelLibrary.DataAccess;

namespace ModelLibrary
{
    public class Authentication : IAuthentication
    {
        public static readonly string AUTHENTICATION_FAILED = "Invalid login credentials.";
        public static readonly string AUTHENTICATION_SUCCESS = "Login successful.";
        public static readonly string AUTHENTICATION_IN_PROGRESS = "Attempting Login...";

        private UserCredentials _user;

        public Authentication(UserCredentials user)
        {
            _user = user;
        }
        public UserCredentials Authenticate(string userName , string userPassword)
        {
            UserDataAccess uda = new UserDataAccess();
            var u = uda.GetUserByUsername(userName);
            if (null != u)
            {
                if (u.password == userPassword)
                {
                    _user.UserAccessOptions = ( UserAccessOptions ) u.accessflags;
                    _user.UserName = u.username;
                    _user.FullName = u.userfullname;
                   return _user;
                }
            }
            return null;
        }
    }
}
