using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace ModelLibrary.Internal.DataAccess
{
    internal class EFDataAccess
    {
        public List<T> GetData<T>(string predicate , object[] parameters) where T : class
        {
            return Repository.Context.Set<T>().Where(predicate , parameters).ToList();
        }

        public List<T> GetOrderedData<T>(string predicate, object[] parameters, string orderby, object[] orderbyParameters) where T : class
        {
                return GetData<T>(predicate , parameters).OrderBy(orderby , orderbyParameters).ToList();
        }

        public void SaveData()
        {
            Repository.Context.SaveChanges();
        }
    }
}
