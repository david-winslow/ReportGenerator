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

        public override int OrderIndex
        {
            get { return 6; }
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


    public class MedicalInformation : Section
    {
        private class MedicalData
        {
            public DateTime? Date { get; set; }
            public string History { get; set; }
        }

        private class BodyCheck
        {
            public string System { get; set; }
            public string Result { get; set; }
        }

        protected override string SectionName
        {
            get { return "Medical Information"; }
        }

        public override int OrderIndex
        {
            get { return 5; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { MedicalData = e.Get<MedicalData>("A1", "B20"), Counter.I, BodyCheck = e.Get<BodyCheck>("D1", "E8") }; }
        }
    }

    public class DocsReceived : Section
    {
        protected override string SectionName
        {
            get { return "Documentation Received"; }
        }

        public override int OrderIndex
        {
            get { return 4; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { Doc = e.Get<Doc>("A1", "C8"), Counter.I }; }
        }
    }
}