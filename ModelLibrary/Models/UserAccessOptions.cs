using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    [Flags]
    public enum UserAccessOptions : byte
    {
        None = 0,
        Create = 1,
        Edit = 2,
        View = 4,
        UserControl = 8,

    }
}
