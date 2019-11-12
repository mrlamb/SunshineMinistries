using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.EventModels
{
    public class SearchResultsSelectedItemChanged
    {
        public ReturnedEntity Entity { get; set; }
        public SearchResultsSelectedItemChanged(ReturnedEntity entity)
        {
            Entity = entity;
        }
    }
}
