using System;

namespace Contact_App.Interfaces
{
    public interface IRecordView
    {

        event EventHandler FormNameUpdated;

        void SetData(object record);
        object GetData();
        string FullName { get; }
    }
}