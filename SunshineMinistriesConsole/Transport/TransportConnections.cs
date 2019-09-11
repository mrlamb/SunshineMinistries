using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public static partial class Transport
    {
        public delegate void MessageReceived(Socket socket, StringBuilder sb, List<byte> lb);
        public static event MessageReceived messageReceivedEvent;

        public static ConnectionManager Manager = new ConnectionManager();


        /// <summary>
        /// Method used by clients to connect up
        /// </summary>
        public static Socket ConnectSocket()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.75.224"), 22480);

            try
            {
                socket.Connect(ipe);

                StateObject so = new StateObject(socket);
                WaitForData(so);
                return socket;
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
            int read = 0;
            try
            {
                read = so.workSocket.EndReceive(ar);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client disconnect: " + e.Message);
            }
            //Some data was sent
            if (read > 0)
            {
                //Collect what we have
                so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
                so.lb.AddRange(so.buffer.Where(a => a != 0));
                //If we read a full buffer's worth, send us back into the listen mode to get more
                if (so.workSocket.Available == 0)
                {
                    if (so.sb.Length > 0)
                    {
                        if (messageReceivedEvent != null)
                            messageReceivedEvent.Invoke(so.workSocket, so.sb, so.lb);

                        so.sb.Clear();
                        so.lb.Clear();
                        so.buffer = new byte[StateObject.BUFFER_SIZE];

                    }

                }

                    so.workSocket.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(OnReceive), so);
                                    
            }

            //After all above Asyncs we dump out here to handle the data
            
        }

    }
}
