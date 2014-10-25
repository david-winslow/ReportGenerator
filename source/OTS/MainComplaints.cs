using System;
using System.Diagnostics;
using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public class MainComplaints :Section
    {
        protected override string SectionName
        {
            get { return "Main complaints"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { L = e.GetSelected("MainComplaintsList"), Counter.I }; }
        }
    }
}