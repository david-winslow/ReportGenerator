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
            get { return e => new {Purposes = e.SelectedValuesList("A2", "B20"),Counter.I}; }
        }
    }
}