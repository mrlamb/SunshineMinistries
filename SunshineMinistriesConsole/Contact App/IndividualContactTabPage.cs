using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private DataInputForms.IndividualForm uc;
        private contact savedContact;
        public IndividualContactTabPage(DataInputForms.IndividualForm uc)
        {
            this.uc = uc;
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            Transport.messageReceivedEvent += MessageReceivedEventHandler;
            uc.FormNameUpdated += UpdateTabName;
        }

        private void UpdateTabName(object sender, EventArgs e)
        {
            this.Text = uc.FirstName + " " + uc.LastName + "   ";
        }

        private void MessageReceivedEventHandler(Socket socket, StringBuilder sb, List<byte> lb)
        {
            MessageObj mo = Transport.DeconstructMessage(lb);

            if (mo.ReturnTo == ID)
            {
                contact record = JsonConvert.DeserializeObject<contact>(mo.Message);
                savedContact = record;

                switch (mo.Protocol)
                {
                    case TransportProtocol.SEND_INDIVIDUAL_RECORD:
                        if (uc.InvokeRequired)
                        {
                            uc.Invoke(new EventHandler(delegate { MessageReceivedEventHandler(socket, sb, lb); }));
                        }
                        else
                        {
                            uc.FirstName = record.firstname;
                            uc.LastName = record.lastname;
                            uc.Phone = record.phone;
                            uc.SetFinancialSupport(record.financialsupport == 0 ?
                                false : true);
                            if (null != record.actions)
                            {
                                foreach(var a in record.actions)
                                {
                                    uc.AddActionToList(a);
                                }
                            }

                            foreach(var x in record.addresses)
                            {
                                if (x.primary)
                                {
                                    uc.StreetPrimary = x.streetAddress;
                                    uc.CityPrimary = x.city;
                                    uc.StatePrimary = x.state;
                                    uc.ZipPrimary = x.zip;
                                }
                                else
                                {
                                    uc.StreetSecondary = x.streetAddress;
                                    uc.CitySecondary = x.city;
                                    uc.StateSecondary = x.state;
                                    uc.ZipSecondary = x.zip;
                                }
                            }


                            this.Text = record.firstname + " " + record.lastname + "   ";
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        internal contact GetContactFromData()
        {
            if (null == savedContact)
            {
                savedContact = new contact();
            }
            savedContact.firstname = uc.FirstName;
            savedContact.lastname = uc.LastName;
            savedContact.sunshineidl = uc.ID;
            savedContact.phone = uc.Phone;
            if (savedContact.addresses.Count > 0)
            {
                foreach (var x in savedContact.addresses)
                {
                    if (x.primary)
                    {
                        x.streetAddress = uc.StreetPrimary;
                        x.city = uc.CityPrimary;
                        x.state = uc.StatePrimary;
                        x.zip = uc.ZipPrimary;
                    }
                    else
                    {
                        x.streetAddress = uc.StreetSecondary;
                        x.city = uc.CitySecondary;
                        x.state = uc.StateSecondary;
                        x.zip = uc.ZipSecondary;
                    }

                }
            }
            else
            {
                address a1 = new address();
                address a2 = new address();
                a1.streetAddress = uc.StreetPrimary;
                a2.streetAddress = uc.StreetSecondary;
                a1.city = uc.CityPrimary;
                a2.city = uc.CitySecondary;
                a1.state = uc.StatePrimary;
                a2.state = uc.StateSecondary;
                a1.zip = uc.ZipPrimary;
                a2.zip = uc.ZipSecondary;
                a1.ownerid = savedContact.id;
                a2.ownerid = savedContact.id;
                a1.primary = true;
                a2.primary = false;

                savedContact.addresses.Add(a1);
                savedContact.addresses.Add(a2);
            }
            savedContact.actions.Clear();
            savedContact.actions = uc.GetActionList();

           
            savedContact.financialsupport = uc.GetFinancialSupport() ? (sbyte)1 : (sbyte)0 ;
            return savedContact;
        }
    }
}
