using System;
using System.Linq;
using Castle.Core.Internal;

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
            get { return e => new {MedicalData = e.Get<MedicalData>("medicalHistory").Where(x => !x.History.IsNullOrEmpty()), Counter.I, BodyCheck = e.Get<BodyCheck>("bodyCheck") }; }
        }
    }
}