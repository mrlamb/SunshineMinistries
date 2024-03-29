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
    
    public partial class individual
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public individual()
        {
            this.actions_individual = new HashSet<actions_individual>();
            this.addresses_individual = new HashSet<addresses_individual>();
            this.officers = new HashSet<officer>();
            this.phonenumbers_individual = new HashSet<phonenumbers_individual>();
            this.social_media_individual = new HashSet<social_media_individual>();
        }
    
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool financialsupport { get; set; }
        public string phone { get; set; }
        public Nullable<int> source { get; set; }
        public string sunshineid { get; set; }
        public byte[] notes { get; set; }
        public Nullable<int> sunshineidnumber { get; set; }
        public string sunshineidchar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<actions_individual> actions_individual { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<addresses_individual> addresses_individual { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<officer> officers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phonenumbers_individual> phonenumbers_individual { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<social_media_individual> social_media_individual { get; set; }
        public virtual organization organization { get; set; }
    }
}
