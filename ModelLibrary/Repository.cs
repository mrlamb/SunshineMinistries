using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    internal static class Repository
    {
        private static sunshinedataEntities _context;

        public static sunshinedataEntities Context
        {
            get { return _context; }
            
        }

        static Repository()
        {
            _context = new sunshinedataEntities();
        }

    }
}
