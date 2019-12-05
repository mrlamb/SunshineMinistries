using ModelLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.Helpers
{
    public class SunshineIDHelper
    {
        private IndividualDataAccess _ida;
        private OrganizationDataAccess _oda;

        public SunshineIDHelper(IndividualDataAccess ida, OrganizationDataAccess oda)
        {
            _ida = ida;
            _oda = oda;
        }

        public string GetNextIndividualID()
        {
            var lastId = _ida.GetIndividuals("").Max(a => a.sunshineidnumber);
            return $"I{++lastId}";
        }
    }
}
