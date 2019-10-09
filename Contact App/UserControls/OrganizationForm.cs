using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contact_App.Interfaces;
using ModelLibrary;
using ModelLibrary.OrganizationsModel;

namespace DataInputForms
{
    public partial class OrganizationForm : UserControl, IRecordView, IHasActionList
    {

        private List<action> actions;
        private organization savedRecord, workingRecord;

        public OrganizationForm()
        {
            InitializeComponent();
        }

        public string FullName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler FormNameUpdated;

        public object GetData()
        {
            throw new NotImplementedException();
        }

        public void InitializeActionList(ICollection<IAction> actions)
        {
            throw new NotImplementedException();
        }

        public void SaveActionToList(IAction a)
        {
            throw new NotImplementedException();
        }

        public void SetData(object record)
        {
            throw new NotImplementedException();
        }
    }
}
