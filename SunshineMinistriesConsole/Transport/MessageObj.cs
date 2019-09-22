using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public class MessageObj
    {
        public TransportProtocol Protocol { get; set; }
        public string Message { get; internal set; }
        public byte ReturnTo { get; internal set; }
    }
}
