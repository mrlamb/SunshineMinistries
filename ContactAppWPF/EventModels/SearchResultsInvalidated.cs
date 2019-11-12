using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.EventModels
{
    public class SearchResultsInvalidated
    {
        public ReturnedEntity Entity;

        public SearchResultsInvalidated(ReturnedEntity entity)
        {
            Entity = entity;
        }
    }
}
