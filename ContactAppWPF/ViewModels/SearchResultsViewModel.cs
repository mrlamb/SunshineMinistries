using Caliburn.Micro;
using ContactAppWPF.EventModels;
using ContactAppWPF.Views;
using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ContactAppWPF.ViewModels
{
    public class SearchResultsViewModel : Conductor<IDetailView>, IHandle<SearchResultsInvalidated>
    {
        private SimpleContainer _container;
        private Visibility _dataGridVisibility;
        private IDetailView _detailView;
        private BindableCollection<ReturnedEntity> _entities;
        private IEventAggregator _eventAggregator;
        private SearchAggregator _sa;
        private int _selectedIndex = -1;
        private ReturnedEntity _selectedItem;
        public SearchResultsViewModel(SearchAggregator searchAggregator, IEventAggregator eventAggregator, SimpleContainer container)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _sa = searchAggregator;
            _entities = new BindableCollection<ReturnedEntity>(_sa.GetAllBySearchTerm());
            _eventAggregator.Subscribe(this);
        }

        public Visibility DataGridVisibility
        {
            get { return _dataGridVisibility; }
            set
            {
                _dataGridVisibility = value;
                NotifyOfPropertyChange(() => DataGridVisibility);
            }
        }

        public BindableCollection<ReturnedEntity> Entities
        {
            get { return _entities; }
            set
            {
                _entities = value;
                NotifyOfPropertyChange(() => Entities);
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyOfPropertyChange(() => SelectedIndex);
            }
        }

        public ReturnedEntity SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                var origValue = _selectedItem;

                if (value == _selectedItem)
                {
                    return;
                }

                _selectedItem = value;

                if (Repository.HasChanges())
                {
                    var result = MessageBox.Show($"You have unsaved changes, save first?", $"Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                    switch (result)
                    {
                        case MessageBoxResult.None:
                        case MessageBoxResult.No:
                            Repository.CancelChanges();
                            RefreshResults(_selectedItem);
                            break;

                        case MessageBoxResult.Yes:
                            try
                            {
                                Repository.SaveChanges();
                                RefreshResults(_selectedItem);
                                return;
                            }
                            catch
                            {
                                MessageBox.Show("Unable to save.");
                                Application.Current.Dispatcher.BeginInvoke(
                                    new System.Action(() =>
                                    {
                                        _selectedItem = origValue;
                                        NotifyOfPropertyChange(() => SelectedItem);
                                    }),
                                DispatcherPriority.ContextIdle,
                                null
                                );
                                return;
                            }
                        case MessageBoxResult.Cancel:
                            Application.Current.Dispatcher.BeginInvoke(
                                    new System.Action(() =>
                                    {
                                        _selectedItem = origValue;
                                        NotifyOfPropertyChange(() => SelectedItem);
                                    }),
                                DispatcherPriority.ContextIdle,
                                null
                                );
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    NotifyOfPropertyChange(() => SelectedItem);
                }
                if (_selectedItem == null)
                {
                    _selectedItem = origValue;
                }
                if (_selectedItem.TypeString == "Individual")
                {
                    _detailView = _container.GetInstance<IndividualDetailViewModel>();
                    _detailView.Entity = _selectedItem;
                }
                else
                {
                    _detailView = _container.GetInstance<OrganizationDetailViewModel>();
                    _detailView.Entity = _selectedItem;
                }
                ActivateItem(_detailView);
            }

        }
        public void Handle(SearchResultsInvalidated message)
        {
            if (_selectedItem != null)
            {
                RefreshResults(_selectedItem);
            }
        }

        public void RefreshResults(ReturnedEntity entity)
        {
            Repository.Reload();
            Entities = new BindableCollection<ReturnedEntity>(_sa.GetAllBySearchTerm());
            try
            {
                SelectedItem = Entities?.First(a => a.Type == entity.Type &&
                a.Id == entity.Id);
            }
            catch
            {
                Console.WriteLine();
            }
        }
    }
}