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

        public UserCredentials Authenticate(string userName , string userPassword)
        {
            UserDataAccess uda = new UserDataAccess();
            var u = uda.GetUserByUsername(userName);
            if (null != u)
            {
                if (u.password == userPassword)
                {
                    return new UserCredentials()
                    {
                        UserAccessOptions = ( UserAccessOptions ) u.accessflags ,
                        UserName = u.username
                    };
                }
            }
            return null;
        }
    }
}
