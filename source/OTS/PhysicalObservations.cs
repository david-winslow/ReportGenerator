using System;

namespace OTS
{
    public class PhysicalObservations:Section
    {
        protected override string SectionName
        {
            get { return "Physical Observations"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Counter.I, L = e.GetSelected("PhysicalObservationsList")}; }
        }
    }
}