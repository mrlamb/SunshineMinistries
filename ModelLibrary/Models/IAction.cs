using System;

namespace ModelLibrary.Models
{
    public interface IAction
    {
        string actionType { get; set; }
        string completedBy { get; set; }
        byte[] Notes { get; set; }
        Nullable<System.DateTime> date { get; set; }
        string DecodedNotes { get; set; }
    }
}