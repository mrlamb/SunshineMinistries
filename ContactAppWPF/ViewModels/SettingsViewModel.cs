using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.ViewModels
{
    class SettingsViewModel : Conductor<object>
    {
        private SimpleContainer _container;
        private string _listSelectedItem;

        public SettingsViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
            ListSelectedItem = "General";
            
        }

        public string ListSelectedItem
        {
         

            get { return _listSelectedItem; }
            set
            {
                
                _listSelectedItem = value;
                SetContentView(ListSelectedItem);
            }
        }

        private void SetContentView(string listSelectedItem)
        {
            switch (listSelectedItem)
            {
                case "General":
                    ActivateItem(_container.GetInstance<SettingsGeneralViewModel>());
                    break;
                default:
                    break;
            }
        }
    }
}
