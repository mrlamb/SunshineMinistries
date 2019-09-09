using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public static partial class Transport
    {
        public static byte[] ConstructMessage(TransportProtocol tp)
        {
            return ConstructMessage(tp, "");
        }

        public static byte[] ConstructMessage(TransportProtocol tp, string v)
        {
            byte[] message = new byte[1 + v.Length];
            message[0] = (byte)tp;
            Encoding.ASCII.GetBytes(v).CopyTo(message, 1);
            return message;
        }

        public static MessageObj DeconstructMessage(List<byte> lb)
        {
            MessageObj mo = new MessageObj()
            {
                Protocol = (TransportProtocol)lb.First()
            };
            lb.RemoveAt(0);
            mo.Message = Encoding.ASCII.GetString(lb.ToArray());
            return mo;           
        }
    }
}
