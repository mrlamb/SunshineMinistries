using ModelLibrary.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DataAccess
{
    public class IndividualDataAccess : IDataAccess
    {
        private EFDataAccess da = new EFDataAccess();

        public void Add(individual individual)
        {
            
            da.Add<individual>(individual);
        }

        public List<individual> GetIndividuals(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                return da.GetData<individual>();
            }
            else
            {
                var output = GetIndividualsByFirstName(parameter).Union(
                    GetIndividualsByLastName(parameter).Union(
                        GetIndividualsBySunshineId(parameter).Union(
                            GetIndividualsByZip(parameter).Union(
                                GetIndividualsByCity(parameter).Union(
                                    GetIndividualsByState(parameter)))))).ToList();
                return output;
            }
        }

        private List<individual> GetIndividualsByFirstName(string parameter)
        {
            var output = da.GetData<individual>("firstname.Contains(@0)", new object[] { parameter });
            return output;
        }

        private List<individual> GetIndividualsByLastName(string parameter)
        {
            var output = da.GetData<individual>("lastname.Contains(@0)", new object[] { parameter });
            return output;
        }

        private List<individual> GetIndividualsBySunshineId(string parameter)
        {
            var output = da.GetData<individual>("sunshineid = @0", new object[] { parameter });
            return output;
        }

        private List<individual> GetIndividualsByZip(string parameter)
        {
            return da.GetData<individual>("addresses_individual.Any(zip = @0)", new object[] { parameter });
        }

        private List<individual> GetIndividualsByCity(string parameter)
        {
            return da.GetData<individual>("addresses_individual.Any(city.Contains(@0))", new object[] { parameter });
        }

        private List<individual> GetIndividualsByState(string parameter)
        {
            return da.GetData<individual>("addresses_individual.Any(state.Contains(@0))", new object[] { parameter });
        }

        public void SaveData()
        {
            da.SaveData();
        }
    }
}
