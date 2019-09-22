using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transportation;

namespace Contact_App
{

    public class IndividualContactTabPage : TabPage
    {
        public byte ID { get; set; }
        private UserControl uc;
        public IndividualContactTabPage(UserControl uc)
        {
            this.uc = uc;
            this.Controls.Add(uc);
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            MessageObj mo = Transport.DeconstructMessage(lb);

            if (mo.ReturnTo == ID)
            {
                contact record = JsonConvert.DeserializeObject<contact>(mo.Message);

                switch (mo.Protocol)
                {
                    case TransportProtocol.SEND_INDIVIDUAL_RECORD:
                        if (uc.InvokeRequired)
                        {
                            uc.Invoke(new EventHandler(delegate { MessageReceivedEventHandler(socket, sb, lb); }));
                        }
                        else
                        {
                            (uc as OrganizationRecord).OrgName = record.firstname + " " + record.lastname;
                            this.Text = record.firstname + " " + record.lastname;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
