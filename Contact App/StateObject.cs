using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Contact_App
{
    public class StateObject
    {
        public Socket workSocket { get; set; }
        public Guid id { get; set; }

    }
}
