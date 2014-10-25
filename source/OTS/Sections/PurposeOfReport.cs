using System;

namespace OTS
{
    public class PurposeOfReport: Section
    {
        protected override string SectionName
        {
            get { return "Purpose of report"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Purposes = e.GetSelected("purposes"),Counter.I}; }
        }
    }
 
}