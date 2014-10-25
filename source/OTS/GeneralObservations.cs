using System;

namespace OTS
{
    public class GeneralObservations : Section
    {

        
        protected override string SectionName
        {
            get { return "General observations"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { L = e.GetSelected("GeneralComplaints"), Counter.I }; }
        }
    }
}