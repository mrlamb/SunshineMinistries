using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Internal.DataAccess;

namespace ModelLibrary.DataAccess
{
    internal class UserDataAccess : IDataAccess
    {
        EFDataAccess da = new EFDataAccess();

        public user GetUserByUsername(string username)
        {
            var output = da.GetData<user>("username = @0", new object[] { username }).FirstOrDefault();

            return output;
        }

        public void SaveData()
        {
            da.SaveData();
        }
    }
}
