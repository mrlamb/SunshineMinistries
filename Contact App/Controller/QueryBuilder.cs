using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.Collections;

namespace Contact_App.Controller
{
    public static class QueryBuilder
    {
        //Generic search returns all matches, but only matches.
        public static void SearchWithKeywords(ListBox lb , string keywords)
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

        public static QueryableItem[] BuildQueryItem(string[] columns , string[] filters)
        {
            QueryableItem[] returnVals;
            var isb = new StringBuilder();
            var osb = new StringBuilder();
            var indvColumns = new List<string>();
            var orgColumns = new List<string>();

            foreach (var column in columns)
            {
                if (column.Contains("individual"))
                {
                    indvColumns.Add(column.Substring(column.IndexOf('.') + 1));
                }
                else
                {
                    orgColumns.Add(column.Substring(column.IndexOf('.') + 1));
                }
            }

            if (indvColumns.Count > 0)
            {
                isb.Append("new(");
                foreach (var column in indvColumns)
                {
                    isb.Append($"{column}");
                    if (!(column == indvColumns.Last()))
                    {
                        isb.Append($", ");
                    }
                    else
                    {
                        isb.Append($")");
                    }
                }
            }
            if (orgColumns.Count > 0)
            {
                osb.Append("new(");
                foreach (var column in orgColumns)
                {
                    osb.Append($"{column}");
                    if (!(column == orgColumns.Last()))
                    {
                        osb.Append($", ");
                    }
                    else
                    {
                        osb.Append($")");
                    }
                }
            }

            if (isb.Length == 0 && osb.Length == 0)
            {
                returnVals = null;
            }
            else if (isb.Length > 0 && osb.Length > 0)
            {
                returnVals = new QueryableItem[2]
                {
                    new QueryableItem {
                        QType = QueryableItemTypes.INDIVIDUAL,
                        Query = isb.ToString() },
                    new QueryableItem
                    {
                        QType = QueryableItemTypes.ORGANIZATION,
                        Query = osb.ToString()
                    }

                };
            }
            else
            {
                returnVals = new QueryableItem[1];
                if (isb.Length > 0)
                {
                    returnVals[0] = new QueryableItem
                    {
                        QType = QueryableItemTypes.INDIVIDUAL ,
                        Query = isb.ToString()
                    };
                }
                else
                {
                    returnVals[0] = new QueryableItem
                    {
                        QType = QueryableItemTypes.ORGANIZATION ,
                        Query = osb.ToString()
                    };
                }

            }
            return returnVals;
        }

        internal static List<dynamic> ExecuteQueries(QueryableItem[] queries)
        {
            List<dynamic> finalList = new List<dynamic>();
            if (null == queries)
            {
                return null;
            }

            if (queries.Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in queries)
                {
                    if (item.QType == QueryableItemTypes.INDIVIDUAL)
                    {
                        IEnumerable query = Program.Entities.individuals.Select(item.Query);
                        finalList.AddRange(query.Cast<dynamic>().ToList());
                    }
                    else
                    {
                        IEnumerable query = Program.Entities.organizations.Select(item.Query);
                        finalList.AddRange(query.Cast<dynamic>().ToList());
                    }
                }
                return finalList;
            }



        }
    }
}

