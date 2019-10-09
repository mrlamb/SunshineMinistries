using System.Collections.Generic;
using ModelLibrary;

namespace Contact_App.Interfaces
{
    public interface IHasActionList
    {
        void InitializeActionList(ICollection<IAction> actions);
        void SaveActionToList(IAction a);
    }
}
