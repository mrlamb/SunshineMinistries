using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class ReturnedEntity
    {
        public int Id { get; set; }
        public object Entity { get; set; }
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string SunshineId { get; set; }
        public string LastAction { get; set; }
        public Type Type { get; set; }
        public string TypeString { get; set; }
        public IAction Action { get; set; }
    }
}
