using System;

namespace OTS
{

    public static class Counter
    {
        private static int i;
        public static int I {
            get { return ++i; }
        }
    }
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
                Edu = e.Get<Education>("A28","C39"),
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


    public class DocumentationReceived : Section
    {
        protected override string SectionName
        {
            get { return "Documentation Received"; }
        }

    

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Doc = e.Get<Doc>("A1", "C8"), Counter.I }; }
        }
    }
}