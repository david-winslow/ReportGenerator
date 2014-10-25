using System;

namespace OTS
{
    public class Safety : Section
    {
        protected override string SectionName
        {
            get { return "Safety"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Counter.I, L = e.GetSelected("SafetyList") }; }
        }
    }
}