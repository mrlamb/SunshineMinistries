using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunshineMinistriesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new sunshinedataEntities())
            {
                var clients = from b in context.clients
                            select b;
                var client = context.clients.FirstOrDefault();
                Console.Write(client.firstname);
            }
            
            
        }
    }
}
