//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class actions_organization
    {
        public int ownerID { get; set; }
        public string actionType { get; set; }
        public string completedBy { get; set; }
        public byte[] Notes { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public int id { get; set; }
    
        public virtual organization organization { get; set; }
    }
}
