using Transportation;
using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;

namespace Server
{
    class Program
    {
        static ConnectionManager manager = new ConnectionManager();
        static UserEntities UserContext = new UserEntities();
        static void Main(string[] args)
        {
            try
            {
                //Initialize server

                Transport.StartListener();
                Transport.messageReceivedEvent += MessageReceivedEventHandler;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            while (true)
            {
            }
        }

        private static void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {


            MessageObj message = Transport.DeconstructMessage(lb);
            Console.WriteLine("A message was received from the client!");
            Console.WriteLine("Type: " + message.Protocol.ToString());
            Console.WriteLine("Content: " + message.Message);

            switch (message.Protocol)
            {
                case TransportProtocol.SEND_GUID:
                    break;
                case TransportProtocol.SEND_USER:
                    ValidateUserName(socket, message.Message);
                    break;
                case TransportProtocol.SEND_PASSWORD:
                    AuthenticateUser(socket, message.Message);
                    break;
                default:
                    break;
            }
        }

        private static void AuthenticateUser(Socket socket, string message)
        {
            if (manager.ConnectionExists(socket))
            {
                string name = manager.GetUserNameFromSocket(socket);

                user u = UserContext.users.First(a => a.username == name);
                if (u.password == message)
                {
                    socket.Send(Transport.ConstructMessage(TransportProtocol.AUTHENTICATED));
                }
                else
                {
                    socket.Send(Transport.ConstructMessage(TransportProtocol.PASS_FAILED));
                }
            }
        }

        private static void ValidateUserName(Socket socket, string v)
        {
            if (!manager.ConnectionExists(socket))
                manager.AddConnection(socket);

            manager.SetUserForSocket(socket, v);

            user u = UserContext.users.FirstOrDefault(a => a.username.Equals(v.ToLower()));
            if (null != u)
            {
                socket.Send(Transport.ConstructMessage(TransportProtocol.SEND_PASSWORD));
            }
            else
            {
                socket.Send(Transport.ConstructMessage(TransportProtocol.USER_NOT_FOUND));
            }

        }
    }
}
