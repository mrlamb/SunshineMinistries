using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public partial class actions_individual : IAction
    {
        public string DecodedNotes {
            get { return Notes != null ? Encoding.ASCII.GetString(Notes) : null; }
            set { Notes = Encoding.ASCII.GetBytes(value); }
        }
    }

    public partial class actions_organization : IAction
    {
        public string DecodedNotes
        {
            get { return Notes != null ? Encoding.ASCII.GetString(Notes) : null; }
            set { Notes = Encoding.ASCII.GetBytes(value); }
        }
    }


    public partial class organization
    {
        public string DecodedNotes
        {
            get { return notes != null ? Encoding.ASCII.GetString(notes) : null; }
            set { notes = Encoding.ASCII.GetBytes(value); }
        }
    }

    public partial class individual
    {
        public string DecodedNotes
        {
            get { return notes != null ? Encoding.ASCII.GetString(notes) : null; }
            set { notes = Encoding.ASCII.GetBytes(value); }
        }
    }
}


