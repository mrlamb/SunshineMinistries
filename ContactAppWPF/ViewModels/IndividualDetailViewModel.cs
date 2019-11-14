﻿using Caliburn.Micro;
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

            if (_individual.addresses_individual.Any(a => a.streetAddress == add.streetAddress) &&
                _individual.addresses_individual.Any(a => a.city == add.city) &&
                _individual.addresses_individual.Any(a => a.zip == add.zip))
            {
                return;
            }
            else
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                add.contactid = _individual.id;
                _individual.addresses_individual.Add(add);
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
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _individual.phonenumbers_individual.Add(pn);
                NotifyOfPropertyChange(() => PhoneNumbers);
                ClearPhoneNumber();
            }
        }

       
        public void ClearAddress()
        {
            SelectedAddress = null;
            NotifyOfPropertyChange(() => SelectedAddress);
            SelectedAddress = new addresses_individual();
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
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _individual.addresses_individual.Remove(SelectedAddress);
                SelectedAddress = new addresses_individual();
                NotifyOfPropertyChange(() => Addresses);
                ClearAddress();
            }
        }

        public void RemovePhoneNumber()
        {
            if (null != PhoneSelectedItem)
            {
                _events.PublishOnUIThread(new RepositoryHasChanges());
                _individual.phonenumbers_individual.Remove(PhoneSelectedItem);
                PhoneSelectedItem = null;
                NotifyOfPropertyChange(() => PhoneNumbers);
            }
        }
    }
}