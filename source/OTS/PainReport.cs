using System;

namespace OTS
{
    public class PainReport : Section
    {
        protected override string SectionName
        {
            get { return "Pain report"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Counter.I, L = e.GetSelected("PainList")}; }
        }
    }
}