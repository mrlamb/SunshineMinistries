using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_App.Model
{
    public partial class contact
    {
        public override string ToString()
        {
            return firstname + " " + lastname;
            
        }

        public contact DeepCopy()
        {
            contact other = (contact) this.MemberwiseClone();
            other.firstname = string.Copy(firstname);
            other.lastname = string.Copy(lastname);
            other.phone = string.Copy(phone);
            other.source = string.Copy(source);
            other.sunshineidl = string.Copy(sunshineidl);
            other.phonenumbers = new List<phonenumber>(phonenumbers);
            other.actions = new List<action>(actions);

            return other;
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
