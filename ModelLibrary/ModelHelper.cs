using System;
using System.Collections.Generic;
using System.Text;


//Individual Model Namespace
namespace ModelLibrary
{
    public partial class sm_types
    {
        public override string ToString()
        {
            return this.sm_type_name;
        }
    }
    public partial class individual
    {
        public override string ToString()
        {
            return firstname + " " + lastname;
            
        }

        public individual DeepCopy()
        {
            individual other = (individual) this.MemberwiseClone();
            other.firstname = string.Copy(firstname);
            other.lastname = string.Copy(lastname);
            other.phone = string.Copy(phone);
            other.source = string.Copy(source);
            other.sunshineid = string.Copy(sunshineid);
            other.phonenumbers_individual = new List<phonenumbers_individual>();
            other.actions_individual = new List<actions_individual>(actions_individual);

            return other;
        }
    }

   
    public partial class actions_individual : IAction
    {
        public actions_individual()
        {
                
        }
        public actions_individual(int ownerID, string actionType, string completedBy, byte[] Notes, DateTime date)
        {
            this.ownerID = ownerID;
            this.actionType = actionType;
            this.completedBy = completedBy;
            this.Notes = Notes;
            this.date = date;
        }
        public override string ToString()
        {
            return this.date.ToString() + "\t" + this.actionType + "\t" + this.completedBy + "\t" + 
                Encoding.ASCII.GetString(this.Notes); 
        }

        public static explicit operator actions_individual(actions_organization d) => new actions_individual(d.ownerID, d.actionType, d.completedBy, d.Notes, d.date);
        
    }

 
}

//User Model Namespace
namespace ModelLibrary
{
    public partial class user
    {
        public override string ToString()
        {
            return username;
        }
    }

}

//Organization Model Namespace
namespace ModelLibrary
{
    public partial class organization
    {
        //Any needed helper stuff goes here
        public override string ToString()
        {
            return name;

        }
    }

    public partial class actions_organization : IAction
    {
        public actions_organization()
        {

        }
        public actions_organization(int ownerID , string actionType , string completedBy , byte[] Notes , DateTime date)
        {
            this.ownerID = ownerID;
            this.actionType = actionType;
            this.completedBy = completedBy;
            this.Notes = Notes;
            this.date = date;
        }

        public override string ToString()
        {
            return this.date.ToString() + "\t" + this.actionType + "\t" + this.completedBy + "\t" +
                Encoding.ASCII.GetString(this.Notes);
        }

        public static explicit operator actions_organization(actions_individual d) => new actions_organization(d.ownerID, d.actionType, d.completedBy, d.Notes, d.date);

    }
}


