using Caliburn.Micro;
using ContactAppWPF.Models;
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
        private DateTime _endDate = DateTime.Now;
        private ReportModel _rm;
        private SimpleContainer _container;
       
        public ReportsViewModel(ReportModel reportModel, SimpleContainer simpleContainer)
        {
            _rm = reportModel;
            _container = simpleContainer;
        }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _rm.BeginDate = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _rm.EndDate = value; }
        }

        public List<string> ReportTypes
        {
            get {
                return new List<string>()
            {
                "Most recent action for each record.",
                "Record type (schools, churchs, etc)",
                "Lapsed - no action in 13 months"
            };
            }
        }

        public string ReportTypesSelectedItem { get; set; }



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
                default:
                    break;
            }
        }

    }
}
