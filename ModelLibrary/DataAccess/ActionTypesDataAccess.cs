using ModelLibrary.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DataAccess
{
    public class ActionTypesDataAccess : IDataAccess
    {
        public List<string> GetActionTypes()
        {
            EFDataAccess da = new EFDataAccess();

            var output = new List<string>();

            foreach (var item in da.GetOrderedData<actiontype>("actionType1"))
            {
                output.Add(item.actionType1);
            }
            return output;
        }


        public void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
