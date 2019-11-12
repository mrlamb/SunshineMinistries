/*Class UserDataAccess
 * Contains methods to get particular users or lists of users from the underlying datastore
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Internal.DataAccess;

namespace ModelLibrary.DataAccess
{
    public class UserDataAccess : IDataAccess
    {
        EFDataAccess da = new EFDataAccess();

        public user GetUserByUsername(string username)
        {
            var output = da.GetData<user>("username = @0", new object[] { username }).FirstOrDefault();

            return output;
        }

        public List<user> GetAllUsers()
        {
            var output = da.GetData<user>();

            return output;
        }

        public void SaveData()
        {
            da.SaveData();
        }

        public List<string> GetUserNames()
        {
            var output = new List<string>();
            foreach (var item in GetAllUsers())
            {
                output.Add(item.userfullname);
            }
            return output;


        }
    }
}
