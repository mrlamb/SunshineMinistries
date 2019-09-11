using System;
using System.Collections.Generic;
namespace Contact_App
{
    public partial class contact
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public override string ToString()
        {
            return firstname + ' ' + lastname;
        }
    }

    
}