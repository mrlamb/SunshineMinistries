using System.Net.Sockets;
using System.Text;

namespace Transportation
{
    internal class StateObject
    {
        public Socket workSocket { get; private set; }
        public const int BUFFER_SIZE = 1024;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public StringBuilder sb { get; private set; }


        public StateObject(Socket socket)
        {
            this.workSocket = socket;
            sb = new StringBuilder();
        }
    }
}