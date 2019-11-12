using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppWPF.Models
{
    public abstract class ReportExporter
    {
        public abstract void Export();
        public string Data { get; set; }


    }
}
