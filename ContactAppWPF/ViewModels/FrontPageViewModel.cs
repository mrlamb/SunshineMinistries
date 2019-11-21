using Caliburn.Micro;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.ViewModels
{
    class FrontPageViewModel : Conductor<object>
    {
        private UserCredentials _uc;
        public FrontPageViewModel(SimpleContainer simpleContainer, UserCredentials userCredentials)
        {
            _uc = userCredentials;
            ActivateItem(simpleContainer.GetInstance<SearchResultsFrontPageViewModel>());
        }

        public string UserFullName
        {
            get { return _uc.FullName; }
        }
    }
}
