using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public static class Repository
    {
        private static sunshinedataEntities _context;

        internal static sunshinedataEntities Context
        {
            get
            {
                
                return _context;
            }

        }

        static Repository()
        {
            _context = new sunshinedataEntities();
        }

        public static bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public static void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CancelChanges()
        {
            _context = new sunshinedataEntities();
        }

        public static void Reload()
        {
            _context = new sunshinedataEntities();
        }
    }
}
