using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using ContactAppWPF.EventModels;
using ContactAppWPF.Helpers;
using ModelLibrary;
using ModelLibrary.DataAccess;
using ModelLibrary.Models;

namespace ContactAppWPF.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<RepositoryHasChanges>
    {
        private object _activeItem;
        private SimpleContainer _container;
        private IEventAggregator _events;
        private Visibility _newIndividualVisibility = Visibility.Collapsed;
        private Visibility _newOrganizationVisibility = Visibility.Collapsed;
        private ReportsViewModel _rvm;
        private SearchAggregator _sa;
        private SearchResultsViewModel _srvm;
        private UserCredentials _userCredentials;
        private IWindowManager _wm;
        private SettingsHelper _settings;

        public MainViewModel(SimpleContainer container, SearchAggregator searchAggregator, IEventAggregator eventAggregator,
            UserCredentials userCredentials, IWindowManager windowManager, SettingsHelper settings)
        {
            _wm = windowManager;
            _userCredentials = userCredentials;
            _events = eventAggregator;
            _events.Subscribe(this);
            _sa = searchAggregator;
            _container = container;
            ActivateItem(_container.GetInstance<FrontPageViewModel>());
            _settings = settings;
            settings.Read();

            Activated += OnActivate;

        }
        public void OnActivate(object sender, ActivationEventArgs e)
        {
            Application.Current.MainWindow.FontFamily = new FontFamily(_settings.AppFont);
            Application.Current.MainWindow.FontSize = _settings.AppFontSize;
        }

        public object ContentView
        {
            get { return _activeItem; }
            set { _activeItem = value;
                NotifyOfPropertyChange(() => ContentView); }
        }

        public Visibility NewIndividualVisibility
        {
            get { return _newIndividualVisibility; }
            set
            {
                _newIndividualVisibility = value;
                NotifyOfPropertyChange(() => NewIndividualVisibility);
            }
        }

        public Visibility NewOrganizationVisibility
        {
            get { return _newOrganizationVisibility; }
            set
            {
                _newOrganizationVisibility = value;
                NotifyOfPropertyChange(() => NewOrganizationVisibility);
            }
        }

        public ReportsViewModel ReportsVM
        {
            get { return _rvm; }
            private set
            {
                _rvm = value;
                NotifyOfPropertyChange(() => ReportsVM);
            }
        }

        public bool SaveEnabled
        {
            //TODO FIGURE OUT HOW TO CHECK DYNAMICALLY
            get { return Repository.HasChanges(); }
        }

        public SearchResultsViewModel SearchResultsVM
        {
            get { return _srvm; }
            private set
            {
                _srvm = value;
                NotifyOfPropertyChange(() => SearchResultsVM);
            }
        }

        public string SearchTerms { get; set; }

        public string UserName
        {
            get { return _userCredentials.FullName; }
        }

        public void GoHome()
        {
            ActivateItem(_container.GetInstance<FrontPageViewModel>());
        }

        public void Handle(RepositoryHasChanges message)
        {
            NotifyOfPropertyChange(() => SaveEnabled);
        }

        public void NewIndividual()
        {
            ReportsVM = null;
            NewIndividualVisibility = Visibility.Collapsed;
            NewOrganizationVisibility = Visibility.Collapsed;
            ContentView = _container.GetInstance<IndividualDetailViewModel>();
            individual i = new individual();
            (ContentView as IndividualDetailViewModel).Entity = new ModelLibrary.Models.ReturnedEntity()
            {
                Entity = i
            };
            var ida = _container.GetInstance<IndividualDataAccess>();
            ida.Add(i);
            ActivateItem(ContentView);
        }

        public void NewOrganization()
        {
            ReportsVM = null;
            NewIndividualVisibility = Visibility.Collapsed;
            NewOrganizationVisibility = Visibility.Collapsed;
            ContentView = _container.GetInstance<OrganizationDetailViewModel>();
            organization o = new organization();
            (ContentView as OrganizationDetailViewModel).Entity = new ReturnedEntity()
            {
                Entity = o
            };
            var oda = _container.GetInstance<OrganizationDataAccess>();
            oda.Add(o);
            ActivateItem(ContentView);
        }

        public void OpenReports()
        {
            ReportsVM = _container.GetInstance<ReportsViewModel>();
            ActivateItem(ReportsVM);
        }

        public void OpenSettings()
        {
            _wm.ShowDialog(_container.GetInstance<SettingsViewModel>());
        }

        public void ProcessSearch()
        {
            _sa.SearchTerms = SearchTerms;
            ContentView = _container.GetInstance<SearchResultsViewModel>();
            ActivateItem(ContentView);
        }

        public void Save()
        {
            try
            {
                Repository.SaveChanges();
                NotifyOfPropertyChange(() => SaveEnabled);
                _events.PublishOnUIThread(new SearchResultsInvalidated());
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to save: {e.Message}");
            }
        }

        public void ShowNewOptions()
        {
            NewIndividualVisibility = Visibility.Visible;
            NewOrganizationVisibility = Visibility.Visible;
        }
    }
}
