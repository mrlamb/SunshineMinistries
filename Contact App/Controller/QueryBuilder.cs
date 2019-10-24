using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_App.Controller
{
    public static class QueryBuilder
    {
        public static void SearchWithKeywords(ListBox lb, string keywords)
        {
            List<object> objects = new List<object>();

            var searchTerms = keywords.ToLower().Split(null);
            if (searchTerms.Length > 0)
            {
                for (int i = 0; i < searchTerms.Length; i++)
                {
                    var tmp = searchTerms[i];
                    List<object> results = (from e in Program.Entities.individuals
                                            where (e.firstname.Contains(tmp)
                                  || e.lastname.Contains(tmp)
                                  || e.sunshineid.Contains(tmp))
                                            select e).ToList<object>();

                    foreach (var item in results)
                    {
                        objects.Add(item);
                    }
                    List<object> results2 = (from e in Program.Entities.organizations
                                             where (e.name.Contains(tmp)
                                  || e.orgsunshineid.Contains(tmp))
                                             select e).ToList<object>();

                    foreach (var item in results2)
                    {
                        objects.Add(item);
                    }

                }
            }
            if (objects.Count > 0)
            {
                lb.DataSource = objects;
            }
        }
    }
}
