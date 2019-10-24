using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Contact_App.Interfaces;
using ModelLibrary;

namespace Contact_App
{

    public class RecordViewTabPage : TabPage
    {
        public byte ID { get; set; }
        private IRecordView uc;
        private object savedContact;
        public int RecordID { get { return uc.RecordID; } }

        public RecordViewTabPage(IRecordView uc)
        {
            this.uc = uc;
            this.Controls.Add(uc as Control);
            (uc as Control).Dock = DockStyle.Fill;
            
            uc.FormNameUpdated += UpdateTabName;
            
        }

        private void UpdateTabName(object sender, EventArgs e)
        {
            this.Text = uc.FullName;
        }


        internal object GetContactFromData()
        {
            if (null == savedContact)
            {
                savedContact = new object();
            }
            savedContact = uc.GetData();
            return savedContact; 
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
