using Transportation;
using System;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Initialize server

                Transport.StartListener();
                Transport.messageReceivedEvent += MessageReceivedEventHandler;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            while(true)
                {
                }
        }

        private static void MessageReceivedEventHandler(StringBuilder sb, List<byte> lb)
        {
            Console.WriteLine("A message was received from the client!");
            Console.WriteLine(sb.ToString());

            TransportProtocol tp = new TransportProtocol();
            tp = (TransportProtocol)lb[0];


            switch (tp)
            {
                case TransportProtocol.SEND_GUID:
                    break;
                case TransportProtocol.SEND_LOGIN:
                    sb.Remove(0, 1);
                    Console.WriteLine("Attempting to authenticate: " + sb.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
