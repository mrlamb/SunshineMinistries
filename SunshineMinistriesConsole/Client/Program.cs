using Transportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static Socket mySocket;
        //static Guid myID;

        static void Main(string[] args)
        {
            Transport.messageReceivedEvent += messageReceivedEventHandler;
            mySocket = Transport.ConnectSocket();
            while(true)
            {

            }
        }

        private static void messageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            Console.WriteLine("A Message Was Received");
            string messageBack = "A message Back to the server!";
            mySocket.Send(Encoding.ASCII.GetBytes(messageBack));
        }
    }
}
