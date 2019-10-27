using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_App.Interfaces
{
    interface IFilter
    {
        string SQLSnippet { get; }
    }
}
