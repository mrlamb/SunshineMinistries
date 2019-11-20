using ModelLibrary.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DataAccess
{
    public class DenominationTypesDataAccess : IDataAccess
    {
        private EFDataAccess da = new EFDataAccess();

        public List<string> GetDenominations()
        {
            var output = new List<string>();

            foreach (var item in da.GetData<denomination>())
            {
                output.Add(item.name);
            }
            return output;
        }


        public void SaveData()
        {
            da.SaveData();
        }
    }
}
