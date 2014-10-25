using System;

namespace OTS
{
    public class PhychoSocialResult: Section
    {
        private class List : Selectable
        {
            public string Aspect { get; set; }
            public string Text { get; set; }
        }
        protected override string SectionName
        {
            get { return "PhychoSocial results"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { L = e.GetSelected<List>("PhychoSocialResultList"), Counter.I }; }

        }
    }

    public class CognitiveResult:Section
    {
        private class List :Selectable
        {
            public string Aspect { get; set; }
            public string Text { get; set; }
        }
        protected override string SectionName
        {
            get { return "Cognitive results"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { L = e.GetSelected<List>("CognitiveResult"),  Counter.I }; }
        }
    }
}