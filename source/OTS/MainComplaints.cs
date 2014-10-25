using System;
using System.Diagnostics;
using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public class MainComplaints :Section
    {

        private class List
        {
            public string Text { get; set; }
        }
        protected override string SectionName
        {
            get { return "Main complaints"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("MC").Where(b => !b.Text.IsNullOrEmpty()), Counter.I }; }
        }
    }
}