using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    internal class Connection
    {
        internal Socket socket;
        internal Guid guid;
        internal string username;

        internal Connection(Socket socket)
        {
            this.socket = socket;
            guid = new Guid(System.Guid.NewGuid().ToByteArray());
        }

    }

    public class ConnectionManager
    {
        List<Connection> connections = new List<Connection>();

        public Guid AddConnection(Socket socket)
        {
            Connection c = new Connection(socket);
            connections.Add(c);
            return c.guid;
        }

        public Guid GetGuidFromSocket(Socket socket)
        {
            return connections.Find(a => a.socket.Equals(socket)).guid;
        }

        public bool ConnectionExists(Socket socket)
        {
            if (connections.Any(a => a.socket == socket))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetUserForSocket(Socket socket, string name)
        {
            Connection c = connections.Find(a => a.socket == socket);
            c.username = name;
        }

        public string GetUserNameFromSocket(Socket socket)
        {
            Connection c = connections.Find(a => a.socket == socket);
            return c.username;
        }
    }



}
