﻿using System;
using System.Collections.Generic;
using System.Text;


//Individual Model Namespace
namespace ModelLibrary.IndividualsModel
{
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
            other.sunshineidl = string.Copy(sunshineidl);
            other.phonenumbers = new List<phonenumber>(phonenumbers);
            other.actions = new List<action>(actions);

            return other;
        }
    }

   
    public partial class action : IAction
    {
        public action()
        {
                
        }
        public action(long ownerID, string actionType, string completedBy, byte[] Notes, DateTime date)
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

        public static explicit operator action(OrganizationsModel.action d) => new action(d.ownerID, d.actionType, d.completedBy, d.Notes, d.date);
        
    }

   public class officer : individual
    {
        public string Title { get; set; }
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
namespace ModelLibrary.OrganizationsModel
{
    public partial class organization
    {
        //Any needed helper stuff goes here
        public override string ToString()
        {
            return name;

        }
    }

    public partial class action : IAction
    {
        public action()
        {

        }
        public action(long ownerID , string actionType , string completedBy , byte[] Notes , DateTime date)
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

        public static explicit operator action(IndividualsModel.action d) => new action(d.ownerID, d.actionType, d.completedBy, d.Notes, d.date);

    }
}


