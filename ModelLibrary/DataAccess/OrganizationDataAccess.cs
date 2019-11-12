using ModelLibrary.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLibrary.DataAccess
{
    public class OrganizationDataAccess : IDataAccess
    {
        private EFDataAccess da = new EFDataAccess();

        public List<organization> GetOrganizations(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                return da.GetData<organization>();
            }
            var output = GetOrganizationsByName(parameter).Union(
                GetOrganizationsBySunshineId(parameter).Union(
                    GetOrganizationsByZip(parameter).Union(
                        GetOrganizationsByCity(parameter).Union(
                            GetOrganizationsByState(parameter).Union(
                                GetOrganizationsByType(parameter)))))).ToList();
            return output;
        }

        private List<organization> GetOrganizationsByName(string parameter)
        {
            var output = da.GetData<organization>("name.Contains(@0)", new object[] { parameter });
            return output;
        }

        private List<organization> GetOrganizationsBySunshineId(string parameter)
        {
            var output = da.GetData<organization>("orgsunshineid = @0", new object[] { parameter });
            return output;
        }

        //private List<organization> GetOrganizationsByDenomination(string parameter)
        //{

        //}

        private List<organization> GetOrganizationsByType(string parameter)
        {
            var output = da.GetData<organization>("org_types.type.Contains(@0)", new object[] { parameter });
            return output;
        }

        private List<organization> GetOrganizationsByZip(string parameter)
        {
            return da.GetData<organization>("addresses_organization.Any(zip = @0)", new object[] { parameter });
        }

        private List<organization> GetOrganizationsByCity(string parameter)
        {
            return da.GetData<organization>("addresses_organization.Any(city.Contains(@0))", new object[] { parameter });
        }

        private List<organization> GetOrganizationsByState(string parameter)
        {
            return da.GetData<organization>("addresses_organization.Any(state.Contains(@0))", new object[] { parameter });
        }

        public void SaveData()
        {
            da.SaveData();
        }

        public void Add(organization o)
        {
            da.Add(o);
        }
    }
}