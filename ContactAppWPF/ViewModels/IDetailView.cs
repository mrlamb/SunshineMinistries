using Caliburn.Micro;
using ModelLibrary.Models;

namespace ContactAppWPF.ViewModels
{
    public interface IDetailView : IGuardClose
    {
       ReturnedEntity Entity { get; set; }
        bool Deactivated { get; }
    }
}