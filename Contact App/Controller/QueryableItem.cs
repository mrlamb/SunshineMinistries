using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_App.Controller
{
    public enum QueryableItemTypes
    {
        INDIVIDUAL, ORGANIZATION
    }
    public class QueryableItem
    {
        public QueryableItemTypes QType { get; set; }
        public string Query { get; set; }
        public string Filter { get; set; }

    }
}
