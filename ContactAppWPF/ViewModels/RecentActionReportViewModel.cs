using Caliburn.Micro;
using ContactAppWPF.Models;
using ModelLibrary;
using ModelLibrary.DataAccess;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactAppWPF.ViewModels
{
    public class RecentActionReportViewModel : Screen
    {
        private ReportModel _rm;
        private BindableCollection<LastActionReportReturnedEntity> _entities;

        public RecentActionReportViewModel(ReportModel reportModel, IndividualDataAccess individualDataAccess, OrganizationDataAccess organizationDataAccess)
        {
            _entities = new BindableCollection<LastActionReportReturnedEntity>();

            
            foreach (var item in individualDataAccess.GetIndividuals("").Where(a => a.actions_individual.Count > 0))
            {
                var LARRE = new LastActionReportReturnedEntity();
                var LastDate = item.actions_individual.Max(a => a.date);
                LARRE.Action = item.actions_individual.FirstOrDefault(a => a.date == LastDate);
                LARRE.FullName = $"{item.firstname} {item.lastname}";
                LARRE.Type = "Individual";
                _entities.Add(LARRE);
                
            }

            foreach (var item in organizationDataAccess.GetOrganizations("").Where(a => a.actions_organization.Count >0))
            {
                var LARRE = new LastActionReportReturnedEntity();
                var LastDate = item.actions_organization.Max(a => a.date);
                LARRE.Action = item.actions_organization.FirstOrDefault(a => a.date == LastDate);
                LARRE.FullName = item.name;
                LARRE.Type = item.org_type != null ? item.org_types.type : "Organization";
                _entities.Add(LARRE);
            }

            var test = new System.Windows.Controls.DataGrid();
            


            _rm = reportModel;
        }

        public BindableCollection<LastActionReportReturnedEntity> ReportEntities
        {
            get { return _entities; }
        }

        public void OnExportClicked(ItemCollection sender)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type,Name,Action Summary,Notes");
            foreach (LastActionReportReturnedEntity item in sender.SourceCollection)
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
