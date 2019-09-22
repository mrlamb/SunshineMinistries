using Newtonsoft.Json;
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
        static ContactEntities ContactContext = new ContactEntities();
        private const int FormID = 1;
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
                case TransportProtocol.SEND_INDIVIDUAL_RECORD:
                    SendSingleRecord(socket, message);
                    break;
                case TransportProtocol.BATCH_SEND_RECORD:
                    BatchSend(socket, message);
                    break;
                case TransportProtocol.UPDATE_RECORD:
                    UpdateRecord(message.Message);
                    break;
                case TransportProtocol.DELETE_RECORD:
                    DeleteRecord(message.Message);
                    break;
                default:
                    break;
            }
        }

        private static void DeleteRecord(string message)
        {
            contact c = JsonConvert.DeserializeObject<contact>(message);
            contact record = ContactContext.contacts.First(a => a.id == c.id);
            ContactContext.contacts.Remove(record);
            ContactContext.SaveChanges();
            
        }

        private static void UpdateRecord(string message)
        {
            contact c = new contact();
            try
            {
                c = JsonConvert.DeserializeObject<contact>(message);
                contact record = ContactContext.contacts.First(a => a.id == c.id);
                record.firstname = c.firstname;
                record.lastname = c.lastname;
                ContactContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                ContactContext.contacts.Add(c);
                ContactContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }

        private static void SendSingleRecord(Socket socket, MessageObj message)
        {
            contact record = ContactContext.contacts.First(a => a.id.ToString() == message.Message);
            socket.Send(Transport.ConstructMessage(message.ReturnTo, TransportProtocol.SEND_INDIVIDUAL_RECORD, JsonConvert.SerializeObject(record, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void BatchSend(Socket socket, MessageObj message)
        {
            string AllRecords = JsonConvert.SerializeObject(ContactContext.contacts.Select(con => new { con.id, con.firstname, con.lastname }));


            socket.Send(Transport.ConstructMessage(message.ReturnTo, TransportProtocol.BATCH_SEND_RECORD, AllRecords));
        }

        private static void AuthenticateUser(Socket socket, string message)
        {
            if (manager.ConnectionExists(socket))
            {
                string name = manager.GetUserNameFromSocket(socket);

                user u = UserContext.users.First(a => a.username == name);
                if (u.password == message)
                {
                    socket.Send(Transport.ConstructMessage(FormID, TransportProtocol.AUTHENTICATED));
                }
                else
                {
                    socket.Send(Transport.ConstructMessage(FormID, TransportProtocol.PASS_FAILED));
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
                socket.Send(Transport.ConstructMessage(FormID, TransportProtocol.SEND_PASSWORD));
            }
            else
            {
                socket.Send(Transport.ConstructMessage(FormID, TransportProtocol.USER_NOT_FOUND));
            }

        }
    }
}
