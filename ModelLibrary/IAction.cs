using System.Collections.Generic;

namespace ModelLibrary
{
    public interface IAction 
    {
        long ownerID { get; set; }
        string actionType { get; set; }
        string completedBy { get; set; }
        byte[] Notes { get; set; }
        System.DateTime date { get; set; }
    }
}