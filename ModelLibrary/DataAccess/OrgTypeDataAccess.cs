using ModelLibrary.Internal.DataAccess;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DataAccess
{
    public class OrgTypeDataAccess : IDataAccess
    {
        EFDataAccess da = new EFDataAccess();

        public List<org_types> GetTypes()
        {
            return da.GetOrderedData<org_types>("type");
        }


        public void SaveData()
        {
            da.SaveData();
        }
    }
}
