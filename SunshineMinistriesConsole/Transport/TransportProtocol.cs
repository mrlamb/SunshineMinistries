using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation
{
    public enum TransportProtocol
    {
        SEND_GUID = 1,
        SEND_USER,
        MESSAGE_BOX,
        USER_NOT_FOUND,
        SEND_PASSWORD,
        PASS_FAILED,
        AUTHENTICATED,
    }
}
