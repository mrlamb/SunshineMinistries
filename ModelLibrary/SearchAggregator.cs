using ModelLibrary.DataAccess;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class SearchAggregator
    {
        private IndividualDataAccess ida = new IndividualDataAccess();
        private OrganizationDataAccess oda = new OrganizationDataAccess();
        public string SearchTerms { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<ReturnedEntity> GetAllBySearchTerm()
        {
            List<ReturnedEntity> output = new List<ReturnedEntity>();

            foreach (var item in ida.GetIndividuals(SearchTerms))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                re.SunshineId = item.sunshineid;
                re.Id = item.id;
                re.FullName = $"{item.firstname} {item.lastname}";
                re.Type = typeof(individual);
                re.TypeString = "Individual";
                try
                {
                    var primAddress = item.addresses_individual.First(a => a.primary == true);
                    re.FullAddress = $"{primAddress.streetAddress} {primAddress.city}, {primAddress.state} {primAddress.zip}";
                }
                catch (Exception)
                {
                    re.FullAddress = "No primary address on record";
                }
                try
                {
                    var lastAction = item.actions_individual.Max(a => a.date);
                    var action = item.actions_individual.First(a => a.date == lastAction);
                    re.LastAction = $"{lastAction.Value.ToShortDateString()} - {action.actionType}";
                }
                catch (Exception)
                {
                    re.LastAction = "No actions on record.";
                }
                
                output.Add(re);

            }

            foreach (var item in oda.GetOrganizations(SearchTerms))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                re.SunshineId = item.orgsunshineid;
                re.Id = item.orgid;
                re.FullName = $"{item.name}";
                re.Type = typeof(organization);
                re.TypeString = item.org_type != null ? item.org_types.type : "Organization";
                try
                {
                    var primAddress = item.addresses_organization.First(a => a.primary == true);
                    re.FullAddress = $"{primAddress.streetAddress} {primAddress.city}, {primAddress.state} {primAddress.zip}";
                }
                catch (Exception)
                {
                    re.FullAddress = "No primary address on record";
                }
                try
                {
                    var lastAction = item.actions_organization.Max(a => a.date);
                    var action = item.actions_organization.First(a => a.date == lastAction);
                    re.LastAction = $"{lastAction.Value.ToShortDateString()} - {action.actionType}";
                }
                catch (Exception)
                {
                    re.LastAction = "No actions on record.";
                }

                output.Add(re);
            }

            return output;
        }

        public IEnumerable<ReturnedEntity> GetAllByHasLapsedAction()
        {
            var output = new List<ReturnedEntity>();
            var individuals = ida.GetIndividuals("").Where(a => a.actions_individual.Count > 0);
            foreach (var item in individuals.Where(a=> a.actions_individual.All(b=> b.date.Value < DateTime.Now.AddMonths(-13) )))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                var LastDate = item.actions_individual.Max(a => a.date);
                re.Action = item.actions_individual.FirstOrDefault(a => a.date == LastDate);
                re.FullName = $"{item.firstname} {item.lastname}";
                re.TypeString = "Individual";
                output.Add(re);

            }

            var organizations = oda.GetOrganizations("").Where(a => a.actions_organization.Count > 0);
            foreach (var item in organizations.Where(a => a.actions_organization.All(b=> b.date.Value < DateTime.Now.AddMonths(-13))))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                var LastDate = item.actions_organization.Max(a => a.date);
                re.Action = item.actions_organization.FirstOrDefault(a => a.date == LastDate);
                re.FullName = item.name;
                re.TypeString = item.org_type != null ? item.org_types.type : "Organization";
                output.Add(re);

            }
            return output;
        }

        public List<ReturnedEntity> GetAllByNoActions()
        {
            var output = new List<ReturnedEntity>();

            foreach (var item in ida.GetIndividuals(""))
            {
                if (item.actions_individual.Count > 0)
                {
                    continue;
                }
                var re = new ReturnedEntity();

                re.Entity = item;
                re.SunshineId = item.sunshineid;
                re.Id = item.id;
                re.FullName = $"{item.firstname} {item.lastname}";
                re.Type = typeof(individual);
                re.TypeString = "Individual";
                try
                {
                    var primAddress = item.addresses_individual.First(a => a.primary == true);
                    re.FullAddress = $"{primAddress.streetAddress} {primAddress.city}, {primAddress.state} {primAddress.zip}";
                }
                catch (Exception)
                {
                    re.FullAddress = "No primary address on record";
                }

                output.Add(re);
            }

            foreach (var item in oda.GetOrganizations(""))
            {
                if (item.actions_organization.Count > 0)
                {
                    continue;
                }
                var re = new ReturnedEntity();

                re.Entity = item;
                re.SunshineId = item.orgsunshineid;
                re.Id = item.orgid;
                re.FullName = $"{item.name}";
                re.Type = typeof(organization);
                re.TypeString = item.org_type != null ? item.org_types.type : "Organization";
                try
                {
                    var primAddress = item.addresses_organization.First(a => a.primary == true);
                    re.FullAddress = $"{primAddress.streetAddress} {primAddress.city}, {primAddress.state} {primAddress.zip}";
                }
                catch (Exception)
                {
                    re.FullAddress = "No primary address on record";
                }

                output.Add(re);
            }


            return output;
        }

        public List<ReturnedEntity> GetAllByHasActionWithinDateRange()
        {
            var output = GetAllByHasAction().Where(a => a.Action.date > BeginDate && a.Action.date < EndDate);
            return output.ToList();

        }

        public List<ReturnedEntity> GetAllByHasAction()
        {
            var output = new List<ReturnedEntity>();
            foreach (var item in ida.GetIndividuals("").Where(a => a.actions_individual.Count > 0))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                var LastDate = item.actions_individual.Max(a => a.date);
                re.Action = item.actions_individual.FirstOrDefault(a => a.date == LastDate);
                re.FullName = $"{item.firstname} {item.lastname}";
                re.TypeString = "Individual";
                output.Add(re);

            }

            foreach (var item in oda.GetOrganizations("").Where(a => a.actions_organization.Count > 0))
            {
                var re = new ReturnedEntity();
                re.Entity = item;
                var LastDate = item.actions_organization.Max(a => a.date);
                re.Action = item.actions_organization.FirstOrDefault(a => a.date == LastDate);
                re.FullName = item.name;
                re.TypeString = item.org_type != null ? item.org_types.type : "Organization";
                output.Add(re);

            }
            return output;
        }
    }
}
