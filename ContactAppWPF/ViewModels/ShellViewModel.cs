using ModelLibrary;
using System.Windows.Controls;
using Caliburn.Micro;
using ContactAppWPF.EventModels;
using System.Windows;

namespace ContactAppWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>, IViewAware, IHandle<LogOnEvent>
    {
        private MainViewModel _mainVM;
        private IEventAggregator _events;
        private SimpleContainer _container;

        private WindowState _windowState = WindowState.Normal;

        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                _windowState = value;
                NotifyOfPropertyChange(() => WindowState);
            }
        }


        public ShellViewModel(SimpleContainer container , IEventAggregator events , MainViewModel mainVM)
        {
            _events = events;
            _events.Subscribe(this);
            _mainVM = mainVM;
            _container = container;
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            WindowState = WindowState.Maximized;
            ActivateItem(_mainVM);
        }
    }
}