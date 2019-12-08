using Caliburn.Micro;
using ContactAppWPF.Models;
using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ContactAppWPF.ViewModels
{
    public class LapsedActionReportViewModel : Conductor<object>
    {
        private IDetailView _detailView;
        private SimpleContainer _container;
        private ReportModel _rm;
        private ReturnedEntity _selectedItem;
        private BindableCollection<ReturnedEntity> _entities;
        private SearchAggregator _sa;

        public LapsedActionReportViewModel(ReportModel reportModel, SearchAggregator searchAggregator, SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
            _sa = searchAggregator;
            GetRecords();


            _rm = reportModel;
        }

        private void GetRecords()
        {
            _entities = new BindableCollection<ReturnedEntity>(_sa.GetAllByHasLapsedAction());
            NotifyOfPropertyChange(() => ReportEntities);
        }

        public BindableCollection<ReturnedEntity> ReportEntities
        {
            get { return _entities; }
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
        private void RefreshResults(ReturnedEntity selectedItem)
        {
            Repository.Reload();
            GetRecords();
            try
            {
                SelectedItem = _entities?.First(a => a.Type == selectedItem.Type &&
                a.Id == selectedItem.Id);
            }
            catch
            {
                Console.WriteLine();
            }
        }

        public void OnExportClicked()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type,Name,Action Summary,Notes");
            foreach (ReturnedEntity item in ReportEntities)
            {
                sb.AppendLine(
                    $"{item.Type},{item.FullName},{item.Action.actionType} completed by {item.Action.completedBy} on {item.Action.date.Value.ToShortDateString()},\"{item.Action.DecodedNotes}\"");
            }
            ReportExporter exporter = new CSVExporter()
            {
                Data = sb.ToString()
            };
            exporter.Export();

        }
    }
}

