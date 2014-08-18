using System;

namespace OTS
{
    public class PurposeOfReport: Section
    {
    

        protected override string SectionName
        {
            get { return "Purposes"; }
        }

        

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A1", "A10"), Counter.I }; }
        }
    }
}