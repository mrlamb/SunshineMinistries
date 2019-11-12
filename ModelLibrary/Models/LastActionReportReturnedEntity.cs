using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class LastActionReportReturnedEntity
    {
        public IAction Action { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
    }
}
