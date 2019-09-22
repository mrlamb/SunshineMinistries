using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public static partial class Transport
    {
        public static byte[] ConstructMessage(byte formID, TransportProtocol tp)
        {
            return ConstructMessage(formID, tp, "");
        }

        public static byte[] ConstructMessage(byte formID, TransportProtocol tp, string v)
        {
            byte[] message = new byte[2 + v.Length];
            message[0] = (byte)tp;
            message[1] = (byte)formID;
            Encoding.ASCII.GetBytes(v).CopyTo(message, 2);
            return message;
        }

        public static MessageObj DeconstructMessage(List<byte> lb)
        {
            MessageObj mo = new MessageObj()
            {
                Protocol = (TransportProtocol)lb[0]
            };
            mo.ReturnTo = lb[1];
            if (lb.Count > 2)
                mo.Message = Encoding.ASCII.GetString(lb.ToArray(), 2, lb.Count - 2);
            else
                mo.Message = "";
            return mo;           
        }
    }
}
