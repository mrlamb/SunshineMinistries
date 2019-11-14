using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ContactAppWPF.EventModels;
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

        public MainViewModel(SimpleContainer container, SearchAggregator searchAggregator, IEventAggregator eventAggregator,
            UserCredentials userCredentials)
        {
            _userCredentials = userCredentials;
            _events = eventAggregator;
            _events.Subscribe(this);
            _sa = searchAggregator;
            _container = container;

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
        }

        public void OpenReports()
        {
            ReportsVM = _container.GetInstance<ReportsViewModel>();
            ActivateItem(ReportsVM);
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
