using System;
using System.Linq;
using Castle.Core.Internal;

namespace OTS
{
    public class Background:Section
    {
        protected override string SectionName
        {
            get { return "Background"; }
        }

       

        public override Func<Excel, object> ReportData
        {
            get { return e => new
            {
                Dependents = e["Dependents"],
                MaritalStatus = e["MaritalStatus"],
                SupportStructure = e["SupportStructure"], 
                Dwelling =e["dwelling"],
                Occupants = e["Occupants"],
                Facilities = e["Facilities"],
                Accessibility = e["Accessibility"],
                Access = e["Access"],
                Assistance = e["Assistance"], 
                L = e.Get<Education>("Education").Where(ee => !ee.Accomplishment.IsNullOrEmpty()),
                Counter.I
            }; }
        }

        private class Education
        {
            public string EducationLevel { get; set; }
            public string Accomplishment { get; set; }
        }
    }
}