using Caliburn.Micro;
using ContactAppWPF.EventModels;
using ContactAppWPF.Helpers;
using ModelLibrary;
using ModelLibrary.DataAccess;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactAppWPF.ViewModels
{
    public class IndividualDetailViewModel : Screen, IDetailView
    {
        private List<string> _actionCompletedByList = new List<string>();
        private List<string> _actionTypeList = new List<string>();
        private ReturnedEntity _entity;
        private IEventAggregator _events;
        private individual _individual = new individual();
        private phonenumbers_individual _phoneSelectedItem;
        private string _phoneSelectedItemPN;
        private actions_individual _selectedAction;
        private addresses_individual _selectedAddress;
        private string _selectedState;
        private UserCredentials _user;
        private string _selectedAddressStreet;
        private string _selectedAddressCity;
        private string _selectedAddressZip;
        private bool? _selectedAddressPrimary;

        public IndividualDetailViewModel(IEventAggregator eventAggregator, StateListHelper stateListHelper,
            UserDataAccess userDataAccess, UserCredentials userCredentials, ActionTypesDataAccess actionTypesDataAccess)
        {
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

        public BindableCollection<actions_individual> Actions
        {
            get { return new BindableCollection<actions_individual>(_individual.actions_individual); }
            set { _individual.actions_individual = value; }
        }

        public bool ActionsExpanded { get { return _individual.actions_individual.Count > 0; } }
        public BindableCollection<string> ActionTypeList
        {
            get { return new BindableCollection<string>(_actionTypeList); }
        }

        public BindableCollection<addresses_individual> Addresses
        {
            get { return new BindableCollection<addresses_individual>(_individual.addresses_individual); }
        }

        public bool BasicInformationCheck
        {
            get
            {
                var output = (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Phone) || _individual.addresses_individual.Count == 0);
                return output;
            }
        }

        public new bool Deactivated { get; private set; }
        public ReturnedEntity Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                _individual = (individual)value.Entity;
                SelectedAddress = _individual.addresses_individual.FirstOrDefault(a => a.primary == true);
                NotifyOfPropertyChange(() => BasicInformationCheck);
                NotifyOfPropertyChange(() => ActionsExpanded);
                NotifyOfPropertyChange(() => Entity);
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => SunshineId);
                NotifyOfPropertyChange(() => FinancialSupport);
                NotifyOfPropertyChange(() => Phone);
                NotifyOfPropertyChange(() => Addresses);
                NotifyOfPropertyChange(() => SelectedAddress);
                NotifyOfPropertyChange(() => Actions);
                NotifyOfPropertyChange(() => ActionCompletedBy);
            }
        }

        public bool FinancialSupport
        {
            get { return _individual.financialsupport; }
            set
            {
                _individual.financialsupport = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => FinancialSupport);
            }
        }

        public string FirstName
        {
            get { return _individual.firstname; }
            set
            {
                _individual.firstname = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get { return _individual.lastname; }
            set
            {
                _individual.lastname = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string Notes
        {
            get { return _individual.DecodedNotes; }
            set
            {
                _individual.DecodedNotes = value;
                NotifyOfPropertyChange(() => Notes);
                _events.PublishOnUIThread(new RepositoryHasChanges());
            }
        }

        public string Phone
        {
            get { return _individual.phone; }
            set
            {
                _individual.phone = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => Phone);
            }
        }

        public BindableCollection<phonenumbers_individual> PhoneNumbers
        {
            get { return new BindableCollection<phonenumbers_individual>(_individual.phonenumbers_individual); }
        }

        public phonenumbers_individual PhoneSelectedItem
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
                if (PhoneSelectedItem != null)
                {
                    PhoneSelectedItem.phonenumber = value;
                }
                NotifyOfPropertyChange(() => PhoneSelectedItemPN);
            }
        }

        public actions_individual SelectedAction
        {
            get { return _selectedAction; }
            set { _selectedAction = value; }
        }

        public addresses_individual SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
                SelectedState = _selectedAddress != null ? _selectedAddress.state != null ? _selectedAddress.state : "Missouri" : "Missouri";
                SelectedAddressStreet = _selectedAddress?.streetAddress;
                SelectedAddressCity = _selectedAddress?.city;
                SelectedAddressZip = _selectedAddress?.zip;
                SelectedAddressPrimary = _selectedAddress?.primary;
                NotifyOfPropertyChange(() => SelectedAddress);
                NotifyOfPropertyChange(() => SelectedState);
                NotifyOfPropertyChange(() => SelectedAddressStreet);
                NotifyOfPropertyChange(() => SelectedAddressCity);
                NotifyOfPropertyChange(() => SelectedAddressZip);
                NotifyOfPropertyChange(() => SelectedAddressPrimary);
            }
        }

        public string SelectedAddressCity
        {
            get { return _selectedAddressCity; }
            set
            {
                _selectedAddressCity = value;
                if (SelectedAddress != null)
                {
                    SelectedAddress.city = value;
                }
                NotifyOfPropertyChange(() => SelectedAddressCity);
            }
        }
        public string SelectedAddressZip
        {
            get { return _selectedAddressZip; }
            set
            {
                _selectedAddressZip = value;
                if (SelectedAddress != null)
                {
                    SelectedAddress.zip = value;
                }
                NotifyOfPropertyChange(() => SelectedAddressZip);
            }
        }
        public string SelectedAddressStreet
        {
            get { return _selectedAddressStreet; }
            set
            {
                _selectedAddressStreet = value;
                if (SelectedAddress != null)
                {
                    SelectedAddress.streetAddress = value;
                }
                NotifyOfPropertyChange(() => SelectedAddressStreet);
            }
        }

        public bool? SelectedAddressPrimary
        {
            get { return _selectedAddressPrimary; }
            set
            {
                _selectedAddressPrimary = value;
                if (SelectedAddress != null)
                {
                    SelectedAddress.primary = value;
                }
                NotifyOfPropertyChange(() => SelectedAddressPrimary);
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
            get { return _individual.sunshineid; }
            set
            {
                _individual.sunshineid = value;
                _events.PublishOnUIThread(new RepositoryHasChanges());
                NotifyOfPropertyChange(() => SunshineId);
            }
        }

        public void ActionCompletedByChanged(SelectionChangedEventArgs item)
        {
            SelectedAction.completedBy = item.AddedItems[0].ToString();
            _events.PublishOnUIThread(new RepositoryHasChanges());
        }

        public void ActionTypeChanged(SelectionChangedEventArgs item)
        {
            SelectedAction.actionType = item.AddedItems[0].ToString();
            _events.PublishOnUIThread(new RepositoryHasChanges());
        }
        public void AddAddress()
        {
            //TODO THIS ISN'T RIGHT
            var add = SelectedAddress;
            if (add == null)
            {
                add = new addresses_individual();
                add.streetAddress = SelectedAddressStreet;
                add.city = SelectedAddressCity;
                add.zip = SelectedAddressZip;
                add.state = SelectedState;


            }

            if (_individual.addresses_individual.Any(a => a.streetAddress == add.streetAddress) &&
                _individual.addresses_individual.Any(a => a.city == add.city) &&
                _individual.addresses_individual.Any(a => a.zip == add.zip))
            {
                return;
            }
            else
            {
                add.contactid = _individual.id;
                _individual.addresses_individual.Add(add);
                NotifyOfPropertyChange(() => Addresses);
                ClearAddress();
                _events.PublishOnUIThread(new RepositoryHasChanges());
            }
        }

        public void AddPhoneNumber()
        {
            if (string.IsNullOrWhiteSpace(_phoneSelectedItemPN))
            {
                return;
            }

            var pn = new phonenumbers_individual()
            {
                ownerID = _individual.id,
                phonenumber = PhoneSelectedItemPN
            };

            if (_individual.phonenumbers_individual.Any(a => a.phonenumber == pn.phonenumber))
            {
                return;
            }
            else
            {
                _individual.phonenumbers_individual.Add(pn);
                NotifyOfPropertyChange(() => PhoneNumbers);
                ClearPhoneNumber();
                _events.PublishOnUIThread(new RepositoryHasChanges());
            }
        }


        public void ClearAddress()
        {
            SelectedAddress = null;
            NotifyOfPropertyChange(() => SelectedAddress);

        }

        public void ClearPhoneNumber()
        {
            PhoneSelectedItem = null;
        }

        public void OnAddAction(object sender, EventArgs args)
        {
            _events.PublishOnUIThread(new RepositoryHasChanges());
            actions_individual action = (actions_individual)(args as InitializingNewItemEventArgs).NewItem;
            action.completedBy = _user.FullName;
            action.date = DateTime.Now;
            _individual.actions_individual.Add(action);
        }

        public void RemoveAddress()
        {
            if (null != SelectedAddress)
            {
                _individual.addresses_individual.Remove(SelectedAddress);
                SelectedAddress = new addresses_individual();
                NotifyOfPropertyChange(() => Addresses);
                ClearAddress();
                _events.PublishOnUIThread(new RepositoryHasChanges());
            }
        }

        public void RemovePhoneNumber()
        {
            if (null != PhoneSelectedItem)
            {
                _individual.phonenumbers_individual.Remove(PhoneSelectedItem);
                PhoneSelectedItem = null;
                NotifyOfPropertyChange(() => PhoneNumbers);
                _events.PublishOnUIThread(new RepositoryHasChanges());
            }
        }

        public void OnTextChanged(string text)
        {
            if (_selectedAddress != null)
            {
                return;
            }
            _selectedAddress = new addresses_individual();
            NotifyOfPropertyChange(() => SelectedAddress);
        }
    }
}