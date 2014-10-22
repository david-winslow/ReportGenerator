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
                Dependents = e["B2"],
                MaritalStatus = e["B3"],
                SupportStructure = e["B4"], 
                Dwelling =e["B6"], 
                Occupants =e["B7"], 
                Facilities =e["B8"], 
                Accessibility=e["B9"], 
                Access =e["B10"], 
                Assistance =e["B11"], 
                Edu = e.Get<Education>("A28","C39").Where(ee => !CollectionExtensions.IsNullOrEmpty(ee.Accomplishment)),
                Counter.I
            }; }
        }

        public class Education
        {
            public string Period { get; set; }
            public string Institution { get; set; }
            public string Accomplishment { get; set; }
        }
    }
}