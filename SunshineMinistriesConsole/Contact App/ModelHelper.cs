﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_App
{
    public partial class contact
    {
        public override string ToString()
        {
            return firstname + " " + lastname;
            
        }
    }

    public partial class user
    {
        public override string ToString()
        {
            return username;
        }
    }

    public partial class action
    {
        public override string ToString()
        {
            return this.date.ToString() + "\t" + this.actionType + "\t" + this.completedBy + "\t" + 
                Encoding.ASCII.GetString(this.Notes); 
        }
    }
}
