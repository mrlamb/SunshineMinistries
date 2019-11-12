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
        internal List<T> GetData<T>(string predicate, object[] parameters) where T : class
        {
            return Repository.Context.Set<T>().Where(predicate, parameters).ToList();
        }

        internal void Add<T>(T entity) where T : class
        {
            Repository.Context.Set<T>().Add(entity);
        }

        internal List<T> GetOrderedData<T>(string parameter) where T: class
        {
            return GetData<T>().OrderBy(parameter).ToList();
        }

        internal List<T> GetOrderedData<T>(string predicate, object[] parameters, string orderby) where T : class
        {
            return GetData<T>(predicate, parameters).OrderBy(orderby).ToList();
        }

        internal void SaveData()
        {
            Repository.Context.SaveChanges();
        }

        internal List<T> GetData<T>() where T : class
        {
            return Repository.Context.Set<T>().ToList();
        }
    }
}
