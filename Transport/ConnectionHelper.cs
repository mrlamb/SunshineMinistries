using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public static partial class Transport
    {
        public static string RemoteIP { get { return remoteIP; } }
        private static readonly string remoteIP = "10.189.241.55";
    }
}
