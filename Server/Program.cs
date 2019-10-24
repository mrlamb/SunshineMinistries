using Newtonsoft.Json;
using ModelLibrary;
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
        static sunshinedataEntities Entities = new sunshinedataEntities();
        private const int FormID = 1;
        static void Main(string[] args)
        {
            try
            {
                //Initialize server

                Transport.StartListener();
                Transport.messageReceivedEvent += MessageReceivedEventHandler;
                Transport.clientDisconnectedEvent += OnClientDisconnect;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



            while (true)
            {
            }
        }

        private static void OnClientDisconnect(Socket socket)
        {
            manager.RemoveConnection(socket);
            if (manager.GetNumConnections() == 0)
            {
                Console.WriteLine("All clients disconnected. Saving database changes.");
                Entities.SaveChanges();
            }
        }

        private static void MessageReceivedEventHandler(Socket socket , StringBuilder sb , List<byte> lb)
        {


            MessageObj message = Transport.DeconstructMessage(lb);
            Console.WriteLine("A message was received from the client!");
            Console.WriteLine("Type: " + message.Protocol.ToString());
            Console.WriteLine("Content: " + message.Message);

            switch (message.Protocol)
            {
                case TransportProtocol.SEND_ORG_RECORD:
                    SendOrgRecord(socket , message);
                    break;
                case TransportProtocol.UPDATE_ORG_RECORD:
                    UpdateOrgRecord(socket , message);
                    break;
                case TransportProtocol.UPDATE_USER:
                    UpdateUserRecord(socket , message);
                    break;
                case TransportProtocol.SEND_ALL_USERS:
                    SendAllUsers(socket , message);
                    break;
                case TransportProtocol.SEND_USER_OPTIONS:
                    SendUserOptions(socket , message);
                    break;
                case TransportProtocol.SEND_USER:
                    ValidateUserName(socket , message.Message);
                    break;
                case TransportProtocol.SEND_PASSWORD:
                    AuthenticateUser(socket , message.Message);
                    break;
                case TransportProtocol.SEND_INDIVIDUAL_RECORD:
                    SendSingleRecord(socket , message);
                    break;
                case TransportProtocol.BATCH_SEND_RECORD:
                    BatchSend(socket , message);
                    break;
                case TransportProtocol.UPDATE_INDIVIDUAL_RECORD:
                    UpdateIndividualRecord(socket, message);
                    break;
                case TransportProtocol.DELETE_RECORD:
                    DeleteRecord(message.Message);
                    break;
                case TransportProtocol.SEARCH_WITH_TERM:
                    Search(socket , message);
                    break;
                case TransportProtocol.SEND_SOCIAL_MEDIA_TYPES:
                    SendSocialMediaTypes(socket , message);
                    break;
                default:
                    break;
            }
        }

        private static void SendSocialMediaTypes(Socket socket , MessageObj message)
        {
            List<sm_types> list = Entities.sm_types.ToList<sm_types>();
            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_SOCIAL_MEDIA_TYPES ,
                JsonConvert.SerializeObject(list, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void SendOrgRecord(Socket socket , MessageObj message)
        {

            organization record = Entities.organizations.First(a => a.orgid.ToString() == message.Message);
            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_ORG_RECORD , 
                JsonConvert.SerializeObject(record , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void UpdateOrgRecord(Socket socket , MessageObj message)
        {
            organization o = new organization();
            try
            {

                o = JsonConvert.DeserializeObject<organization>(message.Message);
                organization record = Entities.organizations.First(a => a.orgid == o.orgid);
                record.name = o.name;
                record.addresses_organization = o.addresses_organization;
                record.phonenumbers_organization = o.phonenumbers_organization;
                record.phone = o.phone;
                record.financialsupport = o.financialsupport;
                record.actions_organization = o.actions_organization;
                record.social_media_organization = o.social_media_organization;
                record.orgsunshineid = o.orgsunshineid;
                

                Entities.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                Entities.organizations.Add(o);
                Entities.SaveChanges();
            }
            finally
            {
                socket.Send(Transport.ConstructMessage(20 , TransportProtocol.STATUS_UPDATE , $"{o.ToString()} saved."));
            }
        }

        private static void Search(Socket socket , MessageObj message)
        {
            List<object> objects = new List<object>();

            var searchTerms = message.Message.ToLower().Split(null);
            if (searchTerms.Length > 0)
            {
                for (int i = 0; i < searchTerms.Length; i++)
                {
                    var tmp = searchTerms[i];
                    List<object> results = (from e in Entities.individuals
                                            where (e.firstname.Contains(tmp)
                                  || e.lastname.Contains(tmp)
                                  || e.sunshineid.Contains(tmp))
                                            select e).ToList<object>();

                    foreach (var item in results)
                    {
                        objects.Add(item);
                    }
                    List<object> results2 = (from e in Entities.organizations
                                             where (e.name.Contains(tmp)
                                  || e.orgsunshineid.Contains(tmp))
                                             select e).ToList<object>();

                    foreach (var item in results2)
                    {
                        objects.Add(item);
                    }

                }
            }
            if (objects.Count > 0)
            {
                KnownTypesBinder loKnownTypesBinder = new KnownTypesBinder()
                {
                    KnownTypes = new List<Type> { typeof(individual), typeof(organization) }
                };


                JsonSerializerSettings loJsonSerializerSettings = new JsonSerializerSettings();

                loJsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                
                //loJsonSerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                //loJsonSerializerSettings.SerializationBinder = loKnownTypesBinder;



                Console.WriteLine(JsonConvert.SerializeObject(objects, loJsonSerializerSettings));
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.BATCH_SEND_RECORD ,
                    JsonConvert.SerializeObject(objects , loJsonSerializerSettings)));
            }
        }

        private static void UpdateUserRecord(Socket socket , MessageObj message)
        {
            user u = new user();
            try
            {

                u = JsonConvert.DeserializeObject<user>(message.Message);
                user record = Entities.users.First(a => a.id == u.id);
                record.username = u.username;
                record.email = u.email;
                record.accessflags = u.accessflags;
                record.password = u.password;
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.STATUS_UPDATE , $"User: {u.username} updated."));

                Entities.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                Entities.users.Add(u);
                Entities.SaveChanges();
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.STATUS_UPDATE , $"User: {u.username} added."));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SendAllUsers(Socket socket , MessageObj message)
        {
            try
            {
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_ALL_USERS ,
                    JsonConvert.SerializeObject(Entities.users)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void SendUserOptions(Socket socket , MessageObj message)
        {
            var name = manager.GetUserNameFromSocket(socket);
            var record = Entities.users.First(a => a.username == name);
            if (null != record)
            {
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_USER_OPTIONS , record.accessflags.ToString()));
            }
        }

        private static void DeleteRecord(string message)
        {
            individual c = JsonConvert.DeserializeObject<individual>(message);
            individual record = Entities.individuals.First(a => a.id == c.id);
            Entities.individuals.Remove(record);
            //IndividualContext.SaveChanges();

        }

        private static void UpdateIndividualRecord(Socket socket, MessageObj message)
        {
            individual c = new individual();
            try
            {

                c = JsonConvert.DeserializeObject<individual>(message.Message);
                individual record = Entities.individuals.First(a => a.id == c.id);
                record.firstname = c.firstname;
                record.lastname = c.lastname;
                record.addresses_individual = c.addresses_individual;
                record.phone = c.phone;
                record.phonenumbers_individual = c.phonenumbers_individual;
                record.financialsupport = c.financialsupport;
                record.actions_individual = c.actions_individual;
                record.social_media_individual = c.social_media_individual;
                record.sunshineid = c.sunshineid;
                record.source = c.source;

                
            }
            catch (InvalidOperationException)
            {
                Entities.individuals.Add(c);
                
            }
            finally{
                Entities.SaveChanges();
                socket.Send(Transport.ConstructMessage(20 , TransportProtocol.STATUS_UPDATE , $"{c.ToString()} saved."));
            }

            
        }

        private static void SendSingleRecord(Socket socket , MessageObj message)
        {
            individual record = Entities.individuals.First(a => a.id.ToString() == message.Message);
            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_INDIVIDUAL_RECORD , JsonConvert.SerializeObject(record , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void BatchSend(Socket socket , MessageObj message)
        {
            string AllRecords = JsonConvert.SerializeObject(Entities.individuals.Select(con => new { con.id, con.firstname, con.lastname }));


            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.BATCH_SEND_RECORD , AllRecords));
        }

        private static void AuthenticateUser(Socket socket , string message)
        {
            if (manager.ConnectionExists(socket))
            {
                string name = manager.GetUserNameFromSocket(socket);

                user u = Entities.users.First(a => a.username == name);
                if (u.password == message)
                {
                    socket.Send(Transport.ConstructMessage(FormID , TransportProtocol.AUTHENTICATED));
                }
                else
                {
                    socket.Send(Transport.ConstructMessage(FormID , TransportProtocol.PASS_FAILED));
                }
            }
        }

        private static void ValidateUserName(Socket socket , string v)
        {
            if (!manager.ConnectionExists(socket))
                manager.AddConnection(socket);

            manager.SetUserForSocket(socket , v);

            user u = Entities.users.FirstOrDefault(a => a.username.Equals(v.ToLower()));
            if (null != u)
            {
                socket.Send(Transport.ConstructMessage(FormID , TransportProtocol.SEND_PASSWORD));
            }
            else
            {
                socket.Send(Transport.ConstructMessage(FormID , TransportProtocol.USER_NOT_FOUND));
            }

        }
    }
}
