﻿using Newtonsoft.Json;
using ModelLibrary;
using Transportation;
using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using ModelLibrary.IndividualsModel;
using ModelLibrary.OrganizationsModel;

namespace Server
{
    class Program
    {
        static ConnectionManager manager = new ConnectionManager();
        static UserEntities UserContext = new UserEntities();
        static IndividualEntities IndividualContext = new IndividualEntities();
        static OrganizationEntities OrganizationContext = new OrganizationEntities();
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
                IndividualContext.SaveChanges();
                OrganizationContext.SaveChanges();
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
                    UpdateIndividualRecord(message.Message);
                    break;
                case TransportProtocol.DELETE_RECORD:
                    DeleteRecord(message.Message);
                    break;
                case TransportProtocol.SEARCH_WITH_TERM:
                    Search(socket , message);
                    break;
                default:
                    break;
            }
        }

        private static void SendOrgRecord(Socket socket , MessageObj message)
        {
            organization record = OrganizationContext.organizations.First(a => a.orgid.ToString() == message.Message);
            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_ORG_RECORD , 
                JsonConvert.SerializeObject(record , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void UpdateOrgRecord(Socket socket , MessageObj message)
        {
            organization o = new organization();
            try
            {

                o = JsonConvert.DeserializeObject<organization>(message.Message);
                organization record = OrganizationContext.organizations.First(a => a.orgid == o.orgid);
                record.name = o.name;
                record.addresses = o.addresses;
                record.phone = o.phone;
                record.financialsupport = o.financialsupport;
                record.actions = o.actions;
                record.orgsunshineid = o.orgsunshineid;
                

                //IndividualContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                OrganizationContext.organizations.Add(o);
                //IndividualContext.SaveChanges();
            }
            catch
            {
                //Console.WriteLine(e.ToString());
                throw;
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
                    List<object> results = (from e in IndividualContext.individuals
                                            where (e.firstname.Contains(tmp)
                                  || e.lastname.Contains(tmp)
                                  || e.sunshineidl.Contains(tmp))
                                            select e).ToList<object>();

                    foreach (var item in results)
                    {
                        objects.Add(item);
                    }
                    List<object> results2 = (from e in OrganizationContext.organizations
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
                user record = UserContext.users.First(a => a.id == u.id);
                record.username = u.username;
                record.email = u.email;
                record.accessflags = u.accessflags;
                record.password = u.password;
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.STATUS_UPDATE , $"User: {u.username} updated."));

                UserContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                UserContext.users.Add(u);
                UserContext.SaveChanges();
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
                    JsonConvert.SerializeObject(UserContext.users)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void SendUserOptions(Socket socket , MessageObj message)
        {
            var name = manager.GetUserNameFromSocket(socket);
            var record = UserContext.users.First(a => a.username == name);
            if (null != record)
            {
                socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_USER_OPTIONS , record.accessflags.ToString()));
            }
        }

        private static void DeleteRecord(string message)
        {
            individual c = JsonConvert.DeserializeObject<individual>(message);
            individual record = IndividualContext.individuals.First(a => a.id == c.id);
            IndividualContext.individuals.Remove(record);
            //IndividualContext.SaveChanges();

        }

        private static void UpdateIndividualRecord(string message)
        {
            individual c = new individual();
            try
            {

                c = JsonConvert.DeserializeObject<individual>(message);
                individual record = IndividualContext.individuals.First(a => a.id == c.id);
                record.firstname = c.firstname;
                record.lastname = c.lastname;
                record.addresses = c.addresses;
                record.phone = c.phone;
                record.financialsupport = c.financialsupport;
                record.actions = c.actions;
                record.sunshineidl = c.sunshineidl;
                record.source = c.source;

                //IndividualContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                IndividualContext.individuals.Add(c);
                //IndividualContext.SaveChanges();
            }
            catch
            {
                //Console.WriteLine(e.ToString());
                throw;
            }

        }

        private static void SendSingleRecord(Socket socket , MessageObj message)
        {
            individual record = IndividualContext.individuals.First(a => a.id.ToString() == message.Message);
            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.SEND_INDIVIDUAL_RECORD , JsonConvert.SerializeObject(record , new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
        }

        private static void BatchSend(Socket socket , MessageObj message)
        {
            string AllRecords = JsonConvert.SerializeObject(IndividualContext.individuals.Select(con => new { con.id, con.firstname, con.lastname }));


            socket.Send(Transport.ConstructMessage(message.ReturnTo , TransportProtocol.BATCH_SEND_RECORD , AllRecords));
        }

        private static void AuthenticateUser(Socket socket , string message)
        {
            if (manager.ConnectionExists(socket))
            {
                string name = manager.GetUserNameFromSocket(socket);

                user u = UserContext.users.First(a => a.username == name);
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

            user u = UserContext.users.FirstOrDefault(a => a.username.Equals(v.ToLower()));
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