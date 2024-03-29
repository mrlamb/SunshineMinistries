﻿using System;

namespace Contact_App.Interfaces
{
    public interface IRecordView
    {

        event EventHandler FormNameUpdated;

        int RecordID { get; }
        void SetData();
        object GetData();
        string FullName { get; }
    }
}