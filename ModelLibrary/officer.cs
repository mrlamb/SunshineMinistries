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
    
    public partial class officer
    {
        public int id { get; set; }
        public Nullable<int> orgid { get; set; }
        public Nullable<int> indid { get; set; }
        public string title { get; set; }
    
        public virtual individual individual { get; set; }
        public virtual organization organization { get; set; }
    }
}
