using Contact_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Transportation;
using Contact_App.Interfaces;

namespace Contact_App
{

    public class RecordViewTabPage : TabPage
    {
        public byte ID { get; set; }
        private IRecordView uc;
        private object savedContact;

        public RecordViewTabPage(IRecordView uc)
        {
            this.uc = uc;
            this.Controls.Add(uc as Control);
            (uc as Control).Dock = DockStyle.Fill;
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            uc.FormNameUpdated += UpdateTabName;
        }

        private void UpdateTabName(object sender, EventArgs e)
        {
            this.Text = uc.FullName;
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            MessageObj mo = Transport.DeconstructMessage(lb);

            if (mo.ReturnTo == ID)
            {
                
                switch (mo.Protocol)
                {
                    case TransportProtocol.SEND_INDIVIDUAL_RECORD:
                        contact record = JsonConvert.DeserializeObject<contact>(mo.Message);
                        savedContact = record;
                        uc.SetData(record);
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new EventHandler(delegate { this.Text = record.firstname + " " + record.lastname + "   "; }));
                        }
                        
                        break;
                    default:
                        break;
                }
            }
        }

        internal object GetContactFromData()
        {
            if (null == savedContact)
            {
                savedContact = uc.GetData();
            }
            return savedContact; 
        }
    }
}
