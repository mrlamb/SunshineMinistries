using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public static class Transport
    {
        public static ConnectionManager Manager = new ConnectionManager();


        /// <summary>
        /// Method used by clients to connect up
        /// </summary>
        public static void ConnectSocket()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.1.127"), 22480);

            try
            {
                socket.Connect(ipe);

                StateObject so = new StateObject(socket);
                WaitForData(so);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Put server into listening mode
        /// </summary>
        public static void StartListener()
        {
            //Getting servers Network specs
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] localAddress = ipEntry.AddressList;

            //Setting up a new socket with those specs
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(Array.Find(localAddress, a => a.AddressFamily == AddressFamily.InterNetwork), 22480));
            listener.Listen(100);


            Console.WriteLine("IP Address: {0}", Array.Find(localAddress, a => a.AddressFamily == AddressFamily.InterNetwork));
            Console.WriteLine("Server started, awaiting connections.");

            //Putting socket into accept mode
            listener.BeginAccept(new AsyncCallback(OnConnectCallback), listener);


        }



        /// <summary>
        /// When a connection happens, do this
        /// </summary>
        /// <param name="ar"></param>
        private static void OnConnectCallback(IAsyncResult ar)
        {
            //My Socket
            Socket listener = (Socket)ar.AsyncState;

            //Client socket
            Socket socket = listener.EndAccept(ar);

            //Add to connection manager, returning the generated id.
            Guid id = Manager.AddConnection(socket);


            //Create a message to send including this connections ID
            byte[] message = new byte[1];
            message[0] = (byte)TransportProtocol.SEND_GUID;

            //Send the message
            socket.Send(message);
            

            Console.WriteLine("Client connected on: {0}", socket.RemoteEndPoint);

            //Setup this socket for passing data.
            StateObject so = new StateObject(socket);
            WaitForData(so);

            //Put listener back in new connection mode
            listener.BeginAccept(new AsyncCallback(OnConnectCallback), listener);


        }


        /// <summary>
        /// Putting specific socket into read mode so data can be sent through
        /// </summary>
        /// <param name="socket"></param>
        private static void WaitForData(StateObject so)
        {

            //Make sure it's still there.
            if (so.workSocket.Connected)
            {
                AsyncCallback receiveData = new AsyncCallback(OnReceive);
                so.workSocket.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None, receiveData, so);

            }
            else
            {
                throw new SocketException();
            }
        }

        /// <summary>
        /// Handle received data
        /// </summary>
        /// <param name="ar"></param>
        private static void OnReceive(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;

            int read = so.workSocket.EndReceive(ar);
            //Some data was sent
            if (read > 0)
            {
                //Collect what we have
                so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
                //If we read a full buffer's worth, send us back into the listen mode to get more
                if (read == StateObject.BUFFER_SIZE)
                {
                    so.workSocket.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(OnReceive), so);
                    return;
                }
            }

            //After all above Asyncs we dump out here to handle the data
            if (so.sb.Length > 0)
            {

                //STUCK HERE FOR NOW
                //IDEA WAS TO SEND A CONTROL BYTE THROUGH THAT WOULD INDICATE WHAT KIND OF DATA WAS COMING
                //It's either not being sent properly or not casting properly.
                TransportProtocol tp = new TransportProtocol();
                char[] message = new char[so.sb.Length];
                byte b = (byte)message[0];
                tp = (TransportProtocol)b;
                switch (tp)
                {
                    case TransportProtocol.SEND_GUID:
                        Console.WriteLine("Sent GUID:");
                        break;
                    default:
                        Console.WriteLine("Cannot determine message type.");
                        break;
                }

                //Handle the data
                //Use the transport protocol enum to check against the first byte of the message
                Console.WriteLine("Connected client sent: {0}", so.sb.ToString());
            }
        }

    }
}
