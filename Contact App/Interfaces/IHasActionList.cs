using System.Collections.Generic;
using Contact_App.Model;
namespace Contact_App.Interfaces
{
    public interface IHasActionList
    {
        void InitializeActionList(ICollection<action> actions);
        void SaveActionToList(action a);
    }
}
