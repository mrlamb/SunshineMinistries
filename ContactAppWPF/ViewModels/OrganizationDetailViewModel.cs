using Caliburn.Micro;
using ContactAppWPF.EventModels;
using ContactAppWPF.Helpers;
using ModelLibrary;
using ModelLibrary.DataAccess;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ContactAppWPF.ViewModels
{
    class OrganizationDetailViewModel : Screen, IDetailView
    {
        private List<string> _actionCompletedByList = new List<string>();
        private List<string> _actionTypeList = new List<string>();
        private ReturnedEntity _entity;
        private IEventAggregator _events;
        private organization _organization = new organization();
        private BindableCollection<org_types> _orgTypes;
        private org_types _orgTypesSelectedItem;
        private phonenumbers_organization _phoneSelectedItem;
        private string _phoneSelectedItemPN;
        private actions_organization _selectedAction;
        private addresses_organization _selectedAddress;
        private string _selectedState;
        private UserCredentials _user;

        public OrganizationDetailViewModel(IEventAggregator eventAggregator, StateListHelper stateListHelper,
            UserDataAccess userDataAccess, UserCredentials userCredentials, ActionTypesDataAccess actionTypesDataAccess,
            OrgTypeDataAccess orgTypeDataAccess)
        {
            _orgTypes = new BindableCollection<org_types>(orgTypeDataAccess.GetTypes());
            _actionTypeList = actionTypesDataAccess.GetActionTypes();
            _user = userCredentials;
            _actionCompletedByList = userDataAccess.GetUserNames();
            States = new BindableCollection<string>(stateListHelper.States);
            _events = eventAggregator;
            Deactivated = false;
        }

        public BindableCollection<string> ActionCompletedBy
        {
            get { return new BindableCollection<string>(_actionCompletedByList); }
        }

        public BindableCollection<actions_organization> Actions
        {
            get { return new BindableCollection<actions_organization>(_organization.actions_organization); }
            set { _organization.actions_organization = value; }
        }

        public bool ActionsExpanded { get { return _organization.actions_organization.Count > 0; } }
        public BindableCollection<string> ActionTypeList
        {
            get { return new BindableCollection<string>(_actionTypeList); }
        }

        public BindableCollection<addresses_organization> Addresses
        {
            get { return new BindableCollection<addresses_organization>(_organization.addresses_organization); }
        }

        public bool BasicInformationCheck
        {
            get
            {
                var output = (string.IsNullOrWhiteSpace(OrgName) || string.IsNullOrWhiteSpace(Phone) || _organization.addresses_organization.Count == 0);
                return output;
            }
        }

        public new bool Deactivated { get; private set; }

        public Visibility DenominationVisibility
        {
            get
            {
                if (_organization.org_type == _orgTypes.First(a => a.type == "Church").id)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public ReturnedEntity Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                _organization = (organization)value.Entity;
                SelectedAddress = _organization.addresses_organization.FirstOrDefault(a => a.primary == true);
                if (_organization.org_type != null)
                {
                    OrgTypesSelectedItem = _orgTypes.First(a => a.id == _organization.org_type); 
                }
                NotifyOfPropertyChange(() => BasicInformationCheck);
                NotifyOfPropertyChange(() => ActionsExpanded);
                NotifyOfPropertyChange(() => Entity);
                NotifyOfPropertyChange(() => OrgName);
                NotifyOfPropertyChange(() => SunshineId);
                NotifyOfPropertyChange(() => FinancialSupport);
                NotifyOfPropertyChange(() => Phone);
                NotifyOfPropertyChange(() => Addresses);
                NotifyOfPropertyChange(() => SelectedAddress);
                NotifyOfPropertyChange(() => Actions);
                NotifyOfPropertyChange(() => ActionCompletedBy);
                NotifyOfPropertyChange(() => OrgTypesSelectedItem);
            }
        }

        public bool FinancialSupport
        {
            get { return _organization.financialsupport; }
            set
            {
                _organization.financialsupport = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => FinancialSupport);
            }
        }

        public string NickName
        {
            get { return _organization.nickname; }
            set
            {
                _organization.nickname = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => NickName);
            }
        }

        public string OrgName
        {
            get { return _organization.name; }
            set
            {
                _organization.name = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => OrgName);
            }
        }

        public BindableCollection<org_types> OrgTypes
        {
            get { return _orgTypes; }
        }

        public org_types OrgTypesSelectedItem
        {
            get { return _orgTypesSelectedItem; }
            set
            {
                _orgTypesSelectedItem = value;
                _organization.org_type = value.id;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => DenominationVisibility);
            }
        }

        public string Phone
        {
            get { return _organization.phone; }
            set
            {
                _organization.phone = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => Phone);
            }
        }

        public BindableCollection<phonenumbers_organization> PhoneNumbers
        {
            get { return new BindableCollection<phonenumbers_organization>(_organization.phonenumbers_organization); }
        }

        public phonenumbers_organization PhoneSelectedItem
        {
            get { return _phoneSelectedItem; }
            set
            {
                _phoneSelectedItem = value;
                PhoneSelectedItemPN = value?.phonenumber;
                NotifyOfPropertyChange(() => PhoneSelectedItem);
            }
        }

        public string PhoneSelectedItemPN
        {
            get { return _phoneSelectedItemPN; }
            set
            {
                _phoneSelectedItemPN = value;
                NotifyOfPropertyChange(() => PhoneSelectedItemPN);
            }
        }

        public actions_organization SelectedAction
        {
            get { return _selectedAction; }
            set { _selectedAction = value; }
        }

        public addresses_organization SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
                SelectedState = _selectedAddress != null ? _selectedAddress.state != null ? _selectedAddress.state : "Missouri" : "Missouri";
                NotifyOfPropertyChange(() => SelectedAddress);
                NotifyOfPropertyChange(() => SelectedState);
            }
        }

        public string SelectedState
        {
            get { return _selectedState; }
            set
            {
                _selectedState = value;
                NotifyOfPropertyChange(() => SelectedState);
            }
        }

        public BindableCollection<string> States { get; private set; }
        public string SunshineId
        {
            get { return _organization.orgsunshineid; }
            set
            {
                _organization.orgsunshineid = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => SunshineId);
            }
        }

        public void ActionCompletedByChanged(SelectionChangedEventArgs item)
        {
            _events.PublishOnUIThread(new RepositoryHasChanges());
            SelectedAction.completedBy = item.AddedItems[0].ToString();
        }

        public void ActionTypeChanged(SelectionChangedEventArgs item)
        {
            _events.PublishOnUIThread(new RepositoryHasChanges());
            SelectedAction.actionType = item.AddedItems[0].ToString();
        }
        public void AddAddress()
        {
            var add = SelectedAddress;

            if (_organization.addresses_organization.Any(a => a.streetAddress == add.streetAddress) &&
                _organization.addresses_organization.Any(a => a.city == add.city) &&
                _organization.addresses_organization.Any(a => a.zip == add.zip))
            {
                return;
            }
            else
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                add.orgid = _organization.orgid;
                _organization.addresses_organization.Add(add);
                NotifyOfPropertyChange(() => Addresses);
                ClearAddress();
            }
        }

        public void AddPhoneNumber()
        {
            if (string.IsNullOrWhiteSpace(_phoneSelectedItemPN))
            {
                return;
            }

            var pn = new phonenumbers_organization()
            {
                ownerID = _organization.orgid,
                phonenumber = PhoneSelectedItemPN
            };

            if (_organization.phonenumbers_organization.Any(a => a.phonenumber == pn.phonenumber))
            {
                return;
            }
            else
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _organization.phonenumbers_organization.Add(pn);
                NotifyOfPropertyChange(() => PhoneNumbers);
                ClearPhoneNumber();
            }
        }

        
        public void ClearAddress()
        {
            SelectedAddress = null;
            NotifyOfPropertyChange(() => SelectedAddress);
            SelectedAddress = new addresses_organization();
            NotifyOfPropertyChange(() => SelectedAddress);
        }

        public void ClearPhoneNumber()
        {
            PhoneSelectedItem = null;
        }

        public void OnAddAction(object sender, EventArgs args)
        {
            _events.PublishOnUIThread(new RepositoryHasChanges());
            actions_organization action = (actions_organization)(args as InitializingNewItemEventArgs).NewItem;
            action.completedBy = _user.FullName;
            action.date = DateTime.Now;
            _organization.actions_organization.Add(action);
        }

        public void RemoveAddress()
        {
            if (null != SelectedAddress)
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _organization.addresses_organization.Remove(SelectedAddress);
                SelectedAddress = new addresses_organization();
                NotifyOfPropertyChange(() => Addresses);
                ClearAddress();
            }
        }

        public void RemovePhoneNumber()
        {
            if (null != PhoneSelectedItem)
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _organization.phonenumbers_organization.Remove(PhoneSelectedItem);
                PhoneSelectedItem = null;
                NotifyOfPropertyChange(() => PhoneNumbers);
            }
        }
    }
}
