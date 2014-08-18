using System;

namespace OTS
{
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

       

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Conclusion="on this date blblalf", MedicalData = e.Get<MedicalData>("A1", "B20"), Counter.I, BodyCheck = e.Get<BodyCheck>("D1", "E8") }; }
        }
    }
}