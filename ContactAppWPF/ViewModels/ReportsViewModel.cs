using Caliburn.Micro;
using ContactAppWPF.Models;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.ViewModels
{
    public class ReportsViewModel : Conductor<object>
    {
        private DateTime _beginDate = DateTime.Now;
        private SimpleContainer _container;
        private bool _criteriaEnabled = false;
        private DateTime _endDate = DateTime.Now;
        private string _reportTypesSelectedItem;
        private ReportModel _rm;
        private SearchAggregator _sa;

        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { _searchCriteria = value;
                _sa.SearchTerms = value;
                NotifyOfPropertyChange(() => SearchCriteria);
            }
        }


        public ReportsViewModel(ReportModel reportModel, SimpleContainer simpleContainer, SearchAggregator searchAggregator)
        {
            _sa = searchAggregator;
            _rm = reportModel;
            _container = simpleContainer;
            BeginDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
        }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set
            {
                _beginDate = value;
                _sa.BeginDate = value;
                NotifyOfPropertyChange(() => BeginDate);
            }
        }
        public bool CriteriaEnabled
        {
            get { return _criteriaEnabled; }
            set
            {
                _criteriaEnabled = value;
                NotifyOfPropertyChange(() => CriteriaEnabled);
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                _sa.EndDate = value;
                NotifyOfPropertyChange(() => EndDate);
            }
        }
        public List<string> ReportTypes
        {
            get
            {
                return new List<string>()
            {
                "Most recent action for each record.",
                "Record type (schools, churches, etc)",
                "Lapsed - no action in 13 months"
            };
            }
        }
        public string ReportTypesSelectedItem
        {
            get { return _reportTypesSelectedItem; }
            set
            {
                _reportTypesSelectedItem = value;
                if (value == "Record type (schools, churches, etc)")
                {
                    CriteriaEnabled = true;
                }
                else
                {
                    CriteriaEnabled = false;
                }
            }
        }




        public void GenerateReport()
        {
            if (ReportTypesSelectedItem == null)
            {
                return;
            }
            switch (ReportTypesSelectedItem)
            {
                case "Most recent action for each record.":
                    ActivateItem(_container.GetInstance<RecentActionReportViewModel>());
                    break;
                case "Lapsed - no action in 13 months":
                    ActivateItem(_container.GetInstance<LapsedActionReportViewModel>());
                    break;
                case "Record type (schools, churches, etc)":
                    ActivateItem(_container.GetInstance<RecordByTypeReportViewModel>());
                    break;
                default:
                    break;
            }
        }

    }
}
