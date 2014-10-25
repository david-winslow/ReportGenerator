using System;

namespace OTS
{
    public abstract class BulletList : Section
    {
        private class List
        {
            public string Bullet { get; set; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new { List = e.Get<List>("A2", "A10"), Counter.I }; }
        }
    }


    public class CooperationEffort : BulletList
    {
        protected override string SectionName
        {
            get { return "Cooperation effort"; }
        }
    }

    public class ConsistencyOfPerformance : Section
    {
        protected override string SectionName
        {
            get { return "Consistency performance"; }
        }

        public override Func<Excel, object> ReportData
        {
            get { return e => new {Counter.I, Intro = e["CPIntro"], L = e.GetSelected("ConsistencyPerformance")}; }
        }
    }
}